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
    public partial class BMICalc : Form
    {
        double bmi;
        DateTime date = new DateTime(2018, 05, 09);
        bool gender = false;
        public BMICalc()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MoreInfo info = new MoreInfo();
            info.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label16.Text = (date - DateTime.Now).Days + " дней " + (date - DateTime.Now).Hours + " часов и " + (date - DateTime.Now).Minutes + " минут";
        }

        private void BMICalc_Load(object sender, EventArgs e)
        {
            timer1.Start();
            
        }
        private void button3_Click(object sender, EventArgs e)
        {
            gender = true;
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
            if (gender == true)
            {
                double rost = Convert.ToDouble(maskedTextBox1.Text) / 100;
                double ves = Convert.ToDouble(maskedTextBox2.Text);
                if (maskedTextBox1.Text != "" && maskedTextBox2.Text != "")
                {
                    bmi = Math.Round(ves / (rost * rost), 1);
                }
                if (bmi < 18.5)
                {
                    pictureBox1.BackgroundImage = imageList1.Images[3];
                    label10.Text = "Недостаточный";
                    trackBar1.Value = 1;
                }
                if (bmi >= 18.5 && bmi <= 24.9)
                {
                    pictureBox1.BackgroundImage = imageList1.Images[0];
                    label10.Text = "Здоровый";
                    trackBar1.Value = 3;
                }
                if (bmi >= 25 && bmi <= 29.9)
                {
                    pictureBox1.BackgroundImage = imageList1.Images[2];
                    label10.Text = "Избыточный";
                    trackBar1.Value = 5;
                }
                if (bmi >= 30)
                {
                    pictureBox1.BackgroundImage = imageList1.Images[1];
                    label10.Text = "Ожирение";
                    trackBar1.Value = 7;
                }
                
                label9.Text = bmi.ToString();
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }
    }
}
