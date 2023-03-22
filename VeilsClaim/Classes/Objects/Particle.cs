using Microsoft.Xna.Framework;
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
            Colour = Color.White;
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
            if (TimeAlive >= MaxLifespan)
                Destroy();
            if (Size < EndSize)
                Size = MathHelper.Lerp(EndSize, StartSize, (MaxLifespan - TimeAlive) / MaxLifespan);
            
            base.Update(delta);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            Texture2D texture = AssetManager.LoadTexture("blur");

            spriteBatch.Draw(
                texture,
                new Rectangle(
                    (int)(Position.X - (Size / 2f)),
                    (int)(Position.Y - (Size / 2f)),
                    (int)Size, (int)Size),
                texture.Bounds,
                Colour * Fade(),
                Rotation, new Vector2(0.5f), SpriteEffects.None, 0f);
        }
        public virtual float Fade()
        {
            return 1f - (TimeAlive / MaxLifespan);
        }
    }
}