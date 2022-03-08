using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart_Application
{
    class Functionality
    {

        public static int Subtraction(int a, int b)
        {
            return a - b;
        }

        public static int Addition(int a, int b)
        {
            return a + b;
        }

        public static bool IsEqual(int a, int b)
        {
            return a == b;
        }

        public static bool IsGreater(int a, int b)
        {
            return a > b;
        }

        public static bool IsLess(int a, int b)
        {
            return a < b;
        }
        
        public static void Main(string[] args)
        {
            bool test = IsEqual(45, 45);
            Console.WriteLine("Answer is: " + test);
            Console.ReadKey();
        }
    }
}
