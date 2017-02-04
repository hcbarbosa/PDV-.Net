using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Linq;
using ProjetoBackEnd.Entity;

namespace ProjetoBackEnd.Data
{
    public class PdvContext : DataContext
    {
        private string stringConexao { get; set; }

        private Table<Produto> tabelaProduto;

        public Table<Produto> TabelaProduto
        {
            get {
                if(tabelaProduto == null)
                {
                    tabelaProduto = this.GetTable<Produto>();
                }
                return tabelaProduto;
            }

            set
            {
                tabelaProduto = value;
            }
        }


        public PdvContext(string stringConn):base(stringConn)
        {
            stringConexao = stringConn;
        }

    }
}
