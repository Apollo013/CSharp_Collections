using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace CSharpCollections.Enumerators
{
    public class StreamReaderEnumerator : IEnumerator<string>
    {
        private StreamReader reader;
        private string currentLine = null;

        public StreamReaderEnumerator(string path)
        {
            this.reader = new StreamReader(path);
        }

        public string Current
        {
            get
            {
                if(reader == null || currentLine == null)
                {
                    throw new InvalidOperationException();
                }
                return currentLine;
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public bool MoveNext()
        {
            currentLine = reader.ReadLine();
            if(currentLine == null)
            {
                return false;
            }
            return true;
        }

        public void Reset()
        {
            reader.DiscardBufferedData();
            reader.BaseStream.Seek(0, SeekOrigin.Begin);
            currentLine = null;
        }


        // Implement IDisposable, which is also implemented by IEnumerator(T).
        private bool disposedValue = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    // Dispose of managed resources.
                }
                currentLine = null;
                if (reader != null)
                {
                    reader.Close();
                    reader.Dispose();
                }
            }

            this.disposedValue = true;
        }

        ~StreamReaderEnumerator(){
            Dispose(false);
        }
    }
}
