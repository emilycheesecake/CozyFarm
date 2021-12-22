using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace CozyFarm.DesktopClient
{
    internal class MainMenuState : GameState
    {
        private GameStateManager gsm;
        private InputManager inputManager;

        Texture2D menuSheet;
        Rectangle startButton = new Rectangle(6, 16, 53, 41);
        Rectangle exitButton = new Rectangle(70, 16, 53, 41);

        public MainMenuState(GameStateManager gsm, InputManager inputManager) : base(gsm, inputManager)
        {
            this.gsm = gsm;
            this.inputManager = inputManager;
        }

        public override void LoadContent(ContentManager c)
        {
            menuSheet = c.Load<Texture2D>("ui/button maker");
        }
        public override void Update(GameTime gameTime)
        {
            
        }

        public override void Draw(SpriteBatch sb)
        {
            sb.Begin();
            sb.Draw(menuSheet, new Vector2(100, 100), startButton, Color.White);
            sb.Draw(menuSheet, new Vector2(200, 100), exitButton, Color.White);
            sb.End();
        }

        public override void Dispose()
        {

        }
    }
}
