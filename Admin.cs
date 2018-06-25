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
    public partial class Admin : Form
    {
        DateTime date = new DateTime(2018, 05, 09);
        public Admin()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Autorization auth = new Autorization();
            auth.Show();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = (date - DateTime.Now).Days + " дней " + (date - DateTime.Now).Hours + " часов и " + (date - DateTime.Now).Minutes + " минут";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainWindow main = new MainWindow();
            this.Hide();
            main.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Inventar inven = new Inventar();
            inven.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            ControlCharity control = new ControlCharity();
            control.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            VolonterControl volunteer = new VolonterControl();
            volunteer.Show();
        }
    }
}
