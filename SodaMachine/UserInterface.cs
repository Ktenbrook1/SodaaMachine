using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    public static class UserInterface
    {
        public static int AskUser()
        {
            Console.WriteLine("Hello, Welcome to SodaMachine! Please select the soda you would like" +
                "\n1. Coca Cola" +
                "\n2. Orange Soda" +
                "\n3. Rootbeer");
            bool success = false;
            int usersChoice = 0;
            do
            {
                success = Int32.TryParse(Console.ReadLine(), out usersChoice);
                if (success)
                {
                    if (usersChoice == 1 || usersChoice == 2 || usersChoice == 3)
                    {
                        return usersChoice;
                    }
                }
                success = true;
                TryToSelectAgain();
            } while (success);
            
            return usersChoice;
        }
        public static void VoidPurchase()
        {
            Console.WriteLine("Sorry, the purchase was unsuccessful." +
                "\nAny change or payment you have entered will be dispenced or back onto your card." +
                "\nHave a nice day!");
        }
        public static void SuccessfulPurchase()
        {
            Console.WriteLine("The purchase was successful! Enjoy!");
        }
        public static void TryToSelectAgain()
        {
            Console.WriteLine("That is not a valid option. Please try again...");
        }
        public static void PriceOfSoda(Can soda)
        {
            Console.WriteLine("The price of {0} is {1}",soda.name, soda.Cost);
        }
        public static int CardOrCash()
        {
            Console.WriteLine("Enter '1' for Card or '2' for Cash");
            int cashOrCard = 0;
            bool success = false;
            do
            {
                success = Int32.TryParse(Console.ReadLine(), out cashOrCard);
                if (success)
                {
                    if (cashOrCard == 1 || cashOrCard == 2)
                    {
                        return cashOrCard;
                    }
                }
                success = true;
                TryToSelectAgain();
            } while (success);
            return cashOrCard;
        }
        public static int GetCoins()
        {
            bool startOver = false;
            do
            {
                Console.WriteLine("Please enter the coins you plan to enter or press 5 to cancel transaction" +
               "\n1. Enter Quarter" +
               "\n2. Enter Dime" +
               "\n3. Enter Nickle" +
               "\n4. Enter Penny" +
               "\n5. Cancel Transaction");

                bool success = false;
                int coinEntered = 0;
                do
                {
                    success = Int32.TryParse(Console.ReadLine(), out coinEntered);
                    if (success)
                    {
                        if (coinEntered == 1 || coinEntered == 2 || coinEntered == 3 || coinEntered == 4)
                        {
                            return coinEntered;
                        }
                        else if (coinEntered == 5)
                        {
                            int continueOrCancel = CancelTransaction();
                            if (continueOrCancel == 1)
                            {
                                startOver = true;
                            }
                            else if (continueOrCancel == 2)
                            {
                                Console.WriteLine("Have a nice day, goodbye...");
                                Console.ReadLine();
                                break;
                            }
                        }
                    }
                    success = true;
                    TryToSelectAgain();
                } while (success);

                return coinEntered;
            } while (startOver);

        }
        public static void OutOfItem()
        {
            Console.WriteLine("Looks like we are out of that soda, sorry for the inconvience." +
                "\nPlease pick another soda to continue");
        }
        public static void ReturnChange(double moneyEntered, double cost)
        {
            //might not work, need to look up math.round
            double change = moneyEntered - cost;
            Console.WriteLine("Here is your change {0}", change);
            SuccessfulPurchase();
        }
        public static int CancelTransaction()
        {
            Console.WriteLine("If you wish to continue this transaction and add another coin pick '1' To cancel press '2' ");
            bool success = false;
            int continueOrCancel = 0;
            do
            {
                success = Int32.TryParse(Console.ReadLine(), out continueOrCancel);
                if (success)
                {
                    if(continueOrCancel == 1 || continueOrCancel == 2)
                    {
                        return continueOrCancel;
                    }   
                }
                success = true;
                TryToSelectAgain();
            } while (success);
            return continueOrCancel;
        }
        public static void NotEnoughChangeInMachine()
        {
            Console.WriteLine("Were sorry but the amount you entered is to large for our machine to give you back " +
                "\n the proper change. Here is your money back. Please enter a smaller amount to continue.");
        }
        public static string YouOweMoney(double funds)
        {
            Console.WriteLine("There was only {0} paid. Would you like to pay the rest in cash? 'yes' or 'no'", funds);
            string restInCash = Console.ReadLine().ToLower();
            return restInCash;
        }
        public static void YouNowOwe(double moneyNeeded, double costOfSoda)
        {
            moneyNeeded = costOfSoda - moneyNeeded;
            if(moneyNeeded > 0)
            {
                Console.WriteLine("You now owe {0}", moneyNeeded);
            }
            else
            {
                moneyNeeded = moneyNeeded * -1;
                Console.WriteLine("We own you {0}", moneyNeeded);
            }
            
        }
        public static void MoneyDispenced(double moneyIn)
        {
            Console.WriteLine("{0} has been despenced down below. Thank you.", moneyIn);
        }
        public static void Readline()
        {
            Console.ReadLine();
        }
    }
}
