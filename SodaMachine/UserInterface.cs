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
            int cashOrCard = int.Parse(Console.ReadLine());
            return cashOrCard;
        }
        public static int GetCoins()
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
                    else if(coinEntered == 5)
                    {
                        CancelTransaction();
                    }
                }
                success = true;
                TryToSelectAgain();
            } while (success);

            int continueOrCancel = UserInterface.CancelTransaction();
            //I really want to change this
            if (continueOrCancel == 2)
            {
                UserInterface.VoidPurchase();
                GiveBackMoney();

                Console.ReadKey();
                break;
            }

            return coinEntered;
        }
        //public static double RemainingBalance()
        //{
        //    return; 
        //}
       
        //might not need this
        public static void ReturnChange(double moneyEntered, double cost)
        {
            //might not work, need to look up math.round
            double change = moneyEntered - cost;
            Console.WriteLine("Here is your change {0}", change);
            SuccessfulPurchase();
        }
        public static int CancelTransaction()
        {
            //To make this project better I could run PriceOfSoda and add another option to void the transaction
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
    }
}
