using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_Final_Project
{
    public partial class TempConv : Form
    {
        public TempConv()
        {
            InitializeComponent();
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            double temp = 0;
            string fromTemp = "";
            string toTemp = "";

            //try/catch if user enters invalid number
            try
            {
                temp = Convert.ToDouble(textBox1.Text);     
            }
            catch
            {
                MessageBox.Show("Invalid number entered", "Error");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                return;
            }

            if(radioButtonCtoF.Checked) //Celcius to Farenheit
            {
                fromTemp = "C";
                toTemp = "F";
                double farenheit = (temp * ( 1.8)) + 32;
                textBox2.Text = farenheit.ToString();
                textBox3.BackColor = Color.Empty;

                if (temp == 100)
                {
                    textBox3.Text = "Water boils";
                    textBox3.BackColor = Color.Red;
                }else if (temp == 40)
                {
                    textBox3.Text = "Hot Bath";
                    textBox3.BackColor = Color.Red;
                }
                else if (temp == 37)
                {
                    textBox3.Text = "Body temperature";
                    textBox3.BackColor = Color.Green;
                }
                else if (temp == 30)
                {
                    textBox3.Text = "Beach weather";
                    textBox3.BackColor = Color.Green;
                }
                else if (temp == 21)
                {
                    textBox3.Text = "Room temperature";
                    textBox3.BackColor = Color.Red;
                }
                else if (temp == 10)
                {
                    textBox3.Text = "Cool day";
                    textBox3.BackColor = Color.Blue;

                }
                else if (temp == 0)
                {
                    textBox3.Text = "Freezing point of water";
                    textBox3.BackColor = Color.Blue;

                }
                else if (temp == -18)
                {
                    textBox3.Text = "Cool day";
                    textBox3.BackColor = Color.Blue;
                }
                else if (temp == -40)
                {
                    textBox3.Text = "Extremely Cold Day \r (and the same number!)";
                    textBox3.BackColor = Color.Blue;
                }
            }

            if (radioButtonFtoC.Checked) //Farenheit to Celcius
            {
                fromTemp = "F";
                toTemp = "C";
                double celcius = (temp - 32) * 5/9;
                textBox2.Text = celcius.ToString();
                textBox3.BackColor = Color.Empty;

                if (temp == 212)
                {
                    textBox3.Text = "Water boils";
                }else if (temp == 104)
                {
                    textBox3.Text = "Hot Bath";
                }else if (temp == 98.6)
                {
                    textBox3.Text = "Body temperature";
                }else if (temp == 86)
                {
                    textBox3.Text = "Beach weather";
                }else if (temp == 70)
                {
                    textBox3.Text = "Room temperature";
                }else if (temp == 50)
                {
                    textBox3.Text = "Cool day";
                }else if (temp == 32)
                {
                    textBox3.Text = "Freezin point of water";
                }else if (temp == -0)
                {
                    textBox3.Text = "Cool day";
                }else if (temp == -40)
                {
                    textBox3.Text = "Extremely Cold Day \r (and the same number!)";
                }
            }

            // Save the conversions to a file
            string filePath = @".\Files\TempConv.txt";
            DateTime date = DateTime.Now;

            FileStream fs = null;
            try
            {
                fs = new FileStream(filePath, FileMode.Append, FileAccess.Write);
                // create the output stream for a text file that exists
                StreamWriter textOut = new StreamWriter(fs);
                // write the fields into text file

                textOut.Write(textBox1.Text + "" + fromTemp + " = " + textBox2.Text + "" + toTemp);
                textOut.Write(date.ToString(", yyyy/MM/dd h:mm:ss tt "));
                textOut.Write(textBox3.Text);
                textOut.WriteLine();

                // close the output stream for the text file
                textOut.Close();
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message, "IOException");
            }
            finally
            {
                if (fs != null) fs.Close();
            }
        }

        private void radioButtonCtoF_CheckedChanged(object sender, EventArgs e)
        {
            //clears both textboxes when swithching from celsius to farenheit 
            label2.Text = "C";
            label3.Text = "F";
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox3.BackColor = Color.Empty;
        }

        private void radioButtonFtoC_CheckedChanged(object sender, EventArgs e)
        {
            //clears both textboxes when swithching from farenheit to celcius 

            label2.Text = "F";
            label3.Text = "C";
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox3.BackColor = Color.Empty;
        }

        private void btnReadFile_Click(object sender, EventArgs e)
        {
            string filePath = @".\Files\TempConv.txt";
            string fileContent = "";

            try
            {
                // Open the text file for reading
                using (StreamReader reader = new StreamReader(filePath))
                {
                    // Read all lines from the file and append them to the fileContent variable
                    while (reader.Peek() != -1)
                    {
                        fileContent += reader.ReadLine() + "\n";
                    }
                }

                // Display the file content in a message box
                MessageBox.Show(fileContent, "Temperature Conversions");
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message, "IOException");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to quit the Temperature Conversion app?", "Exit", MessageBoxButtons.YesNo).ToString() == "Yes")
            {
                this.Close();
            }
        }
    }

}
