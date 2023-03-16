using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using VeilsClaim.Classes.Managers;
using VeilsClaim.Classes.Utilities;

namespace VeilsClaim
{
    public class Main : Game
    {
        public GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;

        public static Camera camera;
        public static Random random;

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
            Components.Add(new AssetManager(this));
            Components.Add(new EntityManager(this));
            Components.Add(new ParticleManager(this));

            SetResolution(800, 600, false);

            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            random = new Random();
            gameSpeed = 1f;
            physicsDistance = 100f;
            renderDistance = 0f;
            gravityStrength = 1f;
        }
        protected override void Update(GameTime gameTime)
        {
            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds * gameSpeed;

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            camera.Update(delta, 10, Vector2.Zero);

            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            base.Draw(gameTime);
        }
        public void SetResolution(int width, int height, bool fullscreen)
        {
            graphics.PreferredBackBufferWidth = width;
            graphics.PreferredBackBufferHeight = height;
            graphics.IsFullScreen = fullscreen;
            graphics.ApplyChanges();

            camera = new Camera(new Viewport(width / 2, height / 2, width, height));
        }
    }
}