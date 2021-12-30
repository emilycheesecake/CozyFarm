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
        int mapW = 100, mapH = 100;
        int tileW = 16, tileH = 16;
        Texture2D tilesheet;

        public Map(Texture2D tilesheet)
        {
            this.tilesheet = tilesheet;
            mapData = new int[mapW, mapH];
            tileArray = new Tile[mapW, mapH];
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

        public void InitMapToFile()
        {
            for (int i = 0; i < mapW; i++)
            {
                for (int j = 0; j < mapH; j++)
                {
                    mapData[i, j] = 0;
                }
            }

            string fileName = "test.map";
            Serialize(mapData, fileName);
        }

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

        public void Draw(SpriteBatch sb)
        {
            for(int i = 0; i < mapW; i++)
                for(int j = 0; j < mapH; j++)
                    tileArray[i,j].Draw(sb);
        }

        public Texture2D GetTileSheet() { return tilesheet; }
    }
}
