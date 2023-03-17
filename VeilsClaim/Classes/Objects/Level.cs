using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace VeilsClaim.Classes.Objects
{
    public class Level
    {
        public Level()
        {
            tiles = new Tile[32, 32];
            backgroundColour = Color.FromNonPremultiplied(30, 30, 37, 256);
        }
        public Level(int size)
        {
            tiles = new Tile[size, size];
            backgroundColour = Color.FromNonPremultiplied(30, 30, 37, 256);
        }
        public Level(int width, int height)
        {
            tiles = new Tile[width, height];
            backgroundColour = Color.FromNonPremultiplied(30, 30, 37, 256);
        }
        public Level(int width, int height, Color backgroundColour)
        {
            tiles = new Tile[width, height];
            this.backgroundColour = backgroundColour;
        }

        public Tile[,] tiles;
        public List<Entity> entiies;
        public Color backgroundColour;

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            for (int y = 0; y < tiles.GetLength(1); y++)
                for (int x = 0; x < tiles.GetLength(0); x++)
                    tiles[x, y]?.Draw(spriteBatch, new Point(3, 3));
        }
    }
}