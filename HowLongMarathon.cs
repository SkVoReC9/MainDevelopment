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
    public partial class HowLongMarathon : Form
    {
        string name,dlina;
        double length, del;
        DateTime date = new DateTime(2018,05,09);
        public HowLongMarathon()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label16.Text = (date - DateTime.Now).Days + " дней " + (date - DateTime.Now).Hours + " часов и " + (date - DateTime.Now).Minutes + " минут";
        }

        private void HowLongMarathon_Load(object sender, EventArgs e)
        {
            timer1.Start();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MoreInfo more = new MoreInfo();
            more.Show();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            pictureBox11.BackgroundImage = pictureBox10.BackgroundImage;
           
            length = 73;
            name = "Airbus A380";
            del = Math.Round(42000 / length);
            dlina = "Длина " + name + " " + length + " m .Это займет " + del + " из них, чтобы покрыть расстояние в 42 км марафона";
            label14.Text = dlina;
            label13.Text = name;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            pictureBox11.BackgroundImage = pictureBox9.BackgroundImage;
            length = 0.245;
            name = "Pair of Havaianas";
            del =Math.Round(42000 / length);
            dlina = "Длина " + name + " " + length + " m .Это займет " + del + " из них, чтобы покрыть расстояние в 42 км марафона";
            label14.Text = dlina;
            label13.Text = name;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            pictureBox11.BackgroundImage = pictureBox8.BackgroundImage;
            length = 105;
            name = "FootballField";
            del = Math.Round(42000 / length);
            dlina = "Длина " + name + " " + length + " m .Это займет " + del + " из них, чтобы покрыть расстояние в 42 км марафона";
            label14.Text = dlina;
            label13.Text = name;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox11.BackgroundImage = pictureBox1.BackgroundImage;
            length = 345;
            name = "F1 Car";
            del = Math.Round(42 / length,2);
            dlina = "Максимальная скорость "+name+" "+length+"км/ч . Это займет "+del+ " часа чтобы завершить 42km марафон ";
            label14.Text = dlina;
            label13.Text = name;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox11.BackgroundImage = pictureBox2.BackgroundImage;
            length = 0.03;
            name = "Worm";
            del = Math.Round(42 / length, 2);
            dlina = "Максимальная скорость " + name + " " + length + "км/ч . Это займет " + del + " часа чтобы завершить 42km марафон ";
            label14.Text = dlina;
            label13.Text = name;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pictureBox11.BackgroundImage = pictureBox3.BackgroundImage;
            length = 0.12;
            name = "Sloth";
            del = Math.Round(42 / length, 2);
            dlina = "Максимальная скорость " + name + " " + length + "км/ч . Это займет " + del + " часа чтобы завершить 42km марафон ";
            label14.Text = dlina;
            label13.Text = name;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pictureBox11.BackgroundImage = pictureBox4.BackgroundImage;
            length = 35;
            name = "Capybara";
            del = Math.Round(42 / length, 2);
            dlina = "Максимальная скорость " + name + " " + length + "км/ч . Это займет " + del + " часа чтобы завершить 42km марафон ";
            label14.Text = dlina;
            label13.Text = name;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            pictureBox11.BackgroundImage = pictureBox5.BackgroundImage;
            length = 80;
            name = "Jaguar";
            del = Math.Round(42 / length, 2);
            dlina = "Максимальная скорость " + name + " " + length + "км/ч . Это займет " + del + " часа чтобы завершить 42km марафон ";
            label14.Text = dlina;
            label13.Text = name;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            pictureBox11.BackgroundImage = pictureBox7.BackgroundImage;
            length = 1.81;
            name = "Ronaldinho";
            del = Math.Round(42000 / length);
            dlina = "Длина " + name + " " + length + " m .Это займет " + del + " из них, чтобы покрыть расстояние в 42 км марафона";
            label14.Text = dlina;
            label13.Text = name;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            pictureBox11.BackgroundImage = pictureBox6.BackgroundImage;
            length = 10;
            name = "Bus";
            del = Math.Round(42000 / length);
            dlina = "Длина " + name + " " + length + " m .Это займет " + del + " из них, чтобы покрыть расстояние в 42 км марафона";
            label14.Text = dlina;
            label13.Text = name;
        }
    }
}
