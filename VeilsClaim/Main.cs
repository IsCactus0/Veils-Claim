using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using VeilsClaim.Classes.Managers;
using VeilsClaim.Classes.Objects;
using VeilsClaim.Classes.Objects.Tiles;
using VeilsClaim.Classes.Utilities;

namespace VeilsClaim
{
    public class Main : Game
    {
        public GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;

        public static Camera camera;
        public static Random random;
        public static OpenSimplexNoise simplexNoise;

        public static Level level;

        public static float noiseOffset;
        public static float gameSpeed;
        public static float physicsDistance;
        public static float renderDistance;
        public static float gravityStrength;

        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
        protected override void Initialize()
        {
            Components.Add(new InputManager(this));
            Components.Add(new AssetManager(this));
            Components.Add(new EntityManager(this));
            Components.Add(new ParticleManager(this));

            SetResolution(1200, 800, false);

            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            random = new Random();
            simplexNoise = new OpenSimplexNoise();

            gameSpeed = 1f;
            physicsDistance = 100f;
            renderDistance = 0f;
            gravityStrength = 1f;

            level = new Level(32, 16);
        }
        protected override void Update(GameTime gameTime)
        {
            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds * gameSpeed;
            noiseOffset += delta;

            if (InputManager.InputPressed("zoomIn")) camera.Scale += delta * 5f;
            if (InputManager.InputPressed("zoomOut")) camera.Scale -= delta * 5f;
            if (InputManager.InputPressed("exit")) Exit();

            camera.Update(delta, 10, new Vector2(12, 6));
            level.Update(delta);
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(level.backgroundColour);

            spriteBatch.Begin(
                SpriteSortMode.Immediate,
                BlendState.AlphaBlend,
                SamplerState.PointClamp,
                DepthStencilState.None,
                RasterizerState.CullNone,
                null,
                camera.Transform);

            level.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
        public void SetResolution(int width, int height, bool fullscreen)
        {
            graphics.PreferredBackBufferWidth = width;
            graphics.PreferredBackBufferHeight = height;
            graphics.IsFullScreen = fullscreen;
            graphics.ApplyChanges();

            camera = new Camera(new Viewport(width / 2, height / 2, width, height));
            camera.Scale = 10;
        }
    }
}