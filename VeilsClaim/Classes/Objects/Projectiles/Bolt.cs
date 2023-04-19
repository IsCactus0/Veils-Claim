using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using VeilsClaim.Classes.Managers;

namespace VeilsClaim.Classes.Objects.Projectiles
{
    public class Bolt : Projectile
    {
        public Bolt(Projectile copy)
            : base(copy)
        {
            Friction = 1f;
            Hitbox = new Rectangle(0, 0, 3, 3);
            Trail = new Trail(copy.Position, 5, 24f, 5f, 3f, true, Color.White, Color.RoyalBlue);
        }
        public Bolt()
            : base()
        {
            Friction = 1f;
            Hitbox = new Rectangle(0, 0, 3, 3);
            Trail = new Trail(Position, 5, 24f, 5f, 3f, true, Color.White, Color.RoyalBlue);
        }

        public Trail Trail;

        public override List<Vector2> CreateShape()
        {
            return new List<Vector2>();
        }
        public override void Update(float delta)
        {
            Trail.Follow(Position, delta);
            Trail.Limit(Position);

            // if (MathAdditions.Probability(delta, 0.5f))
            //     ParticleManager.particles.Add(new SparkParticle()
            //     {
            //         Position = Position,
            //         Velocity = Velocity,
            //         Size = 3f,
            //         StartSize = 3f,
            //         EndSize = 10f,
            //         SparkSize = 3f,
            //         SparkStartSize = 3f,
            //         SparkEndSize = 1f,
            //         Colour = Color.LightSkyBlue,
            //         StartColour = Color.LightSkyBlue,
            //         EndColour = Color.RoyalBlue,
            //         SparkColour = Color.MintCream,
            //         SparkStartColour = Color.MintCream,
            //         SparkEndColour = Color.DeepSkyBlue,
            //         Friction = 0.1f,
            //         Mass = 0.005f,
            //         WindStrength = 2f,
            //         MaxLifespan = 0.15f + Main.Random.NextSingle() / 5f,
            //     });

            base.Update(delta);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            Trail.Draw(spriteBatch);

            spriteBatch.Draw(
                AssetManager.LoadTexture("blur"),
                new Rectangle(
                    (int)Position.X - 8,
                    (int)Position.Y - 8,
                    16, 16),
                Color.Red);
        }
        public override Bolt Clone()
        {
            return new Bolt(this);
        }
    }
}