``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22000.1098/21H2)
Intel Core i7-10610U CPU 1.80GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.100
  [Host]     : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2
  Job-RLJTJY : .NET 6.0.11 (6.0.1122.52304), X64 RyuJIT AVX2
  Job-JDVSFK : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2
  Job-ILRBIN : .NET Framework 4.8 (4.8.4515.0), X64 RyuJIT VectorSize=256


```
|                           Method |            Runtime |     Mean |    Error |   StdDev |   Median | Ratio | RatioSD |
|--------------------------------- |------------------- |---------:|---------:|---------:|---------:|------:|--------:|
|                          SumLinq |           .NET 6.0 | 544.4 ms | 10.76 ms | 12.81 ms | 539.1 ms |  0.71 |    0.02 |
|                          SumLinq |           .NET 7.0 | 534.8 ms | 10.52 ms | 15.75 ms | 531.5 ms |  0.70 |    0.03 |
|                          SumLinq | .NET Framework 4.8 | 776.0 ms | 12.53 ms | 10.46 ms | 775.2 ms |  1.00 |    0.00 |
|                                  |                    |          |          |          |          |       |         |
|                     SumLinqTwoPi |           .NET 6.0 | 540.3 ms |  6.58 ms |  6.15 ms | 538.9 ms |  0.67 |    0.04 |
|                     SumLinqTwoPi |           .NET 7.0 | 529.5 ms |  9.37 ms |  7.82 ms | 526.8 ms |  0.66 |    0.04 |
|                     SumLinqTwoPi | .NET Framework 4.8 | 912.7 ms | 31.09 ms | 82.99 ms | 929.8 ms |  1.00 |    0.00 |
|                                  |                    |          |          |          |          |       |         |
|                       SumForLoop |           .NET 6.0 | 435.0 ms |  7.36 ms |  7.23 ms | 433.6 ms |  0.54 |    0.01 |
|                       SumForLoop |           .NET 7.0 | 434.5 ms |  8.55 ms |  8.00 ms | 432.3 ms |  0.54 |    0.01 |
|                       SumForLoop | .NET Framework 4.8 | 803.2 ms | 15.20 ms | 14.22 ms | 801.5 ms |  1.00 |    0.00 |
|                                  |                    |          |          |          |          |       |         |
|                 SumLinqOptimizer |           .NET 6.0 | 495.4 ms |  9.49 ms | 12.33 ms | 494.2 ms |  0.59 |    0.02 |
|                 SumLinqOptimizer |           .NET 7.0 | 486.5 ms |  8.92 ms |  8.34 ms | 485.3 ms |  0.58 |    0.01 |
|                 SumLinqOptimizer | .NET Framework 4.8 | 844.3 ms | 15.93 ms | 14.90 ms | 839.0 ms |  1.00 |    0.00 |
|                                  |                    |          |          |          |          |       |         |
| SumLinqOptimizerIncludingCompile |           .NET 6.0 | 488.2 ms |  9.48 ms |  8.87 ms | 487.0 ms |  0.59 |    0.02 |
| SumLinqOptimizerIncludingCompile |           .NET 7.0 | 506.0 ms | 10.01 ms | 11.12 ms | 500.5 ms |  0.61 |    0.02 |
| SumLinqOptimizerIncludingCompile | .NET Framework 4.8 | 834.7 ms | 13.67 ms | 11.41 ms | 832.7 ms |  1.00 |    0.00 |
|                                  |                    |          |          |          |          |       |         |
|                      SumParallel |           .NET 6.0 | 206.4 ms |  3.98 ms |  5.58 ms | 207.0 ms |  0.72 |    0.03 |
|                      SumParallel |           .NET 7.0 | 216.7 ms |  2.65 ms |  2.47 ms | 216.6 ms |  0.74 |    0.03 |
|                      SumParallel | .NET Framework 4.8 | 288.2 ms |  5.68 ms |  9.81 ms | 283.1 ms |  1.00 |    0.00 |
