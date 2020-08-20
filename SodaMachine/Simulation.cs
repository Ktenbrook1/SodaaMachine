using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Simulation
    {
        SodaMachine sodaMachine = new SodaMachine();
        Customer customer = new Customer();

        int locationOfSoda;
        int locationOfCoin;
        public int coinNumEntered;
        public string userChoice;
        public double PriceOfSoda;
        public void RunMachine()
        {
            string userChoice = customer.ChooseSoda(sodaMachine.cans);

            do
            {
                int locationOfSoda = sodaMachine.CheckInventory(userChoice);
                if (locationOfSoda == -1)
                {
                    UserInterface.TryToSelectAgain();
                }
            } while (locationOfSoda == -1);

            //find cost
            double costOfSoda = sodaMachine.cans[locationOfSoda].Cost;
            UserInterface.PriceOfSoda(sodaMachine.cans[locationOfSoda]);
           

            double newBalanceRemaining = 0.00;
            double moneyEntered = 0.0;
            do
            {
                coinNumEntered = UserInterface.GetCoins();
                //with the location of the coin find the value
                locationOfCoin = FindCoin();
                double valueOfCoin = customer.wallet.customerCoins[locationOfCoin].Value;
                //once value is found remove it from wallet
                moneyEntered += valueOfCoin;
                customer.wallet.customerCoins.RemoveAt(locationOfCoin);
                newBalanceRemaining = costOfSoda - valueOfCoin;

                //show new balance
            } while (moneyEntered < costOfSoda);

            //if they enter to much for the system to give proper money back then cancel the transaction and return thr money
            if(moneyEntered == costOfSoda)
            {
                UserInterface.SuccessfulPurchase();
            }
            //if they enter to much but i can make change with what i have then I can return proper change and despence soda
            //if they dont enter enough then dont complete the transaction and give the money back
            //if they enter exact change dispence the soda
            //if they pay with card check available funds and give them the soda if they have enough
        }
        public int FindCoin()
        {
            do
            {
                string coinEntered = customer.SelectCoins(coinNumEntered);

                int locationOfCoin = customer.CheckWallet(coinEntered);
                if (locationOfCoin == -1)
                {
                    UserInterface.TryToSelectAgain();
                }
            } while (locationOfCoin == -1);
            return locationOfCoin;
        }

    }
}
