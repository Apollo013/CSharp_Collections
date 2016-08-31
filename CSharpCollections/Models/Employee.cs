using System;

namespace CSharpCollections.Models
{
    public class Employee : Person
    {
        public string Id { get; set; }
        public Employee()
        {
            Id = Guid.NewGuid().ToString();
        }
        public override string ToString()
        {
            return $"{this.Id} - {this.Name}";
        }
    }
}
