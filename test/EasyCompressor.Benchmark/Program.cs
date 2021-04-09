using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using System.IO;

namespace EasySerializer.Benchmark
{
#pragma warning disable RCS1018 // Add accessibility modifiers (or vice versa).
#pragma warning disable S1118 // Utility classes should not have public constructors
    class Program
#pragma warning restore S1118 // Utility classes should not have public constructors
#pragma warning restore RCS1018 // Add accessibility modifiers (or vice versa).
    {
        static void Main(string[] args)
        {
#if DEBUG
            System.Console.ForegroundColor = System.ConsoleColor.Yellow;
            System.Console.WriteLine("*****To achieve accurate results, set project configuration to Release mode.*****");
            return;
#endif
#pragma warning disable CS0162 // Unreachable code detected
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run();
#pragma warning restore CS0162 // Unreachable code detected
        }
    }
}
