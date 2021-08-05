using System;
using System.Collections.Generic;

namespace _02_NumerosPrimos
{
    public class VerificaPrimo
    {
        private List<int> primos = new List<int>();
        private int somaPrimos = 0;

        public List<int> Primos { get => primos; set => primos = value; }
        public int SomaPrimos { get => somaPrimos; set => somaPrimos = value; }

        /*
        * ADICIONA TODOS OS PRIMOS EM UMA LISTA
        */
        private void calculaPrimos(int number)
        {
            for (int j = 1; j <= number; j++)
            {
                if (retornaPrimo(j))
                {
                    primos.Add(j);
                    somaPrimos += j;
                }
            }
        }

        /*
        * ORGANIZA PARA MOSTRAR EM CONSOLE
        */
        public String printPrimos(int x)
        {
            calculaPrimos(x);

            string a = "";
            for(int i=0; i<primos.Count; i++)
            {
                if (i == primos.Count - 1)
                    a += $"{primos[i]}";
                else
                    a += $"{primos[i]}, ";
            }
            return a;
        }

        private Boolean retornaPrimo(int x)
        {
            int div = 0;

            /*
            * CONTA DIVISORES
            */
            for (int i=1; i<=x; i++)                
                if (x%i == 0)  div++;

            /*
            * VERIFICA SE É PRIMO
            */
            if (div > 2) return false;
            else return true;
        }
    }
}
