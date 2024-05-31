using System;
using System.Threading.Tasks;

class Programa
{
    static async Task FazerTrabalhoAsync(string nomeDaTarefa, int delay, int iteracoes)
    {
        for (int i = 1; i <= iteracoes; i++)
        {
            Console.WriteLine($"{nomeDaTarefa} está trabalhando... Passo {i}/{iteracoes}");
            await Task.Delay(delay); // Simula trabalho assíncrono
        }
        Console.WriteLine($"{nomeDaTarefa} terminou o trabalho.");
    }

    static async Task Main()
    {
        // Inicia duas tarefas assíncronas
        Task tarefa1 = FazerTrabalhoAsync("Tarefa 1", 500, 10);
        Task tarefa2 = FazerTrabalhoAsync("Tarefa 2", 700, 7);

        // Aguarda a conclusão de ambas as tarefas
        await Task.WhenAll(tarefa1, tarefa2);

        Console.WriteLine("Ambas as tarefas foram concluídas.");
    }
}
