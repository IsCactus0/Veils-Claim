using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace VeilsClaim.Classes.Objects.Particles
{
    public class DustParticle : FadeParticle
    {
        public DustParticle() : base()
        {
            WindStrength = 500f;
        }

        public float WindStrength;

        public override void Update(float delta)
        {
            float angle = (float)Main.simplexNoise.Evaluate(
                Position.X / 100f,
                Position.Y / 100f) * MathHelper.TwoPi;

            Force += new Vector2(
                (float)Math.Cos(angle), 
                (float)Math.Sin(angle)) * (WindStrength * (1f - TimeAlive / MaxLifespan));

            Force += new Vector2(0, (TimeAlive / MaxLifespan) * -100f);

            base.Update(delta);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}