using CSharpCollections.Models.EqualityComparers;
using System;

namespace CSharpCollections.Models
{
    public class Box : IComparable<Box>, IEquatable<Box>
    {
        public int Height { get; private set; }
        public int Length { get; private set; }
        public int Width { get; private set; }

        public Box(int h, int l, int w)
        {
            this.Height = h;
            this.Length = l;
            this.Width = w;
        }

        public int CompareTo(Box other)
        {
            // Compares Height, Length, and Width.
            if (this.Height.CompareTo(other.Height) != 0)
            {
                return this.Height.CompareTo(other.Height);
            }
            else if (this.Length.CompareTo(other.Length) != 0)
            {
                return this.Length.CompareTo(other.Length);
            }
            else if (this.Width.CompareTo(other.Width) != 0)
            {
                return this.Width.CompareTo(other.Width);
            }
            else
            {
                return 0;
            }
        }

        public bool Equals(Box other)
        {
            if (new BoxDimensionsEqualityComparer().Equals(this, other))
            {
                return true;
            }
            else
            {
                return false;
            };
        }
    }
}
