using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace GiftExpertSys
{
    //klasa odpowiada za połączenie z bazą danych i pobraniu jej zawartości


    public sealed class SQLManager
    {
        private static SQLManager instance = null;
        private static readonly object _lock = new object();
        private SQLiteConnection con;

        private HashSet<Gift> gifts;

        public static SQLManager getInstance 
        {
            get
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new SQLManager();
                    }

                    return instance;

                }
            }
        }


        


        private SQLManager() 
        {
            con = new SQLiteConnection("Data Source=Baza.sqlite;Version=3;New=False;Compress=True;");
            
            con.Open();
            


            gifts = new HashSet<Gift>();

            string selGifts = "SELECT * FROM Prezenty;";
            string selTags = "SELECT * FROM Tagi;";

            SQLiteCommand giftsCommand = new SQLiteCommand(selGifts,con);
            SQLiteCommand tagsCommand = new SQLiteCommand(selTags, con);

            List<Tag> tags = new List<Tag>();


            // wczytywanie tagów
            SQLiteDataReader reader = tagsCommand.ExecuteReader();


            while (reader.Read())
            {
               //kolumna 0, kolumna 1
                if (reader.IsDBNull(0) || reader.IsDBNull(1))
                    continue;

                string tmp1 = reader.GetString(0);
                string tmp2 = reader.GetString(1);
 
                tags.Add(new Tag(tmp1,tmp2));
               
            }

            // wczytywanie giftów
            reader = giftsCommand.ExecuteReader();

            while (reader.Read())
            {
                string name = reader.GetString(0);
                
                object price = reader.GetValue(1);
                List<string> tmp = new List<string>();

                for (int i = 0; i < tags.Count; i++)
                {
                    Tag t = tags[i];
                    if (t.giftName.Equals(name))
                        tmp.Add(t.tag);
                }
                
                gifts.Add(new Gift(name, (Double)price, tmp));
            }

            
        }


        public HashSet<Gift> findGiftsByTags(int minPrice, int maxPrice, HashSet<string> osoba,
            HashSet<string> okolicznosc, HashSet<string> zainteresowanie)
        {
            HashSet<Gift> set1 = new HashSet<Gift>();

            // Użytkownik wybrał kategorię 'Osoba' - priorytet
            if (CategoryWindow.OSOBA)
            {
                foreach (Gift gift in this.gifts)
                {
                    foreach (string tag in osoba)
                    {
                        if (gift.getTags().Contains(tag) && (gift.getPrice() >= minPrice) && (gift.getPrice() <= maxPrice))
                            set1.Add(gift);
                    }
                }
            }
            // Użytkownik wybrał kategorię 'Okoliczność' - priorytet
            else if (CategoryWindow.OKOLI)
            {
                foreach (Gift gift in this.gifts)
                {
                    foreach (string tag in okolicznosc)
                    {
                        if (gift.getTags().Contains(tag) && (gift.getPrice() >= minPrice) && (gift.getPrice() <= maxPrice))
                            set1.Add(gift);
                    }
                }
            }
            // Użytkownik wybrał kategorię 'Zainteresowanie' - priorytet
            else if(CategoryWindow.ZAINT)
            {
                foreach (Gift gift in this.gifts)
                {
                    foreach (string tag in zainteresowanie)
                    {
                        if (gift.getTags().Contains(tag) && (gift.getPrice() >= minPrice) && (gift.getPrice() <= maxPrice))
                            set1.Add(gift);
                    }
                }
            }

            // Jeśli set1 jest pusty zostaje zwrócona cała lista prezentów
            if (set1.Count <= 0) { return gifts; }

            HashSet<Gift> set2 = new HashSet<Gift>();

            // Jeśli 'Osoba' ma priorytet to drugie znaczenie ma okoliczość
            if (CategoryWindow.OSOBA)
            {
                foreach (Gift gift in set1)
                {
                    foreach (string tag in okolicznosc)
                    {
                        if (gift.getTags().Contains(tag) && (gift.getPrice() >= minPrice) && (gift.getPrice() <= maxPrice))
                            set2.Add(gift);
                    }
                }
            }
            // Jeśli 'Okoliczność' ma priorytet to drugie znaczenie ma osoba
            // Jeśli 'Zainteresowania' ma priorytet to drugie znaczenie ma osoba
            else if (CategoryWindow.OKOLI || CategoryWindow.ZAINT)
            {
                foreach (Gift gift in set1)
                {
                    foreach (string tag in osoba)
                    {
                        if (gift.getTags().Contains(tag) && (gift.getPrice() >= minPrice) && (gift.getPrice() <= maxPrice))
                            set2.Add(gift);
                    }
                }
            }
                
            // Jeśli set3 zawiera jakiekolwiek elementy to kopiuje się do niego zawartość set2, 
            // w przeciwnym kopiuje sie do niego zawartośc set1
            HashSet<Gift> set3 = set2.Count > 0 ? set2 : set1;

            HashSet<Gift> set4 = new HashSet<Gift>();

            // Jeżeli priorytet ma 'Osoba' to trzecie znaczenie mają zainteresowania
            if (CategoryWindow.OSOBA)
            {
                foreach (Gift gift in set3)
                {
                    foreach (string tag in zainteresowanie)
                    {
                        if (gift.getTags().Contains(tag) && (gift.getPrice() >= minPrice) && (gift.getPrice() <= maxPrice))
                            set4.Add(gift);
                    }
                }
            }
            // Jeżeli priorytet ma 'Okoliczność' to trzecie znaczenie mają zainteresowania
            else if (CategoryWindow.OKOLI)
            {
                foreach (Gift gift in set3)
                {
                    foreach (string tag in zainteresowanie)
                    {
                        if (gift.getTags().Contains(tag) && (gift.getPrice() >= minPrice) && (gift.getPrice() <= maxPrice))
                            set4.Add(gift);
                    }
                }
            }
            // Jeżeli priorytet ma 'Zainteresowania' to trzecie znaczenie ma okoliczność
            else if(CategoryWindow.ZAINT)
            {
                foreach (Gift gift in set3)
                {
                    foreach (string tag in okolicznosc)
                    {
                        if (gift.getTags().Contains(tag) && (gift.getPrice() >= minPrice) && (gift.getPrice() <= maxPrice))
                            set4.Add(gift);
                    }
                }
            }

            
            return set4.Count > 0 ? set4 : set3;
           
        }


        struct Tag
        {
            public string giftName, tag;
            public Tag(string giftName, string tag)
            {
                this.giftName = giftName;
                this.tag = tag;
            }
        }

        public HashSet<Gift> getGifts()
        {
            return gifts;
        }

    }
}
