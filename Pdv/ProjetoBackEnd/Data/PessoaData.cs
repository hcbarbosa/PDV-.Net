using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using System.Data.SqlClient;
using ProjetoBackEnd.Entity;

namespace ProjetoBackEnd.Data
{
    class PessoaData : Conexao
    {

        public PessoaData(string stringConexao) : base(stringConexao) { }

            public bool Inserir( Pessoa pessoa )
            {
                bool ok = false;
                SqlTransaction tran = null;
                try { 
                    tran = Cnn.BeginTransaction();// instancia a transacao
                    Cmd = new SqlCommand(); // onde executa de fato o sql, abre o caminho pro banco e executa
                    Cmd.Connection = Cnn;
                    Cmd.Transaction = tran; // avisando q o comand pertence a uma transacao
                    // transacao soh insere no banco quando termina, por enqto os dados fica na memoria

                    Cmd.CommandText = @"insert into pessoas values(@nome,@endereco);" +
                        "select @@IDENTITY from pessoas;";

                    Cmd.Parameters.AddWithValue("@nome", pessoa.Nome);
                    Cmd.Parameters.AddWithValue("@endereco",pessoa.Endereco);

                    pessoa.Codigo = Convert.ToInt32(Cmd.ExecuteScalar()); //ExecuteScalar retorna o q foi pedido, ja o executenoquery nao retorna nada

                    if(pessoa is Cliente)
                    {
                        Cliente cliente = pessoa as Cliente;
                        Cmd.CommandText = @"insert into clientes values(@codigo,@rg,@cpf,@credito";
                        Cmd.Parameters.AddWithValue("@codigo",cliente.Codigo);
                        Cmd.Parameters.AddWithValue("@rg",cliente.Rg);
                        Cmd.Parameters.AddWithValue("@cpf",cliente.Cpf);
                        Cmd.Parameters.AddWithValue("@credito",cliente.Credito);

                        Cmd.ExecuteNonQuery();                       
                    }
                    else if( pessoa is Vendedor)
                    {
                        Vendedor vendedor = pessoa as Vendedor;
                        Cmd.CommandText = @"insert into vendedores values(@codigo,@usuario,@senha,@comissao";
                        Cmd.Parameters.AddWithValue("@codigo", vendedor.Codigo);
                        Cmd.Parameters.AddWithValue("@usuario",vendedor.Usuario);
                        Cmd.Parameters.AddWithValue("@senha",vendedor.Senha);
                        Cmd.Parameters.AddWithValue("@comissao",vendedor.Comissao);

                        Cmd.ExecuteNonQuery();                        
                    }
                    
                    tran.Commit();                    
                    ok = true;
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    Console.WriteLine(e.Message);
                }
                return ok;
            }


        public bool Editar(Pessoa pessoa)
        {
            bool ok = false;
            SqlTransaction tran = null;
            try
            {
                tran = Cnn.BeginTransaction();
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.Transaction = tran;

                Cmd.CommandText = @"update pessoas set nome = @nome, endereco = @endereco where codigo = @codigo";
                Cmd.Parameters.AddWithValue("@nome", pessoa.Nome);
                Cmd.Parameters.AddWithValue("@endereco", pessoa.Endereco);
                Cmd.Parameters.AddWithValue("@codigo", pessoa.Codigo);

                Cmd.ExecuteNonQuery();
                if(pessoa is Cliente)
                { 
                    Cliente cliente = pessoa as Cliente;

                    Cmd.CommandText = @"update clientes set rg = @rg, cpf = @cpf, credito = @credito where codigo = @idPessoa";
                    Cmd.Parameters.AddWithValue("@idPessoa", cliente.Codigo);
                    Cmd.Parameters.AddWithValue("@rg",cliente.Rg);
                    Cmd.Parameters.AddWithValue("@cpf",cliente.Cpf);
                    Cmd.Parameters.AddWithValue("@credito",cliente.Credito);

                    Cmd.ExecuteNonQuery();

                }
                else if(pessoa is Vendedor)
                {
                    Vendedor vendedor = pessoa as Vendedor;

                    Cmd.CommandText = @"update vendedores set usuario = @usuario, senha = @senha, comissao = @comissao where codigo = @idPessoa";
                    Cmd.Parameters.AddWithValue("@idPessoa", vendedor.Codigo);
                    Cmd.Parameters.AddWithValue("@usuario", vendedor.Usuario);
                    Cmd.Parameters.AddWithValue("@senha", vendedor.Senha);
                    Cmd.Parameters.AddWithValue("@comissao", vendedor.Comissao);

                    Cmd.ExecuteNonQuery();
                }

                tran.Commit();
                ok = true;

            }
            catch(Exception e)
            {
                tran.Rollback();
                Console.WriteLine(e.Message);
            }

            return ok;
        }


        public bool Excluir(Pessoa pessoa)
        {
            bool ok = false;
            SqlTransaction tran = null;
            try
            {
                tran = Cnn.BeginTransaction();
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.Transaction = tran;                

                if (pessoa is Cliente)
                {
                    Cmd.CommandText = @"delete from clientes where codigo = @codigo;";
                }
                else if (pessoa is Vendedor)
                {
                    Cmd.CommandText = @"delete from vendedores where codigo = @codigo;";                    
                }
                                
                Cmd.Parameters.AddWithValue("@codigo", pessoa.Codigo);
                Cmd.ExecuteNonQuery();

                Cmd.CommandText = @"delete from pessoas where codigo = @cod;";
                Cmd.Parameters.AddWithValue("@cod", pessoa.Codigo);
                Cmd.ExecuteNonQuery();

                tran.Commit();
                ok = true;
            }
            catch (Exception e)
            {
                tran.Rollback();
                Console.WriteLine(e.Message);
            }
            return ok;
        }

    }
}
