using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Bruh_Overtime_Defense
{
    class Level
    {
        //fields
        List<Texture2D> tiles;
        Rectangle map;
        private string mapFile;
        int sideLengthInTiles;
        int sideLengthInPixels;
        int width;
        int height;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mapFile">the name of the map file</param>
        public Level(string mapFile)
        {
            //500 pixels is an arbitrary amount
            sideLengthInPixels = 500;
            this.mapFile = mapFile;
        }

        /// <summary>
        /// the map rectangle
        /// </summary>
        /// <param name="mapFile">the name of the map file</param>
        public List<string> GenerateMap()
        {

            FileStream stream = null;
            BinaryReader reader = null;

            List<string> codes = new List<string>();

            try
            {
                stream = new FileStream("Content/" + mapFile, FileMode.Open);
                reader = new BinaryReader(stream);

                this.width = reader.ReadInt32();
                this.height = reader.ReadInt32();

                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        string textureCode = reader.ReadString();
                        codes.Add(textureCode);
                    }
                }
                return codes;
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }
        }

        /// <summary>
        /// the tiles for the map in order
        /// </summary>
        public List<Texture2D> Tiles
        {
            get { return tiles; }

        }

        /// <summary>
        /// the side length in tiles
        /// </summary>
        public int SideLength
        {
            get { return sideLengthInTiles; }
        }

        public int Width { get { return width; } }

        public int Height { get { return height; } }

        public void Draw(SpriteBatch sb, Texture2D texture, Rectangle tileLocation)
        {
            sb.Draw(texture, tileLocation, Color.White);
        }
    }
}
