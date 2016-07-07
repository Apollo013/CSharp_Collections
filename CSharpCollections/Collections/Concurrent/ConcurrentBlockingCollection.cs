using CSharpCollections.Models;
using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpCollections.Collections.Concurrent
{
    public class ConcurrentBlockingCollection : BaseClass
    {
        public static void Run()
        {
            PrintTitle("BLOCKING COLLECTION");
            AddTakeExample();
            TryTakeExample();
            FromToAnyExample();
            //BlockingArraysExample();

        }

        private static void AddTakeExample()
        {
            PrintSubTitle("ADD / TAKE EXAMPLE");

            using (BlockingCollection<int> bc = new BlockingCollection<int>())
            {
                Task t1 = Task.Factory.StartNew(() =>
                {
                    bc.Add(1);
                    bc.Add(2);
                    bc.Add(3);
                    bc.CompleteAdding();

                });

                Task t2 = Task.Factory.StartNew(() =>
                {
                    try
                    {
                        while (true) Console.WriteLine(bc.Take());
                    }
                    catch (InvalidOperationException)
                    {
                        Console.WriteLine("That's All!");
                    }                
                });

               Task.WaitAll(t1, t2);
            }
        }

        private static void TryTakeExample()
        {
            PrintSubTitle("TRYTAKE EXAMPLE");

            BlockingCollection<int> bc = new BlockingCollection<int>();

            int numberOfItems = 1000;
            int outerSum = 0;

            // Generate some numbers
            for (int i = 0; i < numberOfItems; ++i)
            {
                bc.Add(i);
            }
            bc.CompleteAdding();

            // Delegate for adding up all numbers
            Action action = () =>
            {
                int item;
                int innerSum = 0;

                while(bc.TryTake(out item))
                {
                    innerSum += item;
                }

                Interlocked.Add(ref outerSum, innerSum);
            };

            // Launch three parallel actions to consume the BlockingCollection
            Parallel.Invoke(action, action, action);

            // Output
            Console.WriteLine($"Sum[0..{numberOfItems}) = {outerSum}, should be {(numberOfItems * (numberOfItems - 1)) / 2}");
            
            // Cleanup
            bc.Dispose();
        }

        private static void FromToAnyExample()
        {
            PrintSubTitle("TRYTAKEFROM ANY / TRYADDTOANY EXAMPLE");

            BlockingCollection<int>[] bcs = new BlockingCollection<int>[2];
            bcs[0] = new BlockingCollection<int>(5); // collection bounded to 5 items
            bcs[1] = new BlockingCollection<int>(5); // collection bounded to 5 items

            // Should be able to add 10 items w/o blocking
            int numberOfFailures = 0;

            for (int i = 0; i < 10; i++)
            {
                if (BlockingCollection<int>.TryAddToAny(bcs, i) == -1)
                {
                    numberOfFailures++;
                }
            }

            Console.WriteLine($"TryAddToAny: {numberOfFailures} failures (should be 0)");

            // Should be able to retrieve 10 items
            int numberOfItems = 0;
            int item;

            while (BlockingCollection<int>.TryTakeFromAny(bcs, out item) != -1)
            {
                numberOfItems++;
            }

            Console.WriteLine($"TryTakeFromAny: retrieved {numberOfItems} items (should be 10)");

        }

        private static void BlockingArraysExample()
        {
            CancellationTokenSource cts = new CancellationTokenSource();

            // Start up a UI thread for cancellation.
            Task.Run(() =>
            {
                if (Console.ReadKey(true).KeyChar == 'c')
                {
                    cts.Cancel();
                }
                    
            });


            // Generate some numbers
            BlockingCollection<int>[] sourceArrs = new BlockingCollection<int>[5];

            for(int i = 0; i < sourceArrs.Length; i++)
            {
                sourceArrs[i] = new BlockingCollection<int>(500);
            }

            Parallel.For(0, sourceArrs.Length * 500, (j) =>
            {
                int k = BlockingCollection<int>.TryAddToAny(sourceArrs, j);
            });


            // Mark the all BlockingCollection<T> instances as not accepting any more additions
            foreach (var arr in sourceArrs)
            {
                arr.CompleteAdding();
            }

            // First filter accepts the ints, keeps back a small percentage as a processing fee, and converts the results to decimals.
            var filter1 = new PipelineFilter<int, decimal>
            (
                sourceArrs,
                (n) => Convert.ToDecimal(n * 0.97),
                cts.Token,
                "filter 1"
            );

            // Second filter accepts the decimals and converts them to System.Strings.
            var filter2 = new PipelineFilter<decimal, string>
            (
                filter1.outputValues,
                (s) => $"{s}",
                cts.Token,
                "filter 2"
            );

            // Third filter uses the constructor with an Action<T> that renders its output to the screen, not a blocking collection.
            var filter3 = new PipelineFilter<string, string>
            (
                filter2.outputValues,
                (s) => Console.WriteLine($"The final result is {s}"),
                cts.Token,
                "filter 3"
            );


            // Start up the pipeline!
            try
            {
                Parallel.Invoke(
                    () => filter1.Process(),
                    () => filter2.Process(),
                    () => filter3.Process()
                );
            }
            catch (AggregateException ae)
            {
                foreach (var ex in ae.InnerExceptions)
                {
                    Console.WriteLine(ex.Message + ex.StackTrace);
                }                    
            }
            finally
            {
                cts.Dispose();
            }
        }

    }
}
