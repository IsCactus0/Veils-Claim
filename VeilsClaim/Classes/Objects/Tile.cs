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

        public virtual void Draw(SpriteBatch spriteBatch, Point gridPosition)
        {
            spriteBatch.Draw(
                AssetManager.LoadTexture(Name),
                new Rectangle(
                    Sprite.X + gridPosition.X * 8,
                    Sprite.Y + gridPosition.Y * 12,
                    Sprite.Width,
                    Sprite.Height),
                Color.White);
        }
    }
}