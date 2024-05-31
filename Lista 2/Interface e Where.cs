using System;

// Interface IServico
public interface IServico
{
    void Executar();
}

// Classe ServicoFabrica<T>
public class ServicoFabrica<T> where T : IServico, new()
{
    // Método para criar uma nova instância de T
    public T NovaInstancia()
    {
        return new T();
    }
}

// Exemplo de classe que implementa a interface IServico
public class ExemploServico : IServico
{
    public void Executar()
    {
        Console.WriteLine("Executando o serviço de exemplo...");
    }
}
// Classe que não implementa a interface IServico
public class Casa
{
    public void MetodoQualquer()
    {
        Console.WriteLine("Método qualquer sendo executado...");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Criando uma instância de ServicoFabrica para a classe ExemploServico
        ServicoFabrica<ExemploServico> fabrica = new ServicoFabrica<ExemploServico>();

        // Criando uma nova instância de ExemploServico usando o método NovaInstancia()
        ExemploServico servico = fabrica.NovaInstancia();

        // O código a seguir resultará em um erro de compilação, pois MinhaClasse não implementa IServico
        // ServicoFabrica<Casa> fabrica = new ServicoFabrica<Casa>();

        // Chamando o método Executar() da instância criada
        servico.Executar();
    }
}
