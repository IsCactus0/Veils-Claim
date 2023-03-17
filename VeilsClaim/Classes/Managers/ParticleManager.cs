using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
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
                    particles[i].Update(delta);

            for (int i = 0; i < Main.random.Next(1, 3); i++)
            particles.Add(new DustParticle()
            {
                StartSize = 10f,
                EndSize = Main.random.Next(200, 400),
                StartColour = Color.Gainsboro * 0.1f,
                EndColour = Color.Transparent,
                MaxLifespan = 3f,
                Position = new Vector2(
                    Main.camera.BoundingBox.Center.X + Main.random.Next(-100, 100),
                    Main.camera.BoundingBox.Center.Y + Main.random.Next(-100, 100))
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