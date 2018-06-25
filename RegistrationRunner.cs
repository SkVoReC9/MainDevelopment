using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;
 

namespace MSkils2018
{
    public partial class RegistrationRunner : Form
    {
        string path;
        bool prov1, prov2 = false;
        DateTime date = new DateTime(2018, 05, 09);
        SqlConnection sqlconn;
        string connection = @"Data Source=DESKTOP-5Q15QCU;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public RegistrationRunner()
        {
            InitializeComponent();
        }
        public static bool Check(String email)
        {
            bool Valid = false;
            Regex mail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (mail.IsMatch(email))
            {
                Valid = true;
            }
            return Valid;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainWindow main = new MainWindow();
            main.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label16.Text = (date - DateTime.Now).Days + " дней " + (date - DateTime.Now).Hours + " часов и " + (date - DateTime.Now).Minutes + " минут";
        }

        private void RegistrationRunner_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "mSSkills2018DataSet.Country". При необходимости она может быть перемещена или удалена.
            this.countryTableAdapter1.Fill(this.mSSkills2018DataSet.Country);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "skillsDataSet.Country". При необходимости она может быть перемещена или удалена.
            // this.countryTableAdapter.Fill(this.skillsDataSet.Country);
            dateTimePicker1.MaxDate = new DateTime(DateTime.Now.Year - 10, DateTime.Now.Month, DateTime.Now.Day);
            timer1.Start();
            sqlconn = new SqlConnection(connection);
            sqlconn.Open();
            SqlDataReader sqlread;
            SqlCommand selectGender = new SqlCommand(" Use MSSkills2018 Select Gender from Gender", sqlconn);
            sqlread = selectGender.ExecuteReader();
            while (sqlread.Read())
            {
                comboBox1.Items.Add(sqlread["Gender"]);
            }
            sqlread.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            prov1 = false;
            prov2 = false;
            string s1 = textBox3.Text;
            string s2 = textBox5.Text;
            for (int i = 0; i < s1.Length; i++)
            {
                if (!Char.IsLetter(s1[i]))
                {
                    prov1 = true;
                }
            }
            for (int i = 0; i < s2.Length; i++)
            {
                if (!Char.IsLetter(s2[i]))
                {
                    prov2 = true;
                }
            }
            try
            {
                byte[] img = null;
                FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read);
                BinaryReader bin = new BinaryReader(file);
                img = bin.ReadBytes((int)file.Length);
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && comboBox1.Text != "" && comboBox2.Text != "" && dateTimePicker1.Text != "")
                {
                    if (Check(textBox1.Text))
                    {
                        if (textBox4.Text.Length >= 6 && Regex.IsMatch(textBox4.Text, @"[a-z,A-Z,А-Я,а-я]") && Regex.IsMatch(textBox4.Text, @"[\#\$\!\@\%\^]") && Regex.IsMatch(textBox4.Text, @"[0-9]"))
                        {
                            if (textBox2.Text == textBox4.Text)
                            {
                                if (prov1 == false && prov2 == false)
                                {
                                    SqlCommand select = new SqlCommand("insert into[User] values(@Email, @Pass, @FirstName, @LastName, @Role, @Photo);insert into Runner values (@Mail,@Gender,@Date,@Country)", sqlconn);
                                    select.Parameters.AddWithValue("Email", textBox1.Text);
                                    select.Parameters.AddWithValue("Pass", textBox4.Text);
                                    select.Parameters.AddWithValue("FirstName", textBox3.Text);
                                    select.Parameters.AddWithValue("LastName", textBox5.Text);
                                    select.Parameters.AddWithValue("Role", "R");
                                    select.Parameters.AddWithValue("Photo", img);
                                    select.Parameters.AddWithValue("Mail", textBox1.Text);
                                    select.Parameters.AddWithValue("Gender", comboBox1.Text);
                                    select.Parameters.AddWithValue("Date", dateTimePicker1.Value);
                                    select.Parameters.AddWithValue("Country", comboBox2.SelectedValue);
                                    select.ExecuteNonQuery();
                                    MessageBox.Show("Вы успешно зарегистрированы");
                                    this.Hide();
                                    MainWindow main = new MainWindow();
                                    main.Show();
                                }
                                else MessageBox.Show("В имени или фамили запрещенные символы");
                            }
                            else MessageBox.Show("Пароли не совпадают");
                        }
                        else MessageBox.Show("Пароль не соответсвует требованиям");
                    }
                    else MessageBox.Show("Неправильный Email");
                }
                else MessageBox.Show("Какие-то из полей не заполнены");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            
        }   

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Title = "Выберите изображение";
                open.Filter = "Файлы изображений (*.jpg, *.png)|*.jpg;*.png";
                open.Multiselect = false;
                open.ShowDialog();
                textBox6.Text = (Path.GetFileName(open.FileName));
                pictureBox1.BackgroundImage = Image.FromFile(open.FileName);
                path = open.FileName;
            }
            catch { }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetter(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetter(e.KeyChar) && e.KeyChar != 8 )
            {
                e.Handled = true;
            }
        }
    }
}
