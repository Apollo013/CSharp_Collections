using System.Collections.Generic;

namespace CSharpCollections.Models.EqualityComparers
{
    public class BoxDimensionsEqualityComparer : EqualityComparer<Box>
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

            if (b1.Height == b2.Height && b1.Length == b2.Length && b1.Width == b2.Width)
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
            int hCode = bx.Height ^ bx.Length ^ bx.Width;
            return hCode.GetHashCode();
        }
    }
}
