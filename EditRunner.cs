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
using System.IO;
using System.Text.RegularExpressions;
namespace MSkils2018
{
    public partial class EditRunner : Form
    {
        bool prov1, prov2 = false;
        string path;
        SqlConnection sqlconn;
        string connection = @"Data Source=DESKTOP-5Q15QCU;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        DateTime date = new DateTime(2018, 05, 09);
        public EditRunner()
        {
            InitializeComponent();
        }
        private void EditRunner_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "mSSkills2018DataSet.Country". При необходимости она может быть перемещена или удалена.
            this.countryTableAdapter1.Fill(this.mSSkills2018DataSet.Country);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "mSSkills2018DataSet.Gender". При необходимости она может быть перемещена или удалена.
            this.genderTableAdapter1.Fill(this.mSSkills2018DataSet.Gender);
            dateTimePicker1.MaxDate = new DateTime(DateTime.Now.Year - 10, DateTime.Now.Month, DateTime.Now.Day);
            byte[] img = null;
            label4.Text = Autorization.Email;
            timer1.Start();
            label13.Text = "Оставьте эти поля, незаполненными, \n если вы не хотите изменять пароль.";
            sqlconn = new SqlConnection(connection);
            sqlconn.Open();
            SqlDataReader sqlread;
            SqlCommand selectGender = new SqlCommand("use MSSkills2018 Select * from [User] inner join Runner on [User].Email = Runner.Email", sqlconn);
            sqlread = selectGender.ExecuteReader();
            while (sqlread.Read())
            {
                if(sqlread["Email"].ToString() == label4.Text)
               {
                    textBox3.Text = sqlread["FirstName"].ToString();
                    textBox5.Text = sqlread["LastName"].ToString();
                    dateTimePicker1.Value = (DateTime)sqlread["DateOfBirth"];
                    comboBox1.Text = sqlread["Gender"].ToString();
                    comboBox2.SelectedValue = sqlread["CountryCode"];
                    img = (byte[])sqlread["Photo"];
                }
            }
            sqlread.Close();
            MemoryStream memory = new MemoryStream();
            memory.Write(img, 0, img.Length);
            pictureBox1.BackgroundImage = Image.FromStream(memory);
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label16.Text = (date - DateTime.Now).Days + " дней " + (date - DateTime.Now).Hours + " часов и " + (date - DateTime.Now).Minutes + " минут";
        }

        private void button3_Click(object sender, EventArgs e)
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
                MessageBox.Show(path);
            }
            catch { }
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
            if (!Char.IsLetter(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
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
                if (textBox3.Text != "" && textBox5.Text != "" && textBox6.Text != "" && comboBox1.Text != "" && comboBox2.Text != "" && dateTimePicker1.Text != "")
                {
                    if (prov1 == false && prov2 == false)
                    {
                        if (textBox4.Text != "" && textBox5.Text != "")
                        {
                            if (textBox4.Text.Length >= 6 && Regex.IsMatch(textBox4.Text, @"[a-z,A-Z,А-Я,а-я]") && Regex.IsMatch(textBox4.Text, @"[\#\$\!\@\%\^]") && Regex.IsMatch(textBox4.Text, @"[0-9]"))
                            {
                                if (textBox2.Text == textBox4.Text)
                                {

                                    SqlCommand select = new SqlCommand("Update [User] set FirstName = @FirstName,LastName = @LastName,Password = @Pass,Photo = @Photo where Email = '" + label4.Text + "';Update Runner set Gender = @Gender,DateOfBirth =@Date,CountryCode = @Country where Email = '" + label4.Text + "';", sqlconn);
                                    select.Parameters.AddWithValue("FirstName", textBox3.Text);
                                    select.Parameters.AddWithValue("LastName", textBox5.Text);
                                    select.Parameters.AddWithValue("Pass", textBox4.Text);
                                    select.Parameters.AddWithValue("Photo", img);
                                    select.Parameters.AddWithValue("Gender", comboBox1.Text);
                                    select.Parameters.AddWithValue("Date", dateTimePicker1.Value);
                                    select.Parameters.AddWithValue("Country", comboBox2.SelectedValue);
                                    select.ExecuteNonQuery();
                                    MessageBox.Show("Данные сохранены");
                                    this.Hide();
                                    RunnerMenu main = new RunnerMenu();
                                    main.Show();

                                }
                                else MessageBox.Show("Пароли не совпадают");
                            }
                            else MessageBox.Show("Пароль не соответсвует требованиям");
                        }
                        else
                        {
                            SqlCommand select = new SqlCommand("Update [User] set FirstName = @FirstName,LastName = @LastName,Photo = @Photo where Email = '" + label4.Text + "';Update Runner set Gender = @Gender,DateOfBirth =@Date,CountryCode = @Country where Email = '" + label4.Text + "';", sqlconn);
                            select.Parameters.AddWithValue("FirstName", textBox3.Text);
                            select.Parameters.AddWithValue("LastName", textBox5.Text);
                            select.Parameters.AddWithValue("Photo", img);
                            select.Parameters.AddWithValue("Gender", comboBox1.Text);
                            select.Parameters.AddWithValue("Date", dateTimePicker1.Value);
                            select.Parameters.AddWithValue("Country", comboBox2.SelectedValue);
                            select.ExecuteNonQuery();
                            MessageBox.Show("Двнные сохранены");
                            this.Hide();
                            RunnerMenu main = new RunnerMenu();
                            main.Show();
                        }
                    }
                    else MessageBox.Show("В имени или фамили запрещенные символы");
                }
                else MessageBox.Show("Какие-то из полей не заполнены");
            }
            catch { MessageBox.Show("Вы не выбрали картинку"); }
        }

    }
}

