using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using VeilsClaim.Classes.Managers;
using VeilsClaim.Classes.Objects.Particles;
using VeilsClaim.Classes.Utilities;

namespace VeilsClaim.Classes.Objects.Projectiles
{
    public class Bolt : Projectile
    {
        public Bolt(Bolt copy)
            : base(copy)
        {
            Trail = new Trail(
                copy.Position,
                copy.Trail.Joints.Count,
                copy.Trail.SegmentLength,
                copy.Trail.StartThickness,
                copy.Trail.EndThickness,
                copy.Trail.AllowShrinking,
                copy.Trail.StartColour,
                copy.Trail.EndColour);
        }
        public Bolt()
            : base()
        {
            Friction = 1f;
            Penetration = 1;
            Trail = new Trail(
                Position,
                32, 2f,
                5f, 1f,
                true,
                Color.White,
                Color.DodgerBlue);
        }

        public Trail Trail;

        public override List<Vector2> CreateShape()
        {
            return new List<Vector2>();
        }
        public override void Destroy()
        {
            // for (int i = 0; i < (int)(Velocity.Length() / 100); i++)
            //     ParticleManager.particles.Add(new SparkParticle()
            //     {
            //         Position = Position,
            //         Velocity = Velocity,
            //         Size = 15f,
            //         StartSize = 15f,
            //         EndSize = 5f,
            //         Colour = Color.LightSkyBlue,
            //         StartColour = Color.LightSkyBlue,
            //         EndColour = Color.RoyalBlue,
            //         Friction = 0.1f,
            //         Mass = 0.005f,
            //         WindStrength = 20f,
            //         MaxLifespan = 0.5f + Main.Random.NextSingle() / 5f,
            //     });

            base.Destroy();
        }
        public override void Update(float delta)
        {
            Trail.Limit(Position);

            if (MathAdditions.Probability(delta, 0.5f))
                ParticleManager.particles.Add(new SparkParticle()
                {
                    Position = Position,
                    Velocity = Velocity,
                    Size = 15f,
                    StartSize = 15f,
                    EndSize = 5f,
                    Colour = Color.LightSkyBlue,
                    StartColour = Color.LightSkyBlue,
                    EndColour = Color.RoyalBlue,
                    Friction = 0.1f,
                    Mass = 0.005f,
                    WindStrength = 2f,
                    MaxLifespan = 0.15f + Main.Random.NextSingle() / 5f,
                });

            base.Update(delta);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            Trail.Draw(spriteBatch);
        }
        public override Bolt Clone()
        {
            return new Bolt(this);
        }
    }
}