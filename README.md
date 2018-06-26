## LINQ Benchmarks

Some simple experiments benchmarking LINQ versus `for` loops, and the use of [LinqOptimizer](http://nessos.github.io/LinqOptimizer/) (.NET Framework only).

The base LINQ query being benchmarked is:

```csharp
const int N = 10000000;
return Enumerable.Range(1, N)
    .Select(n => n * 2)
    .Select(n => Math.Sin((2 * Math.PI * n) / 1000))
    .Select(n => Math.Pow(n, 2))
    .Sum();
```

Just measuring speed at the moment, but the `for` loop version also will have advantages of fewer heap allocations.

### .NET 4.6.2

_running on 4 core i7_

|                           Method |     Mean |      Error |     StdDev |
|--------------------------------- |---------:|-----------:|-----------:|
|                          SumLinq | 905.9 ms | 36.4699 ms | 39.0223 ms |
|                       SumForEach | 787.4 ms |  0.8437 ms |  0.7479 ms |
|                 SumLinqOptimizer | 835.9 ms |  1.2915 ms |  1.1449 ms |
| SumLinqOptimizerIncludingCompile | 836.0 ms |  3.7413 ms |  3.4996 ms |
|                      SumParallel | 213.0 ms |  1.4215 ms |  1.3296 ms |

### .NET Core 2.1

|      Method |     Mean |     Error |    StdDev |
|------------ |---------:|----------:|----------:|
|     SumLinq | 706.9 ms | 19.676 ms | 20.206 ms |
|  SumForEach | 560.3 ms | 11.107 ms | 17.936 ms |
| SumParallel | 146.3 ms |  2.849 ms |  2.798 ms |

