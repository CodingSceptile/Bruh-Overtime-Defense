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

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mapFile">the name of the map file</param>
        public Level(string mapFile)
        {
            //500 pixels is an arbitrary amount
            sideLengthInPixels = 500;
            GenerateMap(mapFile);
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
            }
            finally
            {
                if(stream != null)
                {
                    stream.Close();
                }
            }

        /// <summary>
        /// the tiles for the map in order
        /// </summary>
        public List<Texture2D> Tiles
        {
            get { return tiles; }
            

            return codes;

        }

        /// <summary>
        /// the side length in tiles
        /// </summary>
        public int SideLength
        {
            get { return sideLengthInTiles; }
        }

        /// <summary>
        /// generates a map
        /// </summary>
        /// <param name="mapFile">the name of the map file</param>
        private void GenerateMap(string mapFile)
        {
            //a list of texture names
            List<String> textureCodes = new List<String>();
            //opens the level file to be read
            BinaryReader reader = new BinaryReader(File.Open(mapFile, FileMode.Open));

            //get the side length in tiles from the file
            sideLengthInTiles = reader.ReadInt32();
            //add all the strings as a texture code
            textureCodes.Add(reader.ReadString());

            //for each texture code
            //for (int i = 0; i < textureCodes.Count; i++)
            //{
            //    switch (textureCodes[i])
            //    {
            //        case "../../../test1.jpg":
            //            break;
            //    }
            //}

            //initialize the rectangle 
            map = new Rectangle(0, 0, sideLengthInPixels, sideLengthInPixels);
        }

        public int Width { get { return width; } }

        public int Height { get { return height; } }

        public void Draw(SpriteBatch sb, Texture2D texture, Rectangle tileLocation)
        {
            sb.Draw(texture, tileLocation, Color.White);
        }
    }
}
