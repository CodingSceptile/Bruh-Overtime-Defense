using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace Bruh_Overtime_Defense
{
    public enum CurrEnemy
    {
        Bruh,
        RedBruh,
        GreenBruh,
        BlueBruh,
        Hurb
    }

    //Name: Sami Chamberlain
    //Date: 4/18/2021
    //Purpose: Manages enemy waves
    class WaveManager
    {
        //Fields
        private Dictionary<int, List<Enemy>> waves;
        private StreamReader reader;
        private string fileName;

        //Bruh Stats
        private int bruhHealth;
        private int bruhSpeed;

        //Red Bruh Stats
        private int redHealth;
        private int redSpeed;

        //Green Stats
        private int greenHealth;
        private int greenSpeed;

        //Blue stats
        private int blueHealth;
        private int blueSpeed;

        //hurb stats
        private int hurbHealth;
        private int hurbSpeed;

        //textures
        private Texture2D bruh;
        private Texture2D red;
        private Texture2D blue;
        private Texture2D green;
        private Texture2D hurb;

        //starting rectangle
        private Rectangle startingRect;

        //Properties
        
        /// <summary>
        /// Returns a dictionary that
        /// holds information about each wave
        /// </summary>
        public Dictionary<int, List<Enemy>> Waves
        {
            get { return waves; }
        }
 
        //Constructor

        /// <summary>
        /// Creates a new WaveManager object
        /// </summary>
        /// <param name="fileName">name of enemy waves file</param>
        /// <param name="bruh">bruh default texture</param>
        /// <param name="red">red bruh texture</param>
        /// <param name="blue">blue bruh texture</param>
        /// <param name="green">green bruh texture</param>
        /// <param name="hurb">hurb texture</param>
        /// <param name="startingRect">starting position of the bruhs</param>
        public WaveManager(string fileName, Texture2D bruh, Texture2D red,
            Texture2D blue, Texture2D green, Texture2D hurb, Rectangle startingRect)
        {
            waves = new Dictionary<int, List<Enemy>>();
            this.fileName = fileName;
            this.bruh = bruh;
            this.red = red;
            this.blue = blue;
            this.green = green;
            this.hurb = hurb;
            this.startingRect = startingRect;   
        }

        //Methods

        /// <summary>
        /// Generates the base stats of bruhs
        /// </summary>
        public void GenerateBruhStats()
        {
            waves.Clear();
            try
            {
                reader = new StreamReader("Content/" + fileName);

                //reads information about the stats
                //of each bruh
                string nextBruhStats = reader.ReadLine();
                string[] stats = nextBruhStats.Split('|');

                bruhHealth = int.Parse(stats[0]);
                bruhSpeed = int.Parse(stats[1]);

                nextBruhStats = reader.ReadLine();
                stats = nextBruhStats.Split('|');

                redHealth = int.Parse(stats[0]);
                redSpeed = int.Parse(stats[1]);

                nextBruhStats = reader.ReadLine();
                stats = nextBruhStats.Split('|');

                greenHealth = int.Parse(stats[0]);
                greenSpeed = int.Parse(stats[1]);

                nextBruhStats = reader.ReadLine();
                stats = nextBruhStats.Split('|');

                blueHealth = int.Parse(stats[0]);
                blueSpeed = int.Parse(stats[1]);

                nextBruhStats = reader.ReadLine();
                stats = nextBruhStats.Split('|');

                hurbHealth = int.Parse(stats[0]);
                hurbSpeed = int.Parse(stats[1]);

                
                //formats the waves
                for (int i = 0; i < 20; i++)
                {
                    nextBruhStats = reader.ReadLine();
                    stats = nextBruhStats.Split('|');

                    waves.Add(i + 1, new List<Enemy>());

                    //regular bruhs added
                    for(int j = 0; j < int.Parse(stats[1]); j++)
                    {
                        waves[i + 1].Add(new Enemy(bruh, bruhHealth, bruhSpeed, startingRect, bruhHealth));
                    }
                    //red bruhs added
                    for (int j = 0; j < int.Parse(stats[2]); j++)
                    {
                        waves[i + 1].Add(new Enemy(red, redHealth, redSpeed, startingRect, redHealth));
                    }
                    //green bruhs added
                    for (int j = 0; j < int.Parse(stats[3]); j++)
                    {
                        waves[i + 1].Add(new Enemy(green, greenHealth, greenSpeed, startingRect, greenHealth));
                    }
                    //blue bruhs added
                    for (int j = 0; j < int.Parse(stats[4]); j++)
                    {
                        waves[i + 1].Add(new Enemy(blue, blueHealth, blueSpeed, startingRect, blueHealth));
                    }

                    //checks if hurb needs to be added
                    if(i == 19)
                    {
                        for (int j = 0; j < int.Parse(stats[5]); j++)
                        {
                            waves[i + 1].Add(new Enemy(hurb, hurbHealth, hurbSpeed, startingRect, hurbHealth));
                        }
                    }
                }
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }         
        }
    }
}
