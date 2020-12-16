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

                string[] palavras = File.ReadAllLines(endereco);
                //amazena a palavra e a letra selecionada
                string palavra = "";

                int erros = 0, completo = 0, posicao = 0;
                //bool para manter o loop do game
                bool sair = false;
                const int Limite = 7;
                Random rnd = new Random();

                //escolha vai receber um valor de 0 a n que esse valor sera definido para que palavra receba 
                //uma das palavras que esta associada no endereço do vetor palavras
                int n = 0;
                foreach (string lines in palavras)
                {
                    n++;
                }

                int escolha = rnd.Next(0, n);
                palavra = palavras[escolha];
                //aqui usamos Length, palavra vai armazenar o numero de caracteres que a palavra tem
                char[] quebrada = new char[palavra.Length];

                for (int i = 0; i < palavra.Length; i++)
                {
                    quebrada[i] = '*';
                }

                while (!sair)
                {
                    Console.Clear();
                    Console.WriteLine("Erros: " + erros + " de " + Limite);

                    Console.Write(quebrada);

                    Console.WriteLine("\nA palavra possui " + palavra.Length + " letras");

                    // Console.WriteLine("\nEscolha a posição da letra!");
                    // posicao = int.Parse(Console.ReadLine());

                    Console.WriteLine("Digite a letra: ");
                    char letra = char.Parse(Console.ReadLine().ToLower());


                    bool acerto = false;
                    for (int j = 0; j < quebrada.Length; j++)
                    {
                        if (quebrada[j] == letra)
                        {
                            Console.WriteLine("Letra ja digitada");
                            Console.ReadKey(false);
                        }


                        //descobrir como verificar letra a letra da palavra
                        else if (letra == palavra[j])
                        {
                            quebrada[j] = letra;
                            completo++;
                            acerto = true;
                            
                        }
                       
                    }
                    if (!acerto)
                    {
                        erros++;
                    }

                    //verificando se a letra na posiçao digitada corresponde a palavra que foi selecionada.


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
            catch (FormatException e)
            {
                Console.WriteLine("O sistema so aceita numeros para definir posição! " + e.Message);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Valor digitado acima do numero de letras! " + e.Message);
            }
        }
    }
}




