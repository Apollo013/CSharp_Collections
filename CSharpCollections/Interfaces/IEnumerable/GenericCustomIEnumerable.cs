using CSharpCollections.Collections;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CSharpCollections.Interfaces.IEnumerable
{
    public class GenericCustomIEnumerable : BaseClass
    {
        public static void Run()
        {
            PrintTitle("GENERIC INTERFACES - IENUMERABLE(T)");
            TestEnumerableStreamReader();
            TestReadingFile();
        }

        private static void TestEnumerableStreamReader()
        {
            PrintSubTitle("ENUMERABLE STREAM READER");

            // Vars
            long memoryBefore = GC.GetTotalMemory(true);    // Check the memory before the iterator is used.
            string filename = Environment.CurrentDirectory + @"\TestFiles\SteamReaderTest.txt";
            IEnumerable<string> lines;

            // Open & Read File
            try
            {
                lines = from line in new EnumerableStreamReader(filename)
                        select line;

                Console.WriteLine($"Lines Found: {lines.Count()}");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"{filename} cannot be found");
                return;
            }

            long memoryAfter = GC.GetTotalMemory(false); // Check the memory after the iterator and output it to the console.
            Console.WriteLine("Memory Used With Iterator = \t" + string.Format(((memoryAfter - memoryBefore) / 1000).ToString(), "n") + "kb");
        }

        private static void TestReadingFile()
        {
            PrintSubTitle("STREAM READER");

            // Vars
            long memoryBefore = GC.GetTotalMemory(true);    // Check the memory before the iterator is used.
            string filename = Environment.CurrentDirectory + @"\TestFiles\SteamReaderTest.txt";
            StreamReader reader;
            List<string> fileContents = new List<string>();

            // Open File
            try
            {
                reader = File.OpenText(filename);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"{filename} cannot be found");
                return;
            }

            /// Read File
            while (!reader.EndOfStream)
            {
                fileContents.Add(reader.ReadLine());
            }

            reader.Close();
            Console.WriteLine($"Lines Found: {fileContents.Count()}");

            long memoryAfter = GC.GetTotalMemory(false); // Check the memory after the iterator and output it to the console.
            Console.WriteLine("Memory Used With Iterator = \t" + string.Format(((memoryAfter - memoryBefore) / 1000).ToString(), "n") + "kb");
        }
    }
}
