using System;
using System.Collections.Generic;

namespace CSharpCollections.Collections.Generic
{
    public class GenericListCollection : BaseClass
    {
        public static void Run()
        {
            PrintTitle("LIST COLLECTION");

            List<string> dinosaurs = new List<string>();
            string divider = new String('-', 30);

            Action<string> printCapacity = (title) =>
            {                
                Console.WriteLine();
                Console.WriteLine(divider);
                Console.WriteLine(title);
                Console.WriteLine(divider);
                Console.WriteLine($"Capacity: {dinosaurs.Capacity}");
                Console.WriteLine($"Count: {dinosaurs.Count}");
                Console.WriteLine(divider);
            };

            Action printList = () =>
            {
                Console.WriteLine();
                Console.WriteLine(divider);
                Console.WriteLine("Contents");
                Console.WriteLine(divider);
                foreach (string dinosaur in dinosaurs)
                {
                    Console.WriteLine(dinosaur);
                }
            };


            printCapacity("Before Insertion");            

            dinosaurs.Add("Tyrannosaurus");
            dinosaurs.Add("Amargasaurus");
            dinosaurs.Add("Mamenchisaurus");
            dinosaurs.Add("Deinonychus");
            dinosaurs.Add("Compsognathus");
            Console.WriteLine();
            foreach (string dinosaur in dinosaurs)
            {
                Console.WriteLine(dinosaur);
            }

            printCapacity("After Insertion");

            Console.WriteLine($"\nContains('Deinonychus'): {dinosaurs.Contains("Deinonychus")}");

            Console.WriteLine("\nInsert(2, 'Compsognathus')");
            dinosaurs.Insert(2, "Compsognathus");
            dinosaurs.Sort();

            printList();

            // Shows accessing the list using the Item property.
            Console.WriteLine($"\ndinosaurs[3]: {dinosaurs[3]}");

            Console.WriteLine("\nRemove('Compsognathus')");
            dinosaurs.Remove("Compsognathus");
            dinosaurs.Reverse();

            printList();

            dinosaurs.TrimExcess();
            printCapacity("TrimExcess()");

            dinosaurs.Clear();            
            printCapacity("Clear()");
        }
    }
}
