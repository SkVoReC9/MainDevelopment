using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace MSkils2018
{
    public partial class Autorization : Form
    {
       static public string RunId,Email;
        DateTime date = new DateTime(2018, 05, 09);
        bool prov,prov1 = false;
        SqlConnection sqlconn;
        string connection = @"Data Source=DESKTOP-5Q15QCU;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        
        public Autorization()
        {
            InitializeComponent();
        }

        private void Autorization_Load(object sender, EventArgs e)
        {
            timer1.Start();
            textBox1.Clear();
            textBox2.Clear();
            prov = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            sqlconn = new SqlConnection(connection);
            sqlconn.Open();
            SqlDataReader sqlread;
            SqlCommand select = new SqlCommand("use MSSKills2018 select [User].Email,Password,RunnerId,RoleId from [User] inner join Runner on Runner.Email = [User].Email", sqlconn);
            sqlread = select.ExecuteReader();

            while (sqlread.Read())
            {
                if (textBox1.Text == sqlread["Email"].ToString())
                {
                    prov1 = true;
                    if (sqlread["Password"].ToString() == textBox2.Text)
                    {
                        prov = true;
                        if (sqlread["RoleId"].ToString() == "R")
                        {
                            Email = textBox1.Text;
                            RunId = sqlread["RunnerID"].ToString();
                            this.Hide();                         
                            RunnerMenu run = new RunnerMenu();
                            run.Show();
                        }
                        if (sqlread["RoleId"].ToString() == "C")
                        {
                            this.Hide();
                            Coordinator coor = new Coordinator();
                            coor.Show();
                        }
                        if (sqlread["RoleId"].ToString() == "A")
                        {
                            this.Hide();
                            Admin adm = new Admin();
                            adm.Show();                            
                        }
                    }      
                }                
            }
            if (prov1 == false)
            {
                MessageBox.Show("Такого email не существует");
            }
            if (prov1 == true && prov == false)
            {
                MessageBox.Show("Вы ввели непраильный пароль");
                textBox2.Text = "";
            }

            sqlconn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainWindow main = new MainWindow();
            main.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label6.Text = (date - DateTime.Now).Days + " дней " + (date - DateTime.Now).Hours + " часов и " + (date - DateTime.Now).Minutes + " минут";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainWindow main = new MainWindow();
            main.Show();
        }
    }
}
