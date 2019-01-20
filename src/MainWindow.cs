using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace GiftExpertSys
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            
            InitializeComponent();

            SQLManager m = SQLManager.getInstance;
        }

        // przycisk 'zaczynamy'
        private void button1_Click_1(object sender, EventArgs e)
        {
            CategoryWindow newForm = new CategoryWindow();
            newForm.FormClosing += new FormClosingEventHandler((s, ea) => Application.Exit());
            this.Hide();
            newForm.Show();
        }
    }
}
