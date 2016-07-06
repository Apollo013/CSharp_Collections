using CSharpCollections.Models;
using CSharpCollections.EqualityComparers;
using System;
using System.Collections;
using CSharpCollections.Collections;

namespace CSharpCollections.Interfaces.ICollection
{
    public class GenericCustomICollection : BaseClass
    {
        public static void Run()
        {            
            PrintTitle("GENERIC INTERFACES - ICOLLECTION(T)");

            BoxCollection bxList = new BoxCollection();

            bxList.Add(new Box(10, 4, 6));
            bxList.Add(new Box(4, 6, 10));
            bxList.Add(new Box(6, 10, 4));
            bxList.Add(new Box(12, 8, 10));

            // Same dimensions. Cannot be added:
            bxList.Add(new Box(10, 4, 6));

            // Test the Remove method.
            Display(bxList);
            Console.WriteLine("Removing 6x10x4");
            bxList.Remove(new Box(6, 10, 4));
            Display(bxList);

            // Test the Contains method.
            Box BoxCheck = new Box(8, 12, 10);
            Console.WriteLine($"Contains {BoxCheck.Height.ToString()}x{BoxCheck.Length.ToString()}x{BoxCheck.Width.ToString()} by volume: {bxList.Contains(BoxCheck).ToString()}"); 

            // Test the Contains method overload with a specified equality comparer (compares volume).
            Console.WriteLine($"Contains {BoxCheck.Height.ToString()}x{BoxCheck.Length.ToString()}x{BoxCheck.Width.ToString()} by volume: {bxList.Contains(BoxCheck, new BoxVolumeEqualityComparer()).ToString()}");

        }

        public static void Display(BoxCollection bxList)
        {
            /*
            Console.WriteLine("\nHeight\tLength\tWidth\tHash Code");
            foreach (Box bx in bxList)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}",
                    bx.Height.ToString(), bx.Length.ToString(),
                    bx.Width.ToString(), bx.GetHashCode().ToString());
            }
            */

            // Results by manipulating the enumerator directly:
            IEnumerator enumerator = bxList.GetEnumerator();
            Console.WriteLine("\nHeight\tLength\tWidth\tHash Code");
            while (enumerator.MoveNext())
            {
                Box b = (Box)enumerator.Current;
                Console.WriteLine("{0}\t{1}\t{2}\t{3}",
                b.Height.ToString(), b.Length.ToString(), 
                b.Width.ToString(), b.GetHashCode().ToString());
            }

            Console.WriteLine();
        }
    }
}
