﻿using CSharpCollections.Collections.Concurrent;
using CSharpCollections.Collections.Generic;
using CSharpCollections.Comparers;
using CSharpCollections.EqualityComparers;
using CSharpCollections.Interfaces.ICollection;
using CSharpCollections.Interfaces.IEnumerable;

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
            

            // COMPARISON CLASSES
            //GenericComparerClass.Run();
            //GenericEqualityComparerClass.Run();
            

            // GENERIC COLLECTIONS
            //GenericDictionaryCollection.Run();
            //GenericHashSetCollection.Run();


            // INTERFACE COLLECTIONS
            //GenericCustomICollection.Run();
            GenericCustomIEnumerable.Run();
        }
    }
}
