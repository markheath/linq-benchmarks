using System;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Nessos.LinqOptimizer.Base;
using Nessos.LinqOptimizer.CSharp;

namespace LinqBenchmarks462
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<LinqTests>();
            Console.Read();

            /* with N = 10000000
                           Method |     Mean |     Error |    StdDev |
--------------------------------- |---------:|----------:|----------:|
                          SumLinq | 959.5 ms | 18.962 ms | 25.314 ms |
                       SumForEach | 801.6 ms |  2.068 ms |  1.727 ms |
                 SumLinqOptimizer | 851.2 ms |  5.965 ms |  5.580 ms |
 SumLinqOptimizerIncludingCompile | 846.8 ms |  4.983 ms |  4.661 ms |
                      SumParallel | 213.9 ms |  1.512 ms |  1.415 ms |


            second run
                           Method |     Mean |      Error |     StdDev |
--------------------------------- |---------:|-----------:|-----------:|
                          SumLinq | 905.9 ms | 36.4699 ms | 39.0223 ms |
                       SumForEach | 787.4 ms |  0.8437 ms |  0.7479 ms |
                 SumLinqOptimizer | 835.9 ms |  1.2915 ms |  1.1449 ms |
 SumLinqOptimizerIncludingCompile | 836.0 ms |  3.7413 ms |  3.4996 ms |
                      SumParallel | 213.0 ms |  1.4215 ms |  1.3296 ms |
             *
             */
        }
    }
    public class LinqTests
    {

        public const int N = 10000000;

        private IQueryExpr<double> compiledQuery; 

        public LinqTests()
        {
            compiledQuery = Enumerable.Range(1, N).AsQueryExpr()
                .Select(n => n * 2)
                .Select(n => Math.Sin((2 * Math.PI * n) / 1000))
                .Select(n => Math.Pow(n, 2))
                .Sum();
            compiledQuery.Compile();
        }


        [Benchmark]
        public double SumLinq()
        {
            return Enumerable.Range(1, N)
                .Select(n => n * 2)
                .Select(n => Math.Sin((2 * Math.PI * n) / 1000))
                .Select(n => Math.Pow(n, 2))
                .Sum();
        }

        [Benchmark]
        public double SumForEach()
        {
            double sum = 0;
            for (int n = 1; n <= N; n++)
            {
                var a = n * 2;
                var b = Math.Sin((2 * Math.PI * a) / 1000);
                var c = Math.Pow(b, 2);
                sum += c;
            }

            return sum;
        }


        [Benchmark]
        public double SumLinqOptimizer()
        {
            return compiledQuery.Run();
        }

        [Benchmark]
        public double SumLinqOptimizerIncludingCompile()
        {
            var q = Enumerable.Range(1, N).AsQueryExpr()
                .Select(n => n * 2)
                .Select(n => Math.Sin((2 * Math.PI * n) / 1000))
                .Select(n => Math.Pow(n, 2))
                .Sum();
            q.Compile();
            return q.Run();
        }

        [Benchmark]
        public double SumParallel()
        {
            return Enumerable.Range(1, N).AsParallel()
                .Select(n => n * 2)
                .Select(n => Math.Sin((2 * Math.PI * n) / 1000))
                .Select(n => Math.Pow(n, 2))
                .Sum();
        }
    }
}
