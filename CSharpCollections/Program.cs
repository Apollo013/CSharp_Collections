using CSharpCollections.Collections.Concurrent;

namespace CSharpCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            ConcurrentDictionaryCollection.Run();
            ConcurrentQueueCollection.Run();
        }
    }
}
