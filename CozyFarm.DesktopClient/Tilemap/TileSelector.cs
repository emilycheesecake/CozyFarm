using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace CozyFarm.DesktopClient.Tilemap
{
    internal class TileSelector
    {
        public Texture2D texture;
        public Vector2 Position = new Vector2(0, 0);
        public GameStateManager gsm;
        public Tile selectedTile;
        public int tileId = 69;
        public bool Enabled = true;

        public TileSelector(GameStateManager gsm)
        {
            this.gsm = gsm;
        }

        public void LoadContent(ContentManager c)
        {
            texture = c.Load<Texture2D>("tiles/tile_selector");
        }

        public void Update(GameTime gameTime, InputManager inputManager)
        {
            if (Enabled)
            {
                Vector2 mousePosition = inputManager.GetMouseWorldPosition();
                selectedTile = gsm.GetCurrentMap().GetTileAt(mousePosition);

                Position = selectedTile.Position;

                //Click Input
                if (inputManager.IsActionPressed("interact"))
                    selectedTile.tileId = tileId;

                if (inputManager.IsActionPressed("destroy"))
                    selectedTile.tileId = 69420;

                if (inputManager.IsActionJustPressed("tile_inc"))
                    tileId++;
                if (inputManager.IsActionJustPressed("tile_dec"))
                    tileId--;

                //CozyConsole.WriteLine("Selected Tile: " + tileId.ToString());
            }
        }

        public void Draw(SpriteBatch sb)
        {
            if (Enabled)
            {
                sb.Draw(gsm.GetCurrentMap().GetTileSheet(), Position, gsm.GetCurrentMap().GetTile(tileId).sourceRectangle, Color.White);
                sb.Draw(texture, Position, Color.White);
            }
        }
    }
}
