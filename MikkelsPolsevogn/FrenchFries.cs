using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikkelsPolsevogn
{
    class FrenchFries:Food
    {
        
        //inherits food and set an Expiration date
        public FrenchFries(string name)
        {
            Name = name;
            MadeTime = DateTime.Now;
            ExpirationTime = DateTime.Now.AddSeconds(20);
        }
    }
}
