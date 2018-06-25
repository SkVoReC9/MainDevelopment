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
    public partial class RunnerMenu : Form
    {
        DateTime date = new DateTime(2018, 05, 09);
        public RunnerMenu()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Contacts contact = new Contacts();
            contact.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Autorization auth = new Autorization();
            auth.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label6.Text = (date - DateTime.Now).Days + " дней " + (date - DateTime.Now).Hours + " часов и " + (date - DateTime.Now).Minutes + " минут";
        }

        private void RunnerMenu_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainWindow main = new MainWindow();
            main.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegistrationEvent regEvent = new RegistrationEvent();
            regEvent.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditRunner editrun = new EditRunner();
            editrun.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            ResultsRunner result = new ResultsRunner();
            result.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            MySponsor myspons = new MySponsor();
            myspons.Show();
        }
    }
}
