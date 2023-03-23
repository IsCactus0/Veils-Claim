using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using VeilsClaim.Classes.Managers;
using VeilsClaim.Classes.Objects;
using VeilsClaim.Classes.Utilities;

namespace VeilsClaim
{
    public class Main : Game
    {
        public GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        
        public static RenderTarget2D renderTarget;
        public static OpenSimplexNoise simplexNoise;
        public static Random random;
        public static Camera camera;

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
            random = new Random();
            simplexNoise = new OpenSimplexNoise();

            gameSpeed = 1f;
            physicsDistance = 100f;
            renderDistance = 0f;
            gravityStrength = 1f;

            Components.Add(new InputManager(this));
            Components.Add(new AssetManager(this));
            Components.Add(new LevelManager(this));
            Components.Add(new EntityManager(this));
            Components.Add(new ParticleManager(this));

            camera = new Camera(new Viewport());
            SetResolution(600, 400, 1200, 800, false, false);

            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
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
            
            camera.Update(delta, 10, EntityManager.entities[0].Position);
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
            spriteBatch.Begin(
                SpriteSortMode.Deferred,
                BlendState.AlphaBlend,
                SamplerState.PointClamp,
                DepthStencilState.None,
                RasterizerState.CullNone,
                null);

            spriteBatch.Draw(
                renderTarget,
                new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight),
                Color.White);

            spriteBatch.End();
        }
        public void SetResolution(int width, int height, bool fullscreen, bool vsync)
        {
            SetResolution(width, height, width, height, fullscreen, vsync);
        }
        public void SetResolution(int resolutionWidth, int resolutionHeight, int windowWidth, int windowHeight, bool fullscreen, bool vsync)
        {
            renderTarget = new RenderTarget2D(GraphicsDevice, resolutionWidth, resolutionHeight);
            GraphicsDevice.Clear(Color.Transparent);

            IsFixedTimeStep = vsync;
            graphics.SynchronizeWithVerticalRetrace = vsync;
            graphics.HardwareModeSwitch = false;

            graphics.PreferredBackBufferWidth = windowWidth;
            graphics.PreferredBackBufferHeight = windowHeight;
            graphics.IsFullScreen = fullscreen;
            graphics.ApplyChanges();

            camera.Viewport = new Viewport(
                    resolutionWidth / 2,
                    resolutionHeight / 2,
                    resolutionWidth,
                    resolutionHeight);

            camera.Scale = 10f / (windowWidth / resolutionWidth);
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