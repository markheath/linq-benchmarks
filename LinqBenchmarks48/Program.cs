using System;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Nessos.LinqOptimizer.Base;
using Nessos.LinqOptimizer.CSharp;

namespace LinqBenchmarks48
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<LinqTests>();
            //Console.Read();
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
