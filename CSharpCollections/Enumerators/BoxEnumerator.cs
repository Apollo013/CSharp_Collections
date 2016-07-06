using CSharpCollections.Interfaces.ICollection;
using System.Collections;
using System.Collections.Generic;

namespace CSharpCollections.Models.Enumerators
{
    /// <summary>
    /// Defines the enumerator for Boxcollection
    /// </summary>
    public class BoxEnumerator : IEnumerator<Box>

    {
        private BoxCollection boxCollection;
        private int currentIndex;
        private Box currrentBox;

        public BoxEnumerator(BoxCollection collection)
        {
            boxCollection = collection;
            currentIndex = -1;
            currrentBox = default(Box);
        }

        public Box Current
        {
            get
            {
                return currrentBox;
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public void Dispose()
        { }

        public bool MoveNext()
        {
            if(++currentIndex >= boxCollection.Count)
            {
                return false;
            }
            else
            {
                currrentBox = boxCollection[currentIndex];                
            }
            return true;
        }

        public void Reset()
        {
            currentIndex = -1;
        }
    }
}
