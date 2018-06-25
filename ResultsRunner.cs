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
    public partial class ResultsRunner : Form
    {
        int i = 0;
        SqlConnection sqlconn;
        string connection = @"Data Source=DESKTOP-5Q15QCU;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        DateTime date = new DateTime(2018,05,09);
        public ResultsRunner()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label16.Text = (date - DateTime.Now).Days + " дней " + (date - DateTime.Now).Hours + " часов и " + (date - DateTime.Now).Minutes + " минут";
        }

        private void ResultsRunner_Load(object sender, EventArgs e)
        {
            DateTime datenow = DateTime.Now.Date;
            int h, m, s,min = 0,max = 0;
            int result = 0;
            string gender =null;
            timer1.Start();
            label1.Text = "Это - список всех ваших прошлых результатов гонки для Marathon Skills.Общее место сравнивает всех бегунов.Место по категории compares runners in the same gender and age categories";
            sqlconn = new SqlConnection(connection);
            sqlconn.Open();
            SqlDataReader sqlread;
            SqlCommand select = new SqlCommand("use MSSkills2018 select RunnerId,Gender,DateOfBirth from Runner", sqlconn);
            sqlread = select.ExecuteReader();

            while (sqlread.Read())
            {
                if (Autorization.RunId == sqlread["RunnerId"].ToString())
                {
                    var data = Convert.ToDateTime(sqlread["DateOfBirth"]);
                    var birth = DateTime.Now.Year - Convert.ToDateTime(sqlread["DateOfBirth"]).Year;

                    if (DateTime.Now.Month < data.Month || (DateTime.Now.Month == data.Month && DateTime.Now.Day < data.Day))
                    {
                        birth--;
                    }
                    if (sqlread["Gender"].ToString() == "Male") { gender = "мужской"; }
                    else gender = "женский";
                    if (birth < 18)
                    {
                        label4.Text = "Пол: " + gender + "     Возрастная категория до 18";
                        min = 8;
                        max = 17;
                    }
                    if (birth >= 18 && birth <= 29)
                    {
                        label4.Text = "Пол: " + gender + "     Возрастная категория от 18 до 29";
                        min = 18;
                        max = 29;
                    }
                    if (birth >= 30 && birth <= 39)
                    {
                        label4.Text = "Пол: " + gender + "     Возрастная категория от 30 до 39";
                        min = 30;
                        max = 39;
                    }
                    if (birth >= 40 && birth <= 55)
                    {
                        label4.Text = "Пол: " + gender + "     Возрастная категория от 40 до 55";
                        min = 40;
                        max = 55;
                    }
                    if (birth >= 56 && birth <= 70)
                    {
                        label4.Text = "Пол: " + gender + "     Возрастная категория от 56 до 70";
                        min = 56;
                        max = 70;
                    }
                    if (birth > 70)
                    {
                        label4.Text = "Пол: " + gender + "     Возрастная категория более 70";
                        min = 71;
                        max = 200;
                    }
                }
            }
            sqlread.Close();
            SqlCommand select1 = new SqlCommand("use MSSkills2018 select RunnerId, MarathonName , CityName,EventName,RaceTime from Registration inner join RegistrationEvent on Registration.RegistrationId = RegistrationEvent.RegistrationId inner join [Event] on RegistrationEvent.EventId = [Event].EventId inner join Marathon on [Event].MarathonId = Marathon.MarathonId where MarathonName !='Marathon Skills 2015'", sqlconn);
            sqlread = select1.ExecuteReader();
            while (sqlread.Read())
            {
                if (sqlread["RunnerId"].ToString() == Autorization.RunId)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = sqlread["MarathonName"].ToString() + sqlread["CityName"].ToString();
                    dataGridView1.Rows[i].Cells[1].Value = sqlread["EventName"].ToString();
                    if (sqlread["RaceTime"].ToString() == "")
                    {
                        dataGridView1.Rows[i].Cells[2].Value = "0 часов 0 минут 0 секунд";
                    }
                    else
                    {
                        h = Convert.ToInt16(sqlread["RaceTime"]) / 3600;
                        m = (Convert.ToInt16(sqlread["RaceTime"]) - (h * 3600)) / 60;
                        s = (Convert.ToInt16(sqlread["RaceTime"]) - (h * 3600) - (m * 60));
                        dataGridView1.Rows[i].Cells[2].Value = h + " часа " + m + " минут " + s + " секунд";
                    }
                    i++;
                }
            }
            sqlread.Close();
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                SqlCommand select2 = new SqlCommand("use MSSkills2018 select RunnerId, MarathonName , CityName,EventName,RaceTime from Registration inner join RegistrationEvent on Registration.RegistrationId = RegistrationEvent.RegistrationId inner join [Event] on RegistrationEvent.EventId = [Event].EventId inner join Marathon on [Event].MarathonId = Marathon.MarathonId  where EventName='"+dataGridView1.Rows[i].Cells[1].Value+"' and RaceTime!='0'order by RaceTime", sqlconn);
                sqlread = select2.ExecuteReader();
                while (sqlread.Read())
                {
                    result++;
                    if (sqlread["RunnerId"].ToString() == Autorization.RunId)
                    {
                        dataGridView1.Rows[i].Cells[3].Value = result;
                        result = 0;
                    }
                }
                sqlread.Close();
            }
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                SqlCommand select3 = new SqlCommand("use MSSkills2018 select Registration.RunnerId, MarathonName , CityName,EventName,RaceTime,Gender,DateOfBirth from Runner inner join Registration on Runner.RunnerId = Registration.RunnerId inner join  RegistrationEvent on Registration.RegistrationId = RegistrationEvent.RegistrationId inner join [Event] on RegistrationEvent.EventId = [Event].EventId inner join Marathon on [Event].MarathonId = Marathon.MarathonId  where EventName='" + dataGridView1.Rows[i].Cells[1].Value + "' and RaceTime!='0' and Gender='"+gender+"' and datediff(year, DateOfBirth,"+datenow+ ") between '"+min+"' and '"+max+"' order by RaceTime ", sqlconn);
                sqlread = select3.ExecuteReader();
                while (sqlread.Read())
                {
                    result++;
                    if (sqlread["RunnerId"].ToString() == Autorization.RunId)
                    {
                        dataGridView1.Rows[i].Cells[4].Value = result;
                        result = 0;
                    }
                }
                sqlread.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            RunnerMenu runmen = new RunnerMenu();
            runmen.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Autorization auth = new Autorization();
            auth.Show();
        }
    }
}
