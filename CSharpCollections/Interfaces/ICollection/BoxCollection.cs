using CSharpCollections.EqualityComparers;
using CSharpCollections.Models;
using CSharpCollections.Models.Enumerators;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CSharpCollections.Interfaces.ICollection
{
    public class BoxCollection : ICollection<Box>
    {
        private List<Box> innerCollection;

        public BoxCollection()
        {
            innerCollection = new List<Box>();
        }

        public Box this[int index]
        {
            get { return (Box)innerCollection[index]; }
            set { innerCollection[index] = value; }
        }

        public int Count
        {
            get
            {
                return innerCollection.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public void Add(Box item)
        {
            if (!Contains(item))
            {
                innerCollection.Add(item);
            }
        }

        public void Clear()
        {
            innerCollection.Clear();
        }

        public bool Contains(Box item)
        {
            bool found = false;

            foreach(Box box in innerCollection)
            {
                if (box.Equals(item))
                {
                    found = true;
                    break;
                }
            }

            return found;
        }

        public bool Contains(Box item, EqualityComparer<Box> comparer)
        {
            bool found = false;

            foreach(Box box in innerCollection)
            {
                if(comparer.Equals(box, item))
                {
                    found = true;
                    break;
                }
            }
            return found;
        }

        public void CopyTo(Box[] array, int startIndex)
        {
            if(array == null)
            {
                throw new ArgumentNullException("Array cannot be null");
            }

            if(startIndex < 0)
            {
                throw new ArgumentOutOfRangeException("The starting index cannot be negative");
            }

            if (innerCollection.Count > array.Length - startIndex + 1)
            {
                throw new ArgumentException("The destination array has fwer element than the collection");
            }

            for(int i = 0; i < innerCollection.Count; i++)
            {
                array[i + startIndex] = innerCollection[i];
            }
        }

        public IEnumerator<Box> GetEnumerator()
        {
            return new BoxEnumerator(this);
        }

        public bool Remove(Box item)
        {
            bool removed = false;
            BoxDimensionsEqualityComparer comparer = new BoxDimensionsEqualityComparer();

            for (int i = 0; i < innerCollection.Count; i++)
            {
                Box box = (Box)innerCollection[i];
                if(comparer.Equals(box, item))
                {
                    innerCollection.RemoveAt(i);
                    removed = true;
                    break;
                }
            }

            return removed;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new BoxEnumerator(this);
        }
    }
}
