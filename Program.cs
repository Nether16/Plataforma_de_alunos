using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediawikiNet;
using Newtonsoft.Json.Linq;
namespace plataforma_parte_interna
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> organizacao = new List<string>(); // Cria uma lista vazia
            int nota1, nota2, nota3;

            while (true)
            {
                Console.WriteLine("\nO que você deseja fazer?");

                Console.WriteLine("1 - Organizar tarefas \r\n2 - Ver notas \r\n3 - Acessar Wikipedia");
                int opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("\nEssas são suas tarefas:");
                        foreach (string elemento in organizacao)
                        {
                            Console.WriteLine(elemento);
                        }
                        Console.Write("Digite a tarefa a ser adicionada: ");
                        string adicionar = Console.ReadLine();
                        organizacao.Add(adicionar); // Adiciona o elemento à lista
                        Console.WriteLine("Tarefa adicionada!");
                        break;

                    case 2:
                        Console.WriteLine("\nInforme suas notas para calcularmos quanto você precisa para passar de ano:\r\nOBS: Se não tiver a nota informe zero.");
                        nota1 = int.Parse(Console.ReadLine());
                        nota2 = int.Parse(Console.ReadLine());
                        nota3 = int.Parse(Console.ReadLine());

                        int media = 180 - nota1 - nota2 - nota3;

                        if (media >= 0)
                        {Console.WriteLine("Você precisa de {0} pontos!", media);}

                        else 
                        {Console.WriteLine("Você já passou!");}
                        break;

                    case 3:
                            Console.Write("Digite sua pesquisa: ");
                            string pesquisa = Console.ReadLine();

                            using(WikipediaClient client = new WikipediaClient())
                        {
                            WikiSearchRequest req = new WikiSearchRequest(pesquisa);
                            req.Limit = 5; //We would like 5 results
                            WikiSearchResponse resp = await client.SearchAsync(req);
                        }

                            foreach (SearchResult s in resp.QueryResult.SearchResults)
                            {
                                Console.WriteLine($" - {s.Title}");
                            }
                        break;

                    default:
                        Console.WriteLine("Sessão encerrada.");
                        break;
                }
            }
        }
    }
}
