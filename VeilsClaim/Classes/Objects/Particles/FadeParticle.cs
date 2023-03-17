using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace VeilsClaim.Classes.Objects.Particles
{
    internal class FadeParticle : Particle
    {
        public FadeParticle() : base()
        {
            StartColour = Color.White;
            EndColour = Color.Transparent;
        }
        public FadeParticle(Color colour)
            : base(colour)
        {
            StartColour = colour;
            EndColour = Color.Transparent;
        }
        public FadeParticle(Color startColour, Color endColour)
            : base(startColour)
        {
            StartColour = startColour;
            EndColour = endColour;
        }
        public FadeParticle(Color startColour, Color endColour, float size)
            : base(startColour, size)
        {
            StartColour = startColour;
            EndColour = endColour;
        }
        public FadeParticle(Color startColour, Color endColour, float startSize, float endSize)
            : base(startColour, startSize, endSize)
        {
            StartColour = startColour;
            EndColour = endColour;
        }

        public Color StartColour;
        public Color EndColour;

        public override void Update(float delta)
        {
            Colour = Color.Lerp(EndColour, StartColour, (MaxLifespan - TimeAlive) / MaxLifespan);

            base.Update(delta);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
