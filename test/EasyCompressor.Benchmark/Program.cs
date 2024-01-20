﻿using BenchmarkDotNet.Running;

#if DEBUG
System.Console.ForegroundColor = System.ConsoleColor.Yellow;
System.Console.WriteLine("*****To achieve accurate results, set project configuration to Release mode.*****");
return;
#endif

#pragma warning disable CS0162 // Unreachable code detected
BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run();
#pragma warning restore CS0162 // Unreachable code detected