﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace VeilsClaim.Classes.Objects.Particles
{
    public class DustParticle : FadeParticle
    {
        public DustParticle()
            : base()
        {
            WindStrength = 500f;
        }

        public float WindStrength;

        public override void Update(float delta)
        {
            float angle = (float)Main.SimplexNoise.Evaluate(
                Position.X / 100f + Main.NoiseOffset,
                Position.Y / 100f + Main.NoiseOffset) * MathHelper.TwoPi;

            Force += new Vector2(
                MathF.Cos(angle), 
                MathF.Sin(angle)) * (WindStrength * (1f - TimeAlive / MaxLifespan));

            base.Update(delta);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}