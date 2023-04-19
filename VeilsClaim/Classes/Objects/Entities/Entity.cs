using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using VeilsClaim.Classes.Managers;
using VeilsClaim.Classes.Objects.Effects;

namespace VeilsClaim.Classes.Objects.Entities
{
    public abstract class Entity : GameObject
    {
        public Entity(Entity copy)
            : base(copy)
        {
            Health = copy.Health;
            TimeAlive = copy.TimeAlive;
            TeamIndex = copy.TeamIndex;
            Effects = new List<EntityEffect>(copy.Effects);
        }
        public Entity()
            : base()
        {
            Health = 100;
            TimeAlive = 0f;
            TeamIndex = 1;
            Effects = new List<EntityEffect>();
        }
        public Entity(float x, float y)
            : base(x, y)
        {
            Health = 100;
            TimeAlive = 0f;
            TeamIndex = 1;
            Effects = new List<EntityEffect>();
        }
        public Entity(float x, float y, float vx, float vy)
            : base(x, y, vx, vy)
        {
            Health = 100;
            TimeAlive = 0f;
            TeamIndex = 1;
            Effects = new List<EntityEffect>();
        }
        public Entity(float x, float y, float vx, float vy, float ax, float ay)
            : base(x, y, vx, vy, ax, ay)
        {
            Health = 100;
            TimeAlive = 0f;
            TeamIndex = 1;
            Effects = new List<EntityEffect>();
        }
        public Entity(float x, float y, float vx, float vy, float ax, float ay, float r)
            : base(x, y, vx, vy, ax, ay, r)
        {
            Health = 100;
            TimeAlive = 0f;
            TeamIndex = 1;
            Effects = new List<EntityEffect>();
        }
        public Entity(float x, float y, float vx, float vy, float ax, float ay, float r, float vr)
            : base(x, y, vx, vy, ax, ay, r, vr)
        {
            Health = 100;
            TimeAlive = 0f;
            TeamIndex = 1;
            Effects = new List<EntityEffect>();
        }
        public Entity(float x, float y, float vx, float vy, float ax, float ay, float r, float vr, float ar)
            : base(x, y, vx, vy, ax, ay, r, vr, ar)
        {
            Health = 100;
            TimeAlive = 0f;
            TeamIndex = 1;
            Effects = new List<EntityEffect>();
        }
        public Entity(float x, float y, float vx, float vy, float ax, float ay, float r, float vr, float ar, float mass)
            : base(x, y, vx, vy, ax, ay, r, vr, ar, mass)
        {
            Health = 100;
            TimeAlive = 0f;
            TeamIndex = 1;
            Effects = new List<EntityEffect>();
        }
        public Entity(float x, float y, float vx, float vy, float ax, float ay, float r, float vr, float ar, float mass, float friction)
            : base(x, y, vx, vy, ax, ay, r, vr, ar, mass, friction)
        {
            Health = 100;
            TimeAlive = 0f;
            TeamIndex = 1;
            Effects = new List<EntityEffect>();
        }
        public Entity(float x, float y, float vx, float vy, float ax, float ay, float r, float vr, float ar, float mass, float friction, float health)
            : base(x, y, vx, vy, ax, ay, r, vr, ar, mass, friction)
        {
            Health = health;
            TimeAlive = 0f;
            TeamIndex = 1;
            Effects = new List<EntityEffect>();
        }
        public Entity(float x, float y, float vx, float vy, float ax, float ay, float r, float vr, float ar, float mass, float friction, float health, int teamIndex)
            : base(x, y, vx, vy, ax, ay, r, vr, ar, mass, friction)
        {
            Health = health;
            TimeAlive = 0f;
            TeamIndex = teamIndex;
            Effects = new List<EntityEffect>();
        }
        public Entity(float x, float y, float vx, float vy, float ax, float ay, float r, float vr, float ar, float mass, float friction, float health, int teamIndex, Rectangle hitbox)
            : base(x, y, vx, vy, ax, ay, r, vr, ar, mass, friction, hitbox)
        {
            Health = health;
            TimeAlive = 0f;
            TeamIndex = teamIndex;
            Effects = new List<EntityEffect>();
        }

        public float Health;
        public float TimeAlive;
        public int TeamIndex;
        public List<EntityEffect> Effects;

        public virtual void Damage(int damage)
        {
            Health -= damage;
        }
        public override void Destroy()
        {
            Position.X -= Main.PhysicsDistance;
            EntityManager.entities.Remove(this);
        }
        public override void Update(float delta)
        {
            TimeAlive += delta;
            if (Health <= 0f)
                Destroy();

            foreach (EntityEffect effect in Effects)
                effect.Update(delta, this);

            base.Update(delta);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            foreach (EntityEffect effect in Effects)
                effect.Draw(spriteBatch, this);
        }
        public override GameObject Clone()
        {
            return (Entity)MemberwiseClone();
        }
    }
}