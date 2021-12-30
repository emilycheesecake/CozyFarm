using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace CozyFarm.DesktopClient.Tilemap
{
    internal class Tile
    {
        public Rectangle sourceRectangle { get; set; }
        public int tileId { get; set; }
        public Vector2 Position { get; set; }
        public Texture2D tilesheet;
        private Map map;

        public Tile(int tileId, Rectangle sourceRectangle, Vector2 Position, Map map)
        {
            this.tileId = tileId;
            this.sourceRectangle = sourceRectangle;
            this.Position = Position;
            this.map = map;
            tilesheet = map.GetTileSheet();
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch sb)
        {
            if (tileId != 69420)
                sb.Draw(tilesheet, Position, map.tiles[tileId].sourceRectangle, Color.White);
        }
    }
}
