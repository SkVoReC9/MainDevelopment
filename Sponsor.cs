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
    public partial class Sponsor : Form
    {
        bool prov,prov1,prov2 = false;
        DateTime date = new DateTime(2018,05,09);
        public int ID;
        public string s;
        int Money = 50;
        SqlConnection sqlconn;
        string connection = @"Data Source=DESKTOP-5Q15QCU;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public Sponsor()
        {
            InitializeComponent();
            
        }

        private void Sponsor_Load(object sender, EventArgs e)
        {
            try
            {
                timer1.Start();
                label15.Text = Money.ToString();
                label4.Text = "Пожалуйста выберите бегуна, которого вы отели бы спонсировать и сумму, \n которую вы хотели бы спонсировать. Спасибо за вашу поддержку бегунов и их \n благотворительных учреждений.";
                sqlconn = new SqlConnection(connection);
                sqlconn.Open();
                SqlDataReader sqlread;
                SqlCommand select = new SqlCommand("select[User].FirstName,[User].LastName ,BibNumber, Country.CountryName from RegistrationEvent inner join Registration on Registration.RegistrationId = RegistrationEvent.RegistrationId inner join Runner on Runner.RunnerId = Registration.RunnerId inner join [User] on [User].Email = Runner.Email inner join Country on Runner.CountryCode = Country.CountryCode", sqlconn);
                sqlread = select.ExecuteReader();

                while (sqlread.Read())
                {
                    comboBox1.Items.Add(sqlread["FirstName"].ToString() + " " + sqlread["LastName"].ToString() + " -" + sqlread["BibNumber"] + " " + "(" + sqlread["CountryName"].ToString() + ")");

                }
                sqlread.Close();
            }
            catch { }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CharitySponsor chaspo = new CharitySponsor();
            int index = comboBox1.Text.IndexOf("-")-1;
            s = comboBox1.Text.Substring(0,index);
            SqlDataReader sqlread;
            SqlCommand select = new SqlCommand("select Registration.RegistrationId,FirstName,LastName,Runner.RunnerId , Registration.CharityId,CharityName,CharityDescription,CharityLogo from [User] inner join Runner on[User].Email = Runner.Email inner join Registration on Registration.RunnerId = Runner.RunnerId inner join Charity on Charity.CharityId = Registration.CharityId", sqlconn);
            sqlread = select.ExecuteReader();
            while (sqlread.Read())
            {
                if (sqlread["FirstName"] + " " + sqlread["LastName"] == s)
                {
                    label13.Text = sqlread["CharityName"].ToString();
                    ID = Convert.ToInt16(sqlread["RegistrationId"]);
                }
            }
            
            sqlread.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            CharitySponsor chaspo = new CharitySponsor();
            if (label13.Text != "")
            {
                SqlDataReader sqlread;
                SqlCommand select = new SqlCommand("select FirstName,LastName,Runner.RunnerId , Registration.CharityId,CharityName,CharityDescription,CharityLogo from [User] inner join Runner on[User].Email = Runner.Email inner join Registration on Registration.RunnerId = Runner.RunnerId inner join Charity on Charity.CharityId = Registration.CharityId", sqlconn);
                sqlread = select.ExecuteReader();
                while (sqlread.Read())
                {
                    if (sqlread["FirstName"] + " " + sqlread["LastName"] == s)
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
        private void button5_Click(object sender, EventArgs e)
        {
            Money += 10;
            label15.Text = Money.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Money -= 10;
            label15.Text = Money.ToString();
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            prov1 = false;
            string s2 = textBox5.Text;
            for (int i = 0; i < s2.Length; i++)
            {
                if (!Char.IsDigit(s2[i]))
                {
                    prov1 = true;
                }
            }
            if (e.KeyCode == Keys.Enter && textBox5.Text != "" && prov1 == false)
            {
                label15.Text = textBox5.Text;
                Money = Convert.ToInt32(textBox5.Text);
            }
            if(e.KeyCode == Keys.Enter && prov1 == true )
            {
                MessageBox.Show("Сумма некорректна");
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                e.Handled = true; 
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
      
                prov = false;
                prov1 = false;
                prov2 = false;
                string s = textBox1.Text;
                string s1 = textBox4.Text;
                string s2 = textBox5.Text;
                for (int i = 0; i < s.Length; i++)
                {
                    if (!Char.IsLetter(s[i]) && s[i] != ' ')
                    {
                        prov = true;
                    }
                }
                for (int i = 0; i < s1.Length; i++)
                {
                    if (!Char.IsLetter(s1[i]) && s1[i] != ' ')
                    {
                        prov2 = true;
                    }
                }
                for (int i = 0; i < s2.Length; i++)
                {
                    if (!Char.IsDigit(s2[i]))
                    {
                        prov1 = true;
                    }
                }
            try
            {
                if (textBox1.Text != "" && textBox4.Text != "" && maskedTextBox1.MaskCompleted && maskedTextBox2.MaskCompleted && maskedTextBox4.MaskCompleted && comboBox1.Text != "" && textBox1.Text.Contains("  ") == false && textBox4.Text.Contains("  ") == false)
                {
                    if (s[0] != ' ' && s1[0] != ' ' && s[s.Length - 1] != ' ' && s1[s1.Length - 1] != ' ')
                    {
                        if (Convert.ToDateTime(maskedTextBox2.Text).Year <= 2050 && Convert.ToDateTime(maskedTextBox2.Text).Month <= 12)
                        {
                            if (Convert.ToDateTime(maskedTextBox2.Text).Year > DateTime.Now.Year || (Convert.ToDateTime(maskedTextBox2.Text).Year == DateTime.Now.Year && Convert.ToDateTime(maskedTextBox2.Text).Month >= DateTime.Now.Month))
                            {
                                if (prov == false && prov1 == false && prov2 == false)
                                {
                                    SqlCommand select = new SqlCommand("insert into Sponsorship(SponsorName,RegistrationId,Amount) values(@SponsName,@RegID,@Amount);", sqlconn);
                                    select.Parameters.AddWithValue("SponsName", textBox1.Text);
                                    select.Parameters.AddWithValue("RegID", ID);
                                    select.Parameters.AddWithValue("Amount", Money);
                                    select.ExecuteNonQuery();
                                    ThanksSponsor Thanks = new ThanksSponsor();
                                    Thanks.label3.Text = label13.Text;
                                    Thanks.label4.Text = "$ " + Money.ToString();
                                    Thanks.label5.Text = comboBox1.Text;
                                    Thanks.Show();
                                }
                                else MessageBox.Show("Данные введены некорреткно");
                            }
                            else { MessageBox.Show("Дата устарела"); }
                        }
                        else { MessageBox.Show("Дата введена некорректно"); }
                    }
                    else MessageBox.Show("Где-то стоит лишний пробел");
                }
                else MessageBox.Show("Что-то не заполнено или заполнено неправильно");     
            }
            catch (Exception exe) { MessageBox.Show(exe.Message); }
            
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetter(e.KeyChar) && e.KeyChar != 8 && e.KeyChar!= 32)
            {
                e.Handled = true;
            }
            
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            label16.Text = (date - DateTime.Now).Days + " дней " + (date - DateTime.Now).Hours + " часов и " + (date - DateTime.Now).Minutes + " минут";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainWindow main = new MainWindow();
            main.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            MainWindow main = new MainWindow();
            main.Show();
        }
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetter(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 32)
            {
                e.Handled = true;
            }
        }
    }
}
