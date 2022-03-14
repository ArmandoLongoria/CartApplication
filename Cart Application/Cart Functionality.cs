using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart_Application
{
    class Cart_Functionality
    {
        public int storeInventorySize = 0;
        public int cartInventorySize = 0;
        public Item[] storeInventory = new Item[10];
        Item[] cartInventory = new Item[10];
        
        public Cart_Functionality()
        {
            InitializeInventory();
        }

        private void InitializeInventory()
        {
            storeInventory[0] = new Item("Household", "Toilet Plunger", 17.38, 17, "WYB001");
            storeInventory[1] = new Item("Household", "30-Pack Durable Hangers", 10.65, 40, "WYB002");
            storeInventory[2] = new Item("Electronics", "Apple Lightning to 3.5mm Adapter", 14.99, 4, "WYB003");
            storeInventory[3] = new Item("Electronics", "PlayStation 5 DualSense Wireless Controller", 59.99, 6, "WYB004");
            storeInventory[4] = new Item("Garden", "Gardening Shovel", 24.99, 15, "WYB005");
            storeInventory[5] = new Item("Garden", "11.31 lb Bag Triple Action Fertilizer", 32.49, 18, "WYB006");
            storeInventory[6] = new Item("Office", "8-Pack Ballpoint Pens", 12.59, 20, "WYB007");
            storeInventory[7] = new Item("Office", "25-Pack File Folders", 11.69, 17, "WYB008");
            storeInventory[8] = new Item("Clothing", "Men's Graphic Tee Size: Extra Schmedium", 14.99, 20, "WYB009");
            storeInventory[9] = new Item("Clothing", "Jank Brand Shoes", 23.49, 20, "WYB010");
        }

        private void AddToStoreInventory(Item newItem)
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
            if (cartInventorySize == cartInventory.Length)
            {
                Console.WriteLine("\nCart has a maximum of 10 items.\n");
                return;
            }
            cartInventory[cartInventorySize++] = newItem;
        }

        public void DisplayStoreInventory()
        {
            Console.WriteLine("================================================= STORE INVENTORY ======================================================");
            if (storeInventorySize == 0)
            {
                Console.WriteLine("\nNo items in inventory.\nReturning to Main Menu.\n");
                return;
            }
            for (int i = 0; i < storeInventorySize; i++)
            {
                Console.WriteLine(storeInventory[i].displayInfo("stock"));
            }
        }

        public void DisplayCartInventory()
        {
            Console.WriteLine("\n================================================= CART INVENTORY =======================================================\n");
            if (cartInventorySize == 0)
            {
                Console.WriteLine("\nNo items in cart.\nReturning to Main Menu.\n");
                return;
            }
            for (int i = 0; i < cartInventorySize; i++)
            {
                Console.WriteLine(cartInventory[i].displayInfo("cart"));
                Console.WriteLine();
            }
        }

        public void SearchStoreInventory()
        {
            int command = Prompts.Search();
            if (command == 3) { return; }
            string searchString = Prompts.SearchPrompt(command);
            switch (command)
            {
                case 1: SearchByType(searchString); break;
                case 2: SearchBySerialNumber(searchString); break;
            }
        }

        private void SearchByType(string searchString)
        {
            for (int i = 0; i < storeInventorySize; i++)
            {
                if (storeInventory[i].itemType.Equals(searchString, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(storeInventory[i].displayInfo("stock"));
                }
            }
            Console.WriteLine("\nNot a valid Item Type\nReturning to Search Menu.\n");
        }

        private void SearchBySerialNumber(string searchString)
        {
            for (int i = 0; i < storeInventorySize; i++)
            {
                if (storeInventory[i].itemSerialNumber.Equals(searchString, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(storeInventory[i].displayInfo("stock"));
                }
            }
            Console.WriteLine("\nNo match found for: " + searchString + "\nReturning to Search Menu.\n");
        }

        public void RemoveQuantityFromCart()
        {
            string itemToRemove = Prompts.RemoveCartPrompt();
            for (int i = 0; i < cartInventorySize; i++)
            {
                if (itemToRemove == cartInventory[i].itemSerialNumber)
                {
                    QuantityCalculation(cartInventory[i]);
                    return;
                }
            }
            Console.WriteLine("Could not find product with Serial Number: " + itemToRemove);
        }

        private void QuantityCalculation(Item i)
        {
            int removeQuantity = Prompts.MoveQuantity("");
            if (i.itemCartQuantity >= removeQuantity)
            {
                i.itemCartQuantity = Functionality.Subtraction(i.itemCartQuantity, removeQuantity);
                i.itemStockQuantity = Functionality.Addition(i.itemStockQuantity, removeQuantity);
                i.UpdateQuantity();
                if (i.itemCartQuantity == 0)
                {
                    RemoveFromCart(i.itemSerialNumber);
                }
                if (i.itemStockQuantity == removeQuantity)
                {
                    AddToStoreInventory(i);
                }
                Console.WriteLine("\nItem(s) removed from cart.\n");
                return;
            }
            Console.WriteLine("\nQuantity requested exceeds amount in cart.\nReturning to Remove Menu.\n");
        }

        public void RemoveFromInventory(string deleteSerialNumber)
        {
            int j = 0;
            Item[] tempItems = new Item[storeInventory.Length];
            for (int i = 0; i < storeInventory.Length; i++)
            {
                if (deleteSerialNumber == storeInventory[i].itemSerialNumber)
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
            for (int i = 0; i < cartInventory.Length; i++)
            {
                if (deleteSerialNumber == cartInventory[i].itemSerialNumber)
                {
                    continue;
                }
                tempItems[j++] = cartInventory[i];
            }
            cartInventorySize--;
            cartInventory = tempItems;
        }

        public void BuyItem()
        {
            string itemToBuy = Prompts.BuyPrompt();
            for(int i = 0; i < storeInventorySize; i++)
            {
                if(itemToBuy == storeInventory[i].itemSerialNumber)
                {
                    BuyAmount(storeInventory[i]);
                    return;
                }
            }
            Console.WriteLine("Could not find product with Serial Number: " + itemToBuy);
        }

        public void BuyAmount(Item i)
        {
            int moveQuantity = Prompts.MoveQuantity("Buy");
            if (i.itemStockQuantity >= moveQuantity)
            {

                i.itemStockQuantity = Functionality.Subtraction(i.itemStockQuantity, moveQuantity);
                i.itemCartQuantity = Functionality.Addition(i.itemCartQuantity, moveQuantity);
                i.UpdateQuantity();
                if (i.itemCartQuantity == moveQuantity)
                {
                    AddToCart(i);
                }
                if (i.itemStockQuantity == 0)
                {
                   RemoveFromInventory(i.itemSerialNumber);
                }
                Console.WriteLine("Thank you for your purchase(s)!\nReturning to Main Menu.");
                return;
            }
            Console.WriteLine("Not enough in stock!\nReturning to Buy Menu.");                 
        }
    }
}
