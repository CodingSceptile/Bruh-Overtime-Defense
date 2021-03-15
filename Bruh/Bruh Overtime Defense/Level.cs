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

        private int width;
        private int height;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mapFile">the name of the map file</param>
        public Level(string mapFile)
        {
            this.mapFile = mapFile;
        }

        /// <summary>
        /// generates a map
        /// </summary>
        /// <param name="mapFile">the name of the map file</param>
        public List<string> GenerateMap()
        {
          
            FileStream stream = new FileStream("Content/" + mapFile, FileMode.Open);
            BinaryReader reader = new BinaryReader(stream);

            List<string> codes = new List<string>();

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

        public int Width { get { return width; } }

        public int Height { get { return height; } }

        public void Draw(SpriteBatch sb, Texture2D texture, Rectangle tileLocation)
        {
            sb.Draw(texture, tileLocation, Color.White);
        }
    }
}
