using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;

namespace CSharpCollections.Models
{
    public class PipelineFilter<TInput, TOutput>
    {

        Func<TInput, TOutput> processor = null;
        Action<TInput> outputProcessor = null;
        public BlockingCollection<TInput>[] inputValues;
        public BlockingCollection<TOutput>[] outputValues;
        CancellationToken ct;

        public string Name { get; private set; }


        public PipelineFilter(BlockingCollection<TInput>[] inputValues,
                              Func<TInput, TOutput> processor,
                              CancellationToken ct,
                              string name)
        {
            this.inputValues = inputValues;
            this.processor = processor;
            this.ct = ct;
            this.Name = name;

            // Create collection for final outputs
            this.outputValues = new BlockingCollection<TOutput>[5];
            for (int i = 0; i < this.outputValues.Length; i++)
            {
                this.outputValues[i] = new BlockingCollection<TOutput>(500);
            }
        }

        /// <summary>
        /// Use this constructor for the final endpoint, which does something like write to file or screen, instead of pushing to another pipeline filter.
        /// </summary>
        /// <param name="inputValues"></param>
        /// <param name="renderer"></param>
        /// <param name="ct"></param>
        /// <param name="name"></param>
        public PipelineFilter(BlockingCollection<TInput>[] inputValues,
                              Action<TInput> renderer,
                              CancellationToken ct,
                              string name)
        {
            this.inputValues = inputValues;
            this.outputProcessor = renderer;
            this.ct = ct;
            this.Name = name;
        }

        public void Process()
        {
            Console.WriteLine($"{Name} is running");

            while(!inputValues.All(bc => bc.IsCompleted) && !ct.IsCancellationRequested)
            {
                TInput inputItem;
                int i = BlockingCollection<TInput>.TryTakeFromAny(inputValues, out inputItem, 50, ct);

                if(i >= 0)
                {
                    if(outputValues != null)
                    {
                        TOutput outputItem = processor(inputItem);
                        BlockingCollection<TOutput>.AddToAny(outputValues, outputItem);
                        Console.WriteLine($"{this.Name} sent {outputItem} to next");
                    }
                    else
                    {
                        outputProcessor(inputItem);
                    }
                }
                else
                {
                    Console.WriteLine("Unable to retrieve data from previous filter");
                }
            }
            
            // Marks the all BlockingCollection<T> instances as not accepting any more additions
            if (outputValues != null)
            {
                foreach(var bc in outputValues)
                {
                    bc.CompleteAdding();
                }
            }
        }
    }
}
