using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace VeilsClaim.Classes.Utilities
{
    public static class Drawing
    {
        public static Texture2D Circle(GraphicsDevice graphicsDevice, int radius)
        {
            return Circle(graphicsDevice, radius, Color.White);
        }
        public static Texture2D Circle(GraphicsDevice graphicsDevice, int radius, Color colour)
        {
            Texture2D circle = new Texture2D(graphicsDevice, radius * 2, radius * 2);
            Color[] colors = new Color[circle.Width * circle.Height];
            Vector2 center = new Vector2(radius);

            for (int y = 0; y < circle.Height; y++)
                for (int x = 0; x < circle.Width; x++)
                {
                    float distance = Vector2.Distance(new Vector2(x, y), center);
                    if (distance <= radius)
                        colors[y * circle.Width + x] = colour * (radius - distance); // Used to blur edges.
                }

            circle.SetData(colors);
            return circle;
        }
        public static Texture2D Ellipse(GraphicsDevice graphicsDevice, int width, int height)
        {
            return Ellipse(graphicsDevice, width, height, Color.White);
        }
        public static Texture2D Ellipse(GraphicsDevice graphicsDevice, int width, int height, Color colour)
        {
            Texture2D ellipse = new Texture2D(graphicsDevice, width, height);
            Color[] colors = new Color[width * height];

            Vector2 center = new Vector2(width / 2f, height / 2f);
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    if (Math.Abs(x - center.X) <= width && Math.Abs(y - center.Y) <= height);
                        colors[y * width + x] = colour;
                }

            ellipse.SetData(colors);
            return ellipse;
        }
        public static Texture2D Square(GraphicsDevice graphicsDevice, int size)
        {
            return Rectangle(graphicsDevice, size, size, Color.White);
        }
        public static Texture2D Square(GraphicsDevice graphicsDevice, int size, Color colour)
        {
            return Rectangle(graphicsDevice, size, size, colour);
        }
        public static Texture2D Rectangle(GraphicsDevice graphicsDevice, int width, int height)
        {
            return Rectangle(graphicsDevice, width, height, Color.White);
        }
        public static Texture2D Rectangle(GraphicsDevice graphicsDevice, int width, int height, Color colour)
        {
            Texture2D rectangle = new Texture2D(graphicsDevice, width, height);
            Color[] colors = new Color[width * height];
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                    colors[y * width + x] = colour;
            rectangle.SetData(colors);
            return rectangle;
        }
    }
}