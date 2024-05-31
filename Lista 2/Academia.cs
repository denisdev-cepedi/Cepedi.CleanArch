using System;

// Definição do enum Exercicio
public enum Exercicio
{
    Academia = 1,
    Luta = 2,
    Corrida = 3
}

class Program
{
    static void Main(string[] args)
    {
        // Mostra as opções de exercícios existentes no enum
        Console.WriteLine("Opções de exercícios:");
        foreach (Exercicio exercicio in Enum.GetValues(typeof(Exercicio)))
        {
            Console.WriteLine($"{(int)exercicio}. {exercicio}");
        }

        // Solicita ao usuário a digitação de um exercício (1, 2 ou 3)
        Console.WriteLine("\nDigite o número correspondente ao exercício desejado:");

        try
        {
            // Lê a entrada do usuário e converte para int
            int opcao = int.Parse(Console.ReadLine());

            // Verifica se a opção digitada está associada a um valor do enum Exercicio
            if (Enum.IsDefined(typeof(Exercicio), opcao))
            {
                // Mostra o nome do exercício associado à opção digitada
                Exercicio exercicioSelecionado = (Exercicio)opcao;
                Console.WriteLine($"Você escolheu: {exercicioSelecionado}");
            }
            else
            {
                Console.WriteLine("Opção inválida.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Formato inválido. Digite um número.");
        }
    }
}
