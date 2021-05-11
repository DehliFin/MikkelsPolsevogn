using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikkelsPolsevogn
{
    class Costumer
    {
        List<string> options = new List<string>() {"FrenchFries" , "Normal hotdog"};
        public Costumer()
        {

        }
        public string MakeOrder()
        {
            Random rng = new Random();
            
            return options[rng.Next(0,2)];
        }

    }
}
