using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart_Application
{
    class Prompts
    {
        public static int MainMenu()
        {
            int inputChoice = 0;
            while(inputChoice < 1 || inputChoice > 6)
            {
                Console.WriteLine("==================================================== MAIN MENU =========================================================");
                Console.WriteLine("\nWhat would you like to do?\n1. Check Store Inventory\n2. Search Inventory\n3. Check Cart\n4. Buy\n5. Remove item from cart\n6. Exit\n");
                inputChoice = CustomerInput.GetInt();
            }
            return inputChoice;
        }

        public static void Main(string[] args)
        {
            int test = MainMenu();
        }
    }
}
