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
        private static int usersChoice;

        public static int UsersChoice
        {
            get => usersChoice;
        }
        public static void AskUser()
        {
            Console.WriteLine("Hello, Welcome to SodaMachine! Please select the soda you would like" +
                "\n1. Coca Cola" +
                "\n2. Orange Soda" +
                "\n3. Rootbeer");
            int usersChoice = int.Parse(Console.ReadLine());
        }
        public static void VoidPurchase()
        {
            Console.WriteLine("Sorry, the purchase was unsuccessful");
        }
        public static void TryToSelectAgain()
        {
            Console.WriteLine("That is not a valid option. Please try again...");
        }
    }
}
