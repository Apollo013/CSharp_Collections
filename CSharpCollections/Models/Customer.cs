namespace CSharpCollections.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Customer() { }

        public Customer(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}
