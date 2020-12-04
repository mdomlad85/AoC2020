using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

namespace Day04.Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            var cfg = new DebugBuildConfig();
            cfg.WithOptions(ConfigOptions.DisableOptimizationsValidator);
            // using https://github.com/dotnet/BenchmarkDotNet 
            BenchmarkRunner.Run<Day04Benchmark>(cfg);
        }
    }
}