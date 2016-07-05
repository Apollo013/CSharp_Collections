using CSharpCollections.Collections.Concurrent;
using CSharpCollections.Collections.Generic;

namespace CSharpCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            ConcurrentDictionaryCollection.Run();
            ConcurrentQueueCollection.Run();
            ConcurrentStackCollection.Run();
            ConcurrentBagCollection.Run();

            GenericDictionaryCollection.Run();
            GenericComparerCollection.Run();
        }
    }
}
