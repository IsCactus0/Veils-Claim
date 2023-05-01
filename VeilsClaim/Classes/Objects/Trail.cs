using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using VeilsClaim.Classes.Utilities;

namespace VeilsClaim.Classes.Objects
{
    public class Trail
    {
        public Trail()
        {
            Joints = new List<Vector2>();
            for (int i = 0; i < 5; i++)
                Joints.Add(Vector2.Zero);

            SegmentLength = 10f;
            StartThickness = 5f;
            EndThickness = 2f;
            AllowShrinking = true;
            StartColour = Color.White;
            EndColour = Color.RoyalBlue;
        }
        public Trail(Vector2 position)
        {
            Joints = new List<Vector2>();
            for (int i = 0; i < 5; i++)
                Joints.Add(position);

            SegmentLength = 10f;
            StartThickness = 5f;
            EndThickness = 2f;
            AllowShrinking = true;
            StartColour = Color.White;
            EndColour = Color.RoyalBlue;
        }
        public Trail(Vector2 position, int segmentCount)
        {
            Joints = new List<Vector2>();
            for (int i = 0; i < segmentCount; i++)
                Joints.Add(position);

            SegmentLength = 10f;
            StartThickness = 5f;
            EndThickness = 2f;
            AllowShrinking = true;
            StartColour = Color.White;
            EndColour = Color.RoyalBlue;
        }
        public Trail(Vector2 position, int segmentCount, float length)
        {
            Joints = new List<Vector2>();
            for (int i = 0; i < segmentCount; i++)
                Joints.Add(position);

            SegmentLength = length;
            StartThickness = 5f;
            EndThickness = 2f;
            AllowShrinking = true;
            StartColour = Color.White;
            EndColour = Color.RoyalBlue;
        }
        public Trail(Vector2 position, int segmentCount, float length, float thickness)
        {
            Joints = new List<Vector2>();
            for (int i = 0; i < segmentCount; i++)
                Joints.Add(position);

            SegmentLength = length;
            StartThickness = thickness;
            EndThickness = thickness;
            AllowShrinking = true;
            StartColour = Color.White;
            EndColour = Color.RoyalBlue;
        }
        public Trail(Vector2 position, int segmentCount, float length, float startThickness, float endThickness)
        {
            Joints = new List<Vector2>();
            for (int i = 0; i < segmentCount; i++)
                Joints.Add(position);

            SegmentLength = length;
            StartThickness = startThickness;
            EndThickness = endThickness;
            AllowShrinking = true;
            StartColour = Color.White;
            EndColour = Color.RoyalBlue;
        }
        public Trail(Vector2 position, int segmentCount, float length, float startThickness, float endThickness, bool allowShrinking)
        {
            Joints = new List<Vector2>();
            for (int i = 0; i < segmentCount; i++)
                Joints.Add(position);

            SegmentLength = length;
            StartThickness = startThickness;
            EndThickness = endThickness;
            AllowShrinking = allowShrinking;
            StartColour = Color.White;
            EndColour = Color.RoyalBlue;
        }
        public Trail(Vector2 position, int segmentCount, float length, float startThickness, float endThickness, bool allowShrinking, Color colour)
        {
            Joints = new List<Vector2>();
            for (int i = 0; i < segmentCount; i++)
                Joints.Add(position);

            SegmentLength = length;
            StartThickness = startThickness;
            EndThickness = endThickness;
            AllowShrinking = allowShrinking;
            StartColour = colour;
            EndColour = colour;
        }
        public Trail(Vector2 position, int segmentCount, float length, float startThickness, float endThickness, bool allowShrinking, Color startColour, Color endColour)
        {
            Joints = new List<Vector2>();
            for (int i = 0; i < segmentCount; i++)
                Joints.Add(position);

            SegmentLength = length;
            StartThickness = startThickness;
            EndThickness = endThickness;
            AllowShrinking = allowShrinking;
            StartColour = startColour;
            EndColour = endColour;
        }

        public float SegmentLength;
        public float StartThickness;
        public float EndThickness;
        public bool AllowShrinking;
        public Color StartColour;
        public Color EndColour;
        public List<Vector2> Joints;

        public virtual void Follow(Vector2 target, float speed = 500f, float delta = 0f)
        {
            if (Joints.Count == 0)
                return;

            Vector2 toParent;
            float distance;
            if (target.X != Joints[0].X || target.Y != Joints[0].Y)
            {
                toParent = target - Joints[0];
                distance = toParent.Length();
                    
                if (Joints.Count > 0)
                    Joints[0] += toParent / (distance * delta) * speed;
            }

            if (Joints.Count < 2)
                return;

            for (int i = 1; i < Joints.Count; i++)
            {
                toParent = Joints[i - 1] - Joints[i];
                distance = toParent.Length();

                if (distance == 0 || (AllowShrinking && distance <= SegmentLength))
                    continue;

                float error = distance - SegmentLength;
                toParent /= distance;

                toParent *= error;
                Joints[i] += toParent;
            }
        }
        public virtual void Limit(Vector2 origin)
        {
            if (Joints.Count > 0)
                Joints[Joints.Count - 1] = origin;

            for (int i = Joints.Count - 2; i >= 0; i--)
            {
                Vector2 toChild = Joints[i + 1] - Joints[i];
                float distance = toChild.Length();

                if (distance == 0 || (AllowShrinking && distance <= SegmentLength))
                    continue;

                float error = distance - SegmentLength;
                toChild /= distance;
                toChild *= error;
                Joints[i] += toChild;
            }
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 1; i < Joints.Count; i++)
            {
                float thickness = MathAdditions.Map(i, 1, Joints.Count - 1, EndThickness, StartThickness);
                Color colour = Color.Lerp(EndColour, StartColour, (float)i / Joints.Count);
                Drawing.DrawLine(spriteBatch, Joints[i - 1], Joints[i], colour, thickness);
            }
        }
    }
}