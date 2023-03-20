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

            particles.Add(new SparkParticle()
            {
                StartSize = 5f,
                EndSize = 5f,
                StartColour = Color.Orange * 0.2f,
                EndColour = Color.Maroon * 0.2f,
                SparkStartSize = 3f,
                SparkEndSize = 1f,
                SparkStartColour = Color.White,
                SparkEndColour = Color.OrangeRed,
                MaxLifespan = (float)Main.random.NextDouble() / 2f + 1.5f,
                WindStrength = 400f,
                Position = Main.camera.Position + new Vector2(Main.random.Next(-3, 3), Main.random.Next(-3, 3))
            });

            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin(
                SpriteSortMode.Immediate,                
                BlendState.AlphaBlend,
                SamplerState.PointClamp,
                DepthStencilState.None,
                RasterizerState.CullNone,
                null,
                Main.camera.Transform);

            for (int i = particles.Count - 1; i >= 0; i--)
                particles[i].Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}