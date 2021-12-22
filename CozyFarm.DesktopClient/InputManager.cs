using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace CozyFarm.DesktopClient
{
    internal class InputManager
    {
        Keymap keymap;
        List<Action> inputActions;

        public InputManager()
        {
            inputActions = Keymap.LoadKeymap();
        }

        public void Update()
        {
            KeyboardState state = Keyboard.GetState();

            foreach (Action a in inputActions)
            {
                if (state.IsKeyDown(a.Key))
                    a.Pressed = true;
                else
                    a.Pressed = false;
            }
        }

        public Action GetActionByName(string actionName)
        { 
            foreach (Action a in inputActions)
                if (a.Name == actionName)
                    return a;

            return null;
        }

        public bool IsActionPressed(string actionName)
        {
            if (GetActionByName(actionName) != null)
                return GetActionByName(actionName).Pressed;
            else
                return false;
        }
    }
}
