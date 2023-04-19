using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using VeilsClaim.Classes.Managers;
using VeilsClaim.Classes.Objects.Entities.Weapons;
using VeilsClaim.Classes.Objects.Weapons;

namespace VeilsClaim.Classes.Objects.Entities
{
    public class Player : Vehicle
    {
        public Player() : base()
        {
            Mass = 3;
            Weapons = new List<Weapon>()
            {
                new Chaingun()
            };
        }

        public override void Destroy()
        {
            base.Destroy();
        }
        public override void Update(float delta)
        {
            if (InputManager.InputPressed("accelerate"))
                Thrust = ThrustStrength;
            if (InputManager.InputPressed("reverse"))
                Thrust = -ThrustStrength;
            if (InputManager.InputPressed("turn_left"))
                RotationalForce -= 100f;
            if (InputManager.InputPressed("turn_right"))
                RotationalForce += 100f;
            if (InputManager.InputPressed("shoot"))
                Weapons[SelectedWeapon].Fire(this);
            if (InputManager.InputPressed("reload"))
                Weapons[SelectedWeapon].Reload();

            base.Update(delta);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}