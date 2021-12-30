using CozyFarm.DesktopClient.Tilemap;
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
        private Map testMap;
        private Texture2D tilesheet;

        public MainState(GameStateManager gsm, InputManager inputManager) : base(gsm, inputManager)
        {
            this.gsm = gsm;
            this.inputManager = inputManager;
            player = new Player(gsm);
        }

        public override void LoadContent(ContentManager c)
        {
            tilesheet = c.Load<Texture2D>("tiles/tiles");
            testMap = new Map(tilesheet);
            testMap.LoadMap("test.map");
            player.LoadContent(c);
        }

        public override void Update(GameTime gameTime)
        {
            player.Update(gameTime, inputManager);
        }

        public override void Draw(SpriteBatch sb)
        {
            testMap.Draw(sb);
            player.Draw(sb);
        }

        public override void Dispose()
        {
            
        }
    }
}
