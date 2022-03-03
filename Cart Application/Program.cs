using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart_Application
{
    class Program
    {
        public int storeInventorySize = 0;
        public int cartInventorySize = 0;
        public int purchaseQuantity;
        public int removeQuantity;
        public string command;
        public string itemToBuy;
        public string itemToRemove;
        public string searchString;
        public string purchaseQuantityString;
        public string removeQuantityString;
        Item[] storeInventory = new Item[10];
        Item[] cartInventory = new Item[10];

        /*static void Main(string[] args)
        {
            Console.WriteLine("=========================================== WHAT'RE YA BUYIN' SUPERMART ================================================");
            Console.WriteLine("========================================== Copyright ARMAND LONGORIA 2022 ==============================================");
            Program myProgram = new Program();
            Item plunger = new Item("Household", "Toilet Plunger", 17.38, 17, "WYB001");
            Item hangers = new Item("Household", "30-Pack Durable Hangers", 10.65, 40, "WYB002");
            Item dongle = new Item("Electronics", "Apple Lightning to 3.5mm Adapter", 14.99, 4, "WYB003");
            Item controller = new Item("Electronics", "PlayStation 5 DualSense Wireless Controller", 59.99, 6, "WYB004");
            Item shovel = new Item("Garden", "Gardening Shovel", 24.99, 15, "WYB005");
            Item fertilizer = new Item("Garden", "11.31 lb Bag Triple Action Fertilizer", 32.49, 18, "WYB006");
            Item pens = new Item("Office", "8-Pack Ballpoint Pens", 12.59, 20, "WYB007");
            Item folders = new Item("Office", "25-Pack File Folders", 11.69, 17, "WYB008");
            Item shirt = new Item("Clothing", "Men's Graphic Tee Size: Extra Schmedium", 14.99, 20, "WYB009");
            Item shoes = new Item("Clothing", "Jank Brand Shoes", 23.49, 20, "WYB010");
            myProgram.AddToStoreInventory(plunger);
            myProgram.AddToStoreInventory(hangers);
            myProgram.AddToStoreInventory(dongle);
            myProgram.AddToStoreInventory(controller);
            myProgram.AddToStoreInventory(shovel);
            myProgram.AddToStoreInventory(fertilizer);
            myProgram.AddToStoreInventory(pens);
            myProgram.AddToStoreInventory(folders);
            myProgram.AddToStoreInventory(shirt);
            myProgram.AddToStoreInventory(shoes);
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

        public void AddToStoreInventory(Item newItem)
        {
            if (storeInventorySize == storeInventory.Length)
            {
                Console.WriteLine("\nInventory Full.\n");
                return;
            }
            storeInventory[storeInventorySize++] = newItem;
            Console.WriteLine("{0} added to Store Inventory.\n", newItem.itemName);
        }

        public void AddToCart(Item newItem)
        {
            if(cartInventorySize == cartInventory.Length)
            {
                Console.WriteLine("\nCart has a maximum of 10 items.\n");
                return;
            }
            cartInventory[cartInventorySize++] = newItem;
        }

        public void DisplayStoreInventory()
        {
            Console.WriteLine("================================================= STORE INVENTORY ======================================================");
            for (int i = 0; i < storeInventorySize; i++)
            {
                Console.WriteLine(storeInventory[i].displayInfo("stock"));
            }
        }

        public void DisplayCartInventory()
        {
            Console.WriteLine("\n================================================= CART INVENTORY =======================================================\n");
            if(cartInventorySize == 0)
            {
                Console.WriteLine("\nNo items in cart.\nReturning to Main Menu.\n");
                MainMenu();
            }
            for (int i = 0; i < cartInventorySize; i++)
            {
                Console.WriteLine(cartInventory[i].displayInfo("cart"));
                Console.WriteLine();
            }
        }

        public void SearchStoreInventory()
        {
            Console.WriteLine("\nHow would you like to Search?\n1. Item Type\n2. Serial Number\n3. Return to Main Menu\n");
            command = Console.ReadLine();
            if(command == "1" || command == "2" || command == "3")
            {
                if(command == "1")
                {
                    SearchByType();
                }
                else if(command == "2")
                {
                    SearchBySerialNumber();
                }
                else if(command == "3")
                {
                    MainMenu();
                }

            }
            Console.WriteLine("INVALID INPUT (Use corresponding numbers to execute a command.)\nReturning to Search Menu.\n");
            SearchStoreInventory();

        }

        public void SearchByType()
        {
            int s = 0;
            Console.WriteLine("\nEnter the Item Type you would like to search.\n");
            searchString = Console.ReadLine();
            for(int  i = 0; i < storeInventorySize; i++)
            {
                if(storeInventory[i].itemType.Equals(searchString, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(storeInventory[i].displayInfo("stock")); 
                    s++;
                }
                
            }

            if(s == 0)
            {
                Console.WriteLine("\nNot a valid Item Type\nReturning to Search Menu.\n");
                SearchStoreInventory();
            }
            Console.WriteLine("\nReturning to Main Menu.\n");
            MainMenu();
        }

        public void SearchBySerialNumber()
        {
            int s = 0;
            Console.WriteLine("\nEnter the Serial Number of the Item you would like to search.\n");
            searchString = Console.ReadLine();
            for(int i = 0; i < storeInventorySize; i++)
            {
                if(storeInventory[i].itemSerialNumber.Equals(searchString, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(storeInventory[i].displayInfo("stock"));
                    s++;
                    
                }
            }
            if(s == 0)
            {
                Console.WriteLine("\nNo match found for: " + searchString + "\nReturning to Search Menu.\n");
                SearchStoreInventory();
            }
            Console.WriteLine("\nReturning to Main Menu.\n");
            MainMenu();
        }

        public void BuyMenu()
        {
            Console.WriteLine("\nWhat would you like to buy? (Enter item Serial Number as it appears in item display)");
            itemToBuy = Console.ReadLine();
            foreach (Item i in storeInventory)
            {
                if (itemToBuy == i.itemSerialNumber)
                {
                    Console.WriteLine("Item found. How many would you like to buy?");
                    purchaseQuantityString = Console.ReadLine();
                    if (int.TryParse(purchaseQuantityString, out purchaseQuantity))
                    {
                        if (i.itemStockQuantity >= purchaseQuantity)
                        {
                            i.itemStockQuantity = i.itemStockQuantity - purchaseQuantity;
                            i.itemCartQuantity = i.itemCartQuantity + purchaseQuantity;
                            i.UpdateQuantity();
                            if(i.itemCartQuantity == purchaseQuantity)
                            {
                                AddToCart(i);
                            }
                            if(i.itemStockQuantity == 0)
                            {
                                RemoveFromInventory(i.itemSerialNumber);
                            }
                            Console.WriteLine("Thank you for your purchase(s)!\nReturning to Main Menu.");
                            MainMenu();
                            return;
                        }
                        Console.WriteLine("Not enough in stock!\nReturning to Buy Menu.");
                        BuyMenu();
                    }
                    Console.WriteLine("Not a valid format.\nReturning to Buy Menu.");
                    BuyMenu();
                }                   
            }
            Console.WriteLine("Could not find product with Serial Number: " + itemToBuy);
            Console.WriteLine("Returning to Buy Menu.\n");
            BuyMenu();
            return;
        }

        public void RemoveQuantityFromCart()
        {
            Console.WriteLine("\nWhat item would you like to remove from cart? (Enter Serial Number as it appears in display)\n");
            itemToRemove = Console.ReadLine();
            foreach(Item i in cartInventory)
            {
                if(itemToRemove == i.itemSerialNumber)
                {
                    Console.WriteLine("Item found. How many would you like to remove?");
                    removeQuantityString = Console.ReadLine();
                    if(int.TryParse(removeQuantityString, out removeQuantity))
                    {
                        if(i.itemCartQuantity >= removeQuantity)
                        {
                            
                            i.itemCartQuantity = i.itemCartQuantity - removeQuantity;
                            i.itemStockQuantity = i.itemStockQuantity + removeQuantity;
                            i.UpdateQuantity();
                            if(i.itemCartQuantity == 0)
                            {
                                RemoveFromCart(i.itemSerialNumber);
                            }
                            if (i.itemStockQuantity == removeQuantity)
                            {
                                AddToStoreInventory(i);
                            }
                            Console.WriteLine("\nItem(s) removed from cart.\n");
                            MainMenu();
                            return;
                        }
                        Console.WriteLine("\nQuantity requested exceeds amount in cart.\nReturning to Remove Menu.\n");
                        RemoveQuantityFromCart();
                    }
                    Console.WriteLine("\nNot a valid format.\nReturning to Remove Menu.\n");
                    RemoveQuantityFromCart();
                }
            }
            Console.WriteLine("Could not find product with Serial Number: " + itemToRemove);
            Console.WriteLine("Returning to Remove Menu.\n");
            RemoveQuantityFromCart();
            return;
        }

        public void RemoveFromInventory(string deleteSerialNumber)
        {
            int j = 0;
            Item[] tempItems = new Item[storeInventory.Length];
            for(int i = 0; i < storeInventory.Length; i++)
            {
                if(deleteSerialNumber == storeInventory[i].itemSerialNumber)
                {
                    continue;
                }
                tempItems[j++] = storeInventory[i];
            }
            storeInventorySize--;
            storeInventory = tempItems;
        }

        public void RemoveFromCart(string deleteSerialNumber)
        {
            int j = 0;
            Item[] tempItems = new Item[cartInventory.Length];
            for(int i = 0; i < cartInventory.Length; i++)
            {
                if(deleteSerialNumber == cartInventory[i].itemSerialNumber)
                {
                    continue;
                }
                tempItems[j++] = cartInventory[i];
            }
            cartInventorySize--;
            cartInventory = tempItems;
        }

        public void Exit()
        {
            Console.WriteLine("Press Enter to Exit program.");
            Console.Read();
        }
    }
}
