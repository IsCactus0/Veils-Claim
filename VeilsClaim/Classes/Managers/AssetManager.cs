using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace VeilsClaim.Classes.Managers
{
    public class AssetManager : GameComponent
    {
        public AssetManager(Game game)
            : base(game)
        {
            content = game.Content;
            textures = new Dictionary<string, Texture2D>();

            Texture2D pixel = new Texture2D(game.GraphicsDevice, 1, 1);
            pixel.SetData(new Color[] { Color.White });
            textures.Add("empty", pixel);
        }
        
        public static ContentManager content;
        public static Dictionary<string, Texture2D> textures;

        public static Texture2D GetTexture(string name)
        {
            if (textures.ContainsKey(name))
                return textures[name];
            else return textures["empty"];
        }
    }
}
