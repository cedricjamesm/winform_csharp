using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace OOP_Final_Project
{
    public partial class LottoMax : Form
    {
        public LottoMax()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            //Generate rand numbers under image 
            Random random = new Random();
            string textToDisplay = "";

            for (int i = 0; i < 8; i++)
            {
                int randomNumber = random.Next(0, 9);
                textToDisplay += randomNumber;
            }
            label3.Text = textToDisplay;
            textToDisplay = "";

            //Generate rand unique numbers in textbox
            int[] numbers = new int[8];
            int index = 0;

            while (index < 8)
            {
                int randomNumber = random.Next(1, 50);

                // Check if the number is already in the array
                bool numberExists = false;
                for (int i = 0; i < index; i++)
                {
                    if (numbers[i] == randomNumber)
                    {
                        numberExists = true;
                        break;
                    }
                }

                // If the number doesn't exist in the array, add it
                if (!numberExists)
                {
                    numbers[index] = randomNumber;
                    index++;
                }
            }

            // Display the numbers in the array
            for (int i = 0; i < 8; i++)
            {
                textToDisplay += numbers[i] + "\t";
            }

            textBox1.Text = textToDisplay;

            // Save the numbers to a file
            string filePath = @".\Files\LottoNbrs.txt";
            DateTime date = DateTime.Now;

            FileStream fs = null;
            try
            {
                fs = new FileStream(filePath, FileMode.Append, FileAccess.Write);
                // create the output stream for a text file that exists
                StreamWriter textOut = new StreamWriter(fs);
                // write the fields into text file

                textOut.Write("Max, ");
                textOut.Write(date.ToString("yyyy/MM/dd h:mm:ss tt") + ", ");

                for(int i = 0; i < 7; i++)
                {
                    textOut.Write(numbers[i] + ", ");
                    if (i == 6)
                    {
                        textOut.Write(" Bonus: " + numbers[7]);
                    }
                }


                // close the output stream for the text file
                textOut.WriteLine();
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to quit this application?", "Exit?", MessageBoxButtons.YesNo).ToString() == "Yes")
            {
                this.Close(); //closes only the lottomax form 
            }
        }

        private void btnReadFile_Click(object sender, EventArgs e)
        {
            string filePath = @".\Files\LottoNbrs.txt";
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
                MessageBox.Show(fileContent, "Lotto Numbers");
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message, "IOException");
            } 
        }

        private void LottoMax_Load(object sender, EventArgs e)
        {
            
        }
    }
}
