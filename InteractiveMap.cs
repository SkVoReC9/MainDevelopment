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
    public partial class InteractiveMap : Form
    {
        DateTime date = new DateTime(2018,05,09);
        public InteractiveMap()
        {
            InitializeComponent();
        }

        private void InteractiveMap_Load(object sender, EventArgs e)
        {
            timer1.Start();
            panel3.Visible = false;
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, 36, 33);
            Region rgn = new Region(path);
            pictureBox2.Region = rgn;
            pictureBox3.Region = rgn;
            pictureBox4.Region = rgn;
            button1.Region = rgn;
            button2.Region = rgn;
            button4.Region = rgn;
            button5.Region = rgn;
            button6.Region = rgn;
            button7.Region = rgn;
            button8.Region = rgn;
            button9.Region = rgn;
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            label2.Text = "Race start";
            label4.Text = "Samba Full Marathon";
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;
            pictureBox9.Visible = false;
            label3.Visible = false;
            label5.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            panel3.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
            label5.Visible = true;
            pictureBox5.Visible = true;
            pictureBox6.Visible = true;
            pictureBox7.Visible = true;
            pictureBox8.Visible = true;
            pictureBox9.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
            label11.Visible = true;
            panel3.Visible = true;
            label2.Text = "Checkpoint 1";
            label4.Text = "Avenida Rudge";
            label7.Text = "Drinks";
            label8.Text = "Energy Bars";
            pictureBox5.BackgroundImage = imageList1.Images[0];
            pictureBox9.BackgroundImage = imageList1.Images[1];
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
            label5.Visible = true;
            pictureBox5.Visible = true;
            pictureBox6.Visible = true;
            pictureBox7.Visible = true;
            pictureBox8.Visible = true;
            pictureBox9.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
            label11.Visible = true;
            panel3.Visible = true;
            label2.Text = "Checkpoint 2";
            label4.Text = "Theatro Municipal";
            label7.Text = "Drinks";
            label8.Text = "Energy Bars";
            label9.Text = "Toilets";
            label10.Text = "Information";
            label11.Text = "Medical";
            pictureBox5.BackgroundImage = imageList1.Images[0];
            pictureBox9.BackgroundImage = imageList1.Images[1];
            pictureBox8.BackgroundImage = imageList1.Images[4];
            pictureBox7.BackgroundImage = imageList1.Images[2];
            pictureBox6.BackgroundImage = imageList1.Images[3];

        }

        private void button4_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
            label5.Visible = true;
            pictureBox5.Visible = true;
            pictureBox6.Visible = true;
            pictureBox7.Visible = true;
            pictureBox8.Visible = true;
            pictureBox9.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
            label11.Visible = true;
            panel3.Visible = true;
            label2.Text = "Checkpoint 3";
            label4.Text = "Parque do Ibirapuera";
            label7.Text = "Drinks";
            label8.Text = "Energy Bars";
            label9.Text = "Toilets";
            pictureBox5.BackgroundImage = imageList1.Images[0];
            pictureBox9.BackgroundImage = imageList1.Images[1];
            pictureBox8.BackgroundImage = imageList1.Images[4];
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
            label5.Visible = true;
            pictureBox5.Visible = true;
            pictureBox6.Visible = true;
            pictureBox7.Visible = true;
            pictureBox8.Visible = true;
            pictureBox9.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
            label11.Visible = true;
            panel3.Visible = true;
            label2.Text = "Checkpoint 4";
            label4.Text = "Jardim Luzitania";
            label7.Text = "Drinks";
            label8.Text = "Energy Bars";
            label9.Text = "Toilets";
            label10.Text = "Medical";
            pictureBox5.BackgroundImage = imageList1.Images[0];
            pictureBox9.BackgroundImage = imageList1.Images[1];
            pictureBox8.BackgroundImage = imageList1.Images[4];
            pictureBox7.BackgroundImage = imageList1.Images[3];
            pictureBox6.Visible = false;
            label11.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
            label5.Visible = true;
            pictureBox5.Visible = true;
            pictureBox6.Visible = true;
            pictureBox7.Visible = true;
            pictureBox8.Visible = true;
            pictureBox9.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
            label11.Visible = true;
            panel3.Visible = true;
            label2.Text = "Checkpoint 5";
            label4.Text = "Iguatemi";
            label7.Text = "Drinks";
            label8.Text = "Energy Bars";
            label9.Text = "Toilets";
            label10.Text = "Information";
            pictureBox5.BackgroundImage = imageList1.Images[0];
            pictureBox9.BackgroundImage = imageList1.Images[1];
            pictureBox8.BackgroundImage = imageList1.Images[4];
            pictureBox7.BackgroundImage = imageList1.Images[2];
            pictureBox6.Visible = false;
            label11.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
            label5.Visible = true;
            pictureBox5.Visible = true;
            pictureBox6.Visible = true;
            pictureBox7.Visible = true;
            pictureBox8.Visible = true;
            pictureBox9.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
            label11.Visible = true;
            panel3.Visible = true;
            label2.Text = "Checkpoint 6";
            label4.Text = "Rua Lisboa";
            label7.Text = "Drinks";
            label8.Text = "Energy Bars";
            label9.Text = "Toilets";
            pictureBox5.BackgroundImage = imageList1.Images[0];
            pictureBox9.BackgroundImage = imageList1.Images[1];
            pictureBox8.BackgroundImage = imageList1.Images[4];
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
            label5.Visible = true;
            pictureBox5.Visible = true;
            pictureBox6.Visible = true;
            pictureBox7.Visible = true;
            pictureBox8.Visible = true;
            pictureBox9.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
            label11.Visible = true;
            panel3.Visible = true;
            label2.Text = "Checkpoint 7";
            label4.Text = "Cemitério da Consolação";
            label7.Text = "Drinks";
            label8.Text = "Energy Bars";
            label9.Text = "Toilets";
            label10.Text = "Information";
            label11.Text = "Medical";
            pictureBox5.BackgroundImage = imageList1.Images[0];
            pictureBox9.BackgroundImage = imageList1.Images[1];
            pictureBox8.BackgroundImage = imageList1.Images[4];
            pictureBox7.BackgroundImage = imageList1.Images[2];
            pictureBox6.BackgroundImage = imageList1.Images[3];
        }

        private void button9_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
            label5.Visible = true;
            pictureBox5.Visible = true;
            pictureBox6.Visible = true;
            pictureBox7.Visible = true;
            pictureBox8.Visible = true;
            pictureBox9.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
            label11.Visible = true;
            panel3.Visible = true;
            label2.Text = "Checkpoint 8";
            label4.Text = "Cemitério da Consolação";
            label7.Text = "Drinks";
            label8.Text = "Energy Bars";
            label9.Text = "Toilets";
            label10.Text = "Information";
            label11.Text = "Medical";
            pictureBox5.BackgroundImage = imageList1.Images[0];
            pictureBox9.BackgroundImage = imageList1.Images[1];
            pictureBox8.BackgroundImage = imageList1.Images[4];
            pictureBox7.BackgroundImage = imageList1.Images[2];
            pictureBox6.BackgroundImage = imageList1.Images[3];
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            label2.Text = "Race start";
            label4.Text = "Jongo Half Marathon";
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;
            pictureBox9.Visible = false;
            label3.Visible = false;
            label5.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            panel3.Visible = true;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            label2.Text = "Race start";
            label4.Text = "Capoeira 5km Fun Run";
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;
            pictureBox9.Visible = false;
            label3.Visible = false;
            label5.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            panel3.Visible = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label6.Text = (date - DateTime.Now).Days + " дней " + (date - DateTime.Now).Hours + " часов и " + (date - DateTime.Now).Minutes + " минут";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            MarathonMoreInfo marathon = new MarathonMoreInfo();
            marathon.Show();
        }
    }
}
