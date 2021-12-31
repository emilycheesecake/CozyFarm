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

            //Tiles
            inputActions.Add(new Action("destroy", "left"));
            inputActions.Add(new Action("interact", "right"));
            inputActions.Add(new Action("save_map", Keys.Y));
            inputActions.Add(new Action("tile_menu", Keys.Tab));
            inputActions.Add(new Action("tile_inc", Keys.E));
            inputActions.Add(new Action("tile_dec", Keys.Q));

            return inputActions;
        }

    }
}
