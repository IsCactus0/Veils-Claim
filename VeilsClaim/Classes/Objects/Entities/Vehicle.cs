using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using VeilsClaim.Classes.Managers;
using VeilsClaim.Classes.Objects.Entities.Weapons;
using VeilsClaim.Classes.Objects.Particles;

namespace VeilsClaim.Classes.Objects.Entities
{
    public class Vehicle : Entity
    {
        public Vehicle()
            : base()
        {
            Thrust = 0f;
            ThrustStrength = 25f;
        }

        public float Thrust;
        public float ThrustStrength;
        public int SelectedWeapon;
        public List<Weapon> Weapons;

        public override List<Vector2> CreateShape()
        {
            return new List<Vector2>()
            {
                new Vector2( 12.0f,  0.0f),
                new Vector2(-10.0f,  6.0f),
                new Vector2(-10.0f, -6.0f)
            };
        }
        public override void Update(float delta)
        {
            if (Weapons.Count > 0)
                Weapons[SelectedWeapon].Update(delta);

            if (Thrust != 0f)
            {
                Vector2 dir = new Vector2((float)Math.Cos(Rotation), (float)Math.Sin(Rotation));
                Force += dir * ThrustStrength * Thrust;

                ParticleManager.particles.Add(new SparkParticle()
                {
                    Position = Position - dir * 10f,
                    Force = -Force,
                    Size = 5f,
                    StartSize = 5f,
                    EndSize = 15f,
                    SparkSize = 5f,
                    SparkStartSize = 5f,
                    SparkEndSize = 2.5f,
                    Colour = Color.LightSkyBlue,
                    StartColour = Color.LightSkyBlue,
                    EndColour = Color.RoyalBlue,
                    SparkColour = Color.MintCream,
                    SparkStartColour = Color.MintCream,
                    SparkEndColour = Color.DeepSkyBlue,
                    Friction = 0.1f,
                    Mass = 0.01f,
                    WindStrength = 1f,
                    MaxLifespan = 0.25f + Main.Random.NextSingle() / 5f,
                });
            }

            Thrust = 0f;
            base.Update(delta);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}