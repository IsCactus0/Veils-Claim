﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using VeilsClaim.Classes.Managers;

namespace VeilsClaim.Classes.Objects
{
    public class Particle : Entity
    {
        public Particle()
            : base()
        {
            Colour = Color.Magenta;
            StartSize = 10f;
            EndSize = 10f;
            Size = StartSize;
        }
        public Particle(Color colour)
            : base()
        {
            Colour = colour;
            StartSize = 10f;
            EndSize = StartSize;
            Size = StartSize;
        }
        public Particle(Color colour, float size)
            : base()
        {
            Colour = colour;
            StartSize = size;
            EndSize = StartSize;
            Size = StartSize;
        }
        public Particle(Color colour, float startSize, float endSize)
            : base()
        {
            Colour = colour;
            StartSize = startSize;
            EndSize = endSize;
            Size = StartSize;
        }

        public Color Colour;
        public float StartSize;
        public float EndSize;
        public float Size;
        public float SizeScaleMult;
        public float MaxLifespan;

        public override void Destroy()
        {
            ParticleManager.particles.Remove(this);
        }
        public override void Update(float delta)
        {
            if (Size < EndSize)
                Size = MathHelper.Lerp(
                    StartSize, EndSize, 
                    Math.Clamp(TimeAlive * SizeScaleMult, 0f, 1f));   
            
            base.Update(delta);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                AssetManager.GetTexture("empty"),
                new Rectangle(
                    (int)(Position.X - (Size / 2f)),
                    (int)(Position.Y - (Size / 2f)),
                    (int)Size, (int)Size),
                new Rectangle(),
                Colour * ((Size - StartSize) / EndSize),
                Rotation, new Vector2(0.5f), SpriteEffects.None, 0f);
        }
    }
}