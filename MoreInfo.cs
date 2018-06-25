using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSkils2018
{
    public partial class MoreInfo : Form
    {
        DateTime date = new DateTime(2018,05,09);
        public MoreInfo()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainWindow main = new MainWindow();
            main.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            SpisokBlag spisok = new SpisokBlag();
            spisok.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label6.Text = (date - DateTime.Now).Days + " дней " + (date - DateTime.Now).Hours + " часов и " + (date - DateTime.Now).Minutes + " минут";
        }

        private void MoreInfo_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MarathonMoreInfo martinfo = new MarathonMoreInfo();
            martinfo.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            HowLongMarathon howlong = new HowLongMarathon();
            howlong.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            BMICalc bmi = new BMICalc();
            bmi.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            BMRcalc bmr = new BMRcalc();
            bmr.Show();
        }
    }
}
