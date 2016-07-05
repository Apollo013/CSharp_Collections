using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCollections.Collections
{
    public class BaseClass
    {
        #region PRINT METHODS
        public static void PrintTitle(string title)
        {
            string divider = new String('*', 70);
            Console.WriteLine("");
            Console.WriteLine(divider);
            Console.WriteLine(title);
            Console.WriteLine(divider);
        }

        public static void PrintSubTitle(string title)
        {
            string divider = new String('=', 70);
            Console.WriteLine("");
            Console.WriteLine(divider);
            Console.WriteLine(title);
            Console.WriteLine(divider);
        }

        public static void PrintTime(double time)
        {
            string divider = new String('-', 70);
            Console.WriteLine(divider);
            Console.WriteLine($"Execution time = {time} seconds");
            Console.WriteLine(divider);
        }
        #endregion
    }
}
