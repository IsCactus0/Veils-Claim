using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using VeilsClaim.Classes.Managers;

namespace VeilsClaim.Classes.Objects
{
    public class Tile
    {
        public string Name;
        public float zIndex;
        public Rectangle Sprite;
        public Rectangle Hitbox;

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(AssetManager.LoadTexture(Name), Sprite, Color.White);
        }
    }
}