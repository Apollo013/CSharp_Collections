﻿using CSharpCollections.Models;
using System.Collections.Generic;

namespace CSharpCollections.Comparers
{
    public class BoxLengthFirstComparer : Comparer<Box>
    {
        // Compares by Length, Height, and Width.
        public override int Compare(Box x, Box y)
        {
            if (x.Length.CompareTo(y.Length) != 0)
            {
                return x.Length.CompareTo(y.Length);
            }
            else if (x.Height.CompareTo(y.Height) != 0)
            {
                return x.Height.CompareTo(y.Height);
            }
            else if (x.Width.CompareTo(y.Width) != 0)
            {
                return x.Width.CompareTo(y.Width);
            }
            else
            {
                return 0;
            }
        }
    }
}
