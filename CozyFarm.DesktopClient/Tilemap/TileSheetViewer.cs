using CozyFarm.DesktopClient.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;
using System;
using System.Collections.Generic;
using System.Text;

namespace CozyFarm.DesktopClient.Tilemap
{
    internal class TileSheetViewer
    {
        private GameStateManager _gsm;
        private OrthographicCamera _camera;

        public bool Enabled = false;
        public Vector2 Position = Vector2.Zero;

        public TileSheetViewer(GameStateManager gsm)
        {
            _gsm = gsm;
            var viewportAdapter = new BoxingViewportAdapter(_gsm.GetGame().Window, _gsm.GetGame().GraphicsDevice, Global.SCREEN_WIDTH, Global.SCREEN_HEIGHT);
            _camera = new OrthographicCamera(viewportAdapter);
        }

        public void LoadContent(ContentManager c)
        {

        }

        public void Update(GameTime gameTime, InputManager inputManager)
        {
            if (inputManager.IsActionJustPressed("tile_menu"))
                Enabled = !Enabled;

            if (Enabled)
            {

            }
        }

        public void Draw(SpriteBatch sb)
        {
            if (Enabled)
            {
                sb.Draw(_gsm.GetCurrentMap().GetTileSheet(), Position, Color.White);
            }
        }

        public OrthographicCamera GetCamera() { return _camera; }
    }
}
