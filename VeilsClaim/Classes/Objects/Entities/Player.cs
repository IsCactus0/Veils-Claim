using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using VeilsClaim.Classes.Managers;

namespace VeilsClaim.Classes.Objects.Entities
{
    public class Player : Entity
    {
        public Player() : base()
        {
            Mass = 3;
            Gravity = false;
        }



        public override void Destroy()
        {
            base.Destroy();
        }
        public override void Update(float delta)
        {
            if (InputManager.InputPressed("move_up"))
                Force += new Vector2(0, -100);
            if (InputManager.InputPressed("move_down"))
                Force += new Vector2(0, 100);
            if (InputManager.InputPressed("move_left"))
                Force += new Vector2(-100, 0);
            if (InputManager.InputPressed("move_right"))
                Force += new Vector2(100, 0);

            base.Update(delta);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
