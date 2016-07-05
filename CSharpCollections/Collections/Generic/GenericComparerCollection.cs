using CSharpCollections.Models;
using System;
using System.Collections.Generic;

namespace CSharpCollections.Collections.Generic
{
    public class GenericComparerCollection : BaseClass
    {
        public static void Run()
        {
            PrintTitle("GENERIC COLLECTIONS - COMPARER");

            Action<Box> printMeasurements = (box) =>
            {
                Console.WriteLine($"{box.Height.ToString()}\t{box.Length.ToString()}\t{box.Width.ToString()}");
            };

            Action<string> printMeasurementHeader = (title) => 
            {
                string divider = new String('=', 20);
                Console.WriteLine();
                Console.WriteLine(divider);
                Console.WriteLine(title);
                Console.WriteLine(divider);
                Console.WriteLine("H\tL\tW");
                Console.WriteLine(divider);
            };

            List<Box> Boxes = new List<Box>();
            Boxes.Add(new Box(4, 20, 14));
            Boxes.Add(new Box(12, 12, 12));
            Boxes.Add(new Box(8, 20, 10));
            Boxes.Add(new Box(6, 10, 2));
            Boxes.Add(new Box(2, 8, 4));
            Boxes.Add(new Box(2, 6, 8));
            Boxes.Add(new Box(4, 12, 20));
            Boxes.Add(new Box(18, 10, 4));
            Boxes.Add(new Box(24, 4, 18));
            Boxes.Add(new Box(10, 4, 16));
            Boxes.Add(new Box(10, 2, 10));
            Boxes.Add(new Box(6, 18, 2));
            Boxes.Add(new Box(8, 12, 4));
            Boxes.Add(new Box(12, 10, 8));
            Boxes.Add(new Box(14, 6, 6));
            Boxes.Add(new Box(16, 6, 16));
            Boxes.Add(new Box(2, 8, 12));
            Boxes.Add(new Box(4, 24, 8));
            Boxes.Add(new Box(8, 6, 20));
            Boxes.Add(new Box(18, 18, 12));

            // Sort by an Comparer<T> implementation that sorts first by the length.
            printMeasurementHeader("Sorted On Length");
            Boxes.Sort(new BoxLengthFirstComparer());            
            foreach (Box bx in Boxes) { printMeasurements(bx); }


            // Calling Boxes.Sort() with no parameter is the same as calling Boxs.Sort(defComp) because they are both using the default comparer.
            // Get the default comparer that sorts first by the height.
            printMeasurementHeader("Sorted On Height");
            Comparer<Box> defComp = Comparer<Box>.Default;
            Boxes.Sort(defComp);            
            foreach (Box bx in Boxes){ printMeasurements(bx); }


            // This explicit interface implementation compares first by the length.
            // Returns -1 because the length of BoxA is less than the length of BoxB.
            BoxLengthFirstComparer LengthFirst = new BoxLengthFirstComparer();

            Comparer<Box> bc = (Comparer<Box>)LengthFirst;

            Box BoxA = new Box(2, 6, 8);
            Box BoxB = new Box(10, 12, 14);
            int x = LengthFirst.Compare(BoxA, BoxB);
            Console.WriteLine();
            Console.WriteLine(x.ToString());
        }
    }
}
