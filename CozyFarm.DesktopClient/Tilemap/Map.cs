using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Xna.Framework.Graphics;

namespace CozyFarm.DesktopClient.Tilemap
{
    internal class Map
    {
        int[,] mapData;
        Tile[,] tileArray;
        public int mapW = 100, mapH = 100;
        public int tileW = 16, tileH = 16;
        Texture2D tilesheet;
        
        public List<Tile> tiles;

        public Map(Texture2D tilesheet)
        {
            this.tilesheet = tilesheet;
            mapData = new int[mapW, mapH];
            tileArray = new Tile[mapW, mapH];
            tiles = new List<Tile>();

            int index = 0;
            for (int x = 0; x < (int)Math.Floor((double)tilesheet.Width / 16); x++)
            {
                for (int y = 0; y < (int)Math.Floor((double)tilesheet.Height / 16); y++)
                {
                    tiles.Add(new Tile(index, new Rectangle(x * tileW, y * tileH, tileW, tileH), new Vector2(0, 0), this));
                    index++;
                }
            }
        }

        //Binary (de)serializer from corylulu @ stackoverflow (thank you)
        //https://stackoverflow.com/questions/15512263/what-is-the-easiest-way-to-write-a-two-dimensional-array-to-a-file
        public void Serialize(object t, string path)
        {
            using (Stream stream = File.Open(path, FileMode.Create))
            {
                BinaryFormatter bformatter = new BinaryFormatter();
                bformatter.Serialize(stream, t);
            }
        }

        public object Deserialize(string path)
        {
            using (Stream stream = File.Open(path, FileMode.Open))
            {
                BinaryFormatter bformatter = new BinaryFormatter();
                return bformatter.Deserialize(stream);
            }
        }

        public Tile GetTile(int id)
        {
            foreach (Tile t in tiles)
            {
                if (t.tileId == id)
                    return t;
            }
            return null;
        }

        /// <summary>
        /// Initializes an empty map at the specified path
        /// </summary>
        public void InitMapToFile(string path)
        {
            for (int i = 0; i < mapW; i++)
            {
                for (int j = 0; j < mapH; j++)
                {
                    mapData[i, j] = 0;
                }
            }

            Serialize(mapData, path);
        }

        public void SaveMapToFile(string path)
        {
            Serialize(mapData, path);
        }

        /// <summary>
        /// Loads map from file in path into the tile array
        /// </summary>
        /// <param name="path"></param>
        public void LoadMap(string path)
        {
            mapData = (int[,])Deserialize(path);
            for(int i = 0; i < mapW; i++)
            {
                for(int j = 0; j< mapH; j++)
                {
                    tileArray[i, j] = new Tile(mapData[i, j], new Rectangle(0, 112, tileW, tileH), new Vector2(i * tileW, j * tileH), this);
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            for (int i = 0; i < mapW; i++)
                for (int j = 0; j < mapH; j++)
                    mapData[i, j] = tileArray[i, j].tileId;
        }

        /// <summary>
        /// Runs draw func of all tiles in array
        /// </summary>
        /// <param name="sb"></param>
        public void Draw(SpriteBatch sb)
        {
            for(int i = 0; i < mapW; i++)
                for(int j = 0; j < mapH; j++)
                    tileArray[i,j].Draw(sb);
        }

        /// <summary>
        /// Returns tile that specified position is inside of
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public Tile GetTileAt(Vector2 position)
        {
            int x = (int)Math.Floor(position.X / 16);
            if(x < 0) x = 0;
            if(x > mapW - 1) x = mapW - 1;

            int y = (int)Math.Floor(position.Y / 16);
            if(y < 0) y = 0;
            if(y > mapH - 1) y = mapH - 1;

            return tileArray[x, y];
        }
        public Texture2D GetTileSheet() { return tilesheet; }
    }
}
