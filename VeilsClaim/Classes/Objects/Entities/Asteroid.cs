using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using VeilsClaim.Classes.Managers;
using VeilsClaim.Classes.Utilities;

namespace VeilsClaim.Classes.Objects.Entities
{
    public class Asteroid : Entity
    {
        public Asteroid()
            : base()
        {
            Radius = 10f;
        }

        public float Radius;

        public override List<Vector2> CreateShape()
        {
            return Drawing.Asteroid(10f, 1f, 10f, 5, Position);
        }
        public override void Update(float delta)
        {
            base.Update(delta);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(AssetManager.LoadTexture("blur"), Position, Color.Red);

            base.Draw(spriteBatch);
        }
    }
}