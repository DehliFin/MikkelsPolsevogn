using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikkelsPolsevogn
{
    class Food
    {


        private DateTime madeTime;
        private DateTime expirationTime;
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public DateTime MadeTime
        {
            get { return madeTime; }
            set { madeTime = value; }
        }
        public DateTime ExpirationTime
        {
            get { return expirationTime; }
            set { expirationTime = value; }
        }

        public Food()
        {
           
        }
        public Food(string name)
        {
            Name = name;
        }

    }
}


