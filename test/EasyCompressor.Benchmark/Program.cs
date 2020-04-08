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
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run();
        }
    }
}
