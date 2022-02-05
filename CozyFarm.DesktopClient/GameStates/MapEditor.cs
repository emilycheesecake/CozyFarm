using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace CozyFarm.DesktopClient.GameStates
{
    internal class MapEditor : GameState
    {
        private GameStateManager gsm;
        private InputManager inputManager;

        public MapEditor(GameStateManager gsm, InputManager inputManager) : base (gsm, inputManager)
        {
            this.gsm = gsm;
            this.inputManager = inputManager;
        }

        public override void LoadContent(ContentManager c)
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            
        }

        public override void Draw(SpriteBatch sb)
        {
            
        }

        public override void Dispose()
        {
            
        }
    }
}
