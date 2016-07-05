using System;
using System.Collections.Concurrent;

namespace CSharpCollections.Collections.Concurrent
{
    public class ConcurrentBagCollection : BaseClass
    {
        public static void Run()
        {
            PrintTitle("CONCURRENT BAG");

            // Construct and populate the ConcurrentBag
            ConcurrentBag<int> cb = new ConcurrentBag<int>();
            cb.Add(1);
            cb.Add(2);
            cb.Add(3);

            // Consume the items in the bag
            int item;
            while (!cb.IsEmpty)
            {
                if (cb.TryTake(out item))
                {
                    Console.WriteLine(item);
                }
                else
                {
                    Console.WriteLine("TryTake failed for non-empty bag");
                }
            }

            // Bag should be empty at this point
            if (cb.TryPeek(out item))
            {
                Console.WriteLine("TryPeek succeeded for empty bag!");
            }
        }
    }
}
