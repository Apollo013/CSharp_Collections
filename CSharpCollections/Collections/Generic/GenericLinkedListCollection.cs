using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpCollections.Collections.Generic
{
    public class GenericLinkedListCollection : BaseClass
    {
        public static void Run()
        {
            PrintTitle("LINKEDLIST COLLECTION");

            // Create the link list.
            string[] words = { "the", "fox", "jumped", "over", "the", "dog" };
            LinkedList<string> sentence = new LinkedList<string>(words);

            Display(sentence, "linked list values:");
            Console.WriteLine($"sentence.Contains('jumped') = {sentence.Contains("jumped")}\n");

            // Add the word 'today' to the beginning of the linked list.
            sentence.AddFirst("today");
            Display(sentence, "Added 'today' to beginning:");

            // Move the first node to be the last node.
            LinkedListNode<string> word = sentence.First;
            sentence.RemoveFirst();
            sentence.AddLast(word);
            Display(sentence, "Moved first node to last node:");

            // Change the last node be 'yesterday'.
            sentence.RemoveLast();
            sentence.AddLast("yesterday");
            Display(sentence, "Changed last node to 'yesterday':");

            // Move the last node to be the first node.
            word = sentence.Last;
            sentence.RemoveLast();
            sentence.AddFirst(word);
            Display(sentence, "Moved last node to first node:");

            // Indicate, by using parentheisis, the last occurence of 'the'.
            sentence.RemoveFirst();
            LinkedListNode<string> current = sentence.FindLast("the");
            IndicateNode(current, "Indicate last occurence of 'the':");

            // Add 'lazy' and 'old' after 'the' (the LinkedListNode named current).
            sentence.AddAfter(current, "old");
            sentence.AddAfter(current, "lazy");
            IndicateNode(current, "Add 'lazy' and 'old' after 'the':");

            // Indicate 'fox' node.
            current = sentence.Find("fox");
            IndicateNode(current, "Indicate the 'fox' node:");

            // Add 'quick' and 'brown' before 'fox':
            sentence.AddBefore(current, "quick");
            sentence.AddBefore(current, "brown");
            IndicateNode(current, "Add 'quick' and 'brown' before 'fox':");

            // Keep a reference to the current node, 'fox',
            // and to the previous node in the list. Indicate the 'dog' node.
            word = current;
            LinkedListNode<string> mark2 = current.Previous;
            current = sentence.Find("dog");
            IndicateNode(current, "Indicate the 'dog' node:");

            // Remove the node referred to by mark1, and then add it
            // before the node referred to by current.
            // Indicate the node referred to by current.
            sentence.Remove(word);
            sentence.AddBefore(current, word);
            IndicateNode(current, "Move a referenced node (fox) before the current node (dog):");

            // Remove the node referred to by current.
            sentence.Remove(current);
            IndicateNode(current, "Remove current node (dog) and attempt to indicate it:");

            // Add the node after the node referred to by mark2.
            sentence.AddAfter(mark2, current);
            IndicateNode(current, "Add node removed in test 11 after a referenced node (brown):");

            // The Remove method finds and removes the first node that that has the specified value.
            sentence.Remove("old");
            Display(sentence, "Remove node that has the value 'old':");

            // When the linked list is cast to ICollection(Of String),
            // the Add method adds a node to the end of the list.
            sentence.RemoveLast();
            ICollection<string> icoll = sentence;
            icoll.Add("rhinoceros");
            Display(sentence, "Remove last node, cast to ICollection, and add 'rhinoceros':");


            current = sentence.Find("rhinoceros");
            // The AddBefore method throws an InvalidOperationException
            // if you try to add a node that already belongs to a list.
            Console.WriteLine("Throw exception by adding node (rhinoceros) - already in the list:");
            try
            {
                sentence.AddBefore(current, word);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Exception message: {ex.Message}\n");
            }

            Console.WriteLine("\nCopy the list to an array:");
            // Create an array with the same number of elements as the inked list.
            string[] sArray = new string[sentence.Count];
            sentence.CopyTo(sArray, 0);

            foreach (string s in sArray)
            {
                Console.WriteLine(s);
            }

            // Release all the nodes.
            sentence.Clear();
            Console.WriteLine();
            Console.WriteLine($"linked list cleared. Contains 'jumped' = {sentence.Contains("jumped")}");

        }

        private static void Display(LinkedList<string> words, string title)
        {
            Console.Write($"{title,-70}");
            foreach (string word in words)
            {
                Console.Write(word + " ");
            }
            Console.WriteLine("\n");
        }

        private static void IndicateNode(LinkedListNode<string> node, string title)
        {
            Console.Write($"{title,-70}");
            if (node.List == null)
            {
                Console.WriteLine($"Node '{node.Value}' is not in the list.\n");
                return;
            }

            StringBuilder result = new StringBuilder("(" + node.Value + ")");
            LinkedListNode<string> nodeP = node.Previous;

            // Iterate backwards and insert previos node value at beginning of result sb
            while (nodeP != null)
            {
                result.Insert(0, nodeP.Value + " ");
                nodeP = nodeP.Previous;
            }

            // Now iterate forwards and add any words to end of result sb
            node = node.Next;
            while (node != null)
            {
                result.Append(" " + node.Value);
                node = node.Next;
            }

            Console.WriteLine(result);
            Console.WriteLine();
        }

    }
}
