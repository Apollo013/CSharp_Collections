# CSharp_Collections

A demo of concurrent, generic, non-generic, & abstract collections, and includes examples of custom enumerators, and various comparer implementations

---

Developed with Visual Studio 2015 Community

---

###Techs
|Tech|
|----|
|C#|

---

####Concurrent Collections
|Collection|Features|
|----------|--------|
|ConcurrentDictionary | Threads, TryAdd, TryUpdate, TryRemove, AddOrUpdate, TryGetValue, Clear |
|ConcurrentQueue| Enqueue, TryDequeue, TryPeek, Action delegate, Parallel.Invoke, Interlocked.Add |
|ConcurrentStack| PushRange, TryPopRange, Interlocked.Increment, Parallel.For |
|ConcurrentBag| Add, TryTake, TryPeek |
|Blocking Collection| Add, TryTake, TryAddToAny, TryTakeFromAny, CompleteAdding, Action delegate, Parallel.Invoke, Interlocked.Add, CancellationTokenSource |

---

####Generic Collections
| Collection |Features|
|------------|--------|
| Dictionary(TKey , TValue) | Add, Remove, ValueCollection, KeyValuePair, KeyCollection, TryGetValue, Enumerator, Exception Handling with 'ArgumentException' & 'KeyNotFoundException' |
|HashSet(T)| Add, UnionWith and a second example implements IEqualityComparer(T) |
|SortedDictionary(TKey , TValue)| Add, Remove, ValueCollection, KeyValuePair, KeyCollection, TryGetValue, Exception Handling with 'ArgumentException' & 'KeyNotFoundException' |
|LinkedList(T)| AddFirst, AddLast, AddBefore, AddAfter, RemoveFirst, RemoveLast, Find, FindLast, clear, copying to array & exception handling with 'InvalidOperationException' when node already exists |
|List(T)| Add, Remove, Sort, Reverse, Capacity, Count, Clear, Insert(n,T) |
|KeyedCollection(TKey,TItem)| Add, Insert, Get<TKey>, Remove, RemoveAt, IndexOf |

---

####Observable Collections
| Collection |Features|
|------------|--------|
| ObservableCollection(T) | Custom ObservableCollection(T) implementation with Add, Remove, Contains, CopyTo, Clear & Enumerator |

---

####Immutable Collections
| Collection |Features|
|------------|--------|
| ImmutableList(T) | Create and index access |

---

####Interfaces
| Interface |Features|
|------------|--------|
| ICollection(T) | Demonstrates how to create a custom collection (BoxCollection) that also utilises a custom Enumerator(T). This collection overrides the Remove, Contains, Add, GetEnumerator, IEnumerable.GetEnumerator, Clear, IsReadOnly & Count members, as well as introducing an indexer method and a custom Contains method that allows you to pass in an EqualityComparer(T) object. |
| IEnumerable(T) | Demonstrates how to create a custom file reader (EnumerableStreamReader) that utilises a custom Enumerator(T).|

---
####Enumerators
| Class |Features|
|------------|--------|
| IEnumerator(T) | 2 examples demonstrating iteration over a list and a text file |

---
####Comparer Classes
| Class |Features|
|------------|--------|
| Comparer(T) | Demonstrates sorting collections by implementing IComparable(T) & deriving from Comparer(T) |
| EqualityComparer(T) | Demonstrates equality comparison by deriving from EqualityComparer(T) class|

---
####Resources
| Title | Author | Publisher / Website  |
|--------------|---------|--------|
| Pro C# 5.0 and the .NET 4.5 Framework| Andrew Troelsen | APRESS |
| [System.Collections.Generic Namespace](https://msdn.microsoft.com/en-us/library/system.collections.generic(v=vs.110).aspx) |  | MSDN |
| [How to: Use Arrays of Blocking Collections in a Pipeline](https://msdn.microsoft.com/en-us/library/dd460715(v=vs.110).aspx) |  | MSDN |
| [ObservableCollection<T> Class](https://msdn.microsoft.com/en-us/library/ms668604(v=vs.110).aspx) |  | MSDN |
| [Using the HashSet of T object in C# .NET to store unique elements](https://dotnetcodr.com/2016/08/30/using-the-hashset-of-t-object-in-c-net-to-store-unique-elements-2/#more-8555)| Andras Nemes | dotnetcodr.com |
