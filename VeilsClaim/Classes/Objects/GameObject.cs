using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using VeilsClaim.Classes.Utilities;

namespace VeilsClaim.Classes.Objects
{
    public abstract class GameObject
    {
        public GameObject(GameObject copy)
        {
            Position = new Vector2(copy.Position.X, copy.Position.Y);
            Velocity = new Vector2(copy.Velocity.X, copy.Velocity.Y);
            Acceloration = new Vector2(copy.Acceloration.X, copy.Acceloration.Y);
            Force = new Vector2(copy.Force.X, copy.Force.Y);
            Rotation = copy.Rotation;
            RotationalVelocity = copy.RotationalVelocity;
            RotationalAcceloration = copy.RotationalAcceloration;
            Mass = copy.Mass;
            Friction = copy.Friction;
            Hitbox = new Rectangle(0, 0, copy.Hitbox.Width, copy.Hitbox.Height);
            Polygon = new Polygon(Vector3.Zero, copy.Polygon.OriginalVertices);
        }
        public GameObject()
        {
            Position = Vector2.Zero;
            Velocity = Vector2.Zero;
            Acceloration = Vector2.Zero;
            Force = Vector2.Zero;
            Rotation = 0f;
            RotationalVelocity = 0f;
            RotationalAcceloration = 0f;
            Mass = 1f;
            Friction = 0.1f;
            Hitbox = new Rectangle();
            Polygon = new Polygon(Vector3.Zero, CreateShape());
        }
        public GameObject(float x, float y)
        {
            Position = new Vector2(x, y);
            Velocity = Vector2.Zero;
            Acceloration = Vector2.Zero;
            Force = Vector2.Zero;
            Rotation = 0f;
            RotationalVelocity = 0f;
            RotationalAcceloration = 0f;
            Mass = 1f;
            Friction = 0.1f;
            Hitbox = new Rectangle();
            Polygon = new Polygon(Vector3.Zero, CreateShape());
        }
        public GameObject(float x, float y, float vx, float vy)
        {
            Position = new Vector2(x, y);
            Velocity = new Vector2(vx, vy);
            Acceloration = Vector2.Zero;
            Force = Vector2.Zero;
            Rotation = 0f;
            RotationalVelocity = 0f;
            RotationalAcceloration = 0f;
            Mass = 1f;
            Friction = 0.1f;
            Hitbox = new Rectangle();
            Polygon = new Polygon(Vector3.Zero, CreateShape());
        }
        public GameObject(float x, float y, float vx, float vy, float ax, float ay)
        {
            Position = new Vector2(x, y);
            Velocity = new Vector2(vx, vy);
            Acceloration = new Vector2(ax, ay);
            Force = Vector2.Zero;
            Rotation = 0f;
            RotationalVelocity = 0f;
            RotationalAcceloration = 0f;
            Mass = 1f;
            Friction = 0.1f;
            Hitbox = new Rectangle();
            Polygon = new Polygon(Vector3.Zero, CreateShape());
        }
        public GameObject(float x, float y, float vx, float vy, float ax, float ay, float r)
        {
            Position = new Vector2(x, y);
            Velocity = new Vector2(vx, vy);
            Acceloration = new Vector2(ax, ay);
            Force = Vector2.Zero;
            Rotation = r;
            RotationalVelocity = 0f;
            RotationalAcceloration = 0f;
            Mass = 1f;
            Friction = 0.1f;
            Hitbox = new Rectangle();
            Polygon = new Polygon(Vector3.Zero, CreateShape());
        }
        public GameObject(float x, float y, float vx, float vy, float ax, float ay, float r, float vr)
        {
            Position = new Vector2(x, y);
            Velocity = new Vector2(vx, vy);
            Acceloration = new Vector2(ax, ay);
            Force = Vector2.Zero;
            Rotation = r;
            RotationalVelocity = vr;
            RotationalAcceloration = 0f;
            Mass = 1f;
            Friction = 0.1f;
            Hitbox = new Rectangle();
            Polygon = new Polygon(Vector3.Zero, CreateShape());
        }
        public GameObject(float x, float y, float vx, float vy, float ax, float ay, float r, float vr, float ar)
        {
            Position = new Vector2(x, y);
            Velocity = new Vector2(vx, vy);
            Acceloration = new Vector2(ax, ay);
            Force = Vector2.Zero;
            Rotation = r;
            RotationalVelocity = vr;
            RotationalAcceloration = ar;
            Mass = 1f;
            Friction = 0.1f;
            Hitbox = new Rectangle();
            Polygon = new Polygon(Vector3.Zero, CreateShape());
        }
        public GameObject(float x, float y, float vx, float vy, float ax, float ay, float r, float vr, float ar, float mass)
        {
            Position = new Vector2(x, y);
            Velocity = new Vector2(vx, vy);
            Acceloration = new Vector2(ax, ay);
            Force = Vector2.Zero;
            Rotation = r;
            RotationalVelocity = vr;
            RotationalAcceloration = ar;
            Mass = mass;
            Friction = 0.1f;
            Hitbox = new Rectangle();
            Polygon = new Polygon(Vector3.Zero, CreateShape());
        }
        public GameObject(float x, float y, float vx, float vy, float ax, float ay, float r, float vr, float ar, float mass, float friction)
        {
            Position = new Vector2(x, y);
            Velocity = new Vector2(vx, vy);
            Acceloration = new Vector2(ax, ay);
            Force = Vector2.Zero;
            Rotation = r;
            RotationalVelocity = vr;
            RotationalAcceloration = ar;
            Mass = mass;
            Friction = friction;
            Hitbox = new Rectangle();
            Polygon = new Polygon(Vector3.Zero, CreateShape());
        }
        public GameObject(float x, float y, float vx, float vy, float ax, float ay, float r, float vr, float ar, float mass, float friction, Rectangle hitbox)
        {
            Position = new Vector2(x, y);
            Velocity = new Vector2(vx, vy);
            Acceloration = new Vector2(ax, ay);
            Force = Vector2.Zero;
            Rotation = r;
            RotationalVelocity = vr;
            RotationalAcceloration = ar;
            Mass = mass;
            Friction = friction;
            Hitbox = hitbox;
            Polygon = new Polygon(Vector3.Zero, CreateShape());
        }

        public Vector2 Position;
        public Vector2 Velocity;
        public Vector2 Acceloration;
        public Vector2 Force;
        public float Rotation;
        public float RotationalVelocity;
        public float RotationalAcceloration;
        public float RotationalForce;
        public float Mass;
        public float Friction;
        public Polygon Polygon;

        private Rectangle _hitbox;
        public Rectangle Hitbox
        {
            get
            {
                return new Rectangle(
                    (int)(Position.X + _hitbox.X),
                    (int)(Position.Y + _hitbox.Y),
                    _hitbox.Width,
                    _hitbox.Height);
            }
            set
            {
                _hitbox = value;
            }
        }

        public abstract void Destroy();
        public virtual void CheckCollisions()
        {
            if (!Hitbox.Intersects(Main.Camera.RenderBoundingBox))
                Destroy();
        }
        public virtual List<Vector2> CreateShape()
        {
            return Drawing.Circle(32, 16);
        }
        protected virtual bool WithinBounds()
        {
            return Main.Camera.RenderBoundingBox.Intersects(Polygon.BoundingBox());
        }
        public virtual void Update(float delta)
        {
            RotationalAcceloration = RotationalForce / Mass;
            RotationalVelocity += RotationalAcceloration * delta;
            RotationalVelocity *= (float)Math.Pow(Friction, delta);
            if (Math.Abs(RotationalVelocity) < 0.01f)
                RotationalVelocity = 0f;
            Rotation += RotationalVelocity * delta;

            Acceloration = Force / Mass;
            Velocity += Acceloration * delta;
            Velocity *= (float)Math.Pow(Friction, delta);
            if (Velocity.Length() < 0.01f)
                Velocity = Vector2.Zero;
            Position += Velocity * delta;

            Polygon.Origin = new Vector3(Position.X, Position.Y, 0f);
            Polygon.Yaw = Rotation;
            Polygon.ApplyTransforms();

            RotationalForce = 0f;
            Force = Vector2.Zero;

            CheckCollisions();
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Polygon.Draw(spriteBatch, Color.White, 1f);
        }
        public virtual void ClearForces()
        {
            Force = Vector2.Zero;
            Acceloration = Vector2.Zero;
            Velocity = Vector2.Zero;

            RotationalForce = 0f;
            RotationalAcceloration = 0f;
            RotationalVelocity = 0f;
        }
        public virtual GameObject Clone()
        {
            return (GameObject)MemberwiseClone();
        }
    }
}