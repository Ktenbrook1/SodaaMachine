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
            Console.WriteLine("Sorry, the purchase was unsuccessful");
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
    }
}
