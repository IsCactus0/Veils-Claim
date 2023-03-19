﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace VeilsClaim.Classes.Managers
{
    public class InputManager : GameComponent
    {
        public InputManager(Game game) 
            : base(game)
        {
            keyboardControls = new Dictionary<string, Keys>()
            {
                { "exit", Keys.End },
                { "pause", Keys.Escape },
                { "door", Keys.Space },
                { "zoomIn", Keys.OemPlus },
                { "zoomOut", Keys.OemMinus }
            };
            gamePadControls = new Dictionary<string, Buttons>()
            {
                { "exit", Buttons.Back },
                { "pause", Buttons.Start },
                { "door", Buttons.X },
                { "zoomIn", Buttons.DPadUp },
                { "zoomOut", Buttons.DPadDown }
            };
        }

        public static Dictionary<string, Keys> keyboardControls;
        public static Dictionary<string, Buttons> gamePadControls;
        public static Dictionary<string, Buttons> mouseControls;

        protected static KeyboardState currKeyboardState;
        protected static KeyboardState prevKeyboardState;
        protected static MouseState currMouseState;
        protected static MouseState prevMouseState;
        protected static GamePadState currGamePadState;
        protected static GamePadState prevGamePadState;

        public override void Update(GameTime gameTime)
        {
            prevKeyboardState = currKeyboardState;
            currKeyboardState = Keyboard.GetState();
            prevMouseState = currMouseState;
            currMouseState = Mouse.GetState();
            prevGamePadState = currGamePadState;
            currGamePadState = GamePad.GetState(PlayerIndex.One);

            base.Update(gameTime);
        }

        public static bool InputPressed(string action)
        {
            return (currKeyboardState.IsKeyDown(keyboardControls[action]) ||
                    currGamePadState.IsButtonDown(gamePadControls[action]));
        }
        public static bool InputFirstPressed(string action)
        {
            return (currKeyboardState.IsKeyDown(keyboardControls[action]) &&
                    prevKeyboardState.IsKeyUp(keyboardControls[action])) ||
                    (currGamePadState.IsButtonDown(gamePadControls[action]) &&
                    prevGamePadState.IsButtonUp(gamePadControls[action]));
        }
    }
}