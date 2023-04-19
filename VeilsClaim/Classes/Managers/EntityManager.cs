using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using VeilsClaim.Classes.Objects;
using VeilsClaim.Classes.Objects.Entities;
using VeilsClaim.Classes.Objects.Entities.Weapons;
using VeilsClaim.Classes.Objects.Weapons;
using VeilsClaim.Classes.Utilities;

namespace VeilsClaim.Classes.Managers
{
    public class EntityManager : DrawableGameComponent
    {
        public EntityManager(Game game)
            : base(game)
        {
            spriteBatch = new SpriteBatch(game.GraphicsDevice);
            entities = new List<Entity>();
            player = new Player()
            {
                Weapons = new List<Weapon>()
                {
                    new Chaingun(),
                }
            };
        }

        public static SpriteBatch spriteBatch;
        public static QuadTree quadTree;
        public static List<Entity> entities;
        public static Player player;

        public override void Update(GameTime gameTime)
        {
            quadTree = new QuadTree(Main.Camera.RenderBoundingBox, 8);
            if (entities.Count < 10)
                entities.Add(new Asteroid()
                {
                    Radius = Main.Random.Next(32, 64),
                    Velocity = MathAdditions.RandomVector(12f),
                    Friction = 1f
                });

            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds * Main.GameSpeed;
            if (delta > 0)
            {
                player.Update(delta);
                for (int i = entities.Count - 1; i >= 0; i--)
                {
                    quadTree.Add(entities[i]);
                    entities[i].Update(delta);
                }
            }

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

            for (int i = 0; i < entities.Count; i++)
                entities[i].Draw(spriteBatch);

            player.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
        public static List<Entity> FindAll(Rectangle bounds)
        {
            return quadTree.Query(bounds).Cast<Entity>().ToList();
        }
    }
}