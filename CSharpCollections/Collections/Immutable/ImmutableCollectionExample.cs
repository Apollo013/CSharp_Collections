using CSharpCollections.Models;
using System;
using System.Collections.Immutable;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpCollections.Collections.Immutable
{
    public class ImmutableCollectionExample
    {
        private static ImmutableList<Employee> employees = null;

        public static void Run()
        {
            var e1 = new Employee() { Name = "Mary" };
            var e2 = new Employee() { Name = "John" };
            var e3 = new Employee() { Name = "William" };
            var e4 = new Employee() { Name = "Clare" };

            employees = ImmutableList.Create<Employee>(new Employee[] { e1, e2, e3, e4 });

            Task.Run(() => PrintFromImmutableList());
            Task.Run(() => PrintFromImmutableList());
            Task.Run(() => PrintFromImmutableList());
            Task.Run(() => PrintFromImmutableList());
            Task.Run(() => PrintFromImmutableList());

            Console.ReadLine();
        }

        private static void PrintFromImmutableList()
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} starting to read from immutable list.");
            int collectionSize = employees.Count;
            while (true)
            {
                Random random = new Random();
                int index = random.Next(collectionSize);
                Console.WriteLine($"{employees[index].Name} : Thread {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(1000);
            }
        }
    }
}

