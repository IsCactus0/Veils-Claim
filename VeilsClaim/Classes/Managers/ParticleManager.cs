using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using VeilsClaim.Classes.Objects;
using VeilsClaim.Classes.Objects.Particles;
using VeilsClaim.Classes.Utilities;

namespace VeilsClaim.Classes.Managers
{
    public class ParticleManager : DrawableGameComponent
    {
        public ParticleManager(Game game)
            : base(game)
        {
            spriteBatch = new SpriteBatch(game.GraphicsDevice);
            quadTree = new QuadTree(Main.camera.BoundingBox, 32);
            particles = new List<Particle>();
        }

        public static SpriteBatch spriteBatch;
        public static QuadTree quadTree;
        public static List<Particle> particles;

        public override void Update(GameTime gameTime)
        {
            if (particles.Count > 0)
                quadTree = new QuadTree(Main.camera.RenderBoundingBox, 32);

            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds * Main.gameSpeed;
            if (delta > 0)
                for (int i = particles.Count - 1; i >= 0; i--)
                    particles[i].Update(delta);

            for (int i = particles.Count - 1; i >= 0; i--)
            {
                if (Main.camera.WithinBounds(particles[i], Main.physicsDistance))
                {
                    quadTree.Add(particles[i]);
                    particles[i].Update(delta);
                }
                else particles.RemoveAt(i);
            }

            for (int i = 0; i < Main.camera.BoundingBox.Width; i++)
            {
                particles.Add(new SparkParticle()
                {
                    SparkSize = 12f,
                    StartSize = 12f,
                    EndSize = 8f,

                    Colour = Color.LightSalmon * 0.1f,
                    StartColour = Color.LightSalmon * 0.1f,
                    EndColour = Color.OrangeRed,

                    SparkColour = Color.LightGoldenrodYellow,
                    SparkStartColour = Color.LightGoldenrodYellow,
                    SparkEndColour = Color.OrangeRed,

                    MaxLifespan = 0.2f + (float)Main.random.NextDouble() / 10f,
                    WindStrength = 2000f,

                    Position = 
                        new Vector2(
                            Main.camera.BoundingBox.Left + i,
                            Main.camera.BoundingBox.Bottom)
                });
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
        }
    }
}