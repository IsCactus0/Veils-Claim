using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using VeilsClaim.Classes.Utilities;

namespace VeilsClaim.Classes.Objects.Entities
{
    public class Asteroid : Entity
    {
        public Asteroid()
            : base()
        {
        }

        public float Radius;

        public override List<Vector2> CreateShape()
        {
            return Drawing.Circle(Radius, 12);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}