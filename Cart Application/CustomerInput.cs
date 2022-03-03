using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart_Application
{
    class CustomerInput
    {
        public static int GetInt()
        {
            int numberInput = 0;
            string numberInputString = Console.ReadLine();
            if (!int.TryParse(numberInputString, out numberInput))
            {
                    numberInput = 0;
            }
            return numberInput;
        }

        public static string GetString()
        {
            string inputString = "";

            while (String.IsNullOrEmpty(inputString))
            {
                inputString = Console.ReadLine();
                inputString = inputString.Trim();       
            }
            return inputString;
        }

 
    }
}
