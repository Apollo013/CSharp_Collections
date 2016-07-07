using System;

namespace CSharpCollections.Models
{
    public class Person : IEquatable<Person>
    {
        public string Name { get; set; }

        public bool Equals(Person other)
        {
            return this.Name.Equals(other.Name);
        }
    }
}
