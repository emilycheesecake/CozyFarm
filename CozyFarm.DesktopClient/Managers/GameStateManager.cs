using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using System;
using System.Collections.Generic;
using System.Text;

namespace CozyFarm.DesktopClient
{
    internal class GameStateManager
    {
        private Game1 game { get; }
        private InputManager inputManager { get; }
        private Stack<GameState> states = new Stack<GameState>();
        public GameStateManager(Game1 game, InputManager inputManager)
        {
            this.game = game;
            this.inputManager = inputManager;

            //This is where the initial gamestate is pushed.
            PushState(GetStateByID(1));
        }

        /// <summary>
        /// Pushes specified GameState to top of stack
        /// </summary>
        /// <param name="g">GameState to push</param>
        public void PushState(GameState g)
        {
            states.Push(g);
        }

        /// <summary>
        /// Pops and disposes of GameState on top of stack
        /// </summary>
        public void PopState()
        {
            GameState g = states.Pop();
            g.Dispose();
        }

        /// <summary>
        /// Returns GameState object that matches id given.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public GameState GetStateByID(int id)
        {
            switch(id) //This is where GameStates get their id
            {
                case 0:
                    return new MainMenuState(this, inputManager);
                case 1:
                    return new MainState(this, inputManager);
                default:
                    return null;
            }
        }

        /// <summary>
        /// Updates GameState at top of stack.
        /// </summary>
        public void UpdateState(GameTime gameTime)
        {
            states.Peek().Update(gameTime);
        }

        /// <summary>
        /// Draws GameState at top of stack.
        /// </summary>
        /// <param name="sb">SpriteBatch</param>
        public void DrawState(SpriteBatch sb)
        {
            states.Peek().Draw(sb);
        }

        public void LoadContent(ContentManager c)
        {
            foreach (GameState g in states)
            {
                g.LoadContent(c);
            }
        }

        public OrthographicCamera GetCamera() { return game.camera; }
        public Game1 GetGame() { return game; }
    }
}
