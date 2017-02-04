using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//chamando as entidades que estao dentro da pasta entity
using ProjetoBackEnd.Entity;
using System.Data.SqlClient;



namespace ProjetoBackEnd.Data
{
    class ProdutoData : Conexao //todos os comandos referentes a entidade produto estara aqui
    {
        public ProdutoData(string stringConexao) : base(stringConexao) { }
        
        public bool Inserir(Produto produto)//esse cara é um objeto e quando ele chegar aqui ele precisa estar preenchido
        {
            bool ok = false;
            try
            {
                //cria o comando
                Cmd = new SqlCommand();
                //liga o comando a conexao, permissao para o comando
                Cmd.Connection = Cnn;
                //prepara o comando como sql
                Cmd.CommandText = @"insert into produtos (nome,descricao,preco,estoque,status) values (@nome,@descricao,@preco,@estoque,@status);";
                //passa os parametros pra ele
                Cmd.Parameters.AddWithValue("@nome", produto.Nome);
                Cmd.Parameters.AddWithValue("@descricao", produto.Descricao);
                Cmd.Parameters.AddWithValue("@preco", produto.Preco);
                Cmd.Parameters.AddWithValue("@estoque", produto.Estoque);
                Cmd.Parameters.AddWithValue("@status", produto.Status);
                //executa o comando
                Cmd.ExecuteNonQuery();
                ok = true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return ok;
        }


        public bool Editar(Produto produto)
        {
            bool ok = false;
            try
            {
                //cria o comando
                Cmd = new SqlCommand();
                //liga o comando a conexao, permissao para o comando
                Cmd.Connection = Cnn;
                //prepara o comando como sql
                Cmd.CommandText = @"update produtos set nome = @nome, descricao = @descricao, preco = @preco,"
                + "estoque = @estoque, status = @status where id = @codigo;";
                //passa os parametros pra ele
                Cmd.Parameters.AddWithValue("@nome", produto.Nome);
                Cmd.Parameters.AddWithValue("@descricao", produto.Descricao);
                Cmd.Parameters.AddWithValue("@preco", produto.Preco);
                Cmd.Parameters.AddWithValue("@estoque", produto.Estoque);
                Cmd.Parameters.AddWithValue("@status", produto.Status);
                Cmd.Parameters.AddWithValue("@codigo", produto.Id);
                //executa o comando
                Cmd.ExecuteNonQuery();
                ok = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return ok;
        }


        public bool Excluir(Produto produto)
        {
            bool ok = false;
            try
            {
                //cria o comando
                Cmd = new SqlCommand();
                //liga o comando a conexao, permissao para o comando
                Cmd.Connection = Cnn;
                //prepara o comando como sql
                Cmd.CommandText = @"delete from produtos where id = @codigo;";
                Cmd.Parameters.AddWithValue("@codigo", produto.Id);
                Cmd.ExecuteNonQuery();
                ok = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return ok;
        }

        public Produto Obtem(int id)
        {
            Produto produto = null;
            try{
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandText = @"select * from produtos where id = @codigo;";
                Cmd.Parameters.AddWithValue("@codigo", id);
                // comando que retorna valores
                Dr = Cmd.ExecuteReader();
                if (Dr.Read())
                {
                    produto = new Produto();
                    produto.Id = Dr.GetInt32(0);
                    //produto.Nome = Dr["nome"].ToString();
                    produto.Nome = Dr.GetString(1);
                    produto.Descricao = Dr.GetString(2);

                    produto.Preco = decimal.Parse(Dr["preco"].ToString());//Dr.GetFloat(3);
                    produto.Estoque = Dr.GetInt32(4);
                    produto.Status = Dr.GetInt32(5);
                }
       
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return produto;
        }

        public List<Produto> Listar()
        {
            List<Produto> lista = null;
            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandText = @"select * from produtos;";
                Dr = Cmd.ExecuteReader();

                lista = new List<Produto>();
                while (Dr.Read())
                {
                    Produto produto = new Produto();
                    produto.Id = Dr.GetInt32(0);
                    produto.Nome = Dr.GetString(1);
                    produto.Descricao = Dr.GetString(2);
                    produto.Preco = decimal.Parse(Dr["preco"].ToString());
                    produto.Estoque = Dr.GetInt32(4);
                    produto.Status = Dr.GetInt32(5);

                    lista.Add(produto);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return lista;
        }
    }
}
