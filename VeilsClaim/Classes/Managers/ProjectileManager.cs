using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using VeilsClaim.Classes.Objects;
using VeilsClaim.Classes.Objects.Projectiles;

namespace VeilsClaim.Classes.Managers
{
    public class ProjectileManager : DrawableGameComponent
    {
        public ProjectileManager(Game game)
            : base(game)
        {
            spriteBatch = new SpriteBatch(game.GraphicsDevice);
            projectiles = new List<Projectile>();
        }

        public static SpriteBatch spriteBatch;
        public static QuadTree quadTree;
        public static List<Projectile> projectiles;

        public override void Update(GameTime gameTime)
        {
            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds * Main.GameSpeed;
            if (delta > 0)
                for (int i = projectiles.Count - 1; i >= 0; i--)
                    projectiles[i].Update(delta);

            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.SetRenderTarget(Main.RenderTarget);
            spriteBatch.Begin(
                SpriteSortMode.Immediate,
                BlendState.NonPremultiplied,
                SamplerState.PointClamp,
                DepthStencilState.None,
                RasterizerState.CullNone,
                null,
                Main.Camera.Transform);

            for (int i = projectiles.Count - 1; i >= 0; i--)
                projectiles[i].Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
        public static List<Projectile> FindAll(Rectangle bounds)
        {
            return quadTree.Query(bounds).Cast<Projectile>().ToList();
        }
    }
}