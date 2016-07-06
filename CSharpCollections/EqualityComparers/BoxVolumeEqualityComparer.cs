using CSharpCollections.Models;
using System.Collections.Generic;

namespace CSharpCollections.EqualityComparers
{
    public class BoxVolumeEqualityComparer : EqualityComparer<Box>
    {
        public override bool Equals(Box b1, Box b2)
        {
            if (b1 == null && b2 == null)
            {
                return true;
            }
                
            else if (b1 == null || b2 == null)
            {
                return false;
            }
                
            if (b1.Height * b1.Width * b1.Length == b2.Height * b2.Width * b2.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode(Box bx)
        {       
            int hCode = bx.Height * bx.Length * bx.Width;
            return hCode.GetHashCode();
        }
    }
}
