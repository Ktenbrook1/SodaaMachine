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
        public string ChooseSoda(List<Can> cans)//will pass 
        {
            UserInterface.AskUser();
            //will need to add validation to make sure there is enough in inventory
            
            if (UserInterface.UsersChoice == 1)
            {
                return "Cola";
            }
            else if (UserInterface.UsersChoice == 2)
            {
                //int locationOfOrangeSoda = 0; 
                //Can removedSoda = cans[locationOfOrangeSoda];
                //cans.RemoveAt(locationOfOrangeSoda);
                return "OrangeSoda";
            }
            else if (UserInterface.UsersChoice == 3)
            {
                return "Rootbeer";
            }
            else
            {
                return "no";
            }            
        }
        public void SelectCoins(List<Can> cans)
        {
            

            //tell them the price of that can
            //will need to record the index of where the proper can is...


            //then let them enter whatever change the want
            //if they enter to much for the system to give proper money back then cancel the transaction and return thr money
            //if they enter to much but i can make change with what i have then I can return proper change and despence soda
            //if they dont enter enough then dont complete the transaction and give the money back
            //if they enter exact change dispence the soda
            //if they pay with card check available funds and give them the soda if they have enough
           
        }
        public void SuccessfulPurchase()//pass through that one can
        {
            //add to backpack
        }
    }
}
