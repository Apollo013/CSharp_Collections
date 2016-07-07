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
            BlockingArrays();

        }


        private static void BlockingArrays()
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


            // Generate some source data
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
