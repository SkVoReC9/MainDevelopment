using System;
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
    public partial class MarathonMoreInfo : Form
    {
        DateTime date = new DateTime(2018, 05, 09);
        public MarathonMoreInfo()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label16.Text = (date - DateTime.Now).Days + " дней " + (date - DateTime.Now).Hours + " часов и " + (date - DateTime.Now).Minutes + " минут";
        }

        private void MarathonMoreInfo_Load(object sender, EventArgs e)
        {
            timer1.Start();
            label4.Text = "События: \n - Программа 'Самба' Полный Марафон начнется в Руа - Ду - Американо в 6 утра. \n- Программа 'Джонго' Полумарафон начнет в 7 утра Бегуны будут стартовать от недалеко от пересечения улицы Руа Ciniciata и Авенида. \n - Программа 'Капоэйра' в 5 км забег для новичков начнется в 15 часов Наши новички побегут от Мемориала Унинове. \n \n Спасибо всем волонтерам, которые будут помогать нам проводить марафон!";
            label1.Text = "О Marathon Skills 2018 \n Marathon Skills -фестиваль бега, проводимый каждый год в разных частях мира.Может быть три зачета: Полный Марафон, Полумарафон и забег для новичков -таким образом фестиваль подходит всем.В прошлых годах марафон был проведен в Осаке, Япония (2014); Лейпциг, Германия(2013); Ханой, Вьетнам(2012) и Йорк, Англия (2011).В этом году, Marathon Skills очень зрелищно, продет в Сан-Паоло, Бразилия, он должен быть самым большим фестивалем бега.Это финансовый центр Бразилии и самый большой город в Южной Америке.Сан - Пауло увидят тысячи бегунов, которые будут бежать мимо небоскребов, зеленые парки и великолепная архитектура.Этот фестиваль привлек рекордное количество бегунов со всего мира.особое внимание будет обращено на участников из Кении и Ямайки, поскольку мы надеемся увидеть победителя 2014 года. (Эфиоп закончил гонку за 45 минут 4 секунды.)Атмосфера праздника обещает развлечения для всех зрителей.";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MoreInfo more = new MoreInfo();
            more.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Hide();
            InteractiveMap map = new InteractiveMap();
            map.Show();
        }
    }
}
