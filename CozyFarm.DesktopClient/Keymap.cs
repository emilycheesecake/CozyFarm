using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace CozyFarm.DesktopClient
{
    internal class Keymap
    {
        static List<Action> inputActions;
        /// <summary>
        /// This is where input actions are made, returns list of actions.
        /// </summary>
        /// <returns></returns>
        public static List<Action> LoadKeymap()
        {
            inputActions = new List<Action>();

            //Movement
            inputActions.Add(new Action("move_left", Keys.A));
            inputActions.Add(new Action("move_right", Keys.D));
            inputActions.Add(new Action("move_up", Keys.W));
            inputActions.Add(new Action("move_down", Keys.S));

            return inputActions;
        }

    }
}
