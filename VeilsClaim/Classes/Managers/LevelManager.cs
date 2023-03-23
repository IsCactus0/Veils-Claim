using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using System.Xml.Serialization;
using VeilsClaim.Classes.Objects;

namespace VeilsClaim.Classes.Managers
{
    public class LevelManager : DrawableGameComponent
    {
        public LevelManager(Game game)
            : base(game)
        {
            spriteBatch = new SpriteBatch(game.GraphicsDevice);
            level = new Level();
            savesPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                "\\VeilsClaim";

            level = new Level(32, 16);

            for (int y = 0; y < level.height; y++)
                for (int x = 0; x < level.height; x++)
                {
                    string name = $"floor_{Main.random.Next(3)}";
                    if (y == 0)
                        name = "wall";
                    level.tiles[y * level.width + x] = new Tile
                    {
                        Name = name,
                        Sprite = new Rectangle(x * 8, y * 12, 8, 12),
                        Hitbox = new Rectangle(x * 8, y * 12, 8, 12),
                        zIndex = 0
                    };
                }
        }

        public static SpriteBatch spriteBatch;
        public static Level level;
        public static string savesPath;

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.SetRenderTarget(Main.renderTarget);
            spriteBatch.Begin(
                SpriteSortMode.Immediate,
                BlendState.AlphaBlend,
                SamplerState.PointClamp,
                DepthStencilState.None,
                RasterizerState.CullNone,
                null,
                Main.camera.Transform);

            level.Draw(spriteBatch);

            spriteBatch.End();
        }
        public static void ReadXML(string name)
        {
            XmlSerializer reader = new XmlSerializer(typeof(Level));
            StreamReader stream = new StreamReader(savesPath + $"\\{name}.save");

            level = (Level)reader.Deserialize(stream);
            stream.Close();
        }
        public static void WriteXML(string name)
        {
            Directory.CreateDirectory(savesPath);

            XmlSerializer writer = new XmlSerializer(typeof(Level));
            StreamWriter stream = new StreamWriter(savesPath + $"\\{name}.save");
            
            writer.Serialize(stream, level);
            stream.Close();
        }
    }
}