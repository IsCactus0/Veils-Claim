using Microsoft.Xna.Framework.Graphics;

namespace VeilsClaim.Classes.Objects
{
    public abstract class Constraint
    {
        public bool Visible;
        public GameObject Anchor;

        public abstract void Update(GameObject connected, float delta);
        public virtual void Draw(SpriteBatch spriteBatch, GameObject connected)
        {
            if (!Visible) return;
        }
    }
}