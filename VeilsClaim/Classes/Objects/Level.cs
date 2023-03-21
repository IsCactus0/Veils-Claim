using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace VeilsClaim.Classes.Objects
{
    public class Level
    {
        public Level()
        {
            width = 16;
            height = 16;
            tiles = new Tile[272];
            backgroundColour = Color.FromNonPremultiplied(30, 30, 37, 256);
        }
        public Level(int size)
        {
            width = size;
            height = size;
            tiles = new Tile[size * size + size];
            backgroundColour = Color.FromNonPremultiplied(30, 30, 37, 256);
        }
        public Level(int width, int height)
        {
            this.width = width;
            this.height = height;
            tiles = new Tile[height * width + width];
            backgroundColour = Color.FromNonPremultiplied(30, 30, 37, 256);
        }
        public Level(int width, int height, Color backgroundColour)
        {
            this.width = width;
            this.height = height;
            tiles = new Tile[height * width + width];
            this.backgroundColour = backgroundColour;
        }

        public int width;
        public int height;
        public Tile[] tiles;
        public List<Entity> entiies;
        public Color backgroundColour;

        public virtual void Update(float delta)
        {
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                    if (tiles[y * width + x] is DynamicTile)
                        ((DynamicTile)tiles[y * x + x])?.Update(delta);
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                    tiles[y * width + x]?.Draw(spriteBatch, new Point(x, y));
        }
    }
}