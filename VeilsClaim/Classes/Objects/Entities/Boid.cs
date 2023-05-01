using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using VeilsClaim.Classes.Managers;
using VeilsClaim.Classes.Objects.Particles;
using VeilsClaim.Classes.Utilities;

namespace VeilsClaim.Classes.Objects.Entities
{
    public class Boid : Vehicle
    {
        public Boid()
        {
            Health = 1;
            Hitbox = new Rectangle(-6, -6, 12, 12);

            VisionRange = 1000;
            AvoidRange = 150;
            SeperationStrength = 4.0f;
            AlignmentStrength = 1.0f;
            CoherenceStrength = 0.8f;
            AvoidanceStrength = 0.0f;
        }

        public float VisionRange;
        public float AvoidRange;
        public float SeperationStrength;
        public float AlignmentStrength;
        public float CoherenceStrength;
        public float AvoidanceStrength;

        public virtual List<Boid> FindNeighbours(float range)
        {
            List<Boid> entities = EntityManager
                .FindAll(Position, range) // Find all entities within range.
                .FindAll(x => x is Boid && x != this) // Filter out only other boids.
                .Cast<Boid>().ToList(); // Cast entity list to Boid list.

            return entities;
        }
        public virtual Vector2 Seperate(List<Boid> neighbours)
        {
            if (neighbours.Count < 1)
                return Vector2.Zero;

            Vector2 force = Vector2.Zero;
            foreach (Boid other in neighbours)
                force += Position - other.Position;

            return force * SeperationStrength;
        }
        public virtual Vector2 Align(List<Boid> neighbours)
        {
            if (neighbours.Count < 1)
                return Vector2.Zero;

            Vector2 force = Vector2.Zero;
            foreach (Boid other in neighbours)
                force += other.Velocity;
            force /= neighbours.Count;
            force -= Velocity;

            return force * AlignmentStrength;
        }
        public virtual Vector2 Cohere(List<Boid> neighbours)
        {
            if (neighbours.Count < 1)
                return Vector2.Zero;

            Vector2 force = Vector2.Zero;
            foreach (Boid other in neighbours)
                force += other.Position;
            force /= neighbours.Count;
            force -= Position;

            return force * CoherenceStrength;
        }
        public virtual Vector2 Avoid(List<Vector2> positions)
        {
            if (positions.Count < 1)
                return Vector2.Zero;

            Vector2 force = Vector2.Zero;
            foreach (Vector2 position in positions)
                force += Position - position;

            return force * AvoidanceStrength;
        }
        public override List<Vector2> CreateShape()
        {
            return Drawing.Ellipse(12, 6, 3);
        }
        public override void Destroy()
        {
            for (int i = 0; i < Main.Random.Next(48, 64); i++)
                ParticleManager.particles.Add(new SparkParticle()
                {
                    Position = Position,
                    Velocity = MathAdditions.RandomVector(12, 64),
                    Size = 5f,
                    StartSize = 5f,
                    EndSize = 15f,
                    SparkSize = 5f,
                    SparkStartSize = 5f,
                    SparkEndSize = 2.5f,
                    Colour = Color.LightGoldenrodYellow,
                    StartColour = Color.LightGoldenrodYellow,
                    EndColour = Color.DarkOrange,
                    SparkColour = Color.DarkOrange,
                    SparkStartColour = Color.DarkOrange,
                    SparkEndColour = Color.Maroon,
                    Friction = 0.1f,
                    Mass = 0.01f,
                    WindStrength = 2f,
                    MaxLifespan = 0.5f + Main.Random.NextSingle() / 5f,
                });

            base.Destroy();
        }
        public override void Update(float delta)
        {
            List<Boid> neighbours = FindNeighbours(VisionRange);
            List<Entity> avoiding = EntityManager.FindAll(Position, AvoidRange)
                        .Concat(ProjectileManager.FindAll(Position, AvoidRange).Cast<Entity>()).ToList();
            List<Boid> seperating = avoiding.FindAll(x => x is Boid && x != this).Cast<Boid>().ToList();

            Force += Cohere(neighbours);
            Force += Align(neighbours);
            Force += Seperate(seperating);
            Force += Avoid(avoiding.Select(x => x.Position).ToList());

            Force += new Vector2(MathF.Cos(Rotation), MathF.Sin(Rotation)) * 50f;
            Rotation = MathF.Atan2(Velocity.Y, Velocity.X);

            base.Update(delta);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}