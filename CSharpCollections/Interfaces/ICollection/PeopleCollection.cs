using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace CSharpCollections.Interfaces.ICollection
{
    public class PeopleCollection<Person> : INotifyCollectionChanged, ICollection<Person>
    {
        private ObservableCollection<Person> list = null;
        private bool hasChanges = false;

        #region Properties
        protected Boolean HasChanges
        {
            get
            {
                return this.hasChanges;
            }
        }

        protected ObservableCollection<Person> List
        {
            get
            {
                return list;
            }
            set
            {
                this.list = value;
            }
        }

        public int Count
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsReadOnly
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        #endregion

        #region INotify Collection Changed event handlers

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        protected void OnCollectionChanged(NotifyCollectionChangedAction action, Person changedItem)
        {
            var handler = CollectionChanged;
            if (handler != null)
            {
                CollectionChanged(this, new NotifyCollectionChangedEventArgs(action, changedItem, null));
            }
        }

        protected void OnCollectionChanged(NotifyCollectionChangedAction action, Person oldItem, Person newItem)
        {
            var handler = CollectionChanged;
            if (handler != null)
            {
                CollectionChanged(this, new NotifyCollectionChangedEventArgs(action, newItem, oldItem));
            }
        }

        protected void OnCollectionChanged(NotifyCollectionChangedAction action)
        {
            var handler = CollectionChanged;
            if (handler != null)
            {
                CollectionChanged(this, new NotifyCollectionChangedEventArgs(action));
            }
        }

        protected void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            var action = e.Action;

            switch (action)
            {
                case NotifyCollectionChangedAction.Add:
                    Console.WriteLine("Person Added\n");
                    break;
                case NotifyCollectionChangedAction.Replace:
                    Console.WriteLine("Person Replaced\n");
                    break;
                case NotifyCollectionChangedAction.Remove:
                    Console.WriteLine("Person Removed\n");
                    break;
                case NotifyCollectionChangedAction.Reset:
                    Console.WriteLine("List Cleared\n");
                    break;
            }

            hasChanges = true;
        }
        #endregion

        #region Constructor
        public PeopleCollection()
        {
            list = new ObservableCollection<Person>();
            list.CollectionChanged += OnCollectionChanged;
        }
        #endregion

        #region ICollection Methods
        public Person this[int index]
        {
            get { return list[index]; }
            set
            {
                var origItem = list[index];
                list[index] = value;
                OnCollectionChanged(NotifyCollectionChangedAction.Replace, origItem, value);
            }
        }

        public void Clear()
        {
            this.list.Clear();
            OnCollectionChanged(NotifyCollectionChangedAction.Reset);
        }

        public void Add(Person item)
        {
            if (!Contains(item))
            {
                list.Add(item);
                OnCollectionChanged(NotifyCollectionChangedAction.Add, item);
            }            
        }

        public bool Contains(Person item)
        {
            bool found = false;

            foreach(Person person in list)
            {
                if (person.Equals(item))
                {
                    found = true;
                    break;
                }
            }

            return found;
        }

        public void CopyTo(Person[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Array cannot be null");
            }

            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException("The starting index cannot be negative");
            }

            if (list.Count > array.Length - arrayIndex + 1)
            {
                throw new ArgumentException("The destination array has fewer element than the collection");
            }

            for(int i = 0; i < list.Count; i++)
            {
                array[i + arrayIndex] = list[i];
            }
        }

        public bool Remove(Person item)
        {
            if (!Contains(item))
            {
                return false;
            }
            list.Remove(item);
            OnCollectionChanged(NotifyCollectionChangedAction.Remove, item);
            return true;
        }

        IEnumerator<Person> IEnumerable<Person>.GetEnumerator()
        {
            return list.GetEnumerator();
        }

        public IEnumerator GetEnumerator()
        {
            return list.GetEnumerator();            
        }
        #endregion
    }
}
