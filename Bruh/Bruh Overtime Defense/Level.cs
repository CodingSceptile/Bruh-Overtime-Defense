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

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mapFile">the name of the map file</param>
        public Level(string mapFile)
        {
            GenerateMap(mapFile);
        }

        /// <summary>
        /// generates a map
        /// </summary>
        /// <param name="mapFile">the name of the map file</param>
        private void GenerateMap(string mapFile)
        {
            List<String> textureCodes = new List<String>();
            BinaryReader reader = new BinaryReader(File.Open(mapFile, FileMode.Open));
            int width = reader.ReadInt32();
            int height = reader.ReadInt32();
            textureCodes.Add(reader.ReadString());
            for(int  i = 0; i < textureCodes.Count; i++)
            {
                //switch case where each string corresponds to a texture
            }

            map = new Rectangle(width, height, 500, 500);
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
    }
}
