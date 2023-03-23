using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using VeilsClaim.Classes.Managers;

namespace VeilsClaim.Classes.Objects.Tiles
{
    public class DoorTile : AnimatedTile
    {
        public bool isOpen;
        public bool isLocked;

        public override void Update(float delta)
        {
            if (!isLocked && InputManager.InputFirstPressed("door"))
            {
                isOpen = !isOpen;
                frameChange *= -1;
            }

            base.Update(delta);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}