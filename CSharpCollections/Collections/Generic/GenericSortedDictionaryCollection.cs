using System;
using System.Collections.Generic;

namespace CSharpCollections.Collections.Generic
{
    public class GenericSortedDictionaryCollection : BaseClass
    {
        public static void Run()
        {
            PrintTitle("GENERIC COLLECTIONS - SORTED DICTIONARY");

            // Create a new sorted dictionary of strings, with string keys.
            SortedDictionary<string, string> sortedFileTypes = new SortedDictionary<string, string>();

            // Add some elements to the dictionary. There are no duplicate keys, but some of the values are duplicates.
            sortedFileTypes.Add("txt", "notepad.exe");
            sortedFileTypes.Add("bmp", "paint.exe");
            sortedFileTypes.Add("dib", "paint.exe");
            sortedFileTypes.Add("rtf", "wordpad.exe");

            // The Add method throws an exception if the new key is already in the dictionary.
            try
            {
                sortedFileTypes.Add("txt", "winword.exe");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("An element with that Key already exists.");
            }

            // The Item property is another name for the indexer, so you can omit its name when accessing elements. 
            Console.WriteLine($"For key = \"rtf\", value = {sortedFileTypes["rtf"]}.");

            // The indexer can be used to change the value associated with a key.
            sortedFileTypes["rtf"] = "winword.exe";
            Console.WriteLine($"For key = \"rtf\", value = {sortedFileTypes["rtf"]}.");

            // If a key does not exist, setting the indexer for that key adds a new key/value pair.
            sortedFileTypes["doc"] = "winword.exe";

            // The indexer throws an exception if the requested key is not in the dictionary.
            try
            {
                Console.WriteLine($"For key = \"tif\", value = {sortedFileTypes["tif"]}.");
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Key = \"tif\" is not found.");
            }

            // When a program often has to try keys that turn out not to be in the dictionary, TryGetValue can be a more efficient  way to retrieve values.
            string value = "";
            if (sortedFileTypes.TryGetValue("tif", out value))
            {
                Console.WriteLine($"For key = \"tif\", value = {value}.");
            }
            else
            {
                Console.WriteLine("Key = \"tif\" is not found.");
            }

            // ContainsKey can be used to test keys before inserting 
            // them.
            if (!sortedFileTypes.ContainsKey("ht"))
            {
                sortedFileTypes.Add("ht", "hypertrm.exe");                
                Console.WriteLine($"Value added for key = \"ht\": {sortedFileTypes["ht"]}");
            }

            // When you use foreach to enumerate dictionary elements, the elements are retrieved as KeyValuePair objects.
            Console.WriteLine();
            foreach (KeyValuePair<string, string> kvp in sortedFileTypes)
            {
                Console.WriteLine($"Key = {kvp.Key}, Value = {kvp.Value}");
            }

            // To get the values alone, use the Values property.
            SortedDictionary<string, string>.ValueCollection valueCollection = sortedFileTypes.Values;

            // The elements of the ValueCollection are strongly typed  with the type that was specified for dictionary values.
            Console.WriteLine();
            foreach (string val in valueCollection)
            {
                Console.WriteLine($"Value = {val}");
            }

            // To get the keys alone, use the Keys property.
            SortedDictionary<string, string>.KeyCollection keyCollection = sortedFileTypes.Keys;

            // The elements of the KeyCollection are strongly typed with the type that was specified for dictionary keys.
            Console.WriteLine();
            foreach (string key in keyCollection)
            {
                Console.WriteLine($"Key = {key}");
            }

            // Use the Remove method to remove a key/value pair.
            Console.WriteLine("\nRemove(\"doc\")");
            sortedFileTypes.Remove("doc");

            if (!sortedFileTypes.ContainsKey("doc"))
            {
                Console.WriteLine("Key \"doc\" is not found.");
            }
        }
    }
}
