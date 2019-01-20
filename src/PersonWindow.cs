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
    public partial class PersonWindow : Form
    {

        public PersonWindow()
        {
            InitializeComponent();


            if (CategoryWindow.OKOLI == true)
                button1.Visible = true;

            if (CategoryWindow.ZAINT == true)
                button1.Visible = true;
        }

        //metoda sprawdza zaznaczenie radiobuttonów
        private void checkboxClicked(object sender, EventArgs e)
        {
             wyczyscPersonTagi();
             RadioButton button = (RadioButton)sender;

             if (button.Checked) 
             { 
                 Dane.tagiOsoba.Add(button.Text);
             }
                         
        }

       

        // dalej
        private void button2_Click(object sender, EventArgs e)
        {
            if (CategoryWindow.OKOLI == true)
            {
                InterestsWindow newForm = new InterestsWindow();
                newForm.FormClosing += new FormClosingEventHandler((s, ea) => Application.Exit());
                newForm.Show();
                this.Hide();
            }
            else if (CategoryWindow.ZAINT == true)
            {
                OccasionWindow newForm = new OccasionWindow();
                newForm.FormClosing += new FormClosingEventHandler((s, ea) => Application.Exit());
                newForm.Show();
                this.Hide();
            }
            else
            {
                OccasionWindow newForm = new OccasionWindow();
                newForm.FormClosing += new FormClosingEventHandler((s, ea) => Application.Exit());
                newForm.Show();
                this.Hide();
            }
            
        }

        // pomiń
        private void button1_Click(object sender, EventArgs e)
        {
            wyczyscPersonTagi();
            button2_Click(sender,e);
      
        }

        //metoda czyści listę tagów jeżli radiobutton został odkliknięty
        private void wyczyscPersonTagi()
        {
            foreach (Control c in this.Controls)
            {
                if (c.GetType() == typeof(RadioButton))
                {
                    Dane.tagiOsoba.Remove(c.Text);
                }
                    
            }
        }

    }
}
