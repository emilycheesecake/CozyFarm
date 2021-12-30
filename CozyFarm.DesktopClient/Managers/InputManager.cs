﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using Microsoft.Xna.Framework;

namespace CozyFarm.DesktopClient
{
    /// <summary>
    /// Class for managing custom input "actions"
    /// I just like Godot's input lol
    /// </summary>
    internal class InputManager
    {
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
                if(a.Type == "KEY")
                {
                    if (state.IsKeyDown(a.Key))
                    {
                        a.Pressed = true;
                        currentAction = a;
                    }
                    else
                        a.Pressed = false;
                }

                if (a.Type == "MOUSE")
                {
                    MouseState mouseState = Mouse.GetState();

                    if (a.Mouse == "left")
                    {
                        if (mouseState.LeftButton == ButtonState.Pressed)
                        {
                            a.Pressed = true;
                            currentAction = a;
                        }
                        else
                            a.Pressed = false;
                    }

                    if (a.Mouse == "right")
                    {
                        if (mouseState.RightButton == ButtonState.Pressed)
                        {
                            a.Pressed = true;
                            currentAction = a;
                        }
                        else
                            a.Pressed = false;
                    }
                }
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
        /// <summary>
        /// Returns true if any movement actions defined below are pressed.
        /// </summary>
        /// <returns></returns>
        public bool IsMovementInput()
        {
            return (IsActionPressed("move_left") || IsActionPressed("move_right") || IsActionPressed("move_up") || IsActionPressed("move_down"));
        }


        public Vector2 GetMouseWorldPosition()
        {
            var mouseState = Mouse.GetState();
            return _game.camera.ScreenToWorld(new Vector2(mouseState.X, mouseState.Y));
        }
    }
}
