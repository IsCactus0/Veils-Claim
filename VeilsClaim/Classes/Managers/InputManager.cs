using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using VeilsClaim.Classes.Enums;
using VeilsClaim.Classes.Objects.Entities;

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
                { "zoomIn", Keys.OemPlus },
                { "zoomOut", Keys.OemMinus },

                { "accelerate", Keys.W },
                { "reverse", Keys.S },
                { "turn_left", Keys.A },
                { "turn_right", Keys.D },

                { "shoot", Keys.Space },
                { "reload", Keys.R },
            };
            gamePadControls = new Dictionary<string, Buttons>()
            {
                { "exit", Buttons.Back },
                { "pause", Buttons.Start },
                { "zoomIn", Buttons.DPadUp },
                { "zoomOut", Buttons.DPadDown },

                { "accelerate", Buttons.LeftStick },
                { "reverse", Buttons.LeftStick },
                { "turn_left", Buttons.LeftStick },
                { "turn_right", Buttons.LeftStick },

                { "shoot", Buttons.RightTrigger },
                { "reload", Buttons.X },
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

        public static List<Entity> selectedObjects;
        protected static Vector2 selectStart;
        protected static Vector2 selectEnd;

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
        public static bool MousePressed(MouseButton button = MouseButton.Left)
        {
            switch (button) {
                default:
                    return currMouseState.LeftButton == ButtonState.Pressed;
                case MouseButton.Right:
                    return currMouseState.RightButton == ButtonState.Pressed;
                case MouseButton.Middle:
                    return currMouseState.MiddleButton == ButtonState.Pressed;
            }
        }
        public static bool MouseFirstPressed(MouseButton button = MouseButton.Left)
        {
            switch (button)
            {
                default:
                    return prevMouseState.LeftButton == ButtonState.Released &&
                        currMouseState.LeftButton == ButtonState.Pressed;
                case MouseButton.Right:
                    return prevMouseState.RightButton == ButtonState.Released &&
                        currMouseState.RightButton == ButtonState.Pressed;
                case MouseButton.Middle:
                    return prevMouseState.MiddleButton == ButtonState.Released &&
                        currMouseState.MiddleButton == ButtonState.Pressed;
            }
        }
        public static bool MouseReleased(MouseButton button = MouseButton.Left)
        {
            switch (button)
            {
                default:
                    return currMouseState.LeftButton == ButtonState.Released;
                case MouseButton.Right:
                    return currMouseState.RightButton == ButtonState.Released;
                case MouseButton.Middle:
                    return currMouseState.MiddleButton == ButtonState.Released;
            }
        }
        public static bool MouseFirstReleased(MouseButton button = MouseButton.Left)
        {
            switch (button)
            {
                default:
                    return prevMouseState.LeftButton == ButtonState.Pressed &&
                        currMouseState.LeftButton == ButtonState.Released;
                case MouseButton.Right:
                    return prevMouseState.RightButton == ButtonState.Pressed &&
                        currMouseState.RightButton == ButtonState.Released;
                case MouseButton.Middle:
                    return prevMouseState.MiddleButton == ButtonState.Pressed &&
                        currMouseState.MiddleButton == ButtonState.Released;
            }
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
        public static bool InputReleased(string action)
        {
            return (currKeyboardState.IsKeyUp(keyboardControls[action]) &&
                    prevKeyboardState.IsKeyDown(keyboardControls[action])) ||
                    (currGamePadState.IsButtonUp(gamePadControls[action]) &&
                    prevGamePadState.IsButtonDown(gamePadControls[action]));
        }

        public static Vector2 MouseWorldPosition()
        {
            return Vector2.Transform(currMouseState.Position.ToVector2(), Main.Camera.InvertedTransform);
        }
        public static Vector2 MouseScreenPosition()
        {
            return currMouseState.Position.ToVector2();
        }
        public static Rectangle SelectionBounds()
        {
            int x, y;
            if (selectStart.X < selectEnd.X)
                x = (int)selectStart.X;
            else x = (int)selectEnd.X;

            if (selectStart.Y < selectEnd.Y)
                y = (int)selectStart.Y;
            else y = (int)selectEnd.Y;

            return new Rectangle(
                x, y,
                (int)Math.Abs(selectStart.X - selectEnd.X),
                (int)Math.Abs(selectStart.Y - selectEnd.Y));         
        }
    }
}