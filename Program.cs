using System;
using System.Collections.Generic;

namespace Plataforma_do_Aluno
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Escolha uma operação : \r\n[1] Login \r\n[2] Cadastro");
                int operação = int.Parse(Console.ReadLine());

                if (operação == 1){
                    
                }else if (operação == 2){
                    Console.WriteLine("Insira o seu e-mail");
                    string Email = Console.ReadLine();
                    Console.WriteLine("Insira o nome da sua conta");
                    string Nome = Console.ReadLine();
                    Console.WriteLine("Insira a senha da conta");
                    string Senha = Console.ReadLine();

                    List<Conta> Listaconta = new List<Conta>();
                    Conta conta = new Conta(Email, Nome, Senha);
                    Listaconta.Add(conta);

                    
                }else{
                    Console.WriteLine("\r\nOperação não existe \r\n");
                }
            }
        }
    }
}
