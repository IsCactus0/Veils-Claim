﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using VeilsClaim.Classes.Objects;

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
        public static QuadTree quadTree;
        public static List<Particle> particles;

        public override void Update(GameTime gameTime)
        {
            if (particles.Count > 0)
                quadTree = new QuadTree(Main.Camera.RenderBoundingBox, 32);

            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds * Main.GameSpeed;
            if (delta > 0)
                for (int i = particles.Count - 1; i >= 0; i--)
                    particles[i].Update(delta);

            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.SetRenderTarget(Main.RenderTarget);
            spriteBatch.Begin(
                SpriteSortMode.Immediate,                
                BlendState.Additive,
                SamplerState.PointClamp,
                DepthStencilState.None,
                RasterizerState.CullNone,
                null,
                Main.Camera.Transform);

            for (int i = particles.Count - 1; i >= 0; i--)
                particles[i].Draw(spriteBatch);

            spriteBatch.End();
        }
    }
}