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
            int usersChoice = int.Parse(Console.ReadLine());
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
            Console.WriteLine("Please enter the coins you plan to enter" +
                "\n1. Enter Quarter" +
                "\n2. Enter Dime" +
                "\n3. Enter Nickle" +
                "\n4. Enter Penny");
            int coinEntered = int.Parse(Console.ReadLine());
            return coinEntered;
        }
        //public static double RemainingBalance()
        //{
        //    return; 
        //}
        public static double PriceOfSoda()
        {
            Console.WriteLine("The price of {0} is {1}");
            Console.WriteLine("Please enter the coins you plan to enter" +
                "\n1. Enter Quarter" +
                "\n2. Enter Dime" +
                "\n3. Enter Nickle" +
                "\n4. Enter Penny");
            double coinEntered = int.Parse(Console.ReadLine());
            return coinEntered;
        }
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
                    return continueOrCancel;
                }
                    TryToSelectAgain();
            } while (!success);
            return continueOrCancel;
        }
        public static void NotEnoughChangeInMachine()
        {
            Console.WriteLine("Were sorry but the amount you entered is to large for our machine to give you back " +
                "\n the proper change. Here is your money back. Please enter a smaller amount to continue.");
        }
    }
}
