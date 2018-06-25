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
    public partial class MainWindow : Form
    {
        DateTime date = new DateTime(2018, 05, 09);
        public MainWindow()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            RunnerCheck check = new RunnerCheck();
            check.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Sponsor spons = new Sponsor();
            spons.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            MoreInfo more = new MoreInfo();
            more.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label6.Text = (date - DateTime.Now).Days + " дней " + (date - DateTime.Now).Hours + " часов и " + (date - DateTime.Now).Minutes + " минут";
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Autorization auth = new Autorization();
            auth.Show();
        }
    }
}
