using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace CozyFarm.DesktopClient
{
    internal class MainState : GameState
    {
        private GameStateManager gsm;
        private InputManager inputManager;
        private Player player;

        public MainState(GameStateManager gsm, InputManager inputManager) : base(gsm, inputManager)
        {
            this.gsm = gsm;
            this.inputManager = inputManager;
            player = new Player();
        }

        public override void LoadContent(ContentManager c)
        {
            player.LoadContent(c);
        }

        public override void Update(GameTime gameTime)
        {
            player.Update(gameTime, inputManager);
        }

        public override void Draw(SpriteBatch sb)
        {
            player.Draw(sb);
        }

        public override void Dispose()
        {
            
        }
    }
}
