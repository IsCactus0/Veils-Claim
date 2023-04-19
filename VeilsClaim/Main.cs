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
        public GraphicsDeviceManager Graphics;
        public SpriteBatch SpriteBatch;
        
        public static RenderTarget2D RenderTarget;
        public static OpenSimplexNoise SimplexNoise;
        public static Random Random;
        public static Camera Camera;

        public static float NoiseOffset;
        public static float GameSpeed;
        public static float PhysicsDistance;
        public static float RenderDistance;

        public Main()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
        }
        protected override void Initialize()
        {
            Random = new Random();
            SimplexNoise = new OpenSimplexNoise();

            GameSpeed = 1f;
            PhysicsDistance = 100f;
            RenderDistance = 50f;

            Components.Add(new InputManager(this));
            Components.Add(new AssetManager(this));
            Components.Add(new EntityManager(this));
            Components.Add(new ProjectileManager(this));
            Components.Add(new ParticleManager(this));

            Camera = new Camera(new Viewport());
            SetResolution(1200, 800, 1200, 800, false, false);

            base.Initialize();
        }
        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);
        }
        protected override void Update(GameTime gameTime)
        {
            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds * GameSpeed;
            NoiseOffset += delta;

            if (InputManager.InputPressed("zoomIn"))
                Camera.Scale += delta * 5f;
            if (InputManager.InputPressed("zoomOut"))
                Camera.Scale -= delta * 5f;
            if (InputManager.InputPressed("exit"))
                Quit(true);
            
            Camera.Update(delta, 10f, EntityManager.player.Position);
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.SetRenderTarget(RenderTarget);
            GraphicsDevice.Clear(Color.Black);
            SpriteBatch.Begin(
                SpriteSortMode.Deferred,
                BlendState.AlphaBlend,
                Camera.SamplerState,
                DepthStencilState.None,
                RasterizerState.CullNone,
                null,
                Camera.Transform);

            base.Draw(gameTime);
            SpriteBatch.End();

            GraphicsDevice.SetRenderTarget(null);
            SpriteBatch.Begin(
                SpriteSortMode.Deferred,
                BlendState.AlphaBlend,
                SamplerState.PointClamp,
                DepthStencilState.None,
                RasterizerState.CullNone,
                null);

            SpriteBatch.Draw(
                RenderTarget,
                new Rectangle(0, 0, Graphics.PreferredBackBufferWidth, Graphics.PreferredBackBufferHeight),
                Color.White);

            SpriteBatch.Draw(
                AssetManager.LoadTexture("circle"),
                InputManager.MouseScreenPosition(),
                Color.White);

            SpriteBatch.End();
        }
        public void SetResolution(int width, int height, bool fullscreen, bool vsync)
        {
            SetResolution(width, height, width, height, fullscreen, vsync);
        }
        public void SetResolution(int resolutionWidth, int resolutionHeight, int windowWidth, int windowHeight, bool fullscreen, bool vsync)
        {
            RenderTarget = new RenderTarget2D(GraphicsDevice, resolutionWidth, resolutionHeight);
            GraphicsDevice.Clear(Color.Transparent);

            IsFixedTimeStep = vsync;
            Graphics.SynchronizeWithVerticalRetrace = vsync;
            Graphics.HardwareModeSwitch = false;

            Graphics.PreferredBackBufferWidth = windowWidth;
            Graphics.PreferredBackBufferHeight = windowHeight;
            Graphics.IsFullScreen = fullscreen;
            Graphics.ApplyChanges();

            Camera.Viewport = new Viewport(
                    resolutionWidth / 2,
                    resolutionHeight / 2,
                    resolutionWidth,
                    resolutionHeight);

            Camera.Scale = 1f;
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