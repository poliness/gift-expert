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
    public partial class CategoryWindow : Form
    {

        //zmienne pomocnicze sterujące warunkami
        public static bool OSOBA = false, OKOLI = false, ZAINT = false;

        public CategoryWindow()
        {
            InitializeComponent();
        }

        //osoba
        private void button1_Click(object sender, EventArgs e)
        {
            OSOBA = true;
            PersonWindow newForm = new PersonWindow();
            newForm.FormClosing += new FormClosingEventHandler((s, ea) => Application.Exit());
            newForm.Show();
            this.Hide();
        }

        //na okoliczność
        private void button2_Click(object sender, EventArgs e)
        {
            OKOLI = true;
            OccasionWindow newForm = new OccasionWindow();
            newForm.FormClosing += new FormClosingEventHandler((s, ea) => Application.Exit());
            newForm.Show();
            this.Hide();
        }

        //zainteresowania
        private void button3_Click(object sender, EventArgs e)
        {
            ZAINT = true;
            InterestsWindow newForm = new InterestsWindow();
            newForm.FormClosing += new FormClosingEventHandler((s, ea) => Application.Exit());
            newForm.Show();
            this.Hide();
        }


    }
}
