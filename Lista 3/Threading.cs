using System;
using System.Threading;

class Trabalhador
{
    private string _nome;

    public Trabalhador(string nome)
    {
        _nome = nome;
    }

    public void Trabalhar()
    {
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine($"{_nome} está trabalhando... Passo {i}/10");
            Thread.Sleep(500); // Simula algum trabalho dormindo por 500 milissegundos
        }
        Console.WriteLine($"{_nome} terminou o trabalho.");
    }
}

class Programa
{
    static void Main()
    {
        // Cria duas instâncias de Trabalhador
        Trabalhador trabalhador1 = new Trabalhador("Trabalhador 1");
        Trabalhador trabalhador2 = new Trabalhador("Trabalhador 2");

        // Cria duas threads, cada uma executando o método Trabalhar de uma instância Trabalhador
        Thread thread1 = new Thread(trabalhador1.Trabalhar);
        Thread thread2 = new Thread(trabalhador2.Trabalhar);

        // Inicia ambas as threads
        thread1.Start();
        thread2.Start();

        // Aguarda a conclusão de ambas as threads
        thread1.Join();
        thread2.Join();

        Console.WriteLine("Ambos os trabalhadores terminaram o trabalho.");
    }
}
