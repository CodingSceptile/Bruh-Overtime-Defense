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
        private Song titleTheme;
        private Song gameTheme;
        private Song victoryTheme;
        private Song loseTheme;

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
            Song victoryTheme, Song loseTheme)
        {
            this.bruhHit = bruhHit;
            this.titleTheme = titleTheme;
            this.gameTheme = gameTheme;
            this.victoryTheme = victoryTheme;
            this.loseTheme = loseTheme;
            MediaPlayer.IsRepeating = true;
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
            bruhHit.Play(0.005f, -0.05f, 0);
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
