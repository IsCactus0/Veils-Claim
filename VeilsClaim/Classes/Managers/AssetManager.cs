using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace VeilsClaim.Classes.Managers
{
    public class AssetManager : GameComponent
    {
        public AssetManager(Game game)
            : base(game)
        {
            content = game.Content;
            textures = new Dictionary<string, Texture2D>
            {
                { "empty", Utilities.Drawing.Square(game.GraphicsDevice, 1, Color.Magenta) },
                { "square", Utilities.Drawing.Square(game.GraphicsDevice, 1, Color.White) },
                { "circle", Utilities.Drawing.Circle(game.GraphicsDevice, 16, Color.White) }
            };
        }
        
        public static ContentManager content;
        public static Dictionary<string, Texture2D> textures;

        public static Texture2D GetTexture(string name)
        {
            if (textures.ContainsKey(name))
                return textures[name];
            else
            {
                Console.WriteLine($"texture failed to load: {name}.");
                return textures["empty"];
            }
        }
    }
}