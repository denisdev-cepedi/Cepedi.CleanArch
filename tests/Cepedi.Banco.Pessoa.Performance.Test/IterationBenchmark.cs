using BenchmarkDotNet.Attributes;

namespace Cepedi.Banco.Pessoa.Benchmark.Test;
public class IterationBenchmark
{
    private List<int> numbers;

    [Params(1000/*, 10000,*/ /*100000*/)]
    public int N;

    [GlobalSetup]
    public void Setup()
    {
        numbers = Enumerable.Range(0, N).ToList();
    }

    [Benchmark]
    public int ForLoop()
    {
        int sum = 0;
        for (int i = 0; i < numbers.Count; i++)
        {
            sum += numbers[i];
        }
        return sum;
    }

    [Benchmark]
    public int ForEachLoop()
    {
        int sum = 0;
        foreach (var num in numbers)
        {
            sum += num;
        }
        return sum;
    }

    [Benchmark]
    public int LinqForEach()
    {
        int sum = 0;
        numbers.ForEach(num => sum += num);
        return sum;
    }
}
