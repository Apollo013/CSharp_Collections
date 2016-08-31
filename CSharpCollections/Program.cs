using CSharpCollections.Collections.Generic;

namespace CSharpCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            // CONCURRENT COLLECTIONS
            //ConcurrentDictionaryCollection.Run();
            //ConcurrentQueueCollection.Run();
            //ConcurrentStackCollection.Run();
            //ConcurrentBagCollection.Run();
            //ConcurrentBlockingCollection.Run();


            // COMPARISON CLASSES
            //GenericComparerClass.Run();
            //GenericEqualityComparerClass.Run();


            // GENERIC COLLECTIONS
            //GenericDictionaryCollection.Run();
            //GenericHashSetCollection.Run();
            //GenericSortedDictionaryCollection.Run();
            //GenericLinkedListCollection.Run();
            //GenericListCollection.Run();
            // GenericAbstractKeyedCollection.Run();
            GenericHashSetCollectionWithEqualityComparer.Run();

            // OBSERVABLE COLLECTIONS
            // ObservableCollectionExample.Run();

            // INTERFACES
            //GenericCustomICollection.Run();
            //GenericCustomIEnumerable.Run();

        }
    }
}
