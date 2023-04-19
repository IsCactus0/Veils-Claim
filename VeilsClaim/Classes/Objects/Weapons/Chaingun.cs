using Microsoft.Xna.Framework;
using System;
using VeilsClaim.Classes.Enums;
using VeilsClaim.Classes.Managers;
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
            Loaded = 128;
            Capacity = 128;
            FireRate = 0.05f;
            ReloadTime = 1f;
            MuzzleVelocity = 500f;
            Spread = 0.1f;
            Projectile = new Bolt();
            ShotCount = new Point(1);
            FireMode = FireMode.Automatic;
        }

        public override void Fire(GameObject parent)
        {
            base.Fire(parent);
        }
        public override void Reload()
        {
            base.Reload();
        }
        public override void CreateProjectile(GameObject parent)
        {
            base.CreateProjectile(parent);
        }
        public override void CreateFireEffects(GameObject parent)
        {
            for (int i = 0; i < Main.Random.Next(8, 16); i++)
            {
                ParticleManager.particles.Add(
                    new SparkParticle()
                    {
                        Position = parent.Position,
                        Force = new Vector2((float)Math.Cos(parent.Rotation), (float)Math.Sin(parent.Rotation)) * MuzzleVelocity,
                    });
            }
        }
    }
}