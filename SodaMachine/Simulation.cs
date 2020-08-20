using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace SodaMachine
{
    class Simulation
    {
        SodaMachine sodaMachine;
        Customer customer;

        int locationOfSoda;
        int locationOfCoin;
        public int coinNumEntered;
        public string userChoice;
        public double PriceOfSoda;
        double costOfSoda;

        double newBalanceRemaining = 0.00;
        double moneyEntered = 0.0;
        public Simulation()
        {
            sodaMachine = new SodaMachine();
            customer = new Customer();
        }
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

            costOfSoda = sodaMachine.cans[locationOfSoda].Cost;
            UserInterface.PriceOfSoda(sodaMachine.cans[locationOfSoda]);

            bool isValid;
            do
            {
                isValid = false;
                int cashOrCard = UserInterface.CardOrCash();
                if (cashOrCard == 1)
                {
                    UsingCard();
                }
                else if (cashOrCard == 2)
                {
                    UsingCash();
                }
                else
                {
                    UserInterface.TryToSelectAgain();
                    int continueOrCancel = UserInterface.CancelTransaction();
                    if(continueOrCancel == 1)
                    {
                        UserInterface.VoidPurchase();
                        Console.ReadKey();
                        break;
                    }
                    isValid = true;
                }
            } while (isValid);
           

            //if they enter to much for the system to give proper money back then cancel the transaction and return thr money
            if (moneyEntered == costOfSoda)
            {
                UserInterface.SuccessfulPurchase();
                customer.backpack.cansPurchased.Add(sodaMachine.cans[locationOfSoda]);
                sodaMachine.cans.RemoveAt(locationOfSoda);            
            }
            //if they enter to much but i can make change with what i have then I can return proper change and despence soda
            else if (moneyEntered > costOfSoda)
            {
                UserInterface.ReturnChange(moneyEntered, costOfSoda);
                customer.backpack.cansPurchased.Add(sodaMachine.cans[locationOfSoda]);
                sodaMachine.cans.RemoveAt(locationOfSoda);
            }
            //if they pay with card check available funds and give them the soda if they have eno
        }
        public void UsingCard()
        {
            if(customer.wallet.card.AvailiableFunds >= costOfSoda)
            {
                UserInterface.SuccessfulPurchase();
                double moneyTakenOut = costOfSoda;
                customer.wallet.card.ChargeCard(costOfSoda);
                customer.backpack.cansPurchased.Add(sodaMachine.cans[locationOfSoda]);
                sodaMachine.cans.RemoveAt(locationOfSoda);
            }
            else
            {
                UserInterface.VoidPurchase();
            }

        }
        public void UsingCash()
        {
            do
            {
                coinNumEntered = UserInterface.GetCoins();
                locationOfCoin = customer.FindCoin(coinNumEntered, locationOfCoin);
                double valueOfCoin = customer.wallet.customerCoins[locationOfCoin].Value;
                moneyEntered += valueOfCoin;
                customer.wallet.customerCoins.RemoveAt(locationOfCoin);
                int continueOrCancel = UserInterface.CancelTransaction();
                if(continueOrCancel == 1)
                {
                    UserInterface.VoidPurchase();
                    Console.ReadKey();
                    break;
                }
                //show new balance if possible withput getting crzy number
                newBalanceRemaining = costOfSoda - valueOfCoin;
            } while (moneyEntered < costOfSoda);
        }
    }
}
