using System;
using System.IO;
using System.Text;
using System.Globalization;
using LeituraEscritaArquivo.Entidades;
using System.Collections.Generic;

namespace LeituraEscritaArquivo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Definindo diretórios e pastas 

            string diretorio = @"c:";
            string pastaOrigem = @"\origem";
            string arquivoOrigem = @"\itens.csv";
            string pastaDestino = @"\saida";
            string arquivoDestino = @"\summary.csv";
            List<Produto> listaProdutos = new List<Produto>();

            try
            {
                if (Directory.Exists(diretorio + pastaOrigem)) // Verifica se o caminho de origem está vazio
                {
                    Directory.Delete(diretorio + pastaOrigem, true); // Deleta pasta e tudo que há nela, independente se tem algo na pasta
                }

                Directory.CreateDirectory(diretorio + pastaOrigem); // Criar a pasta de origem a partir de um caminho 
                Directory.CreateDirectory(diretorio + pastaOrigem + pastaDestino); // Criar pasta de saida a partir de um caminho

                // Interação com o usuario 

                Console.Write("Seu arquivo será gravado no : ");
                Console.WriteLine(diretorio + pastaOrigem);
                Console.Write("E o nome dele é : ");
                Console.WriteLine(arquivoOrigem);

                Console.WriteLine();
                Console.Write("Quantos itens deseja cadastrar ? : ");
                int n = int.Parse(Console.ReadLine());

                Console.WriteLine();
                using (StreamWriter sw = File.AppendText(diretorio + pastaOrigem + arquivoOrigem))
                {
                    for (int i = 1; i <= n; i++)
                    {
                        Console.WriteLine($"Produto numero{i}");
                        Console.Write("Nome do produto : ");
                        string nome = Console.ReadLine();
                        Console.Write("Preço unitário do produto : ");
                        double preco = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                        Console.Write("Quantidade vendida : ");
                        int quantidade = int.Parse(Console.ReadLine());

                        Produto produto = new Produto(nome, preco, quantidade);
                        listaProdutos.Add(produto);

                        sw.WriteLine(produto.Nome + "," + produto.Preco.ToString("f2", CultureInfo.InvariantCulture) + "," + produto.Quantidade);
                        Console.WriteLine();
                    }
                }

                using (StreamWriter sw = File.AppendText(diretorio + pastaOrigem + pastaDestino + arquivoDestino))
                {
                    foreach (Produto item in listaProdutos)
                    {
                        sw.WriteLine(item.Nome + "," + item.Total().ToString("F2", CultureInfo.InvariantCulture));
                    }

                    Console.WriteLine("Seu novo arquivo com os totais foi gravado em " + diretorio + pastaOrigem + pastaDestino + arquivoDestino);
                }
                
                // Criar um arquivo dentro dessa pasta de origem

                //StringBuilder conteudoArquivo = new StringBuilder(); // para inserir as linhas do arquivo
                //conteudoArquivo.AppendLine("TV LED,1290.99,1");
                //conteudoArquivo.AppendLine("Video Game Chair,350.50,3");
                //conteudoArquivo.AppendLine("Iphone X,900.00,2");
                //conteudoArquivo.AppendLine("Samsung Galaxy 9,850.00,2");

                //string nomeArquivo = @"\itens.csv"; // nome do arquivo

                //File.AppendAllText(diretorio + pastaOrigem + nomeArquivo, conteudoArquivo.ToString()); // Criando o arquivo de origem

                //// Ler o conteudo do arquivo criado, fazer a multiplicação linha por linha colocando os resultados em outro arquivo

                //double totalVendas = 0.0;

                //using (StreamReader streamReader = File.OpenText(diretorio + pastaOrigem + nomeArquivo)) // Abrindo o arquivo
                //{
                //    StringBuilder sb = new StringBuilder();

                //    while (!streamReader.EndOfStream) //Enquanto não chegar na ultima linha faça
                //    {
                //        string[] linha = streamReader.ReadLine().Split(",");

                //        totalVendas = double.Parse(linha[1],CultureInfo.InvariantCulture) * int.Parse(linha[2]);

                //        sb.AppendLine(linha[0] + ',' + totalVendas.ToString("f2", CultureInfo.InvariantCulture));
                //    }

                //    string nomeArquivoDestino = @"\summary.csv";
                //    File.AppendAllText(diretorio + pastaOrigem + pastaDestino + nomeArquivoDestino, sb.ToString());
                //}

            }
            catch (IOException e)
            {
                Console.WriteLine("Ocorreu um erro!");
                Console.WriteLine(e.Message);
            }
        }
    }
}
