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
        
        public static RenderTarget2D renderTarget;
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
            Components.Add(new LevelManager(this));
            Components.Add(new EntityManager(this));
            Components.Add(new ParticleManager(this));

            SetResolution(1920, 1080, false);

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

            LevelManager.WriteXML("test");
            LevelManager.ReadXML("test");
        }
        protected override void Update(GameTime gameTime)
        {
            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds * gameSpeed;
            noiseOffset += delta;

            if (InputManager.InputPressed("zoomIn"))
                camera.Scale += delta * 5f;
            if (InputManager.InputPressed("zoomOut"))
                camera.Scale -= delta * 5f;
            if (InputManager.InputPressed("exit"))
                Quit(true);

            camera.Update(delta, 10, new Vector2(12, 6));
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.SetRenderTarget(renderTarget);
            GraphicsDevice.Clear(LevelManager.level.backgroundColour);
            spriteBatch.Begin(
                SpriteSortMode.Deferred,
                BlendState.AlphaBlend,
                SamplerState.PointClamp,
                DepthStencilState.None,
                RasterizerState.CullNone,
                null,
                camera.Transform);

            base.Draw(gameTime);

            spriteBatch.End();

            GraphicsDevice.SetRenderTarget(null);
            spriteBatch.Begin();
            spriteBatch.Draw(renderTarget, Vector2.Zero, Color.White);
            spriteBatch.End();
        }
        public void SetResolution(int width, int height, bool fullscreen)
        {
            renderTarget = new RenderTarget2D(GraphicsDevice, width, height);
            GraphicsDevice.Clear(Color.Transparent);

            graphics.PreferredBackBufferWidth = width;
            graphics.PreferredBackBufferHeight = height;
            graphics.IsFullScreen = fullscreen;
            graphics.ApplyChanges();

            camera = new Camera(new Viewport(width / 2, height / 2, width, height));
            camera.Scale = 10;
        }
        public void Quit(bool save = true)
        {
            if (save)
            {

            }

            Exit();
        }
    }
}