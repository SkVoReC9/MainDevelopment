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
    public partial class ControlCharity : Form
    {
        static public bool prov;
        static public int index;
        SqlConnection sqlconn;
        string connection = @"Data Source=DESKTOP-5Q15QCU;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        DateTime date = new DateTime(2018, 05, 09);
        public ControlCharity()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label6.Text = (date - DateTime.Now).Days + " дней " + (date - DateTime.Now).Hours + " часов и " + (date - DateTime.Now).Minutes + " минут";
        }

        private void ControlCharity_Load(object sender, EventArgs e)
        {
            try
            {
                timer1.Start();
                sqlconn = new SqlConnection(connection);
                sqlconn.Open();
                SqlDataReader sqlread;
                SqlCommand select = new SqlCommand("Select CharityId,CharityName,CharityDescription, CharityLogo from Charity", sqlconn);
                sqlread = select.ExecuteReader();
                while (sqlread.Read())
                {
                    dataGridView1.Rows.Add();
                    if(sqlread["CharityLogo"].ToString() != "")
                    {
                        dataGridView1.Rows[Convert.ToInt16(sqlread["CharityId"]) - 1].Cells[0].Value = Image.FromFile(@"C:\Users\Roman\Desktop\ТРПО Шимбирев\d\" + sqlread["CharityLogo"].ToString());
                    }
                    else dataGridView1.Rows[Convert.ToInt16(sqlread["CharityId"]) - 1].Cells[0].Value = Image.FromFile(@"C:\Users\Roman\Desktop\ТРПО Шимбирев\d\Null.png");
                    dataGridView1.Rows[Convert.ToInt16(sqlread["CharityId"]) - 1].Cells[1].Value = sqlread["CharityName"];
                    dataGridView1.Rows[Convert.ToInt16(sqlread["CharityId"]) - 1].Cells[2].Value = sqlread["CharityDescription"];
                    dataGridView1.Rows[Convert.ToInt16(sqlread["CharityId"]) - 1].Cells[3].Value = "Edit";
                }
                sqlread.Close();
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditAddCharity editchar = new EditAddCharity();
            editchar.Show();
            prov = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = dataGridView1.CurrentRow.Index+1;
            if (e.ColumnIndex == 3)
            {
                EditAddCharity editchar = new EditAddCharity();
                SqlDataReader sqlread;
                SqlCommand select = new SqlCommand("Select CharityLogo from Charity where CharityId = '"+index+"'", sqlconn);
                sqlread = select.ExecuteReader();
                while (sqlread.Read())
                {
                    editchar.textBox2.Text = sqlread["CharityLogo"].ToString();
                }
                sqlread.Close();
                this.Hide();
                
                editchar.Show();
                editchar.textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                editchar.textBox4.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                editchar.pictureBox1.BackgroundImage = (Image)dataGridView1.CurrentRow.Cells[0].Value;
                prov = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin admin = new Admin();
            admin.Show();
        }
    }
}
