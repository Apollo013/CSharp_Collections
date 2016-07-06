using CSharpCollections.Enumerators;
using System.Collections;
using System.Collections.Generic;

namespace CSharpCollections.Interfaces.IEnumerable
{
    public class EnumerableStreamReader : IEnumerable<string>
    {

        private string Path;
        public EnumerableStreamReader(string filePath)
        {
            Path = filePath;
        }

        public IEnumerator<string> GetEnumerator()
        {
            return new StreamReaderEnumerator(Path);
        }

        IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
