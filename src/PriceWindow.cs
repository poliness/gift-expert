using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiftExpertSys
{
    public partial class PriceWindow : Form
    {
        //domyślne wartości MINPRICE i MAXPRICE
        public static int MINPRICE = 0, MAXPRICE = 100000;

        public PriceWindow()
        {
            InitializeComponent();
            
            button1.Enabled = false;
        }

        // DALEJ
        private void button1_Click(object sender, EventArgs e)
        {
            //Console.WriteLine("Dalej - Cena");
            FinalWindow newForm = new FinalWindow();
            newForm.FormClosing += new FormClosingEventHandler((s, ea) => Application.Exit());
            newForm.Show();
            this.Hide();
        }

        //POMIŃ
        private void button2_Click(object sender, EventArgs e)
        {
            MINPRICE = 0;
            MAXPRICE = 10000;
            button1_Click(sender, e);
        }

        //podwójnie w konsoli bo zmiana radiobutton (klik i odklik)
        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            button1.Enabled = true;
            MINPRICE = 0;
            MAXPRICE = 100;
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            button1.Enabled = true;
            MINPRICE = 101;
            MAXPRICE = 200;
        }

        private void radioButton3_CheckedChanged_1(object sender, EventArgs e)
        {
            button1.Enabled = true;
            MINPRICE = 201;
            MAXPRICE = 300;
        }

        private void radioButton4_CheckedChanged_1(object sender, EventArgs e)
        {
            button1.Enabled = true;
            MINPRICE = 301;
            MAXPRICE = 500;
        }

        private void radioButton5_CheckedChanged_1(object sender, EventArgs e)
        {
            button1.Enabled = true;
            MINPRICE = 501;
            MAXPRICE = 10000;
        }
    }
}
