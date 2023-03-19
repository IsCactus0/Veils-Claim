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

            SetResolution(800, 600, false);

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
            level.tiles[0, 0] = new Tile()
            {
                Sprite = new Rectangle(0, 0, 8, 12),
                Hitbox = new Rectangle(0, 0, 8, 3),
                Name = "wall",
            };
            level.tiles[1, 0] = new DoorTile()
            {
                Sprite = new Rectangle(0, 0, 8, 12),
                Hitbox = new Rectangle(0, 0, 8, 3),
                frameChange = 1,
                frameRate = 0.02f,
                frames = new List<string>()
                {
                    "airlock_0",
                    "airlock_1",
                    "airlock_2",
                    "airlock_3",
                    "airlock_4",
                    "airlock_5",
                    "airlock_6"
                },
                Name = "airlock_0",
                isOpen = false
            };
            level.tiles[2, 0] = new Tile()
            {
                Sprite = new Rectangle(0, 0, 8, 12),
                Hitbox = new Rectangle(0, 0, 8, 3),
                Name = "wall",
            };

            level.tiles[0, 1] = new Tile()
            {
                Sprite = new Rectangle(0, 0, 8, 8),
                Hitbox = new Rectangle(0, 0, 8, 8),
                Name = "floor_0",
            };
            level.tiles[1, 1] = new Tile()
            {
                Sprite = new Rectangle(0, 0, 8, 8),
                Hitbox = new Rectangle(0, 0, 8, 8),
                Name = "floor_1",
            };
            level.tiles[2, 1] = new Tile()
            {
                Sprite = new Rectangle(0, 0, 8, 8),
                Hitbox = new Rectangle(0, 0, 8, 8),
                Name = "floor_2",
            };
        }
        protected override void Update(GameTime gameTime)
        {
            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds * gameSpeed;
            noiseOffset += delta;

            camera.Scale = 20f;
            camera.Update(delta, 10, new Vector2(12, 6));

            if (InputManager.InputPressed("zoomIn")) camera.Scale += delta * 50f;
            if (InputManager.InputPressed("zoomOut")) camera.Scale -= delta * 50f;
            if (InputManager.InputPressed("exit")) Exit();

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
        }
    }
}