using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;
using System;
using System.Collections.Generic;
using System.Text;

namespace CozyFarm.DesktopClient
{
    internal class MapManager
    {
        private GameStateManager gsm;

        TiledMap _tiledMap;
        TiledMapRenderer _tiledMapRenderer;

        public MapManager(GameStateManager gsm)
        {
            this.gsm = gsm;
        }

        public void LoadContent(ContentManager c)
        {
            _tiledMap = c.Load<TiledMap>("tilemaps/test");
            _tiledMapRenderer = new TiledMapRenderer(gsm.GetGame().GraphicsDevice, _tiledMap);
        }

        public void Update(GameTime gameTime)
        {
            _tiledMapRenderer.Update(gameTime);
        }

        public void Draw()
        {
            _tiledMapRenderer.Draw(gsm.GetCamera().GetViewMatrix());
        }
    }
}
