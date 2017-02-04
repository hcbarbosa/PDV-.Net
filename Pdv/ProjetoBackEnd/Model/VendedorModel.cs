using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjetoBackEnd.Data;
using ProjetoBackEnd.Entity;

namespace ProjetoBackEnd.Model
{
    public class VendedorModel
    {

        private string stringConexao;
        
        public VendedorModel(string stringConexao)
        {
            this.stringConexao = stringConexao;
        }

        //o using garante q enquanto tiver no contexto do using a conexao esta ok chegou na chaves } ele usa o dispose que 
        //fecha a conexao
        public bool Inserir(Vendedor vendedor)
        {
            using (VendedorData data = new VendedorData(stringConexao))
            {
                return data.Inserir(vendedor);
            }
        }


        public bool Editar(Vendedor vendedor)
        {
            using(VendedorData data = new VendedorData(stringConexao))
            {
                return data.Editar(vendedor);
            }
        }


        public bool Excluir(Vendedor vendedor)
        {
            using (VendedorData data = new VendedorData(stringConexao))
            {
                return data.Excluir(vendedor);
            }
        }


        public Vendedor Obtem(int id)
        {
            using (VendedorData data = new VendedorData(stringConexao))
            {
                return data.Obtem(id);
            }
        }


        public Vendedor Obtem(string usuario, string senha)
        {
            using (VendedorData data = new VendedorData(stringConexao))
            {
                return data.Obtem(usuario,senha);
            }
        }

        public List<Vendedor> Listar()
        {
            using (VendedorData data = new VendedorData(stringConexao))
            {
                return data.Listar();
            }
        }
    }
}
