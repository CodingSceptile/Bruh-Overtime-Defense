using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Bruh_Overtime_Defense
{
    //Name: Sami Chamberlain
    //Date: 4/30/2021
    //Purpose: Manages the tutorial of the gmae
    class TutorialManager
    {
        //Fields
        private Button okButton;
        private SpriteFont gameFont;
        private Texture2D bg;
        private Texture2D settingsIcon;
        private Texture2D towerIcon;
        private Texture2D dootSprite;
        private Texture2D sniperSprite;
        private Texture2D dogeSprite;
        private Texture2D ryanSprite;
        private Texture2D notErinSprite;
          
        //Constructor

        /// <summary>
        /// Creates a new instance of the tutorial manager
        /// </summary>
        /// <param name="okButton">button for confirmation</param>
        /// <param name="gameFont">font</param>
        public TutorialManager(Button okButton, SpriteFont gameFont, Texture2D bg,
            Texture2D settingsIcon, Texture2D towerIcon, Texture2D dootSprite,
            Texture2D sniper, Texture2D doge, Texture2D ryan, Texture2D erin)
        {
            this.okButton = okButton;
            this.gameFont = gameFont;
            this.bg = bg;
            this.settingsIcon = settingsIcon;
            this.towerIcon = towerIcon;
            this.dootSprite = dootSprite;
            this.sniperSprite = sniper;
            this.dogeSprite = doge;
            this.ryanSprite = ryan;
            this.notErinSprite = erin;
        }

        //Methods
        
        /// <summary>
        /// Draws instructions on the screen
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="ms"></param>
        /// <param name="prev"></param>
        /// <param name="tutorialPhase"></param>
        public void DrawInstructions(SpriteBatch sb, MouseState ms, MouseState prev,
            int tutorialPhase)
        {
            switch(tutorialPhase)
            {
                //Introduction to the game
                case 0:
                    sb.Draw(bg,
                        new Rectangle(new Point(0, 0),
                        new Point(2000, 2000)), Color.White);
                    okButton.Draw(sb, ms);
                    sb.DrawString(gameFont, 
                        "Welcome to Bruh\nOvertime Defense!\n" +
                        "Let's get the basics\ndown before moving on...\n" +
                        "\n\n(Exit to the map select\n using the settings menu)",
                        new Vector2(75, 250),
                        Color.White);
                    sb.DrawString(gameFont,
                        "Icon:",
                        new Vector2(425, 485),
                        Color.White);
                    sb.Draw(settingsIcon,
                        new Rectangle(
                            new Point(550, 475),
                            new Point(50, 50)),
                        Color.White);
                    break;
                
                //Doot skeleton introduction
                case 1:
                    sb.Draw(bg,
                       new Rectangle(new Point(0, 0),
                       new Point(2000, 2000)), Color.White);
                    okButton.Draw(sb, ms);
                    sb.DrawString(gameFont,
                        "We've supplied enough\n" +
                        "money to get a Doot Skeleton!\n" +
                        "It has high range, and \n" +
                        "high shoot speed.",
                        new Vector2(13, 250),
                        Color.White);
                    break;

                // Placing towers introduction
                case 2:
                    sb.Draw(bg,
                       new Rectangle(new Point(0, 0),
                       new Point(2000, 2000)), Color.White);
                    okButton.Draw(sb, ms);
                    sb.DrawString(gameFont,
                        "Placing a Tower:\n" +
                        "Click on the  icon to\n\n" +
                        "open the tower menu!\n\nClick  , and click\n" +
                        "again somewhere on\nthe map to place it!",
                        new Vector2(75, 250),
                        Color.White);
                    sb.Draw(towerIcon,
                        new Rectangle(
                            new Point(400, 275),
                            new Point(50, 50)),
                        Color.White);
                    sb.Draw(dootSprite,
                        new Rectangle(
                            new Point(215, 375),
                            new Point(50, 50)),
                        Color.White);
                    break;

                //Next wave button introduction
                case 4:
                    sb.Draw(bg,
                       new Rectangle(new Point(0, 0),
                       new Point(2000, 2000)), Color.White);
                    okButton.Draw(sb, ms);
                    sb.DrawString(gameFont,
                        "Great!\n" +
                        "Now to " +
                        "starting a wave!\n" +
                        "Press the \"Next Wave\"\n" +
                        "button to\nstart the next wave!",
                        new Vector2(75, 250),
                        Color.White);
                    break;

                //Displays after the first wave
                case 6:

                    sb.Draw(bg,
                       new Rectangle(new Point(0, 0),
                       new Point(2000, 2000)), Color.White);
                    okButton.Draw(sb, ms);
                    sb.DrawString(gameFont,
                        "That was the first wave! \n" +
                        "it's OK if some\n" +
                        "enemies pass,\n" +
                        "but watch your health!\n\n" +
                        "Defeating enemies will \nreward" +
                        " money!\n" +
                        "(Outside of the tutorial)",
                        new Vector2(75, 250),
                        Color.White);
                    break;

                //Salary introduction
                case 7:
                    sb.Draw(bg,
                       new Rectangle(new Point(0, 0),
                       new Point(2000, 2000)), Color.White);
                    okButton.Draw(sb, ms);
                    sb.DrawString(gameFont,
                        "It looks as if\n" +
                        "the total pay of \n" +
                        "your tower decreased!\n\n" +
                        "Try clicking on it to \n" +
                        "pay it some money!",
                        new Vector2(75, 250),
                        Color.White);
                    break;

                //Displays after the user pays salary, depicts
                //the mechanic in a greater sense
                case 9:

                    sb.Draw(bg,
                       new Rectangle(new Point(0, 0),
                       new Point(2000, 2000)), Color.White);
                    okButton.Draw(sb, ms);
                    sb.DrawString(gameFont,
                        "Great! Keeping your towers\n" +
                        "paid will allow them to stay\n" +
                        "on the field!\n\n" +
                        "Forgetting to pay them\n" +
                        "over time will cause them\n" +
                        "to leave!\n\n" +
                        "Each tower on the field\n" +
                        "will reward extra money\n" +
                        "upon a new wave, so make\n" +
                        "sure to keep as many\n" +
                        "as possible!",
                        new Vector2(30, 150),
                        Color.White);
                    break;

                //Introduces tower variants
                case 10:
                    sb.Draw(bg,
                       new Rectangle(new Point(0, 0),
                       new Point(2000, 2000)), Color.White);
                    okButton.Draw(sb, ms);
                    sb.DrawString(gameFont,
                        "Now let's learn about" +
                        "\nthe different tower\nvariants!",
                        new Vector2(75, 250),
                        Color.White);
                    break;

                //Sniper monke introduction
                case 11:
                    sb.Draw(bg,
                       new Rectangle(new Point(0, 0),
                       new Point(2000, 2000)), Color.White);
                    okButton.Draw(sb, ms);
                    sb.DrawString(gameFont,
                        "Sniper Monke:" +
                        "\n-Has infinite range\n" +
                        "-Slow shoot speed\n" +
                        "- Medium salary\n\n" +
                        "Let's try it out!",
                        new Vector2(150, 250),
                        Color.White);
                    sb.Draw(sniperSprite,
                        new Rectangle(
                            new Point(495, 238),
                            new Point(50, 50)),
                        Color.White);
                    break;

                //Buff doge introduction
                case 13:
                    sb.Draw(bg,
                       new Rectangle(new Point(0, 0),
                       new Point(2000, 2000)), Color.White);
                    okButton.Draw(sb, ms);
                    sb.DrawString(gameFont,
                        "Buff Doge:" +
                        "\n-Has low range\n" +
                        "-High Shoot speed\n" +
                        "-It can damage\n" +
                        "multiple enemies at once!\n" +
                        "-Medium-High salary\n\n" +
                        "Let's try it out!",
                        new Vector2(75, 250),
                        Color.White);
                    sb.Draw(dogeSprite,
                        new Rectangle(
                            new Point(350, 230),
                            new Point(50, 50)),
                        Color.White);
                    break;

                //Ryan introduction
                case 15:
                    sb.Draw(bg,
                       new Rectangle(new Point(0, 0),
                       new Point(2000, 2000)), Color.White);
                    okButton.Draw(sb, ms);
                    sb.DrawString(gameFont,
                        "Ryan the Gatekeeper:\n" +
                        "\n-Has medium\nrange\n" +
                        "-Medium Shoot speed\n" +
                        "- They stop everything\n" +
                        "in their radius!\n" +
                        "- High salary\n\n" +
                        "Let's try it out!",
                        new Vector2(75, 250),
                        Color.White);
                    sb.Draw(ryanSprite,
                        new Rectangle(
                            new Point(600, 230),
                            new Point(50, 50)),
                        Color.White);
                    break;

                //erin introduction
                case 17:
                    sb.Draw(bg,
                       new Rectangle(new Point(0, 0),
                       new Point(2000, 2000)), Color.White);
                    okButton.Draw(sb, ms);
                    sb.DrawString(gameFont,
                        "Not Erin:\n" +
                        "-Has medium range\n" +
                        "-High Shoot speed\n\n" +
                        "- They DESTROY everything\n" +
                        "in sight!\n" +
                        "- VERY High salary\n\n" +
                        "Let's try it out!",
                        new Vector2(75, 250),
                        Color.White);
                    sb.Draw(notErinSprite,
                        new Rectangle(
                            new Point(300, 238),
                            new Point(50, 50)),
                        Color.White);
                    break;

                //Tower conclusion
                case 19:
                    sb.Draw(bg,
                       new Rectangle(new Point(0, 0),
                       new Point(2000, 2000)), Color.White);
                    okButton.Draw(sb, ms);
                    sb.DrawString(gameFont,
                        "Those are all of the\n" +
                        "available towers!\n\n" +
                        "Each tower has it's\n" +
                        "own purpose when fighting\n" +
                        "off the bruhs.",
                        new Vector2(75, 250),
                        Color.White);
                    break;

                //Enemy variant introduction
                case 20:
                    sb.Draw(bg,
                       new Rectangle(new Point(0, 0),
                       new Point(2000, 2000)), Color.White);
                    okButton.Draw(sb, ms);
                    sb.DrawString(gameFont,
                        "Now, onto enemy variants.\n\n" +
                        "There are five enemy\n" +
                        "variants in this game,\n\n" +
                        "each has a different\n" +
                        "health and speed.",
                        new Vector2(75, 250),
                        Color.White);
                    break;

                //Enemy descriptions
                case 21:
                    sb.Draw(bg,
                       new Rectangle(new Point(0, 0),
                       new Point(2000, 2000)), Color.White);
                    okButton.Draw(sb, ms);
                    sb.DrawString(gameFont,
                        "Black Bruh - weakest, slow.\n\n" +
                        "Red Bruh - A little stronger,\n" +
                        "has a moderate pace.\n\n" +
                        "Green Bruh - Strong \nand fast\n\n" +
                        "Blue Bruh - Very strong \nand Very fast\n\n" +
                        "HURB - EXTREMELY strong, \nbut slow.",
                        new Vector2(15, 250),
                        Color.White);
                    break;

                //Goal, and farewell
                case 22:
                    sb.Draw(bg,
                       new Rectangle(new Point(0, 0),
                       new Point(2000, 2000)), Color.White);
                    okButton.Draw(sb, ms);
                    sb.DrawString(gameFont,
                        "The objective of the game\n" +
                        "is to beat wave 20!\n\n\n" +
                        "Good luck!",
                        new Vector2(15, 250),
                        Color.White);
                    break;
            }
        }
    }
}
