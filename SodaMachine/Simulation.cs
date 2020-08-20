using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
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
        List<Coin> moneyEntered = new List<Coin>();

        int locationOfSoda;
        int locationOfCoin;
        int coinNumEntered;
        string userChoice;
        double costOfSoda;
        

        double newBalanceRemaining = 0.00;
        public Simulation()
        {
            sodaMachine = new SodaMachine();
            customer = new Customer();
        }
        public void RunMachine()
        {
            do
            {
                userChoice = customer.ChooseSoda(sodaMachine.cans);
                if(userChoice == "no")
                {
                    UserInterface.TryToSelectAgain();
                }
            } while (userChoice == "no");
           
            do
            {
                locationOfSoda = sodaMachine.CheckInventory(userChoice);
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
                    DispenceChange();
                }
                else
                {
                    UserInterface.TryToSelectAgain();
                    int continueOrCancel = UserInterface.CancelTransaction();
                    if (continueOrCancel == 1)
                    {
                        UserInterface.VoidPurchase();
                        Console.ReadKey();
                        break;
                    }
                    isValid = true;
                }
            } while (isValid); 
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
                if(coinNumEntered == 5)
                {
                    int continueOrCancel = UserInterface.CancelTransaction();
                   
                    if (continueOrCancel == 2)
                    {
                        UserInterface.VoidPurchase();
                        GiveBackMoney();

                        Console.ReadKey();
                        break;
                    }
                }
                locationOfCoin = customer.FindCoin(coinNumEntered, locationOfCoin);
                double valueOfCoin = customer.wallet.customerCoins[locationOfCoin].Value;

                moneyEntered.Add(customer.wallet.customerCoins[locationOfCoin]);

                customer.wallet.customerCoins.RemoveAt(locationOfCoin);
                

                //show new balance if possible withput getting crzy number
                newBalanceRemaining = costOfSoda - valueOfCoin;
            } while (PutInMoneyTotal() < costOfSoda);
        }
        public void DispenceChange()
        {
            //if they enter to much for the system to give proper money back then cancel the transaction and return thr money
            if (PutInMoneyTotal() == costOfSoda)
            {
                UserInterface.SuccessfulPurchase();
                customer.backpack.cansPurchased.Add(sodaMachine.cans[locationOfSoda]);
                sodaMachine.cans.RemoveAt(locationOfSoda);
            }
            //if they enter to much but i can make change with what i have then I can return proper change and despence soda
            else if (PutInMoneyTotal() > costOfSoda)
            {
                double moneyNeededBack = PutInMoneyTotal() - costOfSoda;
                if(MoneyInMachineTotal() > moneyNeededBack)
                {
                    UserInterface.NotEnoughChangeInMachine();
                    GiveBackMoney();
                    //make it either run again with new change or allow them to void
                }
                else
                {
                    UserInterface.ReturnChange(PutInMoneyTotal(), costOfSoda);
                    customer.backpack.cansPurchased.Add(sodaMachine.cans[locationOfSoda]);
                    sodaMachine.cans.RemoveAt(locationOfSoda);
                    //could add the money entered to the soda machine
                } 
            }
        }
        public double PutInMoneyTotal()
        {
            double runningTotalChangeEntered = 0.0;
            for(int i = 0; i < moneyEntered.Count; i++)
            {
                runningTotalChangeEntered += moneyEntered[i].Value;
            }
            return runningTotalChangeEntered;
        }
        public double MoneyInMachineTotal()
        {
            double runningTotalInMachine = 0.00;
            for (int i = 0; i < sodaMachine.coins.Count; i++)
            {
                runningTotalInMachine += sodaMachine.coins[i].Value;
            }
            return runningTotalInMachine;
        }
        public void GiveBackMoney()
        {
            for (int i = 0; i < moneyEntered.Count; i++)
            {
                customer.wallet.customerCoins.Add(moneyEntered[i]);
                moneyEntered.RemoveAt(i);
            }
        }
    }
}
