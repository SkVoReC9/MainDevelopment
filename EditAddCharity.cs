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
using System.IO;
namespace MSkils2018
{
    public partial class EditAddCharity : Form
    {
        string path;
        DateTime date = new DateTime(2018, 05, 09);
        SqlConnection sqlconn;
        string connection = @"Data Source=DESKTOP-5Q15QCU;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public EditAddCharity()
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
            ControlCharity control = new ControlCharity();
            control.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            sqlconn = new SqlConnection(connection);
            sqlconn.Open();
            if (textBox1.Text != "" && textBox1.Text.Contains("  ") == false)
            {
                try
                {
                    if (textBox2.Text != "")
                    {
                        File.Copy(path + @"\" + textBox2.Text, @"C:\Users\Roman\Desktop\ТРПО Шимбирев\d\" + textBox2.Text);
                    }
                }
                catch { }
                if (ControlCharity.prov == false)
                {
                    SqlCommand select = new SqlCommand("insert into Charity values(@CharityName,@CharityDescription,@CharityLogo);", sqlconn);
                    select.Parameters.AddWithValue("CharityName", textBox1.Text);
                    select.Parameters.AddWithValue("CharityDescription", textBox4.Text);
                    select.Parameters.AddWithValue("CharityLogo", textBox2.Text);
                    select.ExecuteNonQuery();
                    this.Hide();
                    ControlCharity control = new ControlCharity();
                    control.Show();
                }
                else
                {
                    SqlCommand select = new SqlCommand("Update Charity set CharityName = @CharityName,CharityDescription = @CharityDescription,CharityLogo = @CharityLogo where CharityId = '"+ControlCharity.index+"';", sqlconn);
                    select.Parameters.AddWithValue("CharityName", textBox1.Text);
                    select.Parameters.AddWithValue("CharityDescription", textBox4.Text);
                    select.Parameters.AddWithValue("CharityLogo", textBox2.Text);
                    select.ExecuteNonQuery();
                    ControlCharity control = new ControlCharity();
                    control.Show();
                }
            }
            else MessageBox.Show("Имя организации не корректно");
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Title = "Выберите изображение";
                open.Filter = "Файлы изображений (*.jpg, *.png *.jpeg *.gif *.bmp)|*.jpg;*.png*.jpeg *.gif *.bmp";
                open.Multiselect = false;
                open.ShowDialog();
                textBox2.Text = (Path.GetFileName(open.FileName));
                pictureBox1.BackgroundImage = Image.FromFile(open.FileName);
                path = Path.GetDirectoryName(open.FileName);
            }
            catch { }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label16.Text = (date - DateTime.Now).Days + " дней " + (date - DateTime.Now).Hours + " часов и " + (date - DateTime.Now).Minutes + " минут";
        }

        private void EditAddCharity_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ControlCharity control = new ControlCharity();
            control.Show();
        }
    }
}
