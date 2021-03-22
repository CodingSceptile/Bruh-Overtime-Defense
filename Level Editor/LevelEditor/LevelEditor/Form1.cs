using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace LevelEditor
{
    //Name: Sami Chamberlain
    //Date: 2/12/2021
    //Purpose: Directs the user to either a loaded map or
    //a new one.
    public partial class Form1 : Form
    {
        //fields
        private int height;
        private int width;
        private string message;
        private string[,] colors;
        private string[,] overlayColors;

        //Constructor

        /// <summary>
        /// Creates the initial menu form
        /// </summary>
        public Form1()
        {
            InitializeComponent();

        }

        /// <summary>
        /// Loads a level for the user when they click the button
        /// </summary>
        /// <param name="sender">The button click</param>
        /// <param name="e"></param>
        private void loadButton_Click(object sender, EventArgs e)
        {
            //Order -
            //Width, Height, Color ARGB Values

            //Opens file explorer for the user, allows
            //them to choose a file
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Open a level file";
            dialog.Filter = "Level Files|*.level";
            DialogResult r = dialog.ShowDialog();

            FileStream stream = null;
            BinaryReader reader = null;
            levelEditor editor = null;

            //User chooses OK in the file explorer
            if (r == DialogResult.OK)
            {

                try
                {
                    //Reads from the file
                    stream = new FileStream(dialog.FileName, FileMode.Open);

                    reader = new BinaryReader(stream);

                    //Width and height obtained
                    width = reader.ReadInt32();
                    height = reader.ReadInt32();

                    colors = new string[width, height];
                    overlayColors = new string[width, height];
                    

                    //Reads Vector2 data and turns it into a color indicator
                    for (int i = 0; i < colors.GetLength(0); i++)
                    {
                        for (int j = 0; j < colors.GetLength(1); j++)
                        {
                            string currentPicture = reader.ReadString();
   
                            if(currentPicture == "<-1, 1>")
                            {
                                colors[i, j] = Color.Red.ToString();
                            }
                            else if(currentPicture == "<1, -1>")
                            {
                                colors[i, j] = Color.Blue.ToString();
                            }
                            else if(currentPicture == "<-1, -1>")
                            {
                                colors[i, j] = Color.Violet.ToString();
                            }
                            else
                            {
                                colors[i, j] = currentPicture;
                            }
                        }
                    }

                    for (int i = 0; i < overlayColors.GetLength(0); i++)
                    {
                        for (int j = 0; j < overlayColors.GetLength(1); j++)
                        {
                            string currentPicture = reader.ReadString();

                            if (currentPicture == "<-1, 1>")
                            {
                                overlayColors[i, j] = Color.Red.ToString();
                            }
                            else if (currentPicture == "<1, -1>")
                            {
                                overlayColors[i, j] = Color.Blue.ToString();
                            }
                            else if (currentPicture == "<-1, -1>")
                            {
                                overlayColors[i, j] = Color.Violet.ToString();
                            }
                            else
                            {
                                overlayColors[i, j] = currentPicture;
                            }
                        }
                    }

                    //establishes the level editor with the given information
                    editor = new levelEditor(width, height);
                    //loads the picture boxes and matches the colors
                    editor.LoadBoxes(colors, overlayColors);
                    //Properly sizes the form
                    editor.ResizeForm();

                    //Prompts the user that it was sucessful!
                    editor.Text = $"Level editor - { dialog.FileName.Remove(0, dialog.FileName.LastIndexOf('\\') + 1)}";
                    MessageBox.Show("Successfully loaded the file!", ":)");
                    editor.ShowDialog();
                }

                catch (Exception ex)
                {
                    //Something was wrong with the file
                    MessageBox.Show("Error reading file! " + ex.Message, ":(");
                }

                finally
                {
                    if (stream != null)
                    {
                        reader.Close();
                    }
                }
            }

            //User exited out of the file explorer...
            else
            {
                return;
            }
        }

        /// <summary>
        /// Creates a fresh map for the user
        /// on request
        /// </summary>
        /// <param name="sender">Button press</param>
        /// <param name="e"></param>
        private void createButton_Click(object sender, EventArgs e)
        {
            //Prints errors, in case params are not 
            //entered correctly
            message = "Errors: \n";
            bool validWidth = int.TryParse(widthBox.Text, out width);
            bool validHeight = int.TryParse(heightBox.Text, out height);

            //width not valid
            if (validWidth == false)
            {
                message = message + " - Not a valid Width.\n";
            }

            //height not valid
            if (validHeight == false)
            {
                message = message + " - Not a valid Height.\n";
            }

            //too small width
            if (width < 10 && validWidth)
            {
                message = message + " - Width too small, the minimum is 10.\n";
            }

            //too large width
            if (width > 30 && validWidth)
            {
                message = message + " - Width too large, the maximum is 30.\n";
            }

            //too small height
            if (height < 10 && validHeight)
            {
                message = message + " - Height too small, the minimum is 10.\n";
            }

            //too large height
            if (height > 30 && validHeight)
            {
                message = message + " - Height to large, the maximum is 30.\n";
            }

            //prints errors to a message box, if any
            if (message != "Errors: \n")
            {
                MessageBox.Show(message, "Error creating level :(");
            }

            //No errors!
            else
            {
                //successfully creates a new level editor instance
                levelEditor editor = new levelEditor(width, height);

                //generates the boxes (previously caused an error when put in the 
                //initialize)
                editor.GenerateBoxes("../../../default-min.png");
                //shows the level
                editor.ShowDialog();
            }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Convert a .level file...";
            dialog.Filter = "Level Files|*.level";
            DialogResult r = dialog.ShowDialog();

            FileStream stream = null;
            FileStream writeStream = null;
            BinaryReader reader = null;
            BinaryWriter writer = null;

            //User chooses OK in the file explorer
            if (r == DialogResult.OK)
            {

                try
                {
                    //Reads AND writes from the file
                    stream = new FileStream(dialog.FileName, FileMode.Open);
                    writeStream = new FileStream(dialog.FileName + "_Appended", FileMode.Create);
                    reader = new BinaryReader(stream);
                    writer = new BinaryWriter(writeStream);

                    //Width and height obtained
                    width = reader.ReadInt32();
                    writer.Write(width);
                    height = reader.ReadInt32();
                    writer.Write(height);

                    //Colors obtained
                    for (int i = 0; i < width; i++)
                    {
                        for (int j = 0; j < height; j++)
                        {
                            string currentPicture = reader.ReadString();
                            if (currentPicture.Contains("../../../"))
                            {
                                currentPicture = currentPicture.Substring
                                    (currentPicture.LastIndexOf('/') + 1,
                                    currentPicture.LastIndexOf('.') - currentPicture.LastIndexOf('/') - 1);
                            }
                            writer.Write(currentPicture);
                        }
                    }

                    //RESERVED FOR VECTOR2 DATA.

                    MessageBox.Show("Successfully appended the file for Bruh Overtime Defense!", ":D");
                }

                catch (Exception ex)
                {
                    //Something was wrong with the file
                    MessageBox.Show("Error reading file! " + ex.Message, ":(");
                }

                finally
                {
                    if (stream != null)
                    {
                        reader.Close();
                    }
                }
            }

        }
    }

}
