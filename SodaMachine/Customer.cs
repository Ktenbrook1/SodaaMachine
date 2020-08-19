using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Customer
    {
        Backpack backpack = new Backpack();
        Wallet wallet = new Wallet();
        public Customer()
        {
            
        }
        //can do, can pick a soda, can pick change
        public void ChooseSoda(List<Can> cans)//will pass in a value
        {
            UserInterface.AskUser();
            if(UserInterface.UsersChoice == 1)
            {
                Cola cola = new Cola();
                cans.Add(cola);
            }
            else if(UserInterface.UsersChoice == 2)
            {
                OrangeSoda orangeSoda = new OrangeSoda();
                cans.Add(orangeSoda);
            }
            else if(UserInterface.UsersChoice == 3)
            {
                RootBeer rootBeer = new RootBeer();
                cans.Add(rootBeer);
            }
        }
        public void SelectCoins()
        {
            int coinChoice = 0;
            //loop goes here
            //do
            //{
            //    if (coinChoice == 1)
            //    {
            //        wallet.customerCoins.Remove();
            //    }
            //} while ();
           
        }
    }
}
