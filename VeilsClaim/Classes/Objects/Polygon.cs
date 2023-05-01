using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using VeilsClaim.Classes.Enums;
using VeilsClaim.Classes.Utilities;

namespace VeilsClaim.Classes.Objects
{
    public class Polygon
    {
        public Polygon()
        {
            OriginalVertices = new List<Vector3>();
            CurrentVertices = new List<Vector3>();
            Origin = Vector3.Zero;
            Offset = Vector3.Zero;
            ScaleX = 1f;
            ScaleY = 1f;
            ScaleZ = 1f;
            Roll = 0f;
            Pitch = 0f;
            Yaw = 0f;
            MaxZDepth = FindFurthestPoint();
        }
        public Polygon(Vector3 origin)
        {
            OriginalVertices = new List<Vector3>();
            CurrentVertices = new List<Vector3>();
            Origin = Vector3.Zero;
            Offset = origin;
            ScaleX = 1f;
            ScaleY = 1f;
            ScaleZ = 1f;
            Roll = 0f;
            Pitch = 0f;
            Yaw = 0f;
            MaxZDepth = FindFurthestPoint();
        }
        public Polygon(Vector3 origin, List<Vector2> vertices)
        {
            OriginalVertices = new List<Vector3>();
            CurrentVertices = new List<Vector3>();
            for (int i = 0; i < vertices.Count; i++)
            {
                OriginalVertices.Add(new Vector3(vertices[i].X, vertices[i].Y, 0));
                CurrentVertices.Add(new Vector3(vertices[i].X, vertices[i].Y, 0));
            }
            Origin = Vector3.Zero;
            Offset = origin;
            ScaleX = 1f;
            ScaleY = 1f;
            ScaleZ = 1f;
            Roll = 0f;
            Pitch = 0f;
            Yaw = 0f;
            MaxZDepth = FindFurthestPoint();
        }
        public Polygon(Vector3 origin, List<Vector3> vertices)
        {
            OriginalVertices = new List<Vector3>(vertices);
            CurrentVertices = new List<Vector3>(vertices);
            Origin = Vector3.Zero;
            Offset = origin;
            ScaleX = 1f;
            ScaleY = 1f;
            ScaleZ = 1f;
            Roll = 0f;
            Pitch = 0f;
            Yaw = 0f;
            MaxZDepth = FindFurthestPoint();
        }

        public List<Vector3> OriginalVertices;
        public List<Vector3> CurrentVertices;
        public Vector3 Origin;
        public Vector3 Offset;
        public float ScaleX;
        public float ScaleY;
        public float ScaleZ;
        public float Roll;
        public float Pitch;
        public float Yaw;
        public float MaxZDepth;

        public void Draw(SpriteBatch spriteBatch, Color colour, float strokeWeight = 3f)
        {
            if (CurrentVertices.Count > 0)
            {
                Drawing.DrawLine(spriteBatch,
                    new Vector2(CurrentVertices[CurrentVertices.Count - 1].X + Origin.X, CurrentVertices[CurrentVertices.Count - 1].Y + Origin.Y),
                    new Vector2(CurrentVertices[0].X + Origin.X, CurrentVertices[0].Y + Origin.Y),
                    colour, strokeWeight);

                for (int v = 0; v < CurrentVertices.Count - 1; v++)
                    Drawing.DrawLine(spriteBatch,
                        new Vector2(CurrentVertices[v].X + Origin.X, CurrentVertices[v].Y + Origin.Y),
                        new Vector2(CurrentVertices[v + 1].X + Origin.X, CurrentVertices[v + 1].Y + Origin.Y),
                        colour, strokeWeight);
            }
        }

        public void ApplyTransforms()
        {
            Matrix translate = Matrix.CreateTranslation(Offset);
            Matrix scale = Matrix.CreateScale(ScaleX, ScaleY, ScaleZ);
            Matrix roll = Matrix.CreateRotationX(Roll);
            Matrix pitch = Matrix.CreateRotationY(Pitch);
            Matrix yaw = Matrix.CreateRotationZ(Yaw);

            for (int i = 0; i < OriginalVertices.Count; i++)
            {
                CurrentVertices[i] = Vector3.Transform(OriginalVertices[i], translate);
                CurrentVertices[i] = Vector3.Transform(CurrentVertices[i], scale);
                CurrentVertices[i] = Vector3.Transform(CurrentVertices[i], roll);
                CurrentVertices[i] = Vector3.Transform(CurrentVertices[i], pitch);
                CurrentVertices[i] = Vector3.Transform(CurrentVertices[i], yaw);
            }
        }
        public void ApplyTransforms(Polygon parent)
        {
            ApplyTransforms();

            Matrix roll = Matrix.CreateRotationX(parent.Roll);
            Matrix pitch = Matrix.CreateRotationY(parent.Pitch);
            Matrix yaw = Matrix.CreateRotationZ(parent.Yaw);

            for (int i = 0; i < OriginalVertices.Count; i++)
            {
                CurrentVertices[i] = Vector3.Transform(CurrentVertices[i], roll);
                CurrentVertices[i] = Vector3.Transform(CurrentVertices[i], pitch);
                CurrentVertices[i] = Vector3.Transform(CurrentVertices[i], yaw);
            }
        }
        public void Rotate(float angle, Axis axis)
        {
            switch (axis)
            {
                case Axis.X:
                    Roll += angle;
                    if (Roll > MathHelper.TwoPi)
                        Roll -= MathHelper.TwoPi;
                    break;
                case Axis.Y:
                    Pitch += angle;
                    if (Pitch > MathHelper.TwoPi)
                        Pitch -= MathHelper.TwoPi;
                    break;
                case Axis.Z:
                    Yaw += angle;
                    if (Yaw > MathHelper.TwoPi)
                        Yaw -= MathHelper.TwoPi;
                    break;
            }
        }
        public void Rotate(float roll, float pitch, float yaw)
        {
            Roll += roll;
            if (Roll > MathHelper.TwoPi)
                Roll -= MathHelper.TwoPi;

            Pitch += pitch;
            if (Pitch > MathHelper.TwoPi)
                Pitch -= MathHelper.TwoPi;

            Yaw += yaw;
            if (Yaw > MathHelper.TwoPi)
                Yaw -= MathHelper.TwoPi;
        }
        public void SetRotation(float angle, Axis axis)
        {
            switch (axis)
            {
                case Axis.X: Roll = angle;
                    break;
                case Axis.Y: Pitch = angle;
                    break;
                case Axis.Z: Yaw = angle;
                    break;
            }
        }
        public void SetRotation(float roll, float pitch, float yaw)
        {
            Roll = roll;
            Pitch = pitch;
            Yaw = yaw;
        }

        public void Scale(float scale)
        {
            ScaleX *= scale;
            ScaleY *= scale;
            ScaleZ *= scale;
        }
        public void Scale(float scaleX, float scaleY)
        {
            ScaleX *= scaleX;
            ScaleY *= scaleY;
            ScaleZ *= 1f;
        }
        public void Scale(float scaleX, float scaleY, float scaleZ)
        {
            ScaleX *= scaleX;
            ScaleY *= scaleY;
            ScaleZ *= scaleZ;
        }
        public void SetScale(float scale)
        {
            ScaleX = scale;
            ScaleY = scale;
            ScaleZ = scale;
        }
        public void SetScale(float scaleX, float scaleY)
        {
            ScaleX = scaleX;
            ScaleY = scaleY;
            ScaleZ = 1f;
        }
        public void SetScale(float scaleX, float scaleY, float scaleZ)
        {
            ScaleX = scaleX;
            ScaleY = scaleY;
            ScaleZ = scaleZ;
        }

        public void Translate(Vector2 move)
        {
            for (int i = 0; i < OriginalVertices.Count; i++)
                OriginalVertices[i] += new Vector3(move, 0);
        }
        public void Translate(float moveX, float moveY)
        {
            for (int i = 0; i < OriginalVertices.Count; i++)
                OriginalVertices[i] += new Vector3(moveX, moveY, 0);
        }
        public void Translate(List<Vector2> vertices, Vector2 move)
        {
            for (int i = 0; i < vertices.Count; i++)
                vertices[i] += move;
        }
        public void Translate(List<Vector2> vertices, float moveX, float moveY)
        {
            for (int i = 0; i < vertices.Count; i++)
                vertices[i] += new Vector2(moveX, moveY);
        }

        public float CalculateLight(Vector2 vertice, float sunAngle, float sunStrength = 1f)
        {
            float angle = MathF.Atan2(vertice.Y, vertice.X);
            float difference = Math.Abs(MathHelper.WrapAngle(sunAngle - angle)) / MathHelper.TwoPi;
            return difference * sunStrength;
        }
        public float CalculateLight(Vector2 vertice, Vector2 lightPos, float sunStrength = 1f)
        {
            float angle = MathF.Atan2(vertice.Y, vertice.X);
            float lightAngle = MathF.Atan2(Origin.Y - lightPos.Y, Origin.X - lightPos.X);
            float difference = Math.Abs(MathHelper.WrapAngle(lightAngle - angle)) / MathHelper.TwoPi;
            return difference * sunStrength;
        }
        public float FindFurthestPoint()
        {
            float dist = 0, length;
            foreach (Vector3 vertice in OriginalVertices)
            {
                length = vertice.Length();
                if (length > dist)
                    dist = length;
            }
            return dist;
        }
        public Rectangle BoundingBox()
        {
            if (CurrentVertices.Count <= 0)
                return new Rectangle((int)Origin.X, (int)Origin.Y, 0, 0);

            float minX = CurrentVertices[0].X + Origin.X;
            float maxX = CurrentVertices[0].X + Origin.X;
            float minY = CurrentVertices[0].Y + Origin.Y;
            float maxY = CurrentVertices[0].Y + Origin.Y;

            foreach (Vector3 vertice in CurrentVertices)
            {
                if (minX > vertice.X + Origin.X) minX = vertice.X + Origin.X;
                if (maxX < vertice.X + Origin.X) maxX = vertice.X + Origin.X;
                if (minY > vertice.Y + Origin.Y) minY = vertice.Y + Origin.Y;
                if (maxY < vertice.Y + Origin.Y) maxY = vertice.Y + Origin.Y;
            }

            return new Rectangle((int)minX, (int)minY, (int)(maxX - minX), (int)(maxY - minY));
        }
        public bool Intersects(Polygon polygon)
        {
            foreach (Vector3 vertice in polygon.CurrentVertices)
            {
                if (PointIntersects(new Vector2(
                    vertice.X + polygon.Origin.X,
                    vertice.Y + polygon.Origin.Y)))
                    return true;
            }

            return false;
        }
        public bool Intersects(Rectangle rectangle)
        {
            for (int y = 0; y < 2; y++)
                for (int x = 0; x < 2; x++)
                    if (PointIntersects(new Vector2(rectangle.Location.X + (rectangle.Width * x), rectangle.Location.Y + (rectangle.Height * y))))
                        return true;

            return false;
        }
        public bool PointIntersects(Vector2 testPoint)
        {
            //Check if a triangle or higher n-gon
            if (CurrentVertices.Count < 3)
                return false;

            //n>2 Keep track of cross product sign changes
            var pos = 0;
            var neg = 0;

            for (var i = 0; i < CurrentVertices.Count; i++)
            {
                //If point is in the polygon
                if (new Vector2(CurrentVertices[i].X + Origin.X, CurrentVertices[i].Y + Origin.Y) == testPoint)
                    return true;

                //Form a segment between the i'th point
                var x1 = CurrentVertices[i].X + Origin.X;
                var y1 = CurrentVertices[i].Y + Origin.Y;

                //And the i+1'th, or if i is the last, with the first point
                var i2 = (i + 1) % CurrentVertices.Count;

                var x2 = CurrentVertices[i2].X + Origin.X;
                var y2 = CurrentVertices[i2].Y + Origin.Y;

                var x = testPoint.X;
                var y = testPoint.Y;

                //Compute the cross product
                var d = (x - x1) * (y2 - y1) - (y - y1) * (x2 - x1);

                if (d > 0) pos++;
                if (d < 0) neg++;

                if (pos > 0 && neg > 0)
                    return false;
            }

            return true;
        }
        public void ResetVertices()
        {
            SetScale(1f);
            SetRotation(0f, 0f, 0f);
            CurrentVertices = OriginalVertices;
        }
    }
}