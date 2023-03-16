using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace VeilsClaim.Classes.Objects.Particles
{
    internal class FadeParticle : Particle
    {
        public Color StartColour;
        public Color EndColour;
        public float ColourScaleMult;

        public override void Update(float delta)
        {
            Colour = Color.Lerp(StartColour, EndColour,
                Math.Clamp(TimeAlive * ColourScaleMult, 0f, 1f));

            base.Update(delta);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
