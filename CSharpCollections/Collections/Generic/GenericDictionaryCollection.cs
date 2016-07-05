using CSharpCollections.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpCollections.Collections.Generic
{
    public class GenericDictionaryCollection : BaseClass
    {
        private static Dictionary<int, Customer> customers;

        public static void Run()
        {
            PrintTitle("GENERIC COLLECTIONS - DICTIONARY");

            customers = new Dictionary<int, Customer>();
            CreateList();
            PrintKeyValuePairs();
            PrintValuesCollection();
            PrintKeysCollection();

            Take2();
            NameSearch();
            GetEnumerator();

            ThrowArguementException();
            ThrowKeyNotFoundException();
            TryGetValue();

            RemoveKey(2);
        }

        private static void CreateList()
        {
            Customer cust1 = new Customer(1, "Cust 1");
            Customer cust2 = new Customer(2, "Cust 2");
            Customer cust3 = new Customer(3, "Cust 3");

            customers.Add(cust1.ID, cust1);
            customers.Add(cust2.ID, cust2);
            customers.Add(cust3.ID, cust3);
        }

        /// <summary>
        /// Remove an element by key
        /// </summary>
        /// <param name="key"></param>
        private static void RemoveKey(int key)
        {
            PrintSubTitle($"REMOVING KEY: {key}");

            customers.Remove(key);
            PrintKeyValuePairs();
        }

        /// <summary>
        /// Throws an error when adding an already existing key
        /// </summary>
        private static void ThrowArguementException()
        {
            PrintSubTitle("EXCEPTION HANDLING - ThrowArguementException");

            // Throw an exception when adding an existing key
            Customer cust1 = new Customer(1, "Cust 7");
            try
            {
                customers.Add(cust1.ID, cust1);
            }
            catch (ArgumentException)
            {
                Console.WriteLine($"An element with Key {cust1.ID} already exists.");
            }
        }

        /// <summary>
        /// Throw an error when key not found
        /// </summary>
        private static void ThrowKeyNotFoundException()
        {
            PrintSubTitle("EXCEPTION HANDLING - ThrowKeyNotFoundException");

            // Throw an exception when a key does not exist
            try
            {
                var cust = customers[10];   // Access element with index
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine($"An element with Key 10 does not exists.");
            }
        }

        /// <summary>
        /// Attempts to get a value without throwing an error
        /// </summary>
        private static void TryGetValue()
        {
            PrintSubTitle("TRY GET VALUE");

            // When a program often has to try keys that turn out not to
            // be in the dictionary, TryGetValue can be a more efficient 
            // way to retrieve values.
            Customer customer;
            if (customers.TryGetValue(1, out customer))
            {
                Console.WriteLine($"Customer ID: {customer.ID}, Name: {customer.Name}");
            }
            else
            {
                Console.WriteLine("Customer not found.");
            }
        }

        /// <summary>
        /// Print Dictionary Key/Value Pairs
        /// </summary>
        private static void PrintKeyValuePairs()
        {
            PrintSubTitle("KEY VALUE PAIRS");

            foreach (KeyValuePair<int, Customer> customerSet in customers)
            {
                Console.WriteLine($"Customer ID: {customerSet.Key}, Name: {customerSet.Value.Name}");
            }
        }

        /// <summary>
        /// Print Dictionary Values
        /// </summary>
        private static void PrintValuesCollection()
        {
            PrintSubTitle("VALUE COLLECTION");

            // To get the values alone, use the Values property.
            Dictionary<int, Customer>.ValueCollection valueCol = customers.Values;
            foreach (Customer cust in valueCol)
            {
                Console.WriteLine($"Customer ID: {cust.ID}, Name: {cust.Name}");
            }
        }

        /// <summary>
        /// Print Dictionary Keys
        /// </summary>
        private static void PrintKeysCollection()
        {
            PrintSubTitle("KEY COLLECTION");

            // To get the values alone, use the Values property.
            Dictionary<int, Customer>.KeyCollection keyColl = customers.Keys;
            foreach (int id in keyColl)
            {
                Console.WriteLine($"Customer ID: {id}");
            }
        }

        /// <summary>
        /// Orders list in descending order using linq and prints the top 2
        /// </summary>
        private static void Take2()
        {
            PrintSubTitle("LINQ - TAKE 2");

            // To get the values alone, use the Values property.            
            var customerList = (from c in customers.Values
                                orderby c.Name descending
                                select c).Take(2);

            foreach (Customer cust in customerList)
            {
                Console.WriteLine($"Customer ID: {cust.ID}, Name: {cust.Name}");
            }
        }

        private static void NameSearch()
        {
            PrintSubTitle("NAME SEARCH");

            // To get the values alone, use the Values property.            
            var customerList = (from c in customers.Values
                                orderby c.Name descending
                                select c).Where(c => c.Name.Contains("2"));

            foreach (Customer cust in customerList)
            {
                Console.WriteLine($"Customer ID: {cust.ID}, Name: {cust.Name}");
            }
        }


        private static void GetEnumerator()
        {
            PrintSubTitle("ENUMERATOR");

            var enumerator = customers.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var pair = enumerator.Current;
                Console.WriteLine($"Customer ID: {pair.Value.ID}, Name: {pair.Value.Name}");
            };
        }
    }
}
