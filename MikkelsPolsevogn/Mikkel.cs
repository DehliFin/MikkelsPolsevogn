using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MikkelsPolsevogn
{
    class Mikkel
    {
        private List<FrenchFries> frenchFries = new List<FrenchFries>();
        private List<Bread> bread = new List<Bread>();
        private List<BoiledSausage> boiledSausages = new List<BoiledSausage>();

        private int orders;
        private int sasuagesBeingMade;
        private int refilDressing;
        private int remolade = 30;
        //private int sennep = 30;
        //private int ketchup = 30;

        public int Orders
        {
            get { return orders; }
            set { orders = value; }
        }



        public Mikkel()
        {

        }
       
        public Food TakeOrder(string FoodItem)
        {
            while (true)
            {

                //changes remolade if there is no more 
                if (remolade < 1 && refilDressing < 1)
                {
                    refilDressing++;
                    Thread.Sleep(4000);
                    remolade = 30;
                    refilDressing--;
                }
                else if (refilDressing == 0)
                {


                    orders++;
                    switch (FoodItem)
                    {
                        case "FrenchFries":

                            while (true)
                            {
                                //checks if fries is ready. if not it makes more
                                if (frenchFries.Count < 1)
                                {

                                    MakeFries();

                                }
                                //checks if the fries is still warm
                                else if (frenchFries[0].ExpirationTime > DateTime.Now)
                                {
                                    FrenchFries temp = frenchFries[0];
                                    frenchFries.RemoveAt(0);
                                    orders--;
                                    return temp;
                                }
                                //removing cold fries
                                else if (frenchFries[0].ExpirationTime < DateTime.Now)
                                {
                                    frenchFries.RemoveAt(0);
                                }

                            }
                        case "Normal hotdog":
                            while (true)
                            {
                                //checks if there is any sauseges ready or if some is being made. if both is false it makes more sauseges
                                if (boiledSausages.Count < 1 && sasuagesBeingMade < 1)
                                {
                                    MakeBoiledSausage();
                                }
                                if (bread.Count < 1)
                                {
                                    WarmBread();
                                }
                                //if there is both bread and sausage it makes a hotdog and returns it
                                else if (boiledSausages.Count > 0 && bread.Count > 0)
                                {
                                    if (bread[0].ExpirationTime > DateTime.Now)
                                    {
                                        NormalHotdog temp = new NormalHotdog(bread[0], boiledSausages[0], "Normal Hotdog");
                                        //the threads is to fast so i had to make if(). 
                                        if (bread.Count > 0)
                                        {
                                            bread.RemoveAt(0);
                                        }
                                        remolade--;
                                        orders--;
                                        boiledSausages.RemoveAt(0);
                                        return temp;
                                    }
                                    else
                                    {
                                        bread.RemoveAt(0);
                                    }

                                }
                            }

                        default:
                            //returns if the string isn't a vailid option
                            return new Food("not a dish on the menu");


                    }


                }
            }
        }
        //waits 10 sec and then make 60 new boiled sauseges
        private void MakeBoiledSausage()
        {
            //makes sure only 60 is being made and not more. stops more threads doing it at the same time
            sasuagesBeingMade++;

            Thread.Sleep(10000);
            for (int i = 0; i < 60; i++)
            {
                boiledSausages.Add(new BoiledSausage("Boiled sausage"));
            }
            sasuagesBeingMade--;
        }

        //warms the bread
        public void WarmBread()
        {
            Thread.Sleep(1000);
            bread.Add(new Bread("bread"));
        }
        //waits 10sec and makes fries
        public void MakeFries()
        {
            Thread.Sleep(10000);
            frenchFries.Add(new FrenchFries("FrenchFries"));
            frenchFries.Add(new FrenchFries("FrenchFries"));

        }
    }
}
