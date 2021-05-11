using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MikkelsPolsevogn
{
    class Program
    {


        static void Main(string[] args)
        {
           
            Costumer costumer = new Costumer();
            Mikkel mikkel = new Mikkel();

            while (true)
            {
                Thread.Sleep(500);
                if (mikkel.Orders < 4)
                {
                    //starts ordering
                    ThreadPool.QueueUserWorkItem(o => MakeOrder(mikkel,costumer));

                    


                }
            }

        }

        //costumer choses what to order and tells the cook mikkel
        private static void MakeOrder(Mikkel mikkel, Costumer costumer)
        {
            string order = costumer.MakeOrder();
            Console.WriteLine("customer have ordered " + order);
            Takeorder(mikkel, order);

        }

        //mikkel takes the order and begins to cook
        public static void Takeorder(Mikkel mikkel, string order)
        {

            Food food = mikkel.TakeOrder(order);
            Console.WriteLine("customer have recived " + food.Name);
        }


    }
}
