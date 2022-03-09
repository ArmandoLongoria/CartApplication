using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart_Application
{
    class Program
    {
        public string command;
        public string itemToBuy;

        /*static void Main(string[] args)
        {
            Console.WriteLine("=========================================== WHAT'RE YA BUYIN' SUPERMART ================================================");
            Console.WriteLine("========================================== Copyright ARMAND LONGORIA 2022 ==============================================");
            Program myProgram = new Program();
            myProgram.MainMenu();
        }*/

        public void MainMenu()
        {
            Console.WriteLine("==================================================== MAIN MENU =========================================================");
            Console.WriteLine("\nWhat would you like to do?\n1. Check Store Inventory\n2. Search Inventory\n3. Check Cart\n4. Buy\n5. Remove item from cart\n6. Exit\n");
            command = Console.ReadLine();
            CheckInput();
        }

        public void CheckInput()
        {
            if (command == "1" || command == "2" || command == "3" || command == "4" || command == "5" || command == "6")
            {
                CheckCommand();
            }
            else
            {
                Console.WriteLine("\nINVALID INPUT (Use corresponding numbers to enter a command");
                MainMenu();
            }
        }

        public void CheckCommand()
        {
            if (command == "1")
            {
                DisplayStoreInventory();
                MainMenu();
            }
            else if (command == "2")
            {
                SearchStoreInventory();
            }
            else if (command == "3")
            {
                DisplayCartInventory();
                MainMenu();
            }
            else if (command == "4")
            {
                BuyMenu();
            }
            else if (command == "5")
            {
                RemoveQuantityFromCart();
            }
            else if (command == "6")
            {
                Exit();
            }
        }

        public void Exit()
        {
            Console.WriteLine("Press Enter to Exit program.");
            Console.Read();
        }
    }
}
