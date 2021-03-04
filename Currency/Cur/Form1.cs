using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cur
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        const double k = 0.05;
        public double USD = 1000;
        public double BTC = 0;
        private void btStart_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            double rate = (double)edRate.Value;
            int days = (int)edDays.Value;
            chart1.Series[0].Points.Clear();
            chart1.Series[0].Points.AddXY(0, rate);

            for (int i = 1; i <= days; i++)
            {
                rate = rate * (1 + k * (random.NextDouble() - 0.5));
                edRate.Value = (decimal)rate;
                chart1.Series[0].Points.AddXY(i, rate);
            }
        }

        private void buttonBuy_Click(object sender, EventArgs e)
        {
            double amount = (double)edAmount.Value;
            double rate = (double)edRate.Value;
            double jojo = rate * amount;
            if (jojo<=USD)
            {
                USD -= jojo;
                BTC += amount;
            }
            labBTC.Text = "BTC: " + BTC;
            labDollars.Text = "USD: " + USD;
        }

        private void buttonSell_Click(object sender, EventArgs e)
        {
            double amount = (double)edAmount.Value;
            double rate = (double)edRate.Value;
            double jojo = amount;
            if (jojo <= BTC)
            {
                BTC -= amount;
                USD += amount*rate;
            }
            labBTC.Text = "BTC: " + BTC;
            labDollars.Text = "USD: " + USD;
        }
    }
}
