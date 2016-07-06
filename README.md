# CSharp_Collections
A demo of concurrent, generic &amp; non-generic collections.

---
####Concurrent Collections
|Collection|Features|
|----------|--------|
|ConcurrentDictionary | Threads, TryAdd, TryUpdate, TryRemove, AddOrUpdate, TryGetValue, Clear |
|ConcurrentQueue| Enqueue, TryDequeue, TryPeek, Action delegate, Parallel.Invoke, Interlocked.Add |
|ConcurrentStack| PushRange, TryPopRange, Interlocked.Increment, Parallel.For |
|ConcurrentBag| Add, TryTake, TryPeek |

---
####Generic Collections
| Collection |Features|
|------------|--------|
| Dictionary(TKey , TValue) | Add, Remove, ValueCollection, KeyValuePair, KeyCollection, TryGetValue, Enumerator, Exception Handling with 'ArgumentException' & 'KeyNotFoundException' |
|HashSet| Add, UnionWith |

---
####Custom Generic Interfaces
| Class |Features|
|------------|--------|
| ICollection(T) | Demonstrates how to create a custom collection (BoxCollection) that also utilises a custom Enumerator(T). This collection overrides the Remove, Contains, Add, GetEnumerator, IEnumerable.GetEnumerator, Clear, IsReadOnly & Count members, as well as introducing an indexer method and a custom Contains method that allows you to pass in an EqualityComparer(T) object. |
| IEnumerator(T) | Demonstrate a custom IEnumerator used by the 'BoxCollection' custom collection |


---
####Generic Comparer Classes
| Class |Features|
|------------|--------|
| Comparer(T) | Demonstrates sorting collections by implementing IComparable(T) & deriving from Comparer(T) |
| EqualityComparer(T) | Demonstrates equality comparison by deriving from EqualityComparer(T) class|

---
####Resources
| Title | Author | Publisher |
|--------------|---------|--------|
| Pro C# 5.0 and the .NET 4.5 Framework| Andrew Troelsen | APRESS |
| [System.Collections.Generic Namespace](https://msdn.microsoft.com/en-us/library/system.collections.generic(v=vs.110).aspx) |  | MSDN |

