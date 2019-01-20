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
    public partial class InterestsWindow : Form
    {
        public InterestsWindow()
        {
            InitializeComponent();

            button1.Enabled = false;

            if (CategoryWindow.ZAINT == true)
                button2.Visible = false;
        }

       
        //dalej
        private void button1_Click(object sender, EventArgs e)
        {
            if (CategoryWindow.ZAINT == true)
            {
                PersonWindow newForm = new PersonWindow();
                newForm.FormClosing += new FormClosingEventHandler((s, ea) => Application.Exit());
                newForm.Show();
                this.Hide();
            }
            else
            {
                PriceWindow newForm = new PriceWindow();
                newForm.FormClosing += new FormClosingEventHandler((s, ea) => Application.Exit());
                newForm.Show();
                this.Hide();
            }
            
        }

        //pomiń
        private void button2_Click(object sender, EventArgs e)
        {
            wyczyscInterestsTagi();
            button1_Click(sender, e);
        }

        
        
        //metoda sprawdza zmianę checkbox'a
        private void checkBoxChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            CheckBox box = (CheckBox)sender;
            if (box.Checked)
            {
                Dane.tagiZainteresowanie.Add(box.Text);
            }
            else 
            {
                Dane.tagiZainteresowanie.Remove(box.Text);
            }
        }

        //czyszczenie checkboxow dla buttona pomin
        private void wyczyscInterestsTagi()
        {
            foreach (Control c in this.Controls)
            {
                if (c.GetType() == typeof(CheckBox))
                {
                    Dane.tagiZainteresowanie.Remove(c.Text);
                }

            }
        }
       
    }
}
