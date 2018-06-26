using System;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;


namespace LinqBenchmarksCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Running .NET Core benchmarks");
            var summary = BenchmarkRunner.Run<LinqTests>();
            Console.WriteLine(".NET Core benchmarks completed");
            Console.Read();
        }

        /*
      Method |     Mean |     Error |    StdDev |
------------ |---------:|----------:|----------:|
     SumLinq | 706.9 ms | 19.676 ms | 20.206 ms |
  SumForEach | 560.3 ms | 11.107 ms | 17.936 ms |
 SumParallel | 146.3 ms |  2.849 ms |  2.798 ms |
         *
         */
    }

    public class LinqTests
    {
        public const int N = 10000000;

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
