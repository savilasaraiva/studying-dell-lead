using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02_NumerosPrimos
{
    class Program
    {
        static void Main(string[] args)
        {
            VerificaPrimo v;
            string input;            

            Console.WriteLine("#CALCULADORA DE NÚMEROS PRIMOS#");

            Console.Write("Digite um número: ");
            input = Console.ReadLine();

            /*
            * VERIFICA SE É CARACTERE NUMÉRICO
            */
            if (Regex.IsMatch(input, @"^[0-9]+$"))
            {
                v = new VerificaPrimo();
                Console.Write("Lista de Primos entre 1 e {0} é: ", input);

                /*
                * IMPRIME NO CONSOLE E SOMA TODOS OS PRIMOS
                */
                Console.WriteLine("{0}", v.printPrimos(int.Parse(input)));
                Console.WriteLine("A soma dos números primos é: {0}", v.SomaPrimos);
            }
            else
                Console.WriteLine("Valor de entrada Invalido");
            
            Console.WriteLine("*ENTER PARA FINALIZAR");

        }
    }
}
