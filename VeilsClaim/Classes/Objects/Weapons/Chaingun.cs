using Microsoft.Xna.Framework;
using System;
using VeilsClaim.Classes.Enums;
using VeilsClaim.Classes.Managers;
using VeilsClaim.Classes.Objects.Entities;
using VeilsClaim.Classes.Objects.Entities.Weapons;
using VeilsClaim.Classes.Objects.Particles;
using VeilsClaim.Classes.Objects.Projectiles;

namespace VeilsClaim.Classes.Objects.Weapons
{
    public class Chaingun : Weapon
    {
        public Chaingun()
            : base()
        {
            Loaded = 256;
            Capacity = 256;
            FireRate = 0.2f;
            ReloadTime = 1f;
            MuzzleVelocity = 750f;
            Spread = 0.03f;
            Projectile = new Bolt();
            ShotCount = new Point(1);
            FireMode = FireMode.Automatic;
        }

        public override void Fire(Entity parent)
        {
            base.Fire(parent);
        }
        public override void Reload()
        {
            base.Reload();
        }
        public override void CreateProjectile(Entity parent)
        {
            base.CreateProjectile(parent);
        }
        public override void CreateFireEffects(Entity parent)
        {
            for (int i = 0; i < Main.Random.Next(8, 16); i++)
            {
                float rotation = (Main.Random.NextSingle() - 0.5f);
                ParticleManager.particles.Add(new SparkParticle()
                {
                    Position = parent.Position + Vector2.Transform(Barrels[barrelIndex], Matrix.CreateRotationZ(parent.Rotation)),
                    Velocity = new Vector2(MathF.Cos(parent.Rotation + rotation), MathF.Sin(parent.Rotation + rotation)) * Main.Random.Next(100, 300),
                    Size = 15f,
                    StartSize = 15f,
                    EndSize = 5f,
                    Colour = Color.LightSkyBlue,
                    StartColour = Color.LightSkyBlue,
                    EndColour = Color.RoyalBlue,
                    Friction = 0.1f,
                    Mass = 0.005f,
                    WindStrength = 2f,
                    MaxLifespan = 0.15f + Main.Random.NextSingle() / 5f,
                });
            }
        }
    }
}