using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using VeilsClaim.Classes.Enums;
using VeilsClaim.Classes.Managers;

namespace VeilsClaim.Classes.Utilities
{
    public static class Drawing
    {
        public static List<Vector2> Square(float size)
        {
            return Rectangle(size, size, size / -2, size / -2);
        }
        public static List<Vector2> Rectangle(float width, float height)
        {
            return Rectangle(width, height, width / -2, height / -2);
        }
        public static List<Vector2> Rectangle(float width, float height, float offsetX, float offsetY)
        {
            return Rectangle(width, height, new Vector2(offsetX, offsetY));
        }
        public static List<Vector2> Rectangle(float width, float height, Vector2 offset)
        {
            List<Vector2> vertices = new List<Vector2>()
            {
                new Vector2(offset.X, offset.Y),
                new Vector2(offset.X + width, offset.Y),
                new Vector2(offset.X + width, offset.Y + height),
                new Vector2(offset.X, offset.Y + height),
            };

            return vertices;
        }
        public static List<Vector2> Rectangle(Rectangle rectangle)
        {
            return new List<Vector2>()
            {
                new Vector2(rectangle.Left, rectangle.Top),
                new Vector2(rectangle.Right, rectangle.Top),
                new Vector2(rectangle.Right, rectangle.Bottom),
                new Vector2(rectangle.Left, rectangle.Bottom)
            };
        }
        public static List<Vector2> Circle(float radius, float detail)
        {
            return Ellipse(radius * 2f, radius * 2f, detail, 0, 0);
        }
        public static List<Vector2> Ellipse(float width, float height, float detail)
        {
            return Ellipse(width, height, detail, 0, 0);
        }
        public static List<Vector2> Ellipse(float width, float height, float detail, float originX, float originY)
        {
            return Ellipse(width, height, detail, new Vector2(originX, originY));
        }
        public static List<Vector2> Ellipse(float width, float height, float detail, Vector2 origin)
        {
            List<Vector2> vertices = new List<Vector2>();
            for (float angle = 0; angle < MathHelper.TwoPi; angle += MathHelper.TwoPi / detail)
                vertices.Add(new Vector2(
                    origin.X + (width / 2) * (float)Math.Cos(angle),
                    origin.Y + (height / 2) * (float)Math.Sin(angle)));

            return vertices;
        }
        public static List<Vector2> Cross(float size)
        {
            return new List<Vector2>()
            {
                new Vector2(-size, -size),
                new Vector2(size, size)
            };
        }
        public static List<Vector2> Asteroid(float radius, float detail, float roughness, int resolution)
        {
            return Asteroid(radius, detail, roughness, resolution, Vector2.Zero);
        }
        public static List<Vector2> Asteroid(float radius, float detail, float roughness, int resolution, Vector2 origin)
        {
            List<Vector2> vertices = new List<Vector2>();

            for (int i = 0; i < resolution; i++)
            {
                float angle = MathHelper.TwoPi / resolution * i;
                float offset = (float)Main.SimplexNoise.Evaluate(Math.Cos(angle) * detail + origin.X, Math.Sin(angle) * detail + origin.Y);

                vertices.Add(new Vector2(
                    (radius + offset * roughness) * (float)Math.Cos(angle),
                    (radius + offset * roughness) * (float)Math.Sin(angle)));
            }

            return vertices;
        }

        public static Texture2D Noise(GraphicsDevice graphicsDevice, int width, int height)
        {
            Texture2D rectangle = new Texture2D(graphicsDevice, width, height);
            Color[] colors = new Color[width * height];
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    colors[y * width + x] = Color.White * (float)Main.SimplexNoise.Evaluate(
                        x / 100f,
                        y / 100f);

                }
            rectangle.SetData(colors);
            return rectangle;
        }
        public static Texture2D Circle(GraphicsDevice graphicsDevice, int radius)
        {
            return Circle(graphicsDevice, radius, Color.White);
        }
        public static Texture2D Circle(GraphicsDevice graphicsDevice, int radius, Color colour)
        {
            return Circle(graphicsDevice, radius, colour, FadeType.Edge);
        }
        public static Texture2D Circle(GraphicsDevice graphicsDevice, int radius, Color colour, FadeType fadeType)
        {
            Texture2D circle = new Texture2D(graphicsDevice, radius * 2 + 1, radius * 2 + 1);
            Color[] colors = new Color[circle.Width * circle.Height];
            Vector2 center = new Vector2(radius);
            Color finalColour;

            for (int y = 0; y < circle.Height; y++)
                for (int x = 0; x < circle.Width; x++)
                {
                    float distance = Vector2.Distance(new Vector2(x, y), center);
                    if (distance <= radius)
                    {
                        finalColour = colour;
                        switch (fadeType)
                        {
                            case FadeType.Edge:
                                finalColour *= (radius - distance);
                                break;
                            case FadeType.Linear:
                                finalColour *= 1f - (distance / radius);
                                break;
                            case FadeType.InverseSquare:
                                finalColour *= 1f - ((distance / radius) * (distance / radius));
                                break;
                        }

                        colors[y * circle.Width + x] = finalColour;
                    }
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
                    if (Math.Abs(x - center.X) <= width && Math.Abs(y - center.Y) <= height)
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

        public static void Draw(SpriteBatch spriteBatch, List<Vector2> vertices, Vector2 origin, Color colour, float strokeWeight = 3f)
        {
            if (vertices.Count > 0)
            {
                DrawLine(spriteBatch, vertices[vertices.Count - 1] + origin, vertices[0] + origin, colour, strokeWeight);
                for (int v = 0; v < vertices.Count - 1; v++)
                    DrawLine(spriteBatch, vertices[v] + origin, vertices[v + 1] + origin, colour, strokeWeight);
            }
        }
        public static void DrawLine(SpriteBatch spriteBatch, Vector2 start, Vector2 end, Color colour, float thickness = 1f)
        {
            var distance = Vector2.Distance(start, end);
            var angle = (float)Math.Atan2(end.Y - start.Y, end.X - start.X);
            var origin = new Vector2(0f, 0.5f);
            var scale = new Vector2(distance, thickness);

            spriteBatch.Draw(AssetManager.textures["simple"], start, null, colour, angle, origin, scale, SpriteEffects.None, 0);
        }
    }
}