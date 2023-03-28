using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using VeilsClaim.Classes.Objects;
using VeilsClaim.Classes.Objects.Particles;
using VeilsClaim.Classes.Utilities;

namespace VeilsClaim.Classes.Managers
{
    public class EntityManager : DrawableGameComponent
    {
        public EntityManager(Game game)
            : base(game)
        {
            spriteBatch = new SpriteBatch(game.GraphicsDevice);
            quadTree = new QuadTree(Main.camera.BoundingBox);
            entities = new List<Entity>();
        }

        public static SpriteBatch spriteBatch;
        public static QuadTree quadTree;
        public static List<Entity> entities;

        public override void Update(GameTime gameTime)
        {
            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds * Main.gameSpeed;
            if (delta > 0)
                for (int i = entities.Count - 1; i >= 0; i--)
                    entities[i].Update(delta);

            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            for (int i = entities.Count - 1; i >= 0; i--)
                entities[i].Draw(spriteBatch);

            spriteBatch.End();
        }
        public static List<Entity> FindAll(Rectangle hitbox)
        {
            return quadTree.Query(hitbox).Cast<Entity>().ToList();
        }
    }
}