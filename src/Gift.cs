using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftExpertSys
{
    //klasa odpowiadające za obiekty reprezentujące prezenty
    public class Gift
    {
        //nazwa prezentu
        private string name;
        //cena prezentu
        private Double price;
        //lista tagów prezentu
        private List<string> tags;

        public Gift(string name, Double price, List<string> tags )
        {
            this.name = name;
            this.price = price;
            this.tags = tags;
        }

        public string getName()
        {
            return name;
        }

        public Double getPrice()
        {
            return price;
        }

        public List<string> getTags()
        {
            return tags;
        }

    }
}
