using Microsoft.Xna.Framework.Graphics;
using VeilsClaim.Classes.Objects.Entities;

namespace VeilsClaim.Classes.Objects.Effects
{
    public abstract class EntityEffect
    {
        public float lastActivated;
        public float activationTime;

        public virtual void Update(float delta, Entity target)
        {
            lastActivated += delta;
            if (lastActivated > activationTime)
            {
                lastActivated = 0f;
                Activate(target);
            }
        }
        public abstract void Activate(Entity target);
        public abstract void Draw(SpriteBatch spriteBatch, Entity target);
    }
}