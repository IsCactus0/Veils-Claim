using Microsoft.Xna.Framework;
using System.Collections.Generic;
using VeilsClaim.Classes.Managers;
using VeilsClaim.Classes.Objects.Entities;
using VeilsClaim.Classes.Utilities;

namespace VeilsClaim.Classes.Objects.Projectiles
{
    public abstract class Projectile : Entity
    {
        public Projectile(Projectile copy)
            : base(copy)
        {
            Penetration = copy.Penetration;
            MinDamage = copy.MinDamage;
            MaxDamage = copy.MaxDamage;
            CritChance = copy.CritChance;
            CritMultiplier = copy.CritMultiplier;
        }
        public Projectile()
        {
            Penetration = 1;
            MinDamage = 1;
            MaxDamage = 2;
            CritChance = 0.1f;
            CritMultiplier = 2f;
        }
        public Projectile(float x, float y)
            : base(x, y)
        {
            Penetration = 1;
            MinDamage = 1;
            MaxDamage = 2;
            CritChance = 0.1f;
            CritMultiplier = 2f;
        }
        public Projectile(float x, float y, float vx, float vy)
            : base(x, y, vx, vy)
        {
            Penetration = 1;
            MinDamage = 1;
            MaxDamage = 2;
            CritChance = 0.1f;
            CritMultiplier = 2f;
        }
        public Projectile(float x, float y, float vx, float vy, float ax, float ay)
            : base(x, y, vx, vy, ax, ay)
        {
            Penetration = 1;
            MinDamage = 1;
            MaxDamage = 2;
            CritChance = 0.1f;
            CritMultiplier = 2f;
        }
        public Projectile(float x, float y, float vx, float vy, float ax, float ay, float r)
            : base(x, y, vx, vy, ax, ay, r)
        {
            Penetration = 1;
            MinDamage = 1;
            MaxDamage = 2;
            CritChance = 0.1f;
            CritMultiplier = 2f;
        }
        public Projectile(float x, float y, float vx, float vy, float ax, float ay, float r, float vr)
            : base(x, y, vx, vy, ax, ay, r, vr)
        {
            Penetration = 1;
            MinDamage = 1;
            MaxDamage = 2;
            CritChance = 0.1f;
            CritMultiplier = 2f;
        }
        public Projectile(float x, float y, float vx, float vy, float ax, float ay, float r, float vr, float ar)
            : base(x, y, vx, vy, ax, ay, r, vr, ar)
        {
            Penetration = 1;
            MinDamage = 1;
            MaxDamage = 2;
            CritChance = 0.1f;
            CritMultiplier = 2f;
        }
        public Projectile(float x, float y, float vx, float vy, float ax, float ay, float r, float vr, float ar, float mass)
            : base(x, y, vx, vy, ax, ay, r, vr, ar, mass)
        {
            Penetration = 1;
            MinDamage = 1;
            MaxDamage = 2;
            CritChance = 0.1f;
            CritMultiplier = 2f;
        }
        public Projectile(float x, float y, float vx, float vy, float ax, float ay, float r, float vr, float ar, float mass, float friction)
            : base(x, y, vx, vy, ax, ay, r, vr, ar, mass, friction)
        {
            Penetration = 1;
            MinDamage = 1;
            MaxDamage = 2;
            CritChance = 0.1f;
            CritMultiplier = 2f;
        }
        public Projectile(float x, float y, float vx, float vy, float ax, float ay, float r, float vr, float ar, float mass, float friction, float health)
            : base(x, y, vx, vy, ax, ay, r, vr, ar, mass, friction, health)
        {
            Penetration = 1;
            MinDamage = 1;
            MaxDamage = 2;
            CritChance = 0.1f;
            CritMultiplier = 2f;
        }
        public Projectile(float x, float y, float vx, float vy, float ax, float ay, float r, float vr, float ar, float mass, float friction, float health, int teamIndex)
            : base(x, y, vx, vy, ax, ay, r, vr, ar, mass, friction, health, teamIndex)
        {
            Penetration = 1;
            MinDamage = 1;
            MaxDamage = 2;
            CritChance = 0.1f;
            CritMultiplier = 2f;
        }
        public Projectile(float x, float y, float vx, float vy, float ax, float ay, float r, float vr, float ar, float mass, float friction, float health, int teamIndex, Rectangle hitbox)
            : base(x, y, vx, vy, ax, ay, r, vr, ar, mass, friction, health, teamIndex, hitbox)
        {
            Penetration = 1;
            MinDamage = 1;
            MaxDamage = 2;
            CritChance = 0.1f;
            CritMultiplier = 2f;
        }
        public Projectile(float x, float y, float vx, float vy, float ax, float ay, float r, float vr, float ar, float mass, float friction, float health, int teamIndex, Rectangle hitbox, int penetration)
            : base(x, y, vx, vy, ax, ay, r, vr, ar, mass, friction, health, teamIndex, hitbox)
        {
            Penetration = penetration;
            MinDamage = 1;
            MaxDamage = 2;
            CritChance = 0.1f;
            CritMultiplier = 2f;
        }
        public Projectile(float x, float y, float vx, float vy, float ax, float ay, float r, float vr, float ar, float mass, float friction, float health, int teamIndex, Rectangle hitbox, int penetration, int damage)
            : base(x, y, vx, vy, ax, ay, r, vr, ar, mass, friction, health, teamIndex, hitbox)
        {
            Penetration = penetration;
            MinDamage = damage;
            MaxDamage = damage;
            CritChance = 0.1f;
            CritMultiplier = 2f;
        }
        public Projectile(float x, float y, float vx, float vy, float ax, float ay, float r, float vr, float ar, float mass, float friction, float health, int teamIndex, Rectangle hitbox, int penetration, int minDamage, int maxDamage)
            : base(x, y, vx, vy, ax, ay, r, vr, ar, mass, friction, health, teamIndex, hitbox)
        {
            Penetration = penetration;
            MinDamage = minDamage;
            MaxDamage = maxDamage;
            CritChance = 0.1f;
            CritMultiplier = 2f;
        }
        public Projectile(float x, float y, float vx, float vy, float ax, float ay, float r, float vr, float ar, float mass, float friction, float health, int teamIndex, Rectangle hitbox, int penetration, int minDamage, int maxDamage, float critChance)
            : base(x, y, vx, vy, ax, ay, r, vr, ar, mass, friction, health, teamIndex, hitbox)
        {
            Penetration = penetration;
            MinDamage = minDamage;
            MaxDamage = maxDamage;
            CritChance = critChance;
            CritMultiplier = 2f;
        }
        public Projectile(float x, float y, float vx, float vy, float ax, float ay, float r, float vr, float ar, float mass, float friction, float health, int teamIndex, Rectangle hitbox, int penetration, int minDamage, int maxDamage, float critChance, int critMultiplier)
            : base(x, y, vx, vy, ax, ay, r, vr, ar, mass, friction, health, teamIndex, hitbox)
        {
            Penetration = penetration;
            MinDamage = minDamage;
            MaxDamage = maxDamage;
            CritChance = critChance;
            CritMultiplier = critMultiplier;
        }

        public int Penetration;
        public int MinDamage;
        public int MaxDamage;
        public float CritChance;
        public float CritMultiplier;

        public override List<Vector2> CreateShape()
        {
            return Drawing.Circle(3, 8);
        }
        public override void Destroy()
        {
            Position.X -= Main.PhysicsDistance * 2;
            ProjectileManager.projectiles.Remove(this);
        }
        public override void CheckCollisions()
        {
            // List<Entity> entities = EntityManager.FindAll(Hitbox);
            // entities.Remove(this);
            // foreach (Entity entity in entities)
            // {
            //     if (entity.TeamIndex == TeamIndex)
            //         continue;
            // 
            //     float damage = Main.Random.Next(MinDamage, MaxDamage);
            //     if (Main.Random.NextSingle() < CritChance)
            //         damage *= CritMultiplier;
            // 
            //     entity.Damage((int)damage);
            //     if (--Penetration <= 0)
            //     {
            //         Destroy();
            //         break;
            //     }
            // }

            base.CheckCollisions();
        }
        public override Projectile Clone()
        {
            return (Projectile)MemberwiseClone();
        }
    }
}