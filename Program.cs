using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace Plataforma_do_Aluno
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Conta> Listaconta = new List<Conta>();
            bool login = true;

            string directoryPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string fileName = "Contas.txt";
            string filePath = Path.Combine(directoryPath, fileName);

            if (!File.Exists(filePath))
            {
                using (FileStream fs = File.Create(filePath)){}
            }
            using (StreamReader sr = new StreamReader(filePath))
            {
                string usuario;
                while ((usuario = sr.ReadLine()) != null)
                {
                    string[] dados = usuario.Split(',');
                    if (dados[0] == null)
                    {
                        continue;
                    }
                    Conta conta = new Conta(dados[0], dados[1], dados[2]);
                    Listaconta.Add(conta);
                }
            }
            while (true)
            {
                if (login)
                {
                    Console.WriteLine("Escolha uma operação : \r\n[1] Login \r\n[2] Cadastro");
                    string operação = Console.ReadLine();

                    if (operação == "1")
                    {
                        Console.WriteLine("Insira o seu e-mail");
                        string Email = Console.ReadLine();
                        Console.WriteLine("Insira sua senha (Se voce esqueceu a senha digite 'esqueci')");
                        string Senha = Console.ReadLine();

                        if (Senha != "esqueci")
                        {
                            foreach (Conta conta in Listaconta)
                            {
                                if ((conta.GetEmail() == Hash(Email)) && (conta.GetSenha() == Hash(Senha)))
                                {
                                    login = false;
                                }
                            }

                        }
                        else
                        {
                            string remetenteEmail = "chupinganabinga@gmail.com";
                            string remetenteSenha = "TrabalhoMosca";

                            string destinatarioEmail = Email;
                            string smtpHost = "smtp.gmail.com";
                            int smtpPort = 587;

                            try
                            {
                                using (SmtpClient smtpClient = new SmtpClient(smtpHost, smtpPort))
                                {
                                    smtpClient.Credentials = new NetworkCredential(remetenteEmail, remetenteSenha);
                                    smtpClient.EnableSsl = true;

                                    MailMessage message = new MailMessage(remetenteEmail, destinatarioEmail);
                                    message.Subject = "Esqueci minha senha";
                                    message.Body = "A senha sua é : ";

                                    smtpClient.Send(message);

                                    Console.WriteLine("Email enviado com sucesso.");
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Erro ao enviar email: " + ex.Message);
                            }
                        }

                    }
                    else if (operação == "2")
                    {
                        Console.WriteLine("Insira o seu e-mail");
                        string Email = Console.ReadLine();
                        Console.WriteLine("Insira o nome da sua conta");
                        string Nome = Console.ReadLine();
                        Console.WriteLine("Insira a senha da conta");
                        string Senha = Console.ReadLine();

                        string HashEmail = Hash(Email);
                        string HashNome = Hash(Nome);
                        string HashSenha = Hash(Senha);

                        try
                        {
                            using (StreamWriter writer = new StreamWriter(filePath, true))
                            {
                                writer.WriteLine($"{HashEmail},{HashNome},{HashSenha}");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Um erro ocorreu : " + ex.Message);
                        }

                        Conta conta = new Conta(HashEmail, HashNome, HashSenha);
                        Listaconta.Add(conta);

                    }
                    else
                    {
                        Console.WriteLine("\r\nOperação não existe \r\n");
                    }

                    string Hash(string dados)
                    {
                        using (SHA256 sha256 = SHA256.Create())
                        {
                            byte[] hash = Encoding.UTF8.GetBytes(dados);
                            StringBuilder sb = new StringBuilder();
                            foreach (byte b in hash)
                            {
                                sb.Append(b.ToString("x2"));
                            }
                            string hashString = sb.ToString();
                            return hashString;
                        }
                    }
                }
                else
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
                                { Console.WriteLine("Você precisa de {0} pontos!", media); }

                                else
                                { Console.WriteLine("Você já passou!"); }
                                break;

                            case 3:
                                Console.Write("Digite sua pesquisa: ");
                                string pesquisa = Console.ReadLine();
                                string url = $"https://pt.wikipedia.org/wiki/{pesquisa}";

                                try
                                {
                                    Process.Start(url);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Erro ao abrir o link: {ex.Message}");
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
    }
}
