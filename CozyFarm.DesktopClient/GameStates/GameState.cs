using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace CozyFarm.DesktopClient
{
    internal abstract class GameState
    {
        private GameStateManager gsm;
        private InputManager inputManager;

        public GameState(GameStateManager gsm, InputManager inputManager)
        {
            this.gsm = gsm;
            this.inputManager = inputManager;
        }

        public abstract void LoadContent(ContentManager c);
        public abstract void Draw(SpriteBatch sb);
        public abstract void Update(GameTime gameTime);
        public abstract void Dispose();
    }
}
