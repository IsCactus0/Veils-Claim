using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using VeilsClaim.Classes.Managers;

namespace VeilsClaim.Classes.Objects.Particles
{
    public class SparkParticle : DustParticle
    {
        public SparkParticle()
            : base()
        {
            SparkColour = Color.White;
            SparkStartColour = Color.White;
            SparkEndColour = Color.White;
            SparkSize = 10f;
            SparkStartSize = 10f;
            SparkEndSize = 2f;
        }

        public Color SparkStartColour;
        public Color SparkEndColour;
        public Color SparkColour;
        public float SparkSize;
        public float SparkStartSize;
        public float SparkEndSize;

        public override void Update(float delta)
        {
            SparkColour = Color.Lerp(SparkEndColour, SparkStartColour, (MaxLifespan - TimeAlive) / MaxLifespan);
            SparkSize = MathHelper.Lerp(SparkEndSize, SparkStartSize, (MaxLifespan - TimeAlive) / MaxLifespan);

            base.Update(delta);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            Texture2D texture = AssetManager.LoadTexture("blur");
            spriteBatch.Draw(
                texture,
                new Rectangle(
                    (int)(Position.X - (SparkSize / 2f)),
                    (int)(Position.Y - (SparkSize / 2f)),
                    (int)SparkSize,
                    (int)SparkSize),
                texture.Bounds,
                SparkColour,
                Rotation,
                new Vector2(0.5f),
                SpriteEffects.None,
                0f);
        }
    }
}