﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSkils2018
{
    public partial class Contacts : Form
    {
        public Contacts()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Contacts_Load(object sender, EventArgs e)
        {
            label2.Text = "Для получения дополнительной информации \n пожалуйста свяжитесь с координаторами";
        }
    }
}
