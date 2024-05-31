using System;
using System.Collections.Generic;
using System.Linq;

enum Tipo
{
    Comida,
    Bebida,
    Higiene,
    Limpeza
}

class ItemMercado
{
    public string Nome { get; set; }
    public Tipo Tipo { get; set; }
    public double Preco { get; set; }

    public ItemMercado(string nome, Tipo tipo, double preco)
    {
        Nome = nome;
        Tipo = tipo;
        Preco = preco;
    }
}

class Program
{
    static void Main()
    {
        // Passo 2: Criar a lista de objetos ItemMercado
        List<ItemMercado> itens = new List<ItemMercado>
        {
            new ItemMercado("Arroz", Tipo.Comida, 3.90),
            new ItemMercado("Azeite", Tipo.Comida, 2.50),
            new ItemMercado("Macarrão", Tipo.Comida, 3.90),
            new ItemMercado("Cerveja", Tipo.Bebida, 22.90),
            new ItemMercado("Refrigerante", Tipo.Bebida, 5.50),
            new ItemMercado("Shampoo", Tipo.Higiene, 7.00),
            new ItemMercado("Sabonete", Tipo.Higiene, 2.40),
            new ItemMercado("Cotonete", Tipo.Higiene, 5.70),
            new ItemMercado("Sabão em pó", Tipo.Limpeza, 8.20),
            new ItemMercado("Detergente", Tipo.Limpeza, 2.60),
            new ItemMercado("Amaciante", Tipo.Limpeza, 6.40)
        };

        // 1) Itens do tipo Higiene ordenados por ordem decrescente de preço
        var higieneOrdenados = itens
            .Where(item => item.Tipo == Tipo.Higiene)
            .OrderByDescending(item => item.Preco)
            .ToList();

        Console.WriteLine("Itens de Higiene ordenados por preço decrescente:");
        higieneOrdenados.ForEach(item => Console.WriteLine($"{item.Nome} - R$ {item.Preco:F2}"));

        // 2) Itens cujo preço seja maior ou igual a R$ 5,00 ordenados por ordem crescente de preço
        var itensPrecoMaiorIgual5 = itens
            .Where(item => item.Preco >= 5.00)
            .OrderBy(item => item.Preco)
            .ToList();

        Console.WriteLine("\nItens com preço maior ou igual a R$ 5,00 ordenados por preço crescente:");
        itensPrecoMaiorIgual5.ForEach(item => Console.WriteLine($"{item.Nome} - R$ {item.Preco:F2}"));

        // 3) Itens do tipo Comida ou Bebida ordenados por nome em ordem alfabética
        var comidaBebidaOrdenados = itens
            .Where(item => item.Tipo == Tipo.Comida || item.Tipo == Tipo.Bebida)
            .OrderBy(item => item.Nome)
            .ToList();

        Console.WriteLine("\nItens de Comida ou Bebida ordenados por nome:");
        comidaBebidaOrdenados.ForEach(item => Console.WriteLine($"{item.Nome} - R$ {item.Preco:F2}"));

        // 4) Cada tipo associado com a quantidade de itens de cada tipo
        var quantidadePorTipo = itens
            .GroupBy(item => item.Tipo)
            .Select(grupo => new { Tipo = grupo.Key, Quantidade = grupo.Count() })
            .ToList();

        Console.WriteLine("\nQuantidade de itens por tipo:");
        quantidadePorTipo.ForEach(grupo => Console.WriteLine($"{grupo.Tipo}: {grupo.Quantidade}"));

        // 5) Cada tipo associado com o preço máximo, preço mínimo e média de preço de cada tipo
        var precosPorTipo = itens
            .GroupBy(item => item.Tipo)
            .Select(grupo => new
            {
                Tipo = grupo.Key,
                PrecoMaximo = grupo.Max(item => item.Preco),
                PrecoMinimo = grupo.Min(item => item.Preco),
                PrecoMedio = grupo.Average(item => item.Preco)
            })
            .ToList();

        Console.WriteLine("\nPreço máximo, mínimo e médio por tipo:");
        precosPorTipo.ForEach(grupo => Console.WriteLine($"{grupo.Tipo}: Máximo = R$ {grupo.PrecoMaximo:F2}, Mínimo = R$ {grupo.PrecoMinimo:F2}, Médio = R$ {grupo.PrecoMedio:F2}"));
    }
}
