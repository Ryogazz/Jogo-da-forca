using System;
using System.Linq;

namespace Jogo_da_forca
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] palavras = { "ar", "gas", "casa", "futebol" };
            //amazena a palavra e a letra selecionada
            string palavra = "", letra = "";

            int erros = 0, completo = 0, posicao = 0;
            //bool para manter o loop do game
            bool sair = false;
            const int Limite = 7;
            Random rnd = new Random();

            //escolha vai receber um valor de 0 a 3 que esse valor sera definido para que palavra receba 
            //uma das palavras que esta associada no endereço do vetor palavras
            int escolha = rnd.Next(0, 3);
            palavra = palavras[escolha];
            //aqui usamos Length, palavra vai armazenar o numero de caracteres que a palavra te
            string[] quebrada = new string[palavra.Length];

            while (!sair)
            {
                Console.Clear();
                Console.WriteLine("Erros: " + erros + " de " + Limite);

                for (int i = 0; i < quebrada.Length; i++)
                {
                    if (quebrada[i] != null)
                    {
                        Console.Write(quebrada[i] + " ");
                    }
                    else
                    {
                        Console.Write("_ ");
                    }
                }
                    Console.WriteLine("\nEscolha a posição da letra!");
                    posicao = int.Parse(Console.ReadLine());
                    Console.WriteLine("Digite a letra: ");
                    letra = Console.ReadLine();

                    //verificando se a letra na posiçao digitaa corresponde a palavra que foi selecionada.

                    if (palavra.ElementAt(posicao - 1) == letra.ElementAt(0))
                    {
                        quebrada[posicao - 1] = letra;
                        completo++;
                    }
                    else
                    {
                        erros++;
                    }

                    if (erros >= Limite)
                    {
                        sair = true;
                    }

                    if (completo == palavra.Length)
                    {
                        sair = true;
                    }
                
            }
            if (completo == palavra.Length)
            {
                Console.Clear();
                Console.WriteLine("Parabens voce acertou a palavra " + palavra);
            }
            else if (erros == Limite)
            {
                Console.Clear();
                Console.WriteLine("Voce foi enforcado a palavra era " + palavra);
            }
            
        }
    }
}
