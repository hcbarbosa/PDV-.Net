using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBackEnd.Entity
{
    public class Pessoa
    {        
        public String Nome {get; set;}
        public String Endereco { get; set; }
        public int Codigo {get ;set; }

        public Pessoa(){}

        public Pessoa(string nome, string endereco, int codigo) {
            Nome = nome;
            Endereco = endereco;
            Codigo = codigo;
        }

    }
}
