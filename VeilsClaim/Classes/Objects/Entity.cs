using Microsoft.Xna.Framework;
using System.Collections.Generic;
using VeilsClaim.Classes.Managers;

namespace VeilsClaim.Classes.Objects
{
    public class Entity : GameObject
    {
        public Entity()
            : base()
        {
            Gravity = true;
            Health = 100;
            TimeAlive = 0f;
            Hitbox = new Rectangle(0, 0, 16, 16);
        }
        public Entity(float x, float y)
            : base(x, y)
        {
            Gravity = true;
            Health = 100;
            TimeAlive = 0f;
            Hitbox = new Rectangle(0, 0, 16, 16);
        }
        public Entity(float x, float y, float vx, float vy)
            : base(x, y, vx, vy)
        {
            Gravity = true;
            Health = 100;
            TimeAlive = 0f;
            Hitbox = new Rectangle(0, 0, 16, 16);
        }
        public Entity(float x, float y, float vx, float vy, float ax, float ay)
            : base(x, y, vx, vy, ax, ay)
        {
            Gravity = true;
            Health = 100;
            TimeAlive = 0f;
            Hitbox = new Rectangle(0, 0, 16, 16);
        }
        public Entity(float x, float y, float vx, float vy, float ax, float ay, float r)
            : base(x, y, vx, vy, ax, ay, r)
        {
            Gravity = true;
            Health = 100;
            TimeAlive = 0f;
            Hitbox = new Rectangle(0, 0, 16, 16);
        }
        public Entity(float x, float y, float vx, float vy, float ax, float ay, float r, float vr)
            : base(x, y, vx, vy, ax, ay, r, vr)
        {
            Gravity = true;
            Health = 100;
            TimeAlive = 0f;
            Hitbox = new Rectangle(0, 0, 16, 16);
        }
        public Entity(float x, float y, float vx, float vy, float ax, float ay, float r, float vr, float ar)
            : base(x, y, vx, vy, ax, ay, r, vr, ar)
        {
            Gravity = true;
            Health = 100;
            TimeAlive = 0f;
            Hitbox = new Rectangle(0, 0, 16, 16);
        }
        public Entity(float x, float y, float vx, float vy, float ax, float ay, float r, float vr, float ar, float mass)
            : base(x, y, vx, vy, ax, ay, r, vr, ar, mass)
        {
            Gravity = true;
            Health = 100;
            TimeAlive = 0f;
            Hitbox = new Rectangle(0, 0, 16, 16);
        }
        public Entity(float x, float y, float vx, float vy, float ax, float ay, float r, float vr, float ar, float mass, float friction)
            : base(x, y, vx, vy, ax, ay, r, vr, ar, mass, friction)
        {
            Gravity = true;
            Health = 100;
            TimeAlive = 0f;
            Hitbox = new Rectangle(0, 0, 16, 16);
        }
        public Entity(float x, float y, float vx, float vy, float ax, float ay, float r, float vr, float ar, float mass, float friction, bool gravity)
            : base(x, y, vx, vy, ax, ay, r, vr, ar, mass, friction)
        {
            Gravity = gravity;
            Health = 100;
            TimeAlive = 0f;
            Hitbox = new Rectangle(0, 0, 16, 16);
        }
        public Entity(float x, float y, float vx, float vy, float ax, float ay, float r, float vr, float ar, float mass, float friction, bool gravity, float health)
            : base(x, y, vx, vy, ax, ay, r, vr, ar, mass, friction)
        {
            Gravity = gravity;
            Health = health;
            TimeAlive = 0f;
            Hitbox = new Rectangle(0, 0, 16, 16);
        }
        public Entity(float x, float y, float vx, float vy, float ax, float ay, float r, float vr, float ar, float mass, float friction, bool gravity, float health, Rectangle hitbox)
            : base(x, y, vx, vy, ax, ay, r, vr, ar, mass, friction)
        {
            Gravity = gravity;
            Health = health;
            TimeAlive = 0f;
            Hitbox = hitbox;
        }

        public bool Gravity;
        public float Health;
        public float TimeAlive;

        public override void Destroy()
        {
            EntityManager.entities.Remove(this);
        }
        public override void CalculateCollisions()
        {
            List<Entity> entities = EntityManager.FindAll(Hitbox);
            entities.Remove(this);

            foreach (Entity entity in entities)
            {
                // TODO
                // if (this.Hitbox.Intersects(entity.Hitbox))
            }
            
        }
        public override void Update(float delta)
        {
            TimeAlive += delta;

            if (Gravity)
                Force += new Vector2(0, Main.gravityStrength * Mass);
            if (Health <= 0f)
                Destroy();

            base.Update(delta);
        }
    }
}