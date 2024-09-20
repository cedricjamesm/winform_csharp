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
    public partial class Lotto649 : Form
    {
        public Lotto649()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            //Generate rand numbers under image
            Random random = new Random();
            string textToDisplay = "";

            for (int i = 0; i < 7; i++)
            {
                int randomNumber = random.Next(0, 9);
                textToDisplay += randomNumber;
            }
            label3.Text = textToDisplay;
            textToDisplay = "";

            //Generate rand unique numbers in textbox
            int[] numbers = new int[7];
            int index = 0;

            while (index < 7)
            {
                int randomNumber = random.Next(1, 49);

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
            for (int i = 0; i < 7; i++)
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

                textOut.Write("649, ");
                textOut.Write(date.ToString("yyyy/MM/dd h:mm:ss tt") + ", ");
                for (int i = 0; i < 6; i++)
                {
                    textOut.Write(numbers[i] + ", "); //print numbers from array 
                    if(i == 5)
                    {
                        textOut.Write(" Bonus: " + numbers[6]);
                    }
                }

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

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to quit this application?", "Exit?", MessageBoxButtons.YesNo).ToString() == "Yes")
            {
                this.Close(); //closes only the lotto649 form 
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
    }
}
