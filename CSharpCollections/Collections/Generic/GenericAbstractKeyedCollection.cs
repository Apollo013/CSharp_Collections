using CSharpCollections.Models;
using System;
using System.Collections.ObjectModel;

namespace CSharpCollections.Collections.Generic
{
    public class GenericAbstractKeyedCollection
    {
        private static EmployeeKeyedDictionary employees;

        public static void Run()
        {
            var e1 = new Employee() { Name = "Mary" };
            var e2 = new Employee() { Name = "John" };
            var e3 = new Employee() { Name = "William" };
            var e4 = new Employee() { Name = "Clare" };

            employees = new EmployeeKeyedDictionary() { e1, e2, e3, e4 };

            PrintEmployees();
            GetEmployeeIndexOf(e4);
            GetEmployeeByKey(e2.Id);
            InsertEmployee(new Employee() { Name = "Heather" });
            RemoveEmployee(e3);
            RemoveEmployeeAt(2);
            ClearEmployees();
        }

        private static void GetEmployeeByKey(string key)
        {
            PrintTitle("GET EMPLOYEE BY 'KEY'");
            Console.WriteLine($"Key: {key}");
            var emp = employees[key];
            PrintEmployee(emp);
        }

        private static void GetEmployeeIndexOf(Employee emp)
        {
            PrintTitle("GET EMPLOYEE 'INDEXOF'");
            var idx = employees.IndexOf(emp);
            PrintEmployee(emp);
            Console.WriteLine($" - Index = {idx}");
        }

        private static void InsertEmployee(Employee emp)
        {
            PrintTitle("INSERT EMPLOYEE");
            Console.Write("Employee: ");
            PrintEmployee(emp);
            employees.Insert(2, emp);
            PrintEmployees();
        }

        private static void RemoveEmployee(Employee emp)
        {
            PrintTitle("REMOVE EMPLOYEE");
            Console.Write("Employee: ");
            PrintEmployee(emp);
            employees.Remove(emp);
            PrintEmployees();
        }

        private static void ClearEmployees()
        {
            PrintTitle("CLEAR EMPLOYEES");
        }

        private static void RemoveEmployeeAt(int idx)
        {
            PrintTitle("REMOVE EMPLOYEE AT");
            Console.WriteLine($"Removing Employee At Index: {idx} ");
            employees.RemoveAt(idx);
            PrintEmployees();
        }

        private static void PrintEmployees()
        {
            PrintTitle("EMPLOYEES", '*');
            foreach (var emp in employees)
            {
                Console.WriteLine(emp.ToString());
            }
        }

        private static void PrintEmployee(Employee emp)
        {
            Console.WriteLine(emp.ToString());
        }

        private static void PrintTitle(string title, char dividerMarker = '=')
        {
            Console.WriteLine();
            string divider = new String(dividerMarker, 80);
            Console.WriteLine(divider);
            Console.WriteLine(title);
            Console.WriteLine(divider);
        }
    }

    public class EmployeeKeyedDictionary : KeyedCollection<string, Employee>
    {
        /// <summary>
        /// Informs the collection which property acts as the key for this collection
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected override string GetKeyForItem(Employee item)
        {
            return item.Id;
        }
    }
}
