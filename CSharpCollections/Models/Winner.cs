using System;

namespace CSharpCollections.Models
{
    public class Winner : Person, IComparable<Winner>
    {
        public int Year { get; set; }

        public int CompareTo(Winner other)
        {
            return this.Name.CompareTo(other.Name);
        }

        public override string ToString()
        {
            return $"{Name} - \t{Year}";
        }
    }
}
