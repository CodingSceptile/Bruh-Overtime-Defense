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
    //Date: 4/15/2021
    //Purpose: Allows enemy information to be written to an
    //external file.
    public partial class EnemyFormation : Form
    {
        //Fields
        private const int START_NUM = 5;
        private FileStream stream;
        private StreamWriter writer;
        private int waveNum;

        //wave totals
        private int wave1Total;
        private int wave2Total;
        private int wave3Total;
        private int wave4Total;
        private int wave5Total;
        private int wave6Total;
        private int wave7Total;
        private int wave8Total;
        private int wave9Total;
        private int wave10Total;
        private int wave11Total;
        private int wave12Total;
        private int wave13Total;
        private int wave14Total;
        private int wave15Total;
        private int wave16Total;
        private int wave17Total;
        private int wave18Total;
        private int wave19Total;
        private int wave20Total;

        /// <summary>
        /// Initializes a new EnemyFormation Form
        /// </summary>
        public EnemyFormation()
        {
            InitializeComponent();

            wave1Total = 0;
            wave2Total = 0;
            wave3Total = 0;
            wave4Total = 0;
            wave5Total = 0;
            wave6Total = 0;
            wave7Total = 0;
            wave8Total = 0;
            wave9Total = 0;
            wave10Total = 0;
            wave11Total = 0;
            wave12Total = 0;
            wave13Total = 0;
            wave14Total = 0;
            wave15Total = 0;
            wave16Total = 0;
            wave17Total = 0;
            wave18Total = 0;
            wave19Total = 0;
            wave20Total = 0;

            waveNum = 1;
        }

        /// <summary>
        /// attempts to generate a file with bruhs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void enemyGenerateButton_Click(object sender, EventArgs e)
        {
            writer = new StreamWriter("../../enemyWave.wave");
            GenerateBoxes();
            try
            {
                writer.WriteLine(GetNumFromBox(bruhHealth) + "|" + GetNumFromBox(bruhSpeed));
                writer.WriteLine(GetNumFromBox(redHealth) + "|" + GetNumFromBox(redSpeed));
                writer.WriteLine(GetNumFromBox(greenHealth) + "|" + GetNumFromBox(greenSpeed));
                writer.WriteLine(GetNumFromBox(blueHealth) + "|" + GetNumFromBox(blueSpeed));
                writer.WriteLine(GetNumFromBox(hurbHealth) + "|" + GetNumFromBox(hurbSpeed));

                for (int i = 0; i < 21; i++)
                {
                    WriteNumBruhs(waveNum, writer);
                    waveNum++;
                }

                MessageBox.Show("Successfully created the enemy wave file!", ":)");


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, ":(");
            }
            finally
            {
                if(writer != null)
                {
                    writer.Close();
                    waveNum = 1;
                }
            }
        }

        /// <summary>
        /// Returns the number held within a box
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        private int GetNumFromBox(TextBox b)
        {
            int num = int.Parse(b.Text);
            return num;
        }

        /// <summary>
        /// Generates all of the data needed
        /// to get the totals for each wave
        /// </summary>
        private void GenerateBoxes()
        {
            wave1Total = GetNumFromBox(a1) + GetNumFromBox(a2) + GetNumFromBox(a3) + GetNumFromBox(a4);
            wave2Total = GetNumFromBox(b1) + GetNumFromBox(b2) + GetNumFromBox(b3) + GetNumFromBox(b4);
            wave3Total = GetNumFromBox(c1) + GetNumFromBox(c2) + GetNumFromBox(c3) + GetNumFromBox(c4);
            wave4Total = GetNumFromBox(d1) + GetNumFromBox(d2) + GetNumFromBox(d3) + GetNumFromBox(d4);
            wave5Total = GetNumFromBox(e1) + GetNumFromBox(e2) + GetNumFromBox(e3) + GetNumFromBox(e4);
            wave6Total = GetNumFromBox(f1) + GetNumFromBox(f2) + GetNumFromBox(f3) + GetNumFromBox(f4);
            wave7Total = GetNumFromBox(g1) + GetNumFromBox(g2) + GetNumFromBox(g3) + GetNumFromBox(g4);
            wave8Total = GetNumFromBox(h1) + GetNumFromBox(h2) + GetNumFromBox(h3) + GetNumFromBox(h4);
            wave9Total = GetNumFromBox(i1) + GetNumFromBox(i2) + GetNumFromBox(i3) + GetNumFromBox(i4);
            wave10Total = GetNumFromBox(j1) + GetNumFromBox(j2) + GetNumFromBox(j3) + GetNumFromBox(j4);
            wave11Total = GetNumFromBox(k1) + GetNumFromBox(k2) + GetNumFromBox(k3) + GetNumFromBox(k4);
            wave12Total = GetNumFromBox(l1) + GetNumFromBox(l2) + GetNumFromBox(l3) + GetNumFromBox(l4);
            wave13Total = GetNumFromBox(m1) + GetNumFromBox(m2) + GetNumFromBox(m3) + GetNumFromBox(m4);
            wave14Total = GetNumFromBox(n1) + GetNumFromBox(n2) + GetNumFromBox(n3) + GetNumFromBox(n4);
            wave15Total = GetNumFromBox(o1) + GetNumFromBox(o2) + GetNumFromBox(o3) + GetNumFromBox(o4);
            wave16Total = GetNumFromBox(p1) + GetNumFromBox(p2) + GetNumFromBox(p3) + GetNumFromBox(p4);
            wave17Total = GetNumFromBox(q1) + GetNumFromBox(q2) + GetNumFromBox(q3) + GetNumFromBox(q4);
            wave18Total = GetNumFromBox(r1) + GetNumFromBox(r2) + GetNumFromBox(r3) + GetNumFromBox(r4);
            wave19Total = GetNumFromBox(s1) + GetNumFromBox(s2) + GetNumFromBox(s3) + GetNumFromBox(s4);
            wave20Total = GetNumFromBox(t1) + GetNumFromBox(t2) + GetNumFromBox(t3) + GetNumFromBox(t4) +
                GetNumFromBox(t5);
        }

        /// <summary>
        /// Writes bruh data to an external file
        /// </summary>
        /// <param name="wave">num wave</param>
        /// <param name="writer">streamWriter</param>
        private void WriteNumBruhs(int wave, StreamWriter writer)
        {
            switch (wave)
            {
                case 1:
                    writer.WriteLine
                        (wave1Total + "|" + GetNumFromBox(a1) + "|"
                        + GetNumFromBox(a2) + "|" + GetNumFromBox(a3) + "|"
                        + GetNumFromBox(a4));

                    break;
                case 2:
                    writer.WriteLine
                        (wave2Total + "|" + GetNumFromBox(b1) + "|"
                        + GetNumFromBox(b2) + "|" + GetNumFromBox(b3) + "|"
                        + GetNumFromBox(b4));
                    break;
                case 3:
                    writer.WriteLine
                        (wave3Total + "|" + GetNumFromBox(c1) + "|"
                        + GetNumFromBox(c2) + "|" + GetNumFromBox(c3) + "|"
                        + GetNumFromBox(c4));
                    break;
                case 4:
                    writer.WriteLine
                        (wave4Total + "|" + GetNumFromBox(d1) + "|"
                        + GetNumFromBox(d2) + "|" + GetNumFromBox(d3) + "|"
                        + GetNumFromBox(d4));
                    break;
                case 5:
                    writer.WriteLine
                        (wave5Total + "|" + GetNumFromBox(e1) + "|"
                        + GetNumFromBox(e2) + "|" + GetNumFromBox(e3) + "|"
                        + GetNumFromBox(e4));
                    break;
                case 6:
                    writer.WriteLine
                        (wave6Total + "|" + GetNumFromBox(f1) + "|"
                        + GetNumFromBox(f2) + "|" + GetNumFromBox(f3) + "|"
                        + GetNumFromBox(f4));
                    break;
                case 7:
                    writer.WriteLine
                        (wave7Total + "|" + GetNumFromBox(g1) + "|"
                        + GetNumFromBox(g2) + "|" + GetNumFromBox(g3) + "|"
                        + GetNumFromBox(g4));
                    break;
                case 8:
                    writer.WriteLine
                        (wave8Total + "|" + GetNumFromBox(h1) + "|"
                        + GetNumFromBox(h2) + "|" + GetNumFromBox(h3) + "|"
                        + GetNumFromBox(h4));
                    break;
                case 9:
                    writer.WriteLine
                        (wave9Total + "|" + GetNumFromBox(i1) + "|"
                        + GetNumFromBox(i2) + "|" + GetNumFromBox(i3) + "|"
                        + GetNumFromBox(i4));
                    break;
                case 10:
                    writer.WriteLine
                        (wave10Total + "|" + GetNumFromBox(j1) + "|"
                        + GetNumFromBox(j2) + "|" + GetNumFromBox(j3) + "|"
                        + GetNumFromBox(j4));
                    break;
                case 11:
                    writer.WriteLine
                        (wave11Total + "|" + GetNumFromBox(k1) + "|"
                        + GetNumFromBox(k2) + "|" + GetNumFromBox(k3) + "|"
                        + GetNumFromBox(k4));
                    break;
                case 12:
                    writer.WriteLine
                        (wave12Total + "|" + GetNumFromBox(l1) + "|"
                        + GetNumFromBox(l2) + "|" + GetNumFromBox(l3) + "|"
                        + GetNumFromBox(l4));
                    break;
                case 13:
                    writer.WriteLine
                        (wave13Total + "|" + GetNumFromBox(m1) + "|"
                        + GetNumFromBox(m2) + "|" + GetNumFromBox(m3) + "|"
                        + GetNumFromBox(m4));
                    break;
                case 14:
                    writer.WriteLine
                        (wave14Total + "|" + GetNumFromBox(n1) + "|"
                        + GetNumFromBox(n2) + "|" + GetNumFromBox(n3) + "|"
                        + GetNumFromBox(n4));
                    break;
                case 15:
                    writer.WriteLine
                        (wave15Total + "|" + GetNumFromBox(o1) + "|"
                        + GetNumFromBox(o2) + "|" + GetNumFromBox(o3) + "|"
                        + GetNumFromBox(o4));
                    break;
                case 16:
                    writer.WriteLine
                        (wave16Total + "|" + GetNumFromBox(p1) + "|"
                        + GetNumFromBox(p2) + "|" + GetNumFromBox(p3) + "|"
                        + GetNumFromBox(p4));
                    break;
                case 17:
                    writer.WriteLine
                        (wave17Total + "|" + GetNumFromBox(q1) + "|"
                        + GetNumFromBox(q2) + "|" + GetNumFromBox(q3) + "|"
                        + GetNumFromBox(q4));
                    break;
                case 18:
                    writer.WriteLine
                        (wave18Total + "|" + GetNumFromBox(r1) + "|"
                        + GetNumFromBox(r2) + "|" + GetNumFromBox(r3) + "|"
                        + GetNumFromBox(r4));
                    break;
                case 19:
                    writer.WriteLine
                        (wave19Total + "|" + GetNumFromBox(s1) + "|"
                        + GetNumFromBox(s2) + "|" + GetNumFromBox(s3) + "|"
                        + GetNumFromBox(a4));
                    break;
                case 20:
                    writer.WriteLine
                        (wave20Total + "|" + GetNumFromBox(t1) + "|"
                        + GetNumFromBox(t2) + "|" + GetNumFromBox(t3) + "|"
                        + GetNumFromBox(t4) + "|" + GetNumFromBox(t5));
                    break;
            }
        }
    }
}
