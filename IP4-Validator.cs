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
using System.Diagnostics;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OOP_Final_Project
{
    public partial class IP4_Validator : Form
    {
        public IP4_Validator()
        {
            InitializeComponent();
        }

        private DateTime formLoadTime;

        private void IP4_Validator_Load(object sender, EventArgs e)
        {
            // Get the current date and time
            DateTime currentDate = DateTime.Now;
            formLoadTime = DateTime.Now;

            // Display the current date in long format
            label1.Text = "Today: " + currentDate.ToLongDateString();
            
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            // Get the IP4 address from the textbox
            string IPAddress = textBox1.Text.Trim();

            // Validate the IP4 address using Regular Expressions
            if (Regex.IsMatch(IPAddress, @"^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$"))
            {              
                MessageBox.Show(IPAddress + "\nThis IP Address is valid!", "Valid IP");
            }
            else
            {
                // Display an error message if the IP4 address is invalid
                MessageBox.Show("The IP must have 4 bytes\nInteger number between 0 to 255\nseparated by a dot (255.255.255.255)", "Error");
                textBox1.Clear();
                textBox1.Focus();
            }

            string pathBinary = @".\Files\IPAddress.dat";
            FileStream fs = null;
            try
            {
                // create the output stream for a binary file that exists
                fs = new FileStream(pathBinary, FileMode.Append, FileAccess.Write);
                BinaryWriter binaryOut = new BinaryWriter(fs);
                DateTime date = DateTime.Now;

                // write the fields into binary file
                binaryOut.Write(textBox1.Text.Trim());
                binaryOut.Write(date.ToString(", yyyy/MM/dd h:mm:ss tt"));

                // close the output stream for the binary file
                binaryOut.Close();

            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message, "IOException");
                textBox1.Clear();
                textBox1.Focus();
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to quit the IP4 Validator app?", "Exit", MessageBoxButtons.YesNo).ToString() == "Yes")
            {
                // Get the current date and time
                DateTime formClosingTime = DateTime.Now;

                // Calculate the total time in seconds and minutes 
                TimeSpan totalTime = formClosingTime - formLoadTime;
                int totalSeconds = (int)totalTime.Seconds;
                int totalMinutes = (int)totalTime.TotalMinutes;

                // Display the total time in seconds and minutes
                MessageBox.Show("You used the form for " + totalSeconds + " second(s) " + "( " + totalMinutes + " minutes ).", "Total Time");
                this.Close();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Focus();
        }
    }
}