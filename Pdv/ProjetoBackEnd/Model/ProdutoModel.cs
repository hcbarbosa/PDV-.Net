using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjetoBackEnd.Data;
using ProjetoBackEnd.Entity;

namespace ProjetoBackEnd.Model
{
    public class ProdutoModel
    {
        private string stringConexao;
        
        public ProdutoModel(string stringConexao)
        {
            this.stringConexao = stringConexao;
        }

        //o using garante q enquanto tiver no contexto do using a conexao esta ok chegou na chaves } ele usa o dispose que 
        //fecha a conexao
        public bool Inserir(Produto produto)
        {
            //using (ProdutoData data = new ProdutoData(stringConexao))
            //{
              //  return data.Inserir(produto);
            //}

            using(PdvContext bd = new PdvContext(stringConexao))
            {
                try
                {
                    bd.TabelaProduto.InsertOnSubmit(produto);
                    bd.SubmitChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }

        }


        public bool Editar(Produto produto)
        {
            //using(ProdutoData data = new ProdutoData(stringConexao))
            //{
             //   return data.Editar(produto);
            //}

           
                using(PdvContext bd = new PdvContext(stringConexao))
                {
                     try
                    {
                         var query = from prd in bd.TabelaProduto
                                where prd.Id == produto.Id
                                select prd;
                         
                         foreach(Produto prd in query)
                         {
                             prd.Id = produto.Id;
                             prd.Nome = produto.Nome;
                             prd.Preco = produto.Preco;
                             prd.Estoque = produto.Estoque;
                             prd.Status = produto.Status;
                         }

                         bd.SubmitChanges();                         
                         return true;
                     }
                     catch
                     {
                         return false;
                     }               
            }
           
        }


        public bool Excluir(Produto produto)
        {
            //using (ProdutoData data = new ProdutoData(stringConexao))
            //{
            //    return data.Excluir(produto);
            //}


            using(PdvContext bd = new PdvContext(stringConexao))
            {
                try
                {
                    bd.TabelaProduto.DeleteOnSubmit(produto);
                    bd.SubmitChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }


        public Produto Obtem(int id)
        {
            //using (ProdutoData data = new ProdutoData(stringConexao))
            //{
            //    return data.Obtem(id);
            //}
            using (PdvContext bd = new PdvContext(stringConexao))
            {
                Produto p = bd.TabelaProduto.FirstOrDefault(pr => pr.Id == id);
                return p;
            }
        }


        public List<Produto> Listar()
        {
            //using (ProdutoData data = new ProdutoData(stringConexao))
            //{
              //  return data.Listar();
            //}
            using (PdvContext bd = new PdvContext(stringConexao))
            {
                return bd.TabelaProduto.ToList();
            }
        }



    }
}
