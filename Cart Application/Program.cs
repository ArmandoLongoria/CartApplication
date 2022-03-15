using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart_Application
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=========================================== WHAT'RE YA BUYIN' SUPERMART ================================================");
            Console.WriteLine("========================================== Copyright ARMAND LONGORIA 2022 ==============================================");
            Cart_Functionality myFunctionality = new Cart_Functionality();
            Program myProgram = new Program();
            myProgram.MenuActions(myFunctionality);
        }

        public void MenuActions(Cart_Functionality functionality)
        {
            int action = 0;
            while(action < 6)
            {
                action = Prompts.MainMenu();
                switch (action)
                {
                    case 1: functionality.DisplayStoreInventory(); break;
                    case 2: functionality.SearchStoreInventory(); break;
                    case 3: functionality.DisplayCartInventory(); break;
                    case 4: functionality.BuyItem(); break;
                    case 5: functionality.RemoveQuantityFromCart(); break;
                    case 6: Exit(); break;
                }
            } 
        }

        public void Exit()
        {
            Console.WriteLine("Press Enter to Exit program.");
            Console.Read();
        }
    }
}
