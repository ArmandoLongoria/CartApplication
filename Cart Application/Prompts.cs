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

        public static int Search()
        {
            int inputChoice = 0;
            while(inputChoice < 1 || inputChoice > 3)
            {
                Console.WriteLine("\nHow would you like to Search?\n1. Item Type\n2. Serial Number\n3. Return to Main Menu\n");
                inputChoice = CustomerInput.GetInt();
            }
            return inputChoice;
        }

        public static int SearchPrompt(int type)
        {
            int inputChoice = 0;
            string typePrompt = (type == 1) ? "Item Type" : "Serial Number";
            while(inputChoice < 1 || inputChoice > 3)
            {
                Console.WriteLine("\nEnter the " + typePrompt + " you would like to search.\n");
                inputChoice = CustomerInput.GetInt();
            }
            return inputChoice;
        }

        public static string BuyPrompt()
        {
            string itemInput = "";
            while(itemInput == "")
            {
                Console.WriteLine("\nWhat would you like to buy? (Enter item Serial Number as it appears in item display)");
                itemInput = CustomerInput.GetString();
            }
            return itemInput;
            
        }

        public static int MoveQuantity(string typeMove)
        {
            int inputQuantity = 0;
            string typeMoveString = (typeMove == "Buy") ? "buy" : "remove";
            while(inputQuantity == 0)
            {
                Console.WriteLine("Item found. How many would you like to " + typeMoveString + "?");
                inputQuantity = CustomerInput.GetInt();
            }
            return inputQuantity;
        }

        public static string RemoveCartPrompt()
        {
            string itemInput = "";
            while (itemInput == "")
            {
                Console.WriteLine("\nWhat item would you like to remove from cart? (Enter Serial Number as it appears in display)\n");
                itemInput = CustomerInput.GetString();
            }
            return itemInput;
        }

        /*public static void Main(string[] args)
        {
            //int test = Search();
            //int test2 = SearchPrompt(test);
            //string test3 = BuyPrompt();
            //Console.WriteLine(test3);
            int test4 = MoveQuantity("Remove");
            Console.ReadKey();
        }*/
    }
}
