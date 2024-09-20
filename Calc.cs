using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_Final_Project
{
    internal class Calc
    {
        private decimal currentValue;
        private decimal operand1;
        private decimal operand2;
        private string op;

        public decimal CurrentValue { get { return currentValue; } }
        public decimal Operand1 { get { return operand1; } }
        public decimal Operand2 { get { return operand2; } }
        public string Op { get { return op; } }

        public Calc()
        {
            currentValue = 0;
            operand1 = 0;
            operand2 = 0;
            op = null;
        }

        public void Add(decimal displayValue)
        {
            operand1 = displayValue;
            currentValue = displayValue;
            op = "+";
        }

        public void Subtract(decimal displayValue)
        {
            operand1 = displayValue;
            currentValue = displayValue;
            op = "-";
        }

        public void Multiply(decimal displayValue)
        {
            operand1 = displayValue;
            currentValue = displayValue;
            op = "*";
        }

        public void Divide(decimal displayValue)
        {
            operand1 = displayValue;
            currentValue = displayValue;
            op = "/";
        }

        public void Equals()
        {
            switch (op)
            {
                case "+":
                    operand1 += operand2;
                    break;
                case "-":
                    operand1 -= operand2;
                    break;
                case "*":
                    operand1 *= operand2;
                    break;
                case "/":
                    if (operand2 != 0)
                    {
                        operand1 /= operand2;
                    }
                    else
                    {
                        MessageBox.Show("Cannot divide by zero!");
                    }
                    break;
                default:
                    break;
            }
            currentValue = operand1;
        }

        public void Equals(decimal displayValue)
        {
            operand2 = displayValue;
            Equals();
        }

        public void Clear()
        {
            currentValue = 0;
            operand1 = 0;
            operand2 = 0;
            op = null;
        }

        public void SaveToFile(string operation)
        {
            string filePath = @".\Files\Calculator.txt";
            FileStream fs = null;

            try
            {
                fs = new FileStream(filePath, FileMode.Append, FileAccess.Write);
                StreamWriter textOut = new StreamWriter(fs);
                textOut.WriteLine(operation);
                textOut.Close();
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (fs != null) fs.Close();
            }
        }
    }
}
