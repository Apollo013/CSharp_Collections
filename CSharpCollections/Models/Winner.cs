namespace CSharpCollections.Models
{
    public class Winner : Person
    {
        public int Year { get; set; }
        public override string ToString()
        {
            return $"{Name} - \t{Year}";
        }
    }
}
