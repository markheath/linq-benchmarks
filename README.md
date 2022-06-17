## LINQ Benchmarks

Some simple experiments benchmarking LINQ versus `for` loops, and the use of [LinqOptimizer](http://nessos.github.io/LinqOptimizer/).

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

Run with `dotnet run -c Release`

### .NET 4.8

_11th Gen Intel Core i7-11800H 2.30GHz, 1 CPU, 16 logical and 8 physical cores_

|                           Method |     Mean |    Error |   StdDev |
|--------------------------------- |---------:|---------:|---------:|
|                          SumLinq | 756.4 ms | 14.83 ms | 19.29 ms |
|                       SumForEach | 645.8 ms | 12.43 ms | 12.21 ms |
|                 SumLinqOptimizer | 689.3 ms | 13.66 ms | 15.73 ms |
| SumLinqOptimizerIncludingCompile | 685.1 ms | 13.63 ms | 17.72 ms |
|                      SumParallel | 160.5 ms |  2.91 ms |  2.72 ms |

### .NET Core 6.0

_11th Gen Intel Core i7-11800H 2.30GHz, 1 CPU, 16 logical and 8 physical cores_

|                           Method |      Mean |    Error |    StdDev |
|--------------------------------- |----------:|---------:|----------:|
|                          SumLinq | 415.14 ms | 8.076 ms |  8.977 ms |
|                       SumForEach | 335.70 ms | 6.553 ms | 10.203 ms |
|                 SumLinqOptimizer | 368.91 ms | 7.350 ms | 10.773 ms |
| SumLinqOptimizerIncludingCompile | 371.84 ms | 7.101 ms |  8.453 ms |
|                      SumParallel |  93.55 ms | 1.824 ms |  2.371 ms |

