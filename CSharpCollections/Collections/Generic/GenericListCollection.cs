using CSharpCollections.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpCollections.Collections.Generic
{
    public class GenericListCollection : BaseClass
    {
        public static void Run()
        {
            PrintTitle("LIST COLLECTION");
            BasicExample();
            JoinExample();
        }

        private static void BasicExample()
        {
            PrintSubTitle("Basics");

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

        private static void JoinExample()
        {
            PrintSubTitle("Join 2 Lists");

            Person magnus = new Person { Name = "Hedlund, Magnus" };
            Person terry = new Person { Name = "Adams, Terry" };
            Person charlotte = new Person { Name = "Weiss, Charlotte" };

            Pet barley = new Pet { Name = "Barley", Owner = terry };
            Pet boots = new Pet { Name = "Boots", Owner = terry };
            Pet whiskers = new Pet { Name = "Whiskers", Owner = charlotte };
            Pet daisy = new Pet { Name = "Daisy", Owner = magnus };

            List<Person> people = new List<Person> { magnus, terry, charlotte };
            List<Pet> pets = new List<Pet> { barley, boots, whiskers, daisy };

            // Create a list of Person-Pet pairs where 
            // each element is an anonymous type that contains a
            // Pet's name and the name of the Person that owns the Pet.
            var query = people.Join(pets,
                                    person => person,
                                    pet => pet.Owner,
                                    (person, pet) =>
                                    new { OwnerName = person.Name, Pet = pet.Name });

            foreach (var obj in query)
            {
                Console.WriteLine($"{obj.OwnerName} - {obj.Pet}");
            }
        }
    }
}
