using Microsoft.Xna.Framework;
using System.Collections.Generic;
using VeilsClaim.Classes.Enums;
using VeilsClaim.Classes.Managers;
using VeilsClaim.Classes.Objects.Projectiles;
using VeilsClaim.Classes.Utilities;

namespace VeilsClaim.Classes.Objects.Entities.Weapons
{
    public abstract class Weapon
    {
        public Weapon()
            : base()
        {
            Loaded = 16;
            Capacity = 16;
            FireRate = 0.5f;
            ReloadTime = 1f;
            MuzzleVelocity = 2000f;
            Spread = 0.1f;
            Projectile = new Bullet();
            Barrels = new List<Vector2>()
            {
                new Vector2(0, 3),
                new Vector2(0, -3)
            };
            ShotCount = new Point(1);
            FireMode = FireMode.Automatic;
        }

        public GameObject parent;
        public int Loaded;
        public int Capacity;
        public float FireRate;
        public float ReloadTime;
        public float MuzzleVelocity;
        /// <summary>
        /// Randomised projectile spread (in radians).
        /// </summary>
        public float Spread;
        public Projectile Projectile;
        public List<Vector2> Barrels;
        public Point ShotCount;
        public FireMode FireMode;

        protected int barrelIndex;
        protected float lastFired;
        protected float lastReloaded;

        public virtual void Fire(Entity parent)
        {
            if (lastFired < FireRate)
                return;

            lastFired = 0f;
            int count = Main.Random.Next(ShotCount.X, ShotCount.Y);
            if (Loaded >= count)
            {
                lastReloaded = 0f;
                Loaded -= count;
                for (int i = 0; i < count; i++)
                    CreateProjectile(parent);

                if (++barrelIndex >= Barrels.Count)
                    barrelIndex = 0;
            }
        }
        public virtual void Reload()
        {
            if (lastReloaded < ReloadTime)
                return;

            lastReloaded = 0;
            Loaded = Capacity;
        }
        public virtual void CreateProjectile(Entity parent)
        {
            Vector2 force = MathAdditions.VectorFromAngle(
                parent.Rotation + (Spread * ((Main.Random.NextSingle() - 0.5f) * 2f))) * MuzzleVelocity;

            Projectile.Position = parent.Position + Vector2.Transform(Barrels[barrelIndex], Matrix.CreateRotationZ(parent.Rotation));
            Projectile.Hitbox = new Rectangle(
                -(int)(Projectile.Position.X - Projectile.Hitbox.Width / 2f),
                -(int)(Projectile.Position.Y - Projectile.Hitbox.Height/ 2f), 6, 6);

            Projectile.Velocity = parent.Velocity + force / Projectile.Mass;
            Projectile.TeamIndex = parent.TeamIndex;

            Projectile copy = Projectile.Clone();
            ProjectileManager.projectiles.Add(copy);

            parent.Force += -force;
            CreateFireEffects(parent);
        }
        public abstract void CreateFireEffects(Entity parent);
        public virtual void Update(float delta)
        {
            lastFired += delta;
            lastReloaded += delta;
        }
    }
}