using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using VeilsClaim.Classes.Managers;
using VeilsClaim.Classes.Objects.Entities.Weapons;
using VeilsClaim.Classes.Objects.Particles;
using VeilsClaim.Classes.Utilities;

namespace VeilsClaim.Classes.Objects.Entities
{
    public class Vehicle : Entity
    {
        public Vehicle()
            : base()
        {
            Thrust = 0f;
            ThrustStrength = 25f;
            Hitbox = new Rectangle(-5, -5, 10, 10);
        }

        public float Thrust;
        public float ThrustStrength;
        public int SelectedWeapon;
        public List<Weapon> Weapons;

        public override List<Vector2> CreateShape()
        {
            return Drawing.Ellipse(15, 8, 3);
        }
        public override void Update(float delta)
        {
            if (Weapons.Count > 0)
                Weapons[SelectedWeapon].Update(delta);

            if (Thrust != 0f)
            {
                Vector2 dir = new Vector2(MathF.Cos(Rotation), MathF.Sin(Rotation));
                Force += dir * ThrustStrength * Thrust;

                ParticleManager.particles.Add(new SparkParticle()
                {
                    Position = Position - dir * 5f,
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