using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data.Linq.Mapping;
using System.Data.Linq;


namespace ProjetoBackEnd.Entity
{
    [Table(Name="produtos")]
    public class Produto //modificar o controle de acesso pq quando nao tem significa que
    //esta com o internal que eh soh aquele projeto que ve e encontra a classe
    {
        [Column(Name="id", IsDbGenerated=true, IsPrimaryKey=true, CanBeNull=false)]
        public int Id {get; set; }

        [Column(Name="nome", CanBeNull=false)]
        public string Nome { get; set; }

        [Column(Name="descricao", CanBeNull=false)]
        public string Descricao { get; set; }

        [Column(Name="preco",CanBeNull=false)]
        public decimal Preco { get; set; }

        [Column(Name = "estoque", CanBeNull = false)]
        public int Estoque { get; set; }

        [Column(Name = "status", CanBeNull = false)]
        public int Status { get; set; }

        public Produto() { }

        public Produto(int id, string nome, string descricao, decimal preco, int estoque, int status)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            Estoque = estoque;
            Status = status;
        }
    }
}
