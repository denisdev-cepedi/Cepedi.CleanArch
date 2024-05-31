using System;

struct Ponto<T>
{
    public T X { get; }
    public T Y { get; }
    public T Z { get; }

    public Ponto(T x, T y, T z)
    {
        X = x;
        Y = y;
        Z = z;
    }
    // Sobrescrevendo o método ToString para imprimir os valores dos pontos
    public override string ToString()
    {
        return $"({X}, {Y}, {Z})";
    }
}
// Classe Triângulo Aceita Qualquer sendo instanciado corretamente 
struct Triangulo<T>
{
    public Ponto<T> P1 { get; }
    public Ponto<T> P2 { get; }
    public Ponto<T> P3 { get; }

    public Triangulo(Ponto<T> p1, Ponto<T> p2, Ponto<T> p3)
    {
        P1 = p1;
        P2 = p2;
        P3 = p3;
    }

    // Sobrescrevendo o método ToString para imprimir os valores dos pontos
    public override string ToString()
    {
        return $"Triângulo com pontos: {P1}, {P2}, {P3}";
    }
}

class Program
{
    static void Main()
    {
        // Criando diferentes triângulos e pontos com diversos tipos de dados

        // Triângulos com inteiros
        Triangulo<int> trianguloInt = new Triangulo<int>(new Ponto<int>(1, 2, 3), new Ponto<int>(4, 5, 6), new Ponto<int>(7, 8, 9));
        Console.WriteLine(trianguloInt);

        // Triângulos com doubles
        Triangulo<double> trianguloDouble = new Triangulo<double>(new Ponto<double>(1.5, 2.5, 3.5), new Ponto<double>(4.5, 5.5, 6.5), new Ponto<double>(7.5, 8.5, 9.5));
        Console.WriteLine(trianguloDouble);

        // Triângulos com strings (apenas para demonstração, não faz muito sentido geometricamente)
        Triangulo<string> trianguloString = new Triangulo<string>(new Ponto<string>("A", "B", "C"), new Ponto<string>("D", "E", "F"), new Ponto<string>("G", "H", "I"));
        Console.WriteLine(trianguloString);
    }
}
