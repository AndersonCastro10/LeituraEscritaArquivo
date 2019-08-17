using System;
using System.IO;

namespace LeituraEscritaArquivo
{
    class Program
    {
        static void Main(string[] args)
        {
            string caminho = @"\c:\";

            try
            {
                // Criar a pasta de origem a partir de um caminho 

                Directory.CreateDirectory(caminho + @"\origem");

                // Criar um arquivo dentro dessa pasta

            }
            catch (IOException e )
            {
                Console.WriteLine("Ocorreu um erro!");
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
