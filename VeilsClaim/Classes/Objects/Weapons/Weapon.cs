using Microsoft.Xna.Framework;
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
            ShotCount = new Point(1);
            FireMode = FireMode.Automatic;
        }

        public GameObject parent;
        public int Loaded;
        public int Capacity;
        public float FireRate;
        public float ReloadTime;
        public float MuzzleVelocity;
        public float Spread;
        public Projectile Projectile;
        public Point ShotCount;
        public FireMode FireMode;

        protected float lastFired;
        protected float lastReloaded;

        public virtual void Fire(GameObject parent)
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
            }
        }
        public virtual void Reload()
        {
            if (lastReloaded < ReloadTime)
                return;

            lastReloaded = 0;
            Loaded = Capacity;
        }
        public virtual void CreateProjectile(GameObject parent)
        {
            Vector2 force = MathAdditions.VectorFromAngle(parent.Rotation) * MuzzleVelocity;
            
            Projectile copy = Projectile.Clone();
            copy.Position = parent.Position;
            copy.Velocity = parent.Velocity + force;
            ProjectileManager.projectiles.Add(copy);
            
            parent.Force -= force;
            CreateFireEffects(parent);
        }
        public abstract void CreateFireEffects(GameObject parent);
        public virtual void Update(float delta)
        {
            lastFired += delta;
            lastReloaded += delta;
        }
    }
}