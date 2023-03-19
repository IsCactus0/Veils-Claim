using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using VeilsClaim.Classes.Managers;

namespace VeilsClaim.Classes.Objects
{
    public abstract class GameObject
    {
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
        }

        public Vector2 Position;
        public Vector2 Velocity;
        public Vector2 Acceloration;
        public Vector2 Force;
        public float Rotation;
        public float RotationalVelocity;
        public float RotationalAcceloration;
        public float Mass;
        public float Friction;

        public abstract void Destroy();
        public virtual void Update(float delta)
        {
            RotationalVelocity += RotationalAcceloration * delta;
            RotationalVelocity *= (float)Math.Pow(Friction, delta);
            Rotation += RotationalVelocity * delta;

            Acceloration = Force / Mass;
            Velocity += Acceloration * delta;
            Velocity *= (float)Math.Pow(Friction, delta);
            if (Velocity.Length() < 0.01f)
                Velocity *= 0;
            Position += Velocity * delta;
            
            Force = Vector2.Zero;
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                AssetManager.LoadTexture("empty"),
                new Rectangle(
                    (int)Position.X, (int)Position.Y, 50, 50),
                new Rectangle(),
                Color.White,
                Rotation, new Vector2(0.5f), SpriteEffects.None, 0f);
        }
    }
}