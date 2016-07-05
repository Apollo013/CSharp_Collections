using CSharpCollections.Models;
using CSharpCollections.Models.EqualityComparers;
using System;
using System.Collections.Generic;

namespace CSharpCollections.Collections.Generic
{
    public class GenericEqualityComparerClass : BaseClass
    {
        private static Dictionary<Box, String> boxes;

        public static void Run()
        {
            PrintTitle("GENERIC COLLECTIONS - EQUALITY COMPARER");

            BoxDimensionsEqualityComparer boxDim = new BoxDimensionsEqualityComparer();
            boxes = new Dictionary<Box, string>(boxDim);

            Console.WriteLine("Box equality by dimensions:");
            Box redBox = new Box(8, 4, 8);
            Box greenBox = new Box(8, 6, 8);
            Box blueBox = new Box(8, 4, 8);
            Box yellowBox = new Box(8, 8, 8);
            AddBox(redBox, "red");
            AddBox(greenBox, "green");
            AddBox(blueBox, "blue");
            AddBox(yellowBox, "yellow");

            Console.WriteLine();
            Console.WriteLine("Box equality by volume:");

            BoxVolumeEqualityComparer boxVolume = new BoxVolumeEqualityComparer();
            boxes = new Dictionary<Box, string>(boxVolume);
            Box pinkBox = new Box(8, 4, 8);
            Box orangeBox = new Box(8, 6, 8);
            Box purpleBox = new Box(4, 8, 8);
            Box brownBox = new Box(8, 8, 4);
            AddBox(pinkBox, "pink");
            AddBox(orangeBox, "orange");
            AddBox(purpleBox, "purple");
            AddBox(brownBox, "brown");
        }

        public static void AddBox(Box bx, string name)
        {
            try
            {
                boxes.Add(bx, name);
                Console.WriteLine($"Added {name}, Count = {boxes.Count.ToString()}, HashCode = {bx.GetHashCode()}");
            }
            catch (ArgumentException)
            {
                Console.WriteLine($"A box equal to {name} is already in the collection.");
            }
        }
    }
}
