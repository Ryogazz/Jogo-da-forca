using System;
using System.Linq;
using System.IO;

namespace Jogo_da_forca
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Digite o endereço do arquivo");
                string endereco = Console.ReadLine();
                int ContarV(string p)
                {
                    return p.Count(x => ((x == 'a') || (x == 'e') || (x == 'i') || (x == 'o') || (x == 'u')));
                }
                
                string[] palavras = File.ReadAllLines(endereco);
                //amazena a palavra e a letra selecionada
                string palavra = "", letra = "";

                int erros = 0, completo = 0, posicao = 0;
                //bool para manter o loop do game
                bool sair = false;
                const int Limite = 7;
                Random rnd = new Random();

                //escolha vai receber um valor de 0 a 3 que esse valor sera definido para que palavra receba 
                //uma das palavras que esta associada no endereço do vetor palavras
                int n = 0;
                foreach (string lines in palavras)
                {
                    n++;
                }

                int escolha = rnd.Next(0, n);
                palavra = palavras[escolha];
                //aqui usamos Length, palavra vai armazenar o numero de caracteres que a palavra te
                string[] quebrada = new string[palavra.Length];
                int cont = 0;
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
                            cont++;
                        }

                    }
                    Console.WriteLine("\nA palavra possui " + cont + " letras");

                    Console.Write("Deseja ajuda? (s/n) ");
                    String ajuda = Console.ReadLine();
                    if (ajuda == "s")
                    {
                        int NV = ContarV(palavra);
                        Console.WriteLine("A palavra possui " + NV + "Vogais");
                    }
                    else
                    {
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
            catch(FormatException e)
            {
                Console.WriteLine("O sistema so aceita numeros para definir posição! " + e.Message);
            }
            catch(ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Valor digitado acima do numero de letras! " + e.Message);
            }
        }
    }
}
