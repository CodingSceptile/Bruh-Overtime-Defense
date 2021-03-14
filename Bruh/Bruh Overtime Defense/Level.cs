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
        }

        /// <summary>
        /// the map rectangle
        /// </summary>
        public Rectangle Map
        {
            get { return map; }
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
            for (int i = 0; i < textureCodes.Count; i++)
            {
                //switch case where each string corresponds to a texture
            }

            //initialize the rectangle 
            map = new Rectangle(0, 0, sideLengthInPixels, sideLengthInPixels);
        }

        /// <summary>
        /// draws all the tiles to the screen in a grid
        /// </summary>
        /// <param name="sb">the SpriteBatch</param>
        public void DrawMap(SpriteBatch sb)
        {
            //the length of each tile is the total pixels over the amount of tiles in a row
            int tileLength = sideLengthInPixels / sideLengthInTiles;

            //for each tile in a row
            for (int i = 0; i < sideLengthInTiles; i++)
            {
                //for each tile in a column
                for(int j = 0; j < sideLengthInTiles; j++)
                {
                    //draw the tiles in a grid
                    sb.Draw(
                        tiles[i], 
                        new Rectangle(tileLength * j, tileLength * i, tileLength, tileLength),
                        Color.White);
                }
                
            }
        }
    }
}
