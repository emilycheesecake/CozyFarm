using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace CozyFarm.DesktopClient
{
    internal class Action
    {
        public string Name { get; }
        public bool Pressed { get; set; } = false;
        public Keys Key;

        /// <summary>
        /// An input action
        /// </summary>
        /// <param name="Name">Name of Action</param>
        /// <param name="Key">Keyboard key of Action</param>
        public Action(string Name, Keys Key)
        {
            this.Name = Name;
            this.Key = Key;
        }
        
    }
}
