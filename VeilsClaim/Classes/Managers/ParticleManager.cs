using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using VeilsClaim.Classes.Objects;
using VeilsClaim.Classes.Objects.Particles;

namespace VeilsClaim.Classes.Managers
{
    public class ParticleManager : DrawableGameComponent
    {
        public ParticleManager(Game game)
            : base(game)
        {
            spriteBatch = new SpriteBatch(game.GraphicsDevice);
            particles = new List<Particle>();
        }

        public static SpriteBatch spriteBatch;
        public static List<Particle> particles;

        public override void Update(GameTime gameTime)
        {
            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds * Main.gameSpeed;
            if (delta > 0)
                for (int i = particles.Count - 1; i >= 0; i--)
                {
                    particles[i].Update(delta);
                }

            particles.Add(new SmokeParticle()
            {
                StartSize = 10f,
                EndSize = 100f,
                SizeScaleMult = 1f,
                StartColour = Color.Gray,
                EndColour = Color.Transparent,
                ColourScaleMult = 1f,
                Rotation = Main.random.Next(-10, 10),
                RotationalVelocity = Main.random.Next(-10, 10),
                Position = new Vector2(
                    Main.random.Next(Main.camera.BoundingBox.Left, Main.camera.BoundingBox.Right),
                    Main.random.Next(Main.camera.BoundingBox.Top, Main.camera.BoundingBox.Bottom)),
            });

            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin(
                SpriteSortMode.Immediate,                
                BlendState.AlphaBlend,
                null, null, null, null,
                Main.camera.Transform);

            for (int i = particles.Count - 1; i >= 0; i--)
                particles[i].Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}