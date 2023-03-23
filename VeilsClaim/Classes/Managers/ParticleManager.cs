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
            
            if (false)
            {
                int strength = Main.random.Next(300, 1000);
                for (int i = 0; i < strength / 10; i++)
                {
                    //float dir = Main.random.NextSingle() * MathHelper.TwoPi;
                    particles.Add(new SparkParticle()
                    {
                        Size = 12f,
                        StartSize = 12f,
                        EndSize = 8f,

                        Colour = Color.LightSalmon * 0.1f,
                        StartColour = Color.LightSalmon * 0.1f,
                        EndColour = Color.OrangeRed,

                        SparkSize = 5f,
                        SparkStartSize = 5f,
                        SparkEndSize = 2f,

                        SparkColour = Color.LightGoldenrodYellow,
                        SparkStartColour = Color.LightGoldenrodYellow,
                        SparkEndColour = Color.OrangeRed,

                        MaxLifespan = 1f + (float)Main.random.NextDouble() / 5f,
                        WindStrength = 1000f,

                        Position =


                        Main.camera.Position + new Vector2(
                            Main.random.Next(-Main.camera.BoundingBox.Width, Main.camera.BoundingBox.Width),
                            Main.random.Next(-Main.camera.BoundingBox.Height, Main.camera.BoundingBox.Height)),

                        // Force = new Vector2(
                        //     (float)Math.Cos(dir),
                        //     (float)Math.Sin(dir)) * Main.random.Next(20 * strength)
                    });
                }
            }

            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.SetRenderTarget(Main.renderTarget);
            spriteBatch.Begin(
                SpriteSortMode.Immediate,                
                BlendState.Additive,
                SamplerState.PointClamp,
                DepthStencilState.None,
                RasterizerState.CullNone,
                null,
                Main.camera.Transform);

            for (int i = particles.Count - 1; i >= 0; i--)
                particles[i].Draw(spriteBatch);

            spriteBatch.End();

            GraphicsDevice.SetRenderTarget(null);
            base.Draw(gameTime);
        }
    }
}