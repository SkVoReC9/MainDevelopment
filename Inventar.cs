using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
namespace MSkils2018
{
    public partial class Inventar : Form
    {
        public string[] A = new string[10];
        SqlConnection sqlconn;
        string connection = @"Data Source=DESKTOP-5Q15QCU;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        DateTime date = new DateTime(2018,05,09);
        public Inventar()
        {
            InitializeComponent();
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
            Admin admin = new Admin();
            admin.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label16.Text = (date - DateTime.Now).Days + " дней " + (date - DateTime.Now).Hours + " часов и " + (date - DateTime.Now).Minutes + " минут";
        }

        private void Inventar_Load(object sender, EventArgs e)
        {
            
            timer1.Start();
            sqlconn = new SqlConnection(connection);
            sqlconn.Open();
            SqlDataReader sqlread;
            SqlCommand select = new SqlCommand("use MSSkills2018 select Count(*) as 'A' from Registration inner join RegistrationEvent on Registration.RegistrationId = RegistrationEvent.RegistrationId inner join [Event] on RegistrationEvent.EventId = [Event].EventId inner join Marathon on [Event].MarathonId = Marathon.MarathonId  where MarathonName = 'Marathon Skills 2015' and RaceKitOptionId = 'A'", sqlconn);
            sqlread = select.ExecuteReader();
            while (sqlread.Read())
            {
                label47.Text = sqlread["A"].ToString();
            }
            sqlread.Close();
            SqlCommand select1 = new SqlCommand("use MSSkills2018 select Count(*) as 'B' from Registration inner join RegistrationEvent on Registration.RegistrationId = RegistrationEvent.RegistrationId inner join [Event] on RegistrationEvent.EventId = [Event].EventId inner join Marathon on [Event].MarathonId = Marathon.MarathonId  where MarathonName = 'Marathon Skills 2015' and RaceKitOptionId = 'B'", sqlconn);
            sqlread = select1.ExecuteReader();
            while (sqlread.Read())
            {
                label48.Text = sqlread["B"].ToString();
            }
            sqlread.Close();
            SqlCommand select2 = new SqlCommand("use MSSkills2018 select Count(*) as 'C' from Registration inner join RegistrationEvent on Registration.RegistrationId = RegistrationEvent.RegistrationId inner join [Event] on RegistrationEvent.EventId = [Event].EventId inner join Marathon on [Event].MarathonId = Marathon.MarathonId  where MarathonName = 'Marathon Skills 2015' and RaceKitOptionId = 'C'", sqlconn);
            sqlread = select2.ExecuteReader();
            while (sqlread.Read())
            {
                label44.Text = sqlread["C"].ToString();
            }
            sqlread.Close();
            label10.Text = label47.Text;
            label11.Text = label48.Text;
            label12.Text = label44.Text;
            label15.Text = label47.Text;
            label17.Text = label48.Text;
            label18.Text = label44.Text;
            label21.Text = label48.Text;
            label22.Text = label44.Text;
            label25.Text = label48.Text;
            label26.Text = label44.Text;
            label29.Text = label44.Text;
            label32.Text = label44.Text;
            label45.Text = Convert.ToString(Convert.ToInt16(label47.Text) + Convert.ToInt16(label48.Text) + Convert.ToInt16(label44.Text));
            label13.Text = Convert.ToString(Convert.ToInt16(label10.Text) + Convert.ToInt16(label11.Text) + Convert.ToInt16(label12.Text));
            label19.Text = Convert.ToString(Convert.ToInt16(label15.Text) + Convert.ToInt16(label17.Text) + Convert.ToInt16(label18.Text));
            label23.Text = Convert.ToString(Convert.ToInt16(label21.Text) + Convert.ToInt16(label22.Text));
            label27.Text = Convert.ToString(Convert.ToInt16(label25.Text) + Convert.ToInt16(label26.Text));
            label30.Text = label26.Text;
            label33.Text = label32.Text;
            for (int i = 1; i <= 6; i++)
            {
                SqlCommand select3 = new SqlCommand("use MSSkills2018 select TovarNumber from Inventar where TovarId = '" + i + "'", sqlconn);
                sqlread = select3.ExecuteReader();
                while (sqlread.Read())
                {
                    A[i] = sqlread["TovarNumber"].ToString();
                }
                sqlread.Close();
            }
            label14.Text = A[1];
            label20.Text = A[2];
            label24.Text = A[3];
            label28.Text = A[4];
            label31.Text = A[5];
            label34.Text = A[6];
            SqlCommand select4 = new SqlCommand("use MSSkills2018 select Count(*) as 'Mar' from Registration inner join RegistrationEvent on Registration.RegistrationId = RegistrationEvent.RegistrationId inner join [Event] on RegistrationEvent.EventId = [Event].EventId inner join Marathon on [Event].MarathonId = Marathon.MarathonId  where EventName= 'Capoeira 5km Fun Run' or EventName= 'Samba Full Marathon' or EventName= 'Jongo Half Marathon'", sqlconn);
            sqlread = select4.ExecuteReader();
            while (sqlread.Read())
            {
                label7.Text = "Всего зарегистрированного  на марафон: "+sqlread["Mar"];
            }
            sqlread.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            InventarControl inventcont = new InventarControl();
            inventcont.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            InventarOtchet otchet = new InventarOtchet();
            for (int i = 0; i <= 5; i++)
            {
                otchet.dataGridView1.Rows.Add();
            }

            otchet.dataGridView1.Rows[0].Cells[1].Value = A[1];
            otchet.dataGridView1.Rows[1].Cells[1].Value = A[2];
            otchet.dataGridView1.Rows[2].Cells[1].Value = A[3];
            otchet.dataGridView1.Rows[3].Cells[1].Value = A[4];
            otchet.dataGridView1.Rows[4].Cells[1].Value = A[5];
            otchet.dataGridView1.Rows[5].Cells[1].Value = A[6];

            otchet.dataGridView1.Rows[0].Cells[2].Value = label13.Text;
            otchet.dataGridView1.Rows[1].Cells[2].Value = label19.Text;
            otchet.dataGridView1.Rows[2].Cells[2].Value = label23.Text;
            otchet.dataGridView1.Rows[3].Cells[2].Value = label27.Text;
            otchet.dataGridView1.Rows[4].Cells[2].Value = label30.Text;
            otchet.dataGridView1.Rows[5].Cells[2].Value = label33.Text;

            otchet.dataGridView1.Rows[0].Cells[0].Value = label3.Text;
            otchet.dataGridView1.Rows[1].Cells[0].Value = label4.Text;
            otchet.dataGridView1.Rows[2].Cells[0].Value = label5.Text;
            otchet.dataGridView1.Rows[3].Cells[0].Value = label6.Text;
            otchet.dataGridView1.Rows[4].Cells[0].Value = label8.Text;
            otchet.dataGridView1.Rows[5].Cells[0].Value = label9.Text;

            for(int i =0;i<=5;i++)
            {
                if(Convert.ToInt16(otchet.dataGridView1.Rows[i].Cells[1].Value) >= Convert.ToInt16(otchet.dataGridView1.Rows[i].Cells[2].Value))
                {
                    otchet.dataGridView1.Rows[i].Cells[3].Value = 0;
                }
                else otchet.dataGridView1.Rows[i].Cells[3].Value = Convert.ToInt16(otchet.dataGridView1.Rows[i].Cells[2].Value) - Convert.ToInt16(otchet.dataGridView1.Rows[i].Cells[1].Value);
            }
            otchet.Show();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
