using CSharpCollections.Interfaces.ICollection;
using CSharpCollections.Models;
using System;

namespace CSharpCollections.Collections.Observable
{
    public class ObservableCollectionExample : BaseClass
    {

        public static void Run()
        {
            PrintTitle("OBSERVABLE COLLECTION");

            PeopleCollection<Person> people = new PeopleCollection<Person>();
            string divider = new string('-', 30);

            Action<string> printTitle = (title) =>
            {
                Console.WriteLine(divider);
                Console.WriteLine(title);
                Console.WriteLine(divider);
            };

            Action printList = () =>
            {
                printTitle("LIST");
                foreach (Person p in people)
                {
                    Console.WriteLine(p.Name);
                }
                Console.WriteLine();
            };

            printTitle("ADDING PEOPLE");
            people.Add(new Person { Name = "Mary" });
            people.Add(new Person { Name = "John" });
            people.Add(new Person { Name = "Phillip" });
            people.Add(new Person { Name = "Joan" });
            people.Add(new Person { Name = "Barry" });

            printList();

            // ---
            printTitle("Changing Mary to Bernard");
            Person mary = people[0];
            mary.Name = "Bernard";
            people[0] = mary;

            printList();

            // ---
            printTitle("Removing Bernard");
            people.Remove(mary);

            printList();


            // ----
            printTitle("Clearing List");
            people.Clear();
        }
    }
}
