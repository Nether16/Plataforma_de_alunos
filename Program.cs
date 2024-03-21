using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plataforma_parte_interna
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> organizacao = new List<string>(); // Cria uma lista vazia
            int notas;

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
                        Console.WriteLine("\nInforme suas notas para calcularmos quanto você precisa para atingir a média trimestral:");
                        notas = int.Parse(Console.ReadLine());
                        break;
                    default:
                        Console.WriteLine("Sessão encerrada.");
                        break;
                }
            }
        }
    }
}
