using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

namespace EasySerializer.Benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
#if DEBUG
            System.Console.ForegroundColor = System.ConsoleColor.Yellow;
            System.Console.WriteLine("*****To achieve accurate results, set project configuration to Release mode.*****");
            return;
#endif
#pragma warning disable CS0162 // Unreachable code detected
            var config = ManualConfig.Create(DefaultConfig.Instance).WithOptions(ConfigOptions.DisableOptimizationsValidator);
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(null, config);
#pragma warning restore CS0162 // Unreachable code detected
        }
    }
}
