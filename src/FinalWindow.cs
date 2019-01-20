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
    public partial class FinalWindow : Form
    {
        public FinalWindow()
        {
            InitializeComponent();


            HashSet<Gift> chosenGifts = SQLManager.getInstance.
                findGiftsByTags(PriceWindow.MINPRICE, PriceWindow.MAXPRICE, Dane.tagiOsoba, Dane.tagiOkolicznosc, Dane.tagiZainteresowanie);

            
            // losowanie finałowej propozycji
            Random random = new Random();
            Gift[] tmpArray = chosenGifts.ToArray();
            Gift finalGift = tmpArray[random.Next(tmpArray.Length)];

            this.label1.Text = finalGift.getName();

            this.label2.Text = finalGift.getPrice().ToString() + " " + "PLN";
        }

        //koniec działania aplikacji
        private void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        //przycisk 'od nowa'
        private void button3_Click(object sender, EventArgs e)
        {
            //System.Windows.Forms.Application.Restart();
            //Application.Restart();
            //Application.ExitThread();
            System.Diagnostics.Process.Start(Application.ExecutablePath);
           // Application.Exit();
            System.Windows.Forms.Application.ExitThread();
        }

    }
}
