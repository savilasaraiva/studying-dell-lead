using System;

namespace _01_SomaNumeros
{
    class Program
    {
        static void Main(string[] args)
        {
            Double numberX, numberY;

            Console.WriteLine("#SOMA DE NÚMEROS#");

            Console.Write("Digite o primeiro número: ");
            numberX = Double.Parse(Console.ReadLine());

            Console.Write("Digite o segundo número: ");
            numberY = Double.Parse(Console.ReadLine());

            Console.WriteLine("A soma dos números é: {0}", numberX+numberY);
            Console.WriteLine("*ENTER PARA FINALIZAR");
        }
    }
}
