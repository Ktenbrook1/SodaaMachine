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
                GetUserChoice();
                GetLocation();
            } while (locationOfSoda == -2);
        
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
                    DispenceChange();
                    UserInterface.Readline();
                }
                else if (cashOrCard == 2)
                {
                    UsingCash();
                    DispenceChange();
                    UserInterface.Readline();
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
        public void GetUserChoice()
        {
            do
            {
                userChoice = customer.ChooseSoda(sodaMachine.cans);
                if (userChoice == "no")
                {
                    UserInterface.TryToSelectAgain();
                }
            } while (userChoice == "no");
        }
        public void GetLocation()
        {
     
                locationOfSoda = sodaMachine.CheckInventory(userChoice);
                if (locationOfSoda == -1)
                {
                    UserInterface.TryToSelectAgain();
                }
                
            
        }
        private void UsingCard()
        {
            if(customer.wallet.card.AvailiableFunds >= costOfSoda)
            {
                UserInterface.SuccessfulPurchase();
                customer.wallet.card.ChargeCard(costOfSoda);
                customer.backpack.cansPurchased.Add(sodaMachine.cans[locationOfSoda]);
                sodaMachine.cans.RemoveAt(locationOfSoda);
                UserInterface.Readline();
            }
            else if (customer.wallet.card.AvailiableFunds >= 0)
            {
                string payRestInCoins = UserInterface.YouOweMoney(customer.wallet.card.AvailiableFunds);
                double availableBalance = customer.wallet.card.AvailiableFunds;

                if(payRestInCoins == "yes")
                {
                    customer.wallet.card.ChargeCard(availableBalance);
                    costOfSoda -= availableBalance;
                    UserInterface.YouNowOwe(availableBalance, costOfSoda);
                    UsingCash();
                }
                else if(payRestInCoins == "no")
                {
                    UserInterface.VoidPurchase();
                    UserInterface.Readline();
                }
            }
        }
        private void UsingCash()
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

                        UserInterface.Readline();
                        break;
                    }
                    else
                    {
                        coinNumEntered = UserInterface.GetCoins();
                    }
                }
                locationOfCoin = customer.FindCoin(coinNumEntered, locationOfCoin);
                double valueOfCoin = customer.wallet.customerCoins[locationOfCoin].Value;

                moneyEntered.Add(customer.wallet.customerCoins[locationOfCoin]);

                customer.wallet.customerCoins.RemoveAt(locationOfCoin);
                

                //show new balance if possible withput getting crzy number
                newBalanceRemaining = costOfSoda - valueOfCoin;
                UserInterface.YouNowOwe(PutInMoneyTotal(), costOfSoda);

            } while (PutInMoneyTotal() < costOfSoda);
        }
        private void DispenceChange()
        {
            if (PutInMoneyTotal() == costOfSoda)
            {
                UserInterface.SuccessfulPurchase();
                customer.backpack.cansPurchased.Add(sodaMachine.cans[locationOfSoda]);
                sodaMachine.cans.RemoveAt(locationOfSoda);
                UserInterface.Readline();
            }
            else if (PutInMoneyTotal() > costOfSoda)
            {
                double moneyNeededBack = PutInMoneyTotal() - costOfSoda;
                if(MoneyInMachineTotal() > moneyNeededBack)
                {
                    UserInterface.NotEnoughChangeInMachine();
                    UserInterface.MoneyDispenced(PutInMoneyTotal());
                    GiveBackMoney();
                    UserInterface.Readline();
                }
                else
                {
                    UserInterface.ReturnChange(PutInMoneyTotal(), costOfSoda);
                    customer.backpack.cansPurchased.Add(sodaMachine.cans[locationOfSoda]);
                    sodaMachine.cans.RemoveAt(locationOfSoda);
                    //could add the money entered to the soda machine
                    UserInterface.Readline();
                } 
            }
        }
        private double PutInMoneyTotal()
        {
            double runningTotalChangeEntered = 0.0;
            for(int i = 0; i < moneyEntered.Count; i++)
            {
                runningTotalChangeEntered += moneyEntered[i].Value;
            }
            return runningTotalChangeEntered;
        }
        private double MoneyInMachineTotal()
        {
            double runningTotalInMachine = 0.00;
            for (int i = 0; i < sodaMachine.coins.Count; i++)
            {
                runningTotalInMachine += sodaMachine.coins[i].Value;
            }
            return runningTotalInMachine;
        }
        private void GiveBackMoney()
        {
            for (int i = 0; i < moneyEntered.Count; i++)
            {
                customer.wallet.customerCoins.Add(moneyEntered[i]);
                moneyEntered.RemoveAt(i);
            }
        }
    }
}
