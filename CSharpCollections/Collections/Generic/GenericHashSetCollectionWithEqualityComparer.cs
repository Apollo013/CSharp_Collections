using CSharpCollections.EqualityComparers;
using CSharpCollections.Models;
using System;
using System.Collections.Generic;

namespace CSharpCollections.Collections.Generic
{
    public class GenericHashSetCollectionWithEqualityComparer
    {
        public static void Run()
        {
            Winner w1 = new Winner() { Name = "Novak Djokovic", Year = 2016 };
            Winner w2 = new Winner() { Name = "Stan Wawrinka", Year = 2015 };
            Winner w3 = new Winner() { Name = "Rafael Nadal", Year = 2014 };
            Winner w4 = new Winner() { Name = "Rafael Nadal", Year = 2013 };
            Winner w5 = new Winner() { Name = "Rafael Nadal", Year = 2012 };

            Winner w6 = new Winner() { Name = "Garbiñe Muguruza", Year = 2016 };
            Winner w7 = new Winner() { Name = "Maria Sharapova", Year = 2015 };
            Winner w8 = new Winner() { Name = "Rafael Nadal", Year = 2014 };
            Winner w9 = new Winner() { Name = "Serena Williams", Year = 2013 };
            Winner w10 = new Winner() { Name = "Maria Sharapova", Year = 2012 };

            HashSet<Winner> FrenchOpenWinners1 = new HashSet<Winner>() { w1, w2, w3, w4, w5, w6, w7, w8, w9, w10 };
            Print("Without Equatable Comparer", FrenchOpenWinners1);

            HashSet<Winner> FrenchOpenWinners2 = new HashSet<Winner>(new FrenchOpenWinnersComparer()) { w1, w2, w3, w4, w5, w6, w7, w8, w9, w10 };
            Print("With Equatable Comparer", FrenchOpenWinners2);
        }

        private static void Print(string title, HashSet<Winner> winners)
        {
            Console.WriteLine();
            string divider = new String('=', 80);
            Console.WriteLine(divider);
            Console.WriteLine(title);
            Console.WriteLine(divider);

            foreach (var winner in winners)
            {
                Console.WriteLine(winner.ToString());
            }
        }
    }
}
