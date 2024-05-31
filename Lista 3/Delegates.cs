using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Passo 1: Criar uma lista contendo os elementos do tipo double
        List<double> numeros = new List<double> { 3, 7, 2, 4, 6 };

        // Passo 2: Usar o método ConvertAll() com uma expressão lambda para dividir cada elemento por 2
        List<double> numerosDivididos = numeros.ConvertAll(numero => numero / 2);

        // Passo 3: Imprimir os elementos da nova lista na tela usando o método ForEach() com uma expressão lambda
        numerosDivididos.ForEach(numero => Console.WriteLine(numero));
    }
}
