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

//Name: Sami Chamberlain
//Date: 2/13/2021
//Purpose: Allows a user to paint individual tiles that serve
//as the tiles of a level

namespace LevelEditor
{
    public partial class levelEditor : Form
    {
        //fields
        private int height;
        private int width;
        private int boxHeight;
        private int boxWidth;
        private PictureBox[,] boxes;
        private PictureBox[,] overlay;
        private List<Button> buttons;
        private FileStream stream;
        private string[,] colors;
        private bool isSaved;

        private Color currentColor;

        private string path;

        /// <summary>
        /// Creates the level editor form
        /// </summary>
        /// <param name="width">The width of the level</param>
        /// <param name="height">The height of the level</param>
        public levelEditor(int width, int height)
        {
            InitializeComponent();

            this.height = height;
            this.width = width;

            boxes = new PictureBox[height, width];
            isSaved = true;

            buttons = new List<Button>();
            AssignColors();

            currentColor = Color.Red;

            path = "Default size/towerDefense_tile001.png";
            texturePic.Load("../../../" + path);
            texturePic.SizeMode = PictureBoxSizeMode.Zoom;
        }

        /// <summary>
        /// Returns the Height of the level
        /// </summary>
        public int Height { get { return height; } }

        /// <summary>
        /// Returns the Width of the level
        /// </summary>
        public int Width { get { return width; } }

        /// <summary>
        /// Loads the level editor, properly sizes it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LevelEditor_Load(object sender, EventArgs e)
        {           
            ResizeForm();

            for (int i = 1; i < 300; i++)
            {
                pictureSelect.Items.Add("Tower defense texture " + i);
            }

        }

        /// <summary>
        /// Tracks clicking the change color buttons, 
        /// or the picture boxes in the level
        /// </summary>
        /// <param name="sender">a click</param>
        /// <param name="e"></param>
        private void button_Click(object sender, EventArgs e)
        {

            //PictureBox is detected
            if(sender is PictureBox)
            {
                if(path == null)
                {
                    return;
                }

                PictureBox p = (PictureBox)sender;

                p.Capture = false;

                if(Control.MouseButtons == MouseButtons.Left)
                {
                    if(p.Image != null)
                    {
                        p.Image.Dispose();
                    }
                    
                    p.SizeMode = PictureBoxSizeMode.Zoom;
                    p.Load("../../../" + path);

                    if (this.Text.IndexOf("*") == -1)
                    {
                        //Puts an asterisk if there are unsaved changes
                        this.Text = this.Text + "*";

                        //Unsaved changes...
                        isSaved = false;
                    }

                    if (recentlyUsed.Items.Contains(path))
                    {
                        return;
                    }
                    else
                    {
                        recentlyUsed.Items.Add(path);
                    }                   
                }

                else if(Control.MouseButtons == MouseButtons.Right)
                {
                    p.Image = null;

                    p.BackColor = currentColor;
                                                          
                    if (this.Text.IndexOf("*") == -1)
                    {
                        //Puts an asterisk if there are unsaved changes
                        this.Text = this.Text + "*";

                        //Unsaved changes...
                        isSaved = false;
                    }
                }
            }                                 
        }

        /// <summary>
        /// Activates when the user clicks the "save"
        /// button, saves the file to a .level extension
        /// </summary>
        /// <param name="sender">the button click</param>
        /// <param name="e">tracks events</param>
        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveMenu = new SaveFileDialog();

            saveMenu.Filter = "Level Files|.level";
            saveMenu.Title = "Save a level";
            DialogResult r = saveMenu.ShowDialog();

            if(r == DialogResult.OK)
            {

                stream = null;
                BinaryWriter writer = null;
                
                //File order
                //Width, height, LEVEL texture data,
                //Special Vector2/tower data.

                try
                {
                    stream = new FileStream(saveMenu.FileName, FileMode.Create);

                    writer = new BinaryWriter(stream);

                    //Saves the width and height
                    writer.Write(width);
                    writer.Write(height);

                    //Saves the ARGB colors of the pictureboxes
                    foreach (PictureBox b in boxes)
                    {
                        if(b.Image != null)
                        {
                            writer.Write(b.ImageLocation);
                        }
                        else
                        {
                            if (b.BackColor == Color.Red)
                            {
                                writer.Write("<-1, 1>");
                            }
                            else if (b.BackColor == Color.Blue)
                            {
                                writer.Write("<1, -1>");
                            }
                            else if (b.BackColor == Color.Violet)
                            {
                                writer.Write("<-1, -1>");
                            }
                            else if (b.BackColor == Color.Pink)
                            {
                                writer.Write("tower");
                            }
                            else
                            {
                                writer.Write("../../../default-min.png");
                            }                            
                        }
                    }

                    //prompts the user that the file was successfully saved.
                    MessageBox.Show("Successfully Saved the file!", ":)");
                    this.Text = $"Level Editor - {saveMenu.FileName.Remove(0, saveMenu.FileName.LastIndexOf('\\') + 1)}";
                    isSaved = true;
                
                }
                catch(Exception ex)
                {
                    //Something went wrong...
                    MessageBox.Show("Error saving file! " + ex.Message, ":(");
                }
                finally
                {
                    //close the stream
                    if(stream != null)
                    {
                        writer.Close();
                    }                    
                }
            }            
        }
        
        /// <summary>
        /// Activates when the user clicks the 
        /// load button.
        /// Purpose: Loads a .level file
        /// </summary>
        /// <param name="sender">the button click</param>
        /// <param name="e">tracks events</param>
        public void loadButton_Click(object sender, EventArgs e)
        {
            //File order - 
            //Width, height, ARGB colors (all int32)
            OpenFileDialog dialog = new OpenFileDialog();

            BinaryReader reader = null;
            FileStream stream = null;

            dialog.Filter = "Level Files|*.level";
            dialog.Title = "Load a level";

            DialogResult r = dialog.ShowDialog();


            try
            {
                if (r == DialogResult.OK)
                {
                    //Loads the data from an external file
                    stream = new FileStream(dialog.FileName, FileMode.Open);

                    reader = new BinaryReader(stream);
                    
                    //Reads width, height
                    width = reader.ReadInt32();
                    height = reader.ReadInt32();
                    //creates a new array that is able to store colors
                    colors = new string[height, width];

                    //Fills the array with the colors of the loaded data
                    for (int i = 0; i < colors.GetLength(0); i++)
                    {
                        for (int j = 0; j < colors.GetLength(1); j++)
                        {
                            string currentPicture = reader.ReadString();
                            
                            if (currentPicture == "<-1, 1>")
                            {
                                colors[i, j] = Color.Red.ToString();
                            }
                            else if (currentPicture == "<1, -1>")
                            {
                                colors[i, j] = Color.Blue.ToString();
                            }
                            else if (currentPicture == "<-1, -1>")
                            {
                                colors[i, j] = Color.Violet.ToString();
                            }
                            else
                            {
                                colors[i, j] = currentPicture;
                            }                           
                        }
                    }
                }
                //User cancels decision
                else if(r == DialogResult.Cancel)
                {
                    return;
                }
                
                //Displays the data on the map
                LoadBoxes(colors);
                //Resizes the form accordingly
                ResizeForm();

                //formats the file name
                this.Text = $"Level editor - {dialog.FileName.Remove(0, dialog.FileName.LastIndexOf('\\') + 1)}";
                //prompts the user that the operation was successful
                MessageBox.Show("Successfully loaded the file!", ":)");
            }

            catch(Exception ex)
            {
                //Error occurred...
                MessageBox.Show("Error Reading File! " + ex.Message, ":(");
            }

            finally
            {
                //Closes the stream
                if (stream != null)
                {
                    reader.Close();
                }
            }                 
        }

        /// <summary>
        /// Generates a new set of PictureBoxes, no load
        /// data required
        /// </summary>
        /// <param name="color">The color of the boxes</param>
        public void GenerateBoxes(string path)
        {
            //Handles Y axis
            for (int i = 0; i < height; i++)
            {
               
                //HAndles X axis
                for (int j = 0; j < width; j++)
                {
                    //Creates width # of Picture boxes height # of times
                    PictureBox box = new PictureBox();
                   
                    //Sizes the boxes to the map width/height
                    //Horizontal is bigger, base off of the width
                    if (width > height || width == height)
                    {
                        box.Size = new Size((mapBox.Width) / width, (mapBox.Width) / width);
                    }
                   
                    //Vertical is bigger, base off of the height
                    else if (height > width)
                    {
                        box.Size = new Size((mapBox.Height - 17) / height, (mapBox.Height - 17) / height);
                    }
                    
                    //Sets the location of the box
                    //by taking the iteration of i and j.
                    box.Location = new Point
                        (10 + box.Width * j, 15 + box.Height * i);
                    //Boxes are visible
                    box.Visible = true;
                    //Adds the box to the list of controls (for the group box)
                    mapBox.Controls.Add(box);
                    //Subscribes box's MouseDown to the button_Click method, so
                    //it is interactable.
                    box.MouseDown += button_Click;
                    box.MouseEnter += button_Click;

                    box.BackColor = Color.White;
                    //saves in an array in case the data
                    //is saved to an external file
                    boxes[i, j] = box;                   
                }
            }

            //resizes the form accordingly
            ResizeForm();
        }

        /// <summary>
        /// Like GenerateBoxes, but takes in loaded color 
        /// data and loads the boxes based on that
        /// </summary>
        /// <param name="colors">The array of loaded colors</param>
        public void LoadBoxes(string[,] colors)
        {
            //Clears the controls (so we dont 
            //get overlap)

            mapBox.Size = new Size(575, 575);

            mapBox.Controls.Clear();

           
            //Most of the functionality here is the same
            //as the above method, look there for non-unique 
            //comments
            boxes = new PictureBox[height, width];

            for (int i = 0; i < height; i++)
            {
               
                for (int j = 0; j < width; j++)
                {
                    PictureBox box = new PictureBox();
                   
                    if (width > height || width == height)
                    {
                        box.Size = new Size((mapBox.Width) / width, (mapBox.Width) / width);
                    }
                  
                    else if (height > width)
                    {
                        box.Size = new Size((mapBox.Height - 17) / height, (mapBox.Height - 17) / height);
                    }
                    
                    box.Location = new Point
                        (10 + box.Width * j, 15 + box.Height * i);
                    box.Visible = true;
                    mapBox.Controls.Add(box);
                    box.MouseDown += button_Click;
                    box.MouseEnter += button_Click;

                    //assigns a box the color from the corresponding
                    //colors array index

                    if(colors[i, j] == "../../../default-min.png")
                    {
                        box.BackColor = Color.White;
                    }
                    else if(colors[i, j].Contains("../../../") == false)
                    {
                        if(colors[i,j] == "Color [Red]")
                        {
                            box.BackColor = Color.Red;
                        }
                        else if(colors[i, j] == "Color [Blue]")
                        {
                            box.BackColor = Color.Blue;
                        }
                        else if(colors[i, j] == "Color [Violet]")
                        {
                            box.BackColor = Color.Violet;
                        }
                    }
                    else
                    {
                        box.Load(colors[i, j]);
                        box.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    
                    mapBox.Controls.Add(box);

                    boxes[i, j] = box;

                }
            }
            
        }

        /// <summary>
        /// Resizes the form and group box
        /// around the generated boxes
        /// </summary>
        public void ResizeForm()
        {
            int width = 0;
            int height = 0;

            //gets the width and height of 
            //an individual box
            boxWidth = boxes[0, 0].Width;
            boxHeight = boxes[0, 0].Height;

            //calculates the total width that the boxes
            //take up
            for(int i = 0; i < Width; i++)
            {
                width += boxWidth;
            }

            //calculates the total height that the boxes
            //take up
            for(int i = 0; i < Height; i++)
            {
                height += boxHeight;
            }

            //resizes the group box, with 25 pixels in each direction
            //for padding
            mapBox.Size = new Size(width + 25, height + 25);

            //resizes the form according to the width of the
            //group box
            this.Size = new Size(350 + mapBox.Width, 750);
        }

        /// <summary>
        /// Determines whether or not 
        /// a prompt needs to be shown
        /// if a user tries to close the program
        /// </summary>
        /// <param name="sender">'x' button click</param>
        /// <param name="e"></param>
        private void LevelEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Level has unsaved changes
            if(isSaved == false)
            {
                //prompts the user that they have unsaved changes
                DialogResult r = MessageBox.Show("There" +
                    " are unsaved changes. Are you sure you want to quit?", 
                    "Unsaved changes", 
                    MessageBoxButtons.YesNo);

                //Force quit
                if(r == DialogResult.Yes)
                {
                    e.Cancel = false;
                }
               
                //Doesn't exit the progarm
                else if(r == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        /// <summary>
        /// Checks for which texture a user chooses
        /// from the list displayed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
           if(sender is ListBox)
            {
                ListBox b = (ListBox)sender;

                int index = b.SelectedIndex + 1;

                if(index < 10)
                {
                    path = "Default size/towerDefense_tile" + $"00{index}.png";
                }
                else if(index < 100)
                {
                    path = "Default size/towerDefense_tile" + $"0{index}.png";
                }
                else
                {
                    path = "Default size/towerDefense_tile" + $"{index}.png";
                }

                texturePic.Load("../../../" + path);
                texturePic.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        /// <summary>
        /// Displays recently selected tiles
        /// in a ListBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RecentSelect(object sender, EventArgs e)
        { 
            if(sender is ListBox)
            {
                ListBox b = (ListBox)sender;

                int index = b.SelectedIndex;

                path = (string)b.Items[index];

                texturePic.Load("../../../" + path);
            }
        }


        private void ColorPicker(object sender, EventArgs e)
        {
            if(sender is Button)
            {
                Button b = (Button)(sender);

                currentColor = b.BackColor;
                colorSelect.BackColor = b.BackColor;               
            }
        }

        /// <summary>
        /// Assigns colors to the buttons shown in the 
        /// color selection
        /// </summary>
        private void AssignColors()
        {
            color1.BackColor = Color.Red;
            buttons.Add(color1);

            color2.BackColor = Color.Blue;
            buttons.Add(color2);

            color11.BackColor = Color.Pink;
            buttons.Add(color11);

            color11.BackColor = Color.Violet;
            buttons.Add(color11);

            color14.BackColor = Color.White;
            buttons.Add(color14);
        }
    }   
}
