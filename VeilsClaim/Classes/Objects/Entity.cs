using Microsoft.Xna.Framework;
using System.Security.Cryptography;
using VeilsClaim.Classes.Managers;

namespace VeilsClaim.Classes.Objects
{
    public class Entity : GameObject
    {
        public Entity()
            : base()
        {
            Health = 100;
        }

        public float Health;
        public float TimeAlive;
        public bool Gravity;

        public override void Destroy()
        {
            EntityManager.entities.Remove(this);
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