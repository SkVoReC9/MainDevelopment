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
    public partial class BMRcalc : Form
    {
        bool gender;
        DateTime date = new DateTime(2018, 05, 09);
        public BMRcalc()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label16.Text = (date - DateTime.Now).Days + " дней " + (date - DateTime.Now).Hours + " часов и " + (date - DateTime.Now).Minutes + " минут";
        }

        private void BMRcalc_Load(object sender, EventArgs e)
        {
            timer1.Start();
            gender = false;
            label4.ForeColor = Color.LightGray;
            label3.ForeColor = Color.Black;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            LevelActive level = new LevelActive();
            level.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            gender = false;
            label4.ForeColor = Color.LightGray;
            label3.ForeColor = Color.Black;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gender = true;
            label3.ForeColor = Color.LightGray;
            label4.ForeColor = Color.Black;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double bmr;
            double rost = Convert.ToDouble(maskedTextBox1.Text) / 100;
            double ves = Convert.ToDouble(maskedTextBox2.Text);
            double vozrast = Convert.ToDouble(maskedTextBox3.Text);
            if (gender == false)
            {
                bmr =Math.Round( 66 + (13.7 * ves) + (5 * rost) - (6.8 * vozrast));
                label12.Text = bmr.ToString();
                label20.Text = Math.Round(bmr*1.2,3).ToString();
                label24.Text = Math.Round(bmr * 1.375, 3).ToString();
                label23.Text = Math.Round(bmr * 1.55, 3).ToString();
                label22.Text = Math.Round(bmr * 1.725, 3).ToString();
                label21.Text = Math.Round(bmr * 1.9, 3).ToString();
                
            }
            if (gender == true)
            {
                bmr = Math.Round(55 + (9.6*ves) + (1.8*rost) -(4.7*vozrast));
                label12.Text = bmr.ToString();
                label20.Text =  Math.Round(bmr * 1.2, 3).ToString();
                label24.Text = Math.Round(bmr * 1.375, 3).ToString();
                label23.Text = Math.Round(bmr * 1.55, 3).ToString();
                label22.Text = Math.Round(bmr * 1.725, 3).ToString();
                label21.Text = Math.Round(bmr * 1.9, 3).ToString();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MoreInfo more = new MoreInfo();
            more.Show();
        }
    }
}
