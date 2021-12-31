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
        private TileSheetViewer tileSheetViewer;

        public MainState(GameStateManager gsm, InputManager inputManager) : base(gsm, inputManager)
        {
            this.gsm = gsm;
            this.inputManager = inputManager;
            player = new Player(gsm);
            tileSheetViewer = new TileSheetViewer(gsm);
        }

        public override void LoadContent(ContentManager c)
        {
            tilesheet = c.Load<Texture2D>("tiles/tiles");
            testMap = new Map(tilesheet);
            testMap.LoadMap("test.map");
            gsm.SetCurrentMap(testMap);
            player.LoadContent(c);
            tileSheetViewer.LoadContent(c);
        }

        public override void Update(GameTime gameTime)
        {
            testMap.Update(gameTime);
            player.Update(gameTime, inputManager);
            tileSheetViewer.Update(gameTime, inputManager);

            if (inputManager.IsActionPressed("save_map"))
            {
                string fileName = "test.map";
                testMap.SaveMapToFile(fileName);
                CozyConsole.WriteLine("Saved map to '" + fileName + "'.");
            }
        }

        public override void Draw(SpriteBatch sb)
        {
            sb.Begin(transformMatrix: gsm.GetCamera().GetViewMatrix());
            testMap.Draw(sb);
            player.Draw(sb);
            sb.End();

            sb.Begin(transformMatrix: tileSheetViewer.GetCamera().GetViewMatrix());
            tileSheetViewer.Draw(sb);
            sb.End();
        }

        public override void Dispose()
        {
            
        }
    }
}
