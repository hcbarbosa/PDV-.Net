using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBackEnd.Entity
{
    public class Cliente : Pessoa //representando heranca
    {
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public decimal Credito { get; set; }

        public Cliente() { }

        public Cliente( int codigo, string nome, string endereco, string rg, string cpf, decimal credito):base(nome,endereco,codigo)
        {
            Rg = rg;
            Cpf = cpf;
            Credito = credito;
        }
    }
}
