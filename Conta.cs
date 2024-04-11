using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plataforma_do_Aluno
{
    class Conta
    {
        private string email;
        private string nome;
        private string senha;
        public string GetNome()
        {
            return email;
        }
        public void SetEmail(string email)
        {
            this.email = email;
        }
        public string GetEmail()
        {
            return nome;
        }
        public void SetNome(string nome)
        {
            this.nome = nome;
        }
        public string GetSenha()
        {
            return senha;
        }
        public void SetSenha(string senha)
        {
            this.senha = senha;
        }
        public Conta(string Email, string Nome, string Senha)
        {
            this.email = Email;
            this.nome = Nome;
            this.senha = Senha;
        }
    }
}
