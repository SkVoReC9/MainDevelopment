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
    public partial class SpisokBlag : Form
    {
        DateTime date = new DateTime(2018, 05, 09);
        SqlConnection sqlconn;
        string connection = @"Data Source=DESKTOP-5Q15QCU;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public SpisokBlag()
        {
            InitializeComponent();
        }
        private void SpisokBlag_Load(object sender, EventArgs e)
        {
                timer1.Start();
                label1.Text = "Это - список всех благотворительных учреждений, которые поддерживаются в \n Marathon Skills 2016. Спасибо за помощь вы поддерживаете их, спонсируя \n бегунов!";
                sqlconn = new SqlConnection(connection);
                sqlconn.Open();
                SqlDataReader sqlread;
                SqlCommand select = new SqlCommand("Select CharityId,CharityName,CharityDescription, CharityLogo from Charity", sqlconn);
                sqlread = select.ExecuteReader();
                while (sqlread.Read())
                {
                    dataGridView1.Rows.Add();
                    //dataGridView1.Rows[Convert.ToInt16(sqlread["CharityId"])-1].Cells[0].Value = Image.FromFile(@"C:);
                    dataGridView1.Rows[Convert.ToInt16(sqlread["CharityId"]) - 1].Cells[1].Value = sqlread["CharityName"];
                    dataGridView1.Rows[Convert.ToInt16(sqlread["CharityId"]) - 1].Cells[1].Value += "\n"+sqlread["CharityDescription"] +"\n";
                }
                sqlread.Close();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text = (date - DateTime.Now).Days + " дней " + (date - DateTime.Now).Hours + " часов и " + (date - DateTime.Now).Minutes + " минут";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainWindow main = new MainWindow();
            this.Hide();
            main.Show();
        }

       
    }
}
