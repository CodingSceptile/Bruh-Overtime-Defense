using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Bruh_Overtime_Defense
{
    //Name: Sami Chamberlain
    //Date: 3/31/2021
    //Purpose: Establishes all of the components of a level, 
    //which is derived from an external file.

    class Level
    {
        //fields
        List<Texture2D> tiles;
        Rectangle map;
        private string mapFile;
        private List<float> rotations;
        private List<Vector2> motionChange;
        private List<Rectangle> locations;
        private int sideLengthInTiles;
        private int sideLengthInPixels;
        private int width;
        private int height;
        private List<Rectangle> trackLocs;

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
        /// Generates a list of references to textures, that are
        /// eventually drawn to the screen
        /// </summary>
        public List<string> GenerateMap()
        {

            FileStream stream = null;
            BinaryReader reader = null;

            List<string> codes = new List<string>();
            rotations = new List<float>();

            motionChange = new List<Vector2>();
            locations = new List<Rectangle>();
            trackLocs = new List<Rectangle>();

            try
            {
                stream = new FileStream("Content/" + mapFile, FileMode.Open);
                reader = new BinaryReader(stream);

                //retrieves the width and height of each tile (to properly format each level)
                this.width = reader.ReadInt32();
                this.height = reader.ReadInt32();

                //retrieves all the various texture references from the 
                //external text file.
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        string textureCode = reader.ReadString();
                        int rotation = reader.ReadInt32();

                        float radRotation = (float)(rotation * (Math.PI / 180));
                        codes.Add(textureCode);
                        rotations.Add(radRotation);                     
                    }
                }

                //COLLISIONS

                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        string textureCode = reader.ReadString();

                        //Checks for Vector2/beginning tile indicators
                        if (textureCode.Contains('>') || textureCode == "begin_tile"
                            || textureCode == "track")
                        {
                            //add a transparent tile
                            codes.Add("default-min");

                            //Vector that focuses on +x
                            if (textureCode == "<1, 0>")
                            {
                                motionChange.Add(
                                    new Vector2(1, 0));

                            }

                            //Vector that focuses on +y
                            else if (textureCode == "<0, 1>")
                            {
                                motionChange.Add(
                                    new Vector2(0, 1));
                            }

                            //Vector that focuses on -x
                            else if (textureCode == "<-1, 1>")
                            {
                                motionChange.Add(
                                    new Vector2(-1, 0));
                            }

                            //Vector that focuses on -y
                            else if (textureCode == "<1, -1>")
                            {
                                motionChange.Add(
                                    new Vector2(0, -1));
                            }
                            else if(textureCode == "track")
                            {
                                trackLocs.Add(
                                    new Rectangle
                                    (new Point(((j * width) * 2) + width / 2,
                                    ((i * height) * 2) + height / 2),
                                    new Point(width * 3, height * 3)));
                                continue;
                            }

                            //Adds the location of the interactible
                            //level component to another list
                            locations.Add(
                                    new Rectangle
                                    (new Point(((j * width) * 2),
                                    ((i * height) * 2)),
                                    new Point(width, height)));
                        }
                        else
                        {
                            //No vector data detected, 
                            //simply add a level tile id to a list
                            codes.Add(textureCode);
                        }
                    }
                }

                //OVERLAY

                for (int i = 0; i < width; i++)
              {
                  for(int j = 0; j < height; j++)
                  {
                      string textureCode = reader.ReadString();

                        //Checks for Vector2/beginning tile indicators
                        if (textureCode.Contains('>') || textureCode == "begin_tile"
                            || textureCode == "track")
                        {
                            //add a transparent tile
                            codes.Add("default-min");
                            
                            //Vector that focuses on +x
                            if(textureCode == "<1, 0>")
                            {
                                motionChange.Add(
                                    new Vector2(1, 0));                              

                            }

                            //Vector that focuses on +y
                            else if(textureCode == "<0, 1>")
                            {
                                motionChange.Add(
                                    new Vector2(0, 1));
                            }

                            //Vector that focuses on -x
                            else if (textureCode == "<-1, 1>")
                            {
                                motionChange.Add(
                                    new Vector2(-1, 0));
                            }

                            //Vector that focuses on -y
                            else if (textureCode == "<1, -1>")
                            {
                                motionChange.Add(
                                    new Vector2(0, -1));
                            }
                            else if (textureCode == "track")
                            {
                                trackLocs.Add(
                                    new Rectangle
                                    (new Point(((j * width) * 2) + width / 2,
                                    ((i * height) * 2) + height / 2),
                                    new Point(width * 3, height * 3)));
                                continue;
                            }

                            //Adds the location of the interactible
                            //level component to another list
                            locations.Add(
                                    new Rectangle
                                    (new Point(((j * width) * 2) + width / 2,
                                    ((i * height) * 2) + height / 2),
                                    new Point(width * 3, height * 3)));
                        }
                        else
                        {
                            //No vector data detected, 
                            //simply add a level tile id to a list
                            codes.Add(textureCode);
                        }                                                                
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
        /// Gets a list of Rectangles
        /// that indicate where a vector is.
        /// </summary>
        public List<Rectangle> Locations
        {
            get { return locations; }
        }

        /// <summary>
        /// Gets the list of vectors that dictates 
        /// a change in direction
        /// </summary>
        public List<Vector2> Vectors
        {
            get { return motionChange; }
        }

        public List<float> Rotations 
        {
            get { return rotations; }
        }



        /// <summary>
        /// the side length in tiles
        /// (UNUSED CURRENTLY)
        /// </summary>
        public int SideLength
        {
            get { return sideLengthInTiles; }
        }

        /// <summary>
        /// Returns the width of a tile
        /// </summary>
        public int Width { get { return width; } }

        /// <summary>
        /// Returns the height of a tile
        /// </summary>
        public int Height { get { return height; } }

        /// <summary>
        /// Draws the tiles to the screen with the
        /// Game1 _spriteBatch
        /// </summary>
        /// <param name="sb">_spriteBatch</param>
        /// <param name="texture">The texture that is drawn</param>
        /// <param name="tileLocation">The Rectangle location of the tile</param>
        public void Draw(SpriteBatch sb, Texture2D texture, Rectangle tileLocation, float rotation)
        {
            sb.Draw(texture, tileLocation, null, Color.White, rotation,
                 new Vector2((texture.Width / 2f), (texture.Height / 2f)), SpriteEffects.None, 0f);
        }
    }
}
