using System;
using System.Collections.Generic;

namespace CSharpCollections.Collections.Generic
{
    public class GenericHashSetCollection : BaseClass
    {
        public static void Run()
        {
            PrintTitle("GENERIC COLLECTIONS - HASHSET");

            HashSet<int> evenNumbers = new HashSet<int>();
            HashSet<int> oddNumbers = new HashSet<int>();

            for (int i = 0; i < 5; i++)
            {
                evenNumbers.Add(i * 2);         // Populate numbers with just even numbers.
                oddNumbers.Add((i * 2) + 1);    // Populate oddNumbers with just odd numbers.
            }

            DisplaySet("evenNumbers", evenNumbers);
            DisplaySet("oddNumbers", oddNumbers);

            // Create a new HashSet populated with even numbers.
            HashSet<int> numbers = new HashSet<int>(evenNumbers);
            numbers.UnionWith(oddNumbers);
            
            DisplaySet("Union numbers", numbers);
        }

        private static void DisplaySet(string title, HashSet<int> set)
        {
            Console.Write($"{title} contains {set.Count} elements: {{");
            foreach (int i in set)
            {
                Console.Write($" {i}");
            }
            Console.WriteLine(" }");
        }
    }
}
