using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart_Application
{
    class CustomerInput
    {
        /*public static int GetInt()
        {
            int numberInput = 0;
            string numberInputString = Console.ReadLine();
            if (!int.TryParse(numberInputString, out numberInput))
            {
                    numberInput = 0;
            }
            return numberInput;
        }*/

        public static int GetInt()
        {
            int intInput = 0;
            string stringInput = Console.ReadLine();
            return int.TryParse(stringInput, out intInput) ? intInput : 0;
        }

        public static string GetString()
        {
            string inputString = "";

            if (String.IsNullOrEmpty(inputString))
            {
                inputString = Console.ReadLine();
                inputString = inputString.Trim();       
            }
            return inputString;
        }

 
    }
}
