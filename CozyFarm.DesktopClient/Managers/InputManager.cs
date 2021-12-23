using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using Microsoft.Xna.Framework;

namespace CozyFarm.DesktopClient
{
    internal class InputManager
    {
        Keymap keymap;
        List<Action> inputActions;
        public Action currentAction;

        private Game1 _game;

        public InputManager(Game1 game)
        {
            _game = game;
            inputActions = Keymap.LoadKeymap();
        }

        /// <summary>
        /// Updating Pressed state for each Action
        /// </summary>
        public void Update()
        {
            KeyboardState state = Keyboard.GetState();

            foreach (Action a in inputActions)
            {
                if (state.IsKeyDown(a.Key))
                {
                    a.Pressed = true;
                    currentAction = a;
                }
                else
                    a.Pressed = false;
            }
        }

        /// <summary>
        /// Returns Action with specific name inside inputActions
        /// </summary>
        /// <param name="actionName"></param>
        /// <returns></returns>
        public Action GetActionByName(string actionName)
        { 
            foreach (Action a in inputActions)
                if (a.Name == actionName)
                    return a;

            return null;
        }

        /// <summary>
        /// Returns the Pressed value of action with specified name, if it exists.
        /// </summary>
        /// <param name="actionName"></param>
        /// <returns></returns>
        public bool IsActionPressed(string actionName)
        {
            if (GetActionByName(actionName) != null)
                return GetActionByName(actionName).Pressed;
            else
                return false;
        }

        public Vector2 GetMouseWorldPosition()
        {
            var mouseState = Mouse.GetState();
            return _game.camera.ScreenToWorld(new Vector2(mouseState.X, mouseState.Y));
        }
    }
}
