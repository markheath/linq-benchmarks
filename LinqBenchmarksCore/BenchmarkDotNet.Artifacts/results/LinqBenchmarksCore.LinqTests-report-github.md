``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
11th Gen Intel Core i7-11800H 2.30GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.300
  [Host]     : .NET 6.0.5 (6.0.522.21309), X64 RyuJIT
  DefaultJob : .NET 6.0.5 (6.0.522.21309), X64 RyuJIT


```
|                           Method |      Mean |    Error |    StdDev |
|--------------------------------- |----------:|---------:|----------:|
|                          SumLinq | 415.14 ms | 8.076 ms |  8.977 ms |
|                       SumForEach | 335.70 ms | 6.553 ms | 10.203 ms |
|                 SumLinqOptimizer | 368.91 ms | 7.350 ms | 10.773 ms |
| SumLinqOptimizerIncludingCompile | 371.84 ms | 7.101 ms |  8.453 ms |
|                      SumParallel |  93.55 ms | 1.824 ms |  2.371 ms |
