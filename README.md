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
| Comparer(T) | Demonstrates sorting collections by implementing IComparable(T) & deriving from Comparer(T) |
| EqualityComparer (T) | Demonstrate equality comparison on a Dictionary(TKey, TValue) |

---
####Resources
| Title | Author | Publisher |
|--------------|---------|--------|
| Pro C# 5.0 and the .NET 4.5 Framework| Andrew Troelsen | APRESS |
| [System.Collections.Generic Namespace](https://msdn.microsoft.com/en-us/library/system.collections.generic(v=vs.110).aspx) |  | MSDN |

