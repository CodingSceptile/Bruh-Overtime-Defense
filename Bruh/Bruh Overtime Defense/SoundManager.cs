using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace Bruh_Overtime_Defense
{
    //Name: Sami Chamberlain
    //Date: 4/25/2021
    //Purpose: Handles sound effects and music in game
    class SoundManager
    {
        //Fields
        private SoundEffect bruhHit;
        private SoundEffect mukundBruh;
        private SoundEffect samiBruh;
        private Song titleTheme;
        private Song gameTheme;
        private Song victoryTheme;
        private Song loseTheme;

        private Random random;

        //Constructor

        /// <summary>
        /// Creates a new instance of the sound manager
        /// </summary>
        /// <param name="bruhHit">bruh sound effect hit</param>
        /// <param name="titleTheme">title music</param>
        /// <param name="gameTheme">main game music</param>
        /// <param name="victoryTheme">victory music</param>
        /// <param name="loseTheme">lose music</param>
        public SoundManager(SoundEffect bruhHit, Song titleTheme, Song gameTheme,
            Song victoryTheme, Song loseTheme, SoundEffect sami, SoundEffect mukund)
        {
            this.bruhHit = bruhHit;
            this.titleTheme = titleTheme;
            this.gameTheme = gameTheme;
            this.victoryTheme = victoryTheme;
            this.loseTheme = loseTheme;
            MediaPlayer.IsRepeating = true;

            mukundBruh = mukund;
            samiBruh = sami;

            random = new Random();
        }


        //Methods
        /// <summary>
        /// Plays the title theme of the game
        /// </summary>
        public void PlayTitle()
        {
            MediaPlayer.Stop();
            MediaPlayer.Volume = 0.10f;
            MediaPlayer.Play(titleTheme);
            MediaPlayer.IsRepeating = true;
        }
        
        /// <summary>
        /// Plays the game theme
        /// </summary>
        public void PlayGameTheme()
        {
            MediaPlayer.Stop();
            MediaPlayer.Volume = 0.05f;
            MediaPlayer.Play(gameTheme);
            MediaPlayer.IsRepeating = true;
        }

        /// <summary>
        /// plays the victory music
        /// </summary>
        public void PlayVictoryTheme()
        {
            MediaPlayer.Stop();
            MediaPlayer.Play(victoryTheme);
            MediaPlayer.IsRepeating = false;
        }

        /// <summary>
        /// plays the lose music
        /// </summary>
        public void PlayLoseTheme()
        {
            MediaPlayer.Stop();
            MediaPlayer.Play(loseTheme);
            MediaPlayer.IsRepeating = false;
        }

        /// <summary>
        /// plays a bruh sound effect
        /// </summary>
        public void PlayBruhSFX()
        {
            float pitch = 0f;

            //gets a random number to
            // indicate which bruh sound effect needs
            // to be played
            int currSFX = random.Next(0, 3);

            int pitchDetermine = random.Next(0, 2);
            //gets a random pitch dependent
            // on the 
            if(pitchDetermine == 0)
            {
                pitch = -(float)random.NextDouble();
            }
            else
            {
                pitch = (float)random.NextDouble();
            }

            //plays a bruh sound effect given the
            //currSFX random number
            switch (currSFX)
            {
                case 0:
                    bruhHit.Play(0.01f, pitch, 0);
                    break;
                case 1:
                    samiBruh.Play(0.33f, pitch, 0);
                    break;

                case 2:
                    mukundBruh.Play(0.33f, pitch, 0);
                    break;           
            }           
        }

        /// <summary>
        /// Stops all music
        /// </summary>
        public void StopMusic()
        {
            MediaPlayer.Stop();
        }
    }
}
