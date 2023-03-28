﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
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
            Hitbox = new Rectangle();
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
        public Rectangle Hitbox;

        public abstract void Destroy();
        public abstract void CalculateCollisions();
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
                Position,
                null,
                Color.White,
                Rotation, new Vector2(0.5f), 8f, SpriteEffects.None, 0f);
        }
    }
}