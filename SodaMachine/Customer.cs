using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Customer
    {
        public Backpack backpack;
        public Wallet wallet;
        public Customer()
        {
            backpack = new Backpack();
            wallet = new Wallet();
        }
        //can do, can pick a soda, can pick change
        public int CheckWallet(string coinPicked)
        {
            int index = -1;
            for (int i = 0; i < wallet.customerCoins.Count; i++)
            {
                if (coinPicked == wallet.customerCoins[i].name)
                {
                    return i;
                }
            }
            return index;
        }
        public string ChooseSoda(List<Can> cans)//will pass 
        {
            int usersChoice = UserInterface.AskUser();
            //will need to add validation to make sure there is enough in inventory
            
            if (usersChoice == 1)
            {
                return "Cola";
            }
            else if (usersChoice == 2)
            {
                //int locationOfOrangeSoda = 0; 
                //Can removedSoda = cans[locationOfOrangeSoda];
                //cans.RemoveAt(locationOfOrangeSoda);
                return "OrangeSoda";
            }
            else if (usersChoice == 3)
            {
                return "Rootbeer";
            }
            else
            {
                return "no";
            }            
        }
        public string SelectCoins(int coinType)
        {

            if (coinType == 1)
            {
                return "Quarter";
            }
            else if (coinType == 2)
            {
                return "Dime";
            }
            else if (coinType == 3)
            {
                return "Nickle";
            }
            else if (coinType == 4)
            {
                return "Penny";
            }
            else
            {
                return "no";
            }
        }
        public void SuccessfulPurchase()//pass through that one can
        {
            //add to backpack
        }
        public int FindCoin(int coinNumEntered, int locationOfCoin)
        {
            do
            {
                string coinEntered = SelectCoins(coinNumEntered);

                locationOfCoin = CheckWallet(coinEntered);
                if (locationOfCoin == -1)
                {
                    UserInterface.TryToSelectAgain();
                }
            } while (locationOfCoin == -1);
            return locationOfCoin;
        }
    }
}
