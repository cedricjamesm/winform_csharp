using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_Final_Project
{
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
        }

        private void btnLottoMax_Click(object sender, EventArgs e)
        {
            LottoMax obj = new LottoMax();
            obj.Show();
        }

        private void btnLotto649_Click(object sender, EventArgs e)
        {
            Lotto649 obj = new Lotto649();
            obj.Show();
        }

        private void btnMoneyExchange_Click(object sender, EventArgs e)
        {
            MoneyEx obj = new MoneyEx();
            obj.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to exit the Dashboard?", "Exit", MessageBoxButtons.YesNo).ToString() == "Yes")
            {
                Application.Exit();
            }
        }

        private void btnTempConvert_Click(object sender, EventArgs e)
        {
            TempConv obj = new TempConv();
            obj.Show();
        }

        private void pictureBoxCalculator_Click(object sender, EventArgs e)
        {
            frmCalculator obj = new frmCalculator();
            obj.Show();
        }

        private void pictureBoxIPValidator_Click(object sender, EventArgs e)
        {
            IP4_Validator obj = new IP4_Validator();
            obj.Show();
        }
    }
}
