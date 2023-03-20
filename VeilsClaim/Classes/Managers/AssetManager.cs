using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using VeilsClaim.Classes.Enums;

namespace VeilsClaim.Classes.Managers
{
    public class AssetManager : GameComponent
    {
        public AssetManager(Game game)
            : base(game)
        {
            content = game.Content;
            device = game.GraphicsDevice;
            textures = new Dictionary<string, Texture2D>
            {
                { "empty", Utilities.Drawing.Square(game.GraphicsDevice, 1, Color.Magenta) },
                { "simple", Utilities.Drawing.Square(game.GraphicsDevice, 1, Color.White) },
                { "circle", Utilities.Drawing.Circle(game.GraphicsDevice, 32, Color.White, FadeType.Edge) },
                { "blur", Utilities.Drawing.Circle(game.GraphicsDevice, 32, Color.White, FadeType.InverseSquare) }
            };
            fonts = new Dictionary<string, SpriteFont>();
            assetPath = @$"../../../Assets/";
        }
        
        public static ContentManager content;
        public static GraphicsDevice device;
        public static Dictionary<string, Texture2D> textures;
        public static Dictionary<string, SpriteFont> fonts;
        public static string assetPath;

        public static Texture2D LoadTexture(string file)
        {
            if (!textures.ContainsKey(file))
            {
                try
                {
                    FileStream stream = File.OpenRead($@"{assetPath}/Textures/{file}.png");
                    Texture2D texture = Texture2D.FromStream(device, stream);
                    stream.Close();

                    Color[] buffer = new Color[texture.Width * texture.Height];
                    texture.GetData(buffer);
                    for (int i = 0; i < buffer.Length; i++)
                        buffer[i] = Color.FromNonPremultiplied(buffer[i].R, buffer[i].G, buffer[i].B, buffer[i].A);
                    texture.SetData(buffer);

                    textures.Add(file, texture);
                }
                catch (FileNotFoundException error)
                {
                    #if (DEBUG)
                        Console.WriteLine($"Error while loading texture {file}:\n{error}\n");
                    #endif
                    return textures["empty"];
                }

            }

            return textures[file];
        }
    }
}