// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using Cepedi.Banco.Pessoa.Benchmark.Test;
using Cepedi.Banco.Pessoa.Benchmark.Test.Helpers;
using Cepedi.Banco.Pessoa.Benchmark.Tests;

//var summary = BenchmarkRunner.Run<StringConcatenationVsStringBuilderBenchmark>();
//var summary = BenchmarkRunner.Run<IterationBenchmark>();
//var summary = BenchmarkRunner.Run<ArrayCopyBenchmark>();
var summary = BenchmarkRunner.Run<DapperVsEfCoreBenchmark>();
