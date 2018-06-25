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
    public partial class MySponsor : Form
    {
        SqlConnection sqlconn;
        string connection = @"Data Source=DESKTOP-5Q15QCU;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        DateTime date = new DateTime(2018, 05, 09);
        public MySponsor()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label16.Text = (date - DateTime.Now).Days + " дней " + (date - DateTime.Now).Hours + " часов и " + (date - DateTime.Now).Minutes + " минут";
        }

        private void MySponsor_Load(object sender, EventArgs e)
        {
            decimal money = 0;
            int i = 0;
            timer1.Start();
            sqlconn = new SqlConnection(connection);
            sqlconn.Open();
            SqlDataReader sqlread;
            SqlCommand selectGender = new SqlCommand("select RunnerId,CharityName,CharityDescription,CharityLogo,SponsorName,Amount from Registration inner join Charity on Registration.CharityId = Charity.CharityId inner join Sponsorship on Registration.RegistrationId = Sponsorship.RegistrationId where RunnerId = '"+Autorization.RunId+"'", sqlconn);
            sqlread = selectGender.ExecuteReader();
            while (sqlread.Read())
            {
                dataGridView1.Rows.Add();
                label1.Text = sqlread["CharityName"].ToString();
                textBox1.Text = sqlread["CharityDescription"].ToString();
             // pictureBox1.BackgroundImage = Image.FromFile(@"C:\Users\Roman\Desktop\ТРПО Шимбирев\d\" + sqlread["CharityLogo"]);
                dataGridView1.Rows[i].Cells[0].Value = sqlread["SponsorName"];
                dataGridView1.Rows[i].Cells[1].Value = sqlread["Amount"];
                i++;
            }
            sqlread.Close();
            for (int i1 = 0;i1<dataGridView1.Rows.Count;i1++)
            {
                money += (decimal)dataGridView1.Rows[i1].Cells[1].Value;
            }
            label5.Text += money.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Autorization auth = new Autorization();
            auth.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            RunnerMenu runmen = new RunnerMenu();
            runmen.Show();
        }
    }
}
