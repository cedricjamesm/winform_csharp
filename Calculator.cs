using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using static OOP_Final_Project.Calc;

namespace OOP_Final_Project
{       
    public partial class frmCalculator : Form
    {
        private Calc calculator;

        public frmCalculator()
        {
            InitializeComponent();
            calculator = new Calc();
        }
         
        private void btn1_Click(object sender, EventArgs e)
        {
            textBox1.Text += "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            textBox1.Text += "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            textBox1.Text += "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            textBox1.Text += "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            textBox1.Text += "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            textBox1.Text += "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            textBox1.Text += "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            textBox1.Text += "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            textBox1.Text += "9";
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            textBox1.Text += "0";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            decimal displayValue = Convert.ToDecimal(textBox1.Text);
            calculator.Add(displayValue);
            textBox1.Clear();
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            decimal displayValue = Convert.ToDecimal(textBox1.Text);
            calculator.Subtract(displayValue);
            textBox1.Clear();
        }

        private void btnMul_Click(object sender, EventArgs e)
        {
            decimal displayValue = Convert.ToDecimal(textBox1.Text);
            calculator.Multiply(displayValue);
            textBox1.Clear();
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            decimal displayValue = Convert.ToDecimal(textBox1.Text);
            calculator.Divide(displayValue);
            textBox1.Clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
             textBox1.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to quit the Calculator app?", "Exit", MessageBoxButtons.YesNo).ToString() == "Yes")
            {
                this.Close(); //closes calculator form
            }
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            decimal displayValue = Convert.ToDecimal(textBox1.Text);
            calculator.Equals(displayValue);
            textBox1.Text = calculator.CurrentValue.ToString();
            //saves operation to txt file
            string operation = calculator.Operand1 + " " + calculator.Op + " " + calculator.Operand2 + " = " + calculator.CurrentValue;
            calculator.SaveToFile(operation);
        }
        private void btnComma_Click(object sender, EventArgs e)
        {
            textBox1.Text += ".";
        }
    }
}
