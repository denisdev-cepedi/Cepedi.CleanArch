using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Text;

namespace Cepedi.Banco.Pessoa.Benchmark.Tests;
public class StringConcatenationVsStringBuilderBenchmark
{
    private const int N = 1000;

    [Benchmark]
    public string StringConcatenation()
    {
        string result = "";
        for (int i = 0; i < N; i++)
        {
            result += "a"; // Simula uma concatenação de string simples
        }
        return result;
    }

    [Benchmark]
    public string StringBuilderConcatenation()
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < N; i++)
        {
            sb.Append("a"); // Usa StringBuilder para construir a string
        }
        return sb.ToString();
    }
}

class Program
{
    static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<StringConcatenationVsStringBuilderBenchmark>();
    }
}
