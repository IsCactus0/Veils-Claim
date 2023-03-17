using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace VeilsClaim.Classes.Objects.Particles
{
    internal class SmokeParticle : FadeParticle
    {
        public SmokeParticle()
        {

        }

        public override void Update(float delta)
        {
            this.Force += new Vector2(0, -300f);

            base.Update(delta);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}