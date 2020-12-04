using System.IO;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Day04.Extensions;

namespace Day04.Benchmarks
{
    [RPlotExporter]
    public class Day04Benchmark
    {
        [Benchmark]
        public void Day04P01Benchmark()
        {
            File.ReadAllText("input.txt").ValidPassportPart01();
        }
        [Benchmark]
        public void Day04P02Benchmark()
        {
            File.ReadAllText("input.txt").ValidPassportPart02();
        }
    }
}