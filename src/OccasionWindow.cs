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
    public partial class OccasionWindow : Form
    {

        public OccasionWindow()
        {
            InitializeComponent();
            
            if (CategoryWindow.OKOLI == true)
                button2.Visible = false;
        }

        //metoda sprawdza zaznaczenie radiobuttonow
        private void checkboxClicked(object sender, EventArgs e)
        {
            wyczyscOccasionTagi();
            RadioButton button = (RadioButton)sender;

            if (button.Checked)
            {
                Dane.tagiOkolicznosc.Add(button.Text);
            }
                

        }

        //metoda czyści listę tagów w momencie odkliknięcia radiobuttona
        private void wyczyscOccasionTagi()
        {
            foreach (Control c in this.Controls)
            {
                if (c.GetType() == typeof(RadioButton))
                {
                    Dane.tagiOkolicznosc.Remove(c.Text);
                }

            }
        }

        //pomiń
        private void button2_Click(object sender, EventArgs e)
        {
            wyczyscOccasionTagi();
            button1_Click(sender, e);

        }

        //dalej
        private void button1_Click(object sender, EventArgs e)
        {
            if (CategoryWindow.OKOLI == true)
            {
                PersonWindow newForm = new PersonWindow();
                newForm.FormClosing += new FormClosingEventHandler((s, ea) => Application.Exit());
                newForm.Show();
                this.Hide();
            }
            else if (CategoryWindow.ZAINT == true)
            {
                PriceWindow newForm = new PriceWindow();
                newForm.FormClosing += new FormClosingEventHandler((s, ea) => Application.Exit());
                newForm.Show();
                this.Hide();
            }
            else
            {
                InterestsWindow newForm = new InterestsWindow();
                newForm.FormClosing += new FormClosingEventHandler((s, ea) => Application.Exit());
                newForm.Show();
                this.Hide();
            }
        }

        
    }
}
