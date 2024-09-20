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
    public partial class MoneyEx : Form
    {
        private DateTime formLoadTime;
        public MoneyEx()
        {
            InitializeComponent();
            formLoadTime = DateTime.Now;
        }

        /*exchange rate 03/20/2023
         * 100 CAD = 73.17 USD
         * 100 CAD = 68.24 EUR
         * 100 CAD = 59.59 GBP
         * 100 CAD = 3969.34 PHP
         * ---------------------
         * 100 USD = 136.67 CAD
         * 100 USD = 93.25 EUR
         * 100 USD = 81.45 GBP
         * 100 USD = 5425 PHP
         * --------------------
         * 100 EUR = 146.55 CAD
         * 100 EUR = 107.23 USD
         * 100 EUR = 87.33 GBP
         * 100 EUR = 5816.79 PHP
         * --------------------
         * 100 GBP = 122.78 USD
         * 100 GBP = 167.81 CAD
         * 100 GBP = 114.51 EUR
         * 100 GBP = 6660.30 PHP
         * --------------------
         * 100 PHP = 2.52 CAD
         * 100 PHP = 1.84 USD
         * 100 PHP = 1.72 EUR
         * 100 PHP = 1.50 GBP
         */
           // Define exchange rates
        private const double CADtoUSD = 0.7317;
        private const double CADtoEUR = 0.6824;
        private const double CADtoGBP = 0.5959;
        private const double CADtoPHP = 39.6934;

        private const double USDtoCAD = 1.3667;
        private const double USDtoEUR = 0.9325;
        private const double USDtoGBP = 0.8145;
        private const double USDtoPHP = 54.25;

        private const double EURtoCAD = 1.4655;
        private const double EURtoUSD = 1.0723;
        private const double EURtoGBP = 0.8733;
        private const double EURtoPHP = 58.1679;

        private const double GBPtoUSD = 1.2278;
        private const double GBPtoCAD = 1.6781;
        private const double GBPtoEUR = 1.1451;
        private const double GBPtoPHP = 66.603;

        private const double PHPtoCAD = 0.0252;
        private const double PHPtoUSD = 0.0184;
        private const double PHPtoEUR = 0.0172;
        private const double PHPtoGBP = 0.0150;

        private void btnConvert_Click(object sender, EventArgs e)
        {
            double amount = 0;
            string fromCurrency = "";
            string toCurrency = ""; 

            //try/catch if user enters invalid amount 
            try
            {
                amount = Convert.ToDouble(textBox1.Text);
                if (amount < 0)
                {
                    MessageBox.Show("Please enter a positive amount", "Error");
                    textBox1.Clear();
                    textBox2.Clear();
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Invalid amount entered", "Error");
                textBox1.Clear();
                textBox2.Clear();
                return;
            }
            

            if (radioButtonCAD.Checked) //converting from CAD
            {
                fromCurrency = "CAD";
                if (radioButtonUSD2.Checked)
                {
                    amount *= CADtoUSD;
                    toCurrency = "USD";
                }
                else if (radioButtonEUR2.Checked)
                {
                    amount *= CADtoEUR;
                    toCurrency = "EUR";
                }
                else if (radioButtonGBP2.Checked)
                {
                    amount *= CADtoGBP;
                    toCurrency = "GBP";
                }
                else if (radioButtonPHP2.Checked)
                {
                    amount *= CADtoPHP;
                    toCurrency = "PHP";
                }
            }
            else if (radioButtonUSD.Checked) //converting from USD
            {
                fromCurrency = "USD";
                if (radioButtonCAD2.Checked)
                {
                    amount *= USDtoCAD;
                    toCurrency = "CAD";
                }
                else if (radioButtonEUR2.Checked)
                {
                    amount *= USDtoEUR;
                    toCurrency = "EUR";
                }
                else if (radioButtonGBP2.Checked)
                {
                    amount *= USDtoGBP;
                    toCurrency = "GBP";
                }
                else if (radioButtonPHP2.Checked)
                {
                    amount *= USDtoPHP;
                    toCurrency = "PHP";
                }
            }
            else if (radioButtonEUR.Checked) //converting from EUR
            {
                fromCurrency = "EUR";
                if (radioButtonCAD2.Checked)
                {
                    amount *= EURtoCAD;
                    toCurrency = "CAD";
                }
                else if (radioButtonUSD2.Checked)
                {
                    amount *= EURtoUSD;
                    toCurrency = "USD";
                }
                else if (radioButtonGBP2.Checked)
                {
                    amount *= EURtoGBP;
                    toCurrency = "GBP";
                }
                else if (radioButtonPHP2.Checked)
                {
                    amount *= EURtoPHP;
                    toCurrency = "PHP";

                }
            }
            else if (radioButtonGBP.Checked) //converting from GBP
            {
                fromCurrency = "GBP";
                if (radioButtonCAD2.Checked)
                {
                    amount *= GBPtoCAD;
                    toCurrency = "CAD";
                }
                else if (radioButtonUSD2.Checked)
                {
                    amount *= GBPtoUSD;
                    toCurrency = "USD";
                }
                else if (radioButtonEUR2.Checked)
                {
                    amount *= GBPtoEUR;
                    toCurrency = "EUR";
                }
                else if (radioButtonPHP2.Checked)
                {
                    amount *= GBPtoPHP;
                    toCurrency = "PHP";
                }
            }
            else if (radioButtonPHP.Checked) //converting from PHP
            {
                fromCurrency = "PHP";
                if (radioButtonCAD2.Checked)
                {
                    amount *= PHPtoCAD;
                    toCurrency = "CAD";
                }
                else if (radioButtonUSD2.Checked)
                {
                    amount *= PHPtoUSD;
                    toCurrency = "USD";
                }
                else if (radioButtonEUR2.Checked)
                {
                    amount *= PHPtoEUR;
                    toCurrency = "EUR";
                }
                else if (radioButtonGBP2.Checked)
                {
                    amount *= PHPtoGBP;
                    toCurrency = "GBP";
                }
            }
            textBox2.Text = amount.ToString("F2"); //F2 displays only 2 numbers after the decimal

            // Save the conversions to a file
            string filePath = @".\Files\MoneyEx.txt";
            DateTime date = DateTime.Now;

            FileStream fs = null;
            try
            {
                fs = new FileStream(filePath, FileMode.Append, FileAccess.Write);
                // create the output stream for a text file that exists
                StreamWriter textOut = new StreamWriter(fs);
                // write the fields into text file

                textOut.Write(textBox1.Text + " "   + fromCurrency + " = " + textBox2.Text + " " +  toCurrency);
                textOut.Write(date.ToString(", yyyy/MM/dd h:mm:ss tt"));
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
            if (MessageBox.Show("Do you want to quit the Money Exchange app?", "Exit", MessageBoxButtons.YesNo).ToString() == "Yes")
            {
                DateTime formClosingTime = DateTime.Now;

                // Calculate the total time in seconds and minutes
                TimeSpan totalTime = formClosingTime - formLoadTime; 
                int totalSeconds = (int)totalTime.Seconds;
                int totalMinutes = (int)totalTime.TotalMinutes;
                MessageBox.Show("You used the form for " + totalSeconds + " second(s) " + "( " + totalMinutes + " minutes ).", "Total Time");
                this.Close();
            }
        }

        private void btnReadFile_Click(object sender, EventArgs e)
        {
            string filePath = @".\Files\MoneyEx.txt";
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
                MessageBox.Show(fileContent, "Money Conversions");
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message, "IOException");
            }
        }

        private void MoneyEx_Load(object sender, EventArgs e)
        {

        }
    }
}
