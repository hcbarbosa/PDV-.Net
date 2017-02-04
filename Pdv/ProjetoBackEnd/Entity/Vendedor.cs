using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBackEnd.Entity
{
    public class Vendedor:Pessoa
    {
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public decimal Comissao { get; set; }

        public Vendedor() { }

        public Vendedor(string nome, string endereco, int codigo, string usuario, string senha, decimal comissao ) :base(nome,endereco,codigo)
        {
            Usuario = usuario;
            Senha = senha;
            Comissao = comissao;
        }

    }
}
