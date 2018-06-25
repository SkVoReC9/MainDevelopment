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
    public partial class InventarControl : Form
    {
        SqlConnection sqlconn;
        string connection = @"Data Source=DESKTOP-5Q15QCU;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        DateTime date = new DateTime(2018, 05, 09);
        public InventarControl()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label6.Text = (date - DateTime.Now).Days + " дней " + (date - DateTime.Now).Hours + " часов и " + (date - DateTime.Now).Minutes + " минут";
        }
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

            

        }
        private void InventarControl_Load(object sender, EventArgs e)
        {
            timer1.Start();
            sqlconn = new SqlConnection(connection);
            sqlconn.Open();
            SqlDataReader sqlread;
            SqlCommand select = new SqlCommand("Select TovarId,TovarName from Inventar", sqlconn);
            sqlread = select.ExecuteReader();
            while (sqlread.Read())
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[Convert.ToInt16(sqlread["TovarId"])-1].Cells[0].Value = sqlread["TovarName"];
                dataGridView1.Rows[Convert.ToInt16(sqlread["TovarId"]) - 1].Cells[1].ReadOnly = false;
                dataGridView1.Rows[Convert.ToInt16(sqlread["TovarId"]) - 1].Cells[0].ReadOnly = true;
            }
            sqlread.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Autorization auth = new Autorization();
            auth.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Inventar inventar = new Inventar();
            inventar.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                sqlconn = new SqlConnection(connection);
                sqlconn.Open();
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    SqlCommand select = new SqlCommand("Update Inventar set TovarNumber +='" + dataGridView1.Rows[i].Cells[1].Value + "' where TovarId = '" + (i + 1) + "'", sqlconn);
                    select.ExecuteNonQuery();
                    dataGridView1.Rows[i].Cells[1].Value = "";
                }
            }
            catch { MessageBox.Show("Ошибка!"); }
        }

        private void dataGridView1_EditingControlShowing_1(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == 1)
            {
                TextBox tb = (TextBox)e.Control;
                tb.KeyPress += new KeyPressEventHandler(tb_KeyPress);
            }
        }
        void tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && (e.KeyChar != '-'))
            {
                if (e.KeyChar != (char)Keys.Back)
                { e.Handled = true; }
            }
        }
    }
}
