using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace Cepedi.Banco.Pessoa.Benchmark.Test;
public class ArrayCopyBenchmark
{
    private int[] sourceArray;
    private int[] destinationArray;

    [Params(1000/*, 10000, 100000*/)]
    public int N;

    [GlobalSetup]
    public void Setup()
    {
        sourceArray = new int[N];
        for (int i = 0; i < N; i++)
        {
            sourceArray[i] = i;
        }
        destinationArray = new int[N];
    }

    [Benchmark]
    public void ArrayCopyMethod()
    {
        Array.Copy(sourceArray, destinationArray, sourceArray.Length);
    }

    [Benchmark]
    public void ArrayCopyToMethod()
    {
        sourceArray.CopyTo(destinationArray, 0);
    }

    [Benchmark]
    public void ForLoopMethod()
    {
        for (int i = 0; i < sourceArray.Length; i++)
        {
            destinationArray[i] = sourceArray[i];
        }
    }
}
