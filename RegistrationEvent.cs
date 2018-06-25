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
    public partial class RegistrationEvent : Form
    {
        int money;
        int CharId;
        bool prov,prov1 = false;
        int RunId;
        Char raceOpt;
        SqlConnection sqlconn;
        string connection = @"Data Source=DESKTOP-5Q15QCU;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        DateTime date = new DateTime(2018, 05, 09);
        public RegistrationEvent()
        {
            InitializeComponent();
        }

        private void RegistrationEvent_Load(object sender, EventArgs e)
        {
            RunId = Convert.ToInt16(Autorization.RunId);
            label11.Text = "$ " + money.ToString();
            radioButton1.Text = "Вариант A ($0): Номер бегуна+ \n RFID браслет.";
            radioButton2.Text = "Вариант B ($20): вариант A + бейсболка + \n бутылка воды.";
            radioButton3.Text = "Вариант C ($45): Вариант B \n +футболка + сувенирный буклет.";
            timer1.Start();
            label4.Text = "Пожалуйста заполните всю информацию, чтобы зарегистрироваться на Skills  \n Marathon 2018 проводимом в Москве. Russia. С вами свяжутся после \n регистрации для уточнения оплаты и другой информации.";
            sqlconn = new SqlConnection(connection);
            sqlconn.Open();
            SqlDataReader sqlread;
            SqlCommand select = new SqlCommand("use MSSKills2018 select CharityName from Charity ", sqlconn);
            sqlread = select.ExecuteReader();

            while (sqlread.Read())
            {
                comboBox1.Items.Add(sqlread["CharityName"]);

            }
            sqlread.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            RunnerMenu runmen = new RunnerMenu();
            runmen.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Autorization auth = new Autorization();
            auth.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label16.Text = (date - DateTime.Now).Days + " дней " + (date - DateTime.Now).Hours + " часов и " + (date - DateTime.Now).Minutes + " минут";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            CharitySponsor chaspo = new CharitySponsor();
            if (comboBox1.Text != "")
            {
                SqlDataReader sqlread;
                SqlCommand select = new SqlCommand("select CharityName,CharityLogo,CharityDescription from Charity", sqlconn);
                sqlread = select.ExecuteReader();
                while (sqlread.Read())
                {
                    if (sqlread["CharityName"].ToString() == comboBox1.Text)
                    {
                        chaspo.label1.Text = sqlread["CharityName"].ToString();
                        chaspo.textBox1.Text = sqlread["CharityDescription"].ToString();
                       // chaspo.pictureBox1.BackgroundImage = Image.FromFile(@"C:);
                        label13.Text = sqlread["CharityName"].ToString();
                    }
                }
                sqlread.Close();
                chaspo.Show();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked)
            {
                money += 145;
                label11.Text ="$ "+ money.ToString();
                prov = true;
            }
            else { money -= 145; label11.Text ="$ "+ money.ToString(); prov = false; }
      
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.CheckState == CheckState.Checked)
            {
                money += 75;
                label11.Text = "$ " + money.ToString();
                prov = true;
            }
            else { money -= 75; label11.Text = "$ " + money.ToString(); prov = false; }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.CheckState == CheckState.Checked)
            {
                money += 20;
                label11.Text = "$ " + money.ToString();
                prov = true;
            }
            else { money -= 20; label11.Text = "$ " + money.ToString(); prov = false; }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                money += 0;
                label11.Text = "$ " + money.ToString();
                raceOpt = 'A';
            }
            else { money -= 0; label11.Text = "$ " + money.ToString(); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            prov1 = false;
            string s1 = textBox5.Text;
            for (int i = 0; i < s1.Length; i++)
            {
                if (!Char.IsDigit(s1[i]))
                {
                    prov1 = true;
                }
            }
            if (textBox5.Text != "" && comboBox1.Text != "")
            {
                if (prov1 == false)
                {
                    if (prov == true)
                    {
                        
                        SqlCommand select = new SqlCommand("insert into Registration values(@RunID, @RegTime, @RaceOption, @RegStatId, @Cost, @CharityId,@SponsorTarg)", sqlconn);
                        select.Parameters.AddWithValue("RunId", RunId);
                        select.Parameters.AddWithValue("RegTime", DateTime.Now);
                        select.Parameters.AddWithValue("RaceOption", raceOpt);
                        select.Parameters.AddWithValue("RegStatId", 1);
                        select.Parameters.AddWithValue("Cost", money);
                        select.Parameters.AddWithValue("CharityId", CharId);
                        select.Parameters.AddWithValue("SponsorTarg",Convert.ToInt16(textBox5.Text));
                        select.ExecuteNonQuery();
                        ThanksRegistration Thanks = new ThanksRegistration();
                        Thanks.Show();
                        
                    }
                    else MessageBox.Show("Вы не выбрали ни одного марафона");
                }
                else MessageBox.Show("Сумма взноса некорректна");
            }
            else MessageBox.Show("Что-то не заполнено");

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                money += 20;
                label11.Text = "$ " + money.ToString();
                raceOpt = 'B';

            }
            else { money -= 20; label11.Text = "$ " + money.ToString(); }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                money += 45;
                label11.Text = "$ " + money.ToString();
                raceOpt = 'C';
            }
            else { money -= 45; label11.Text = "$ " + money.ToString(); }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CharId = comboBox1.SelectedIndex;
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
    }
}
