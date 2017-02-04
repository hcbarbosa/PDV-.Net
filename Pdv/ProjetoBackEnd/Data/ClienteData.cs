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
    class ClienteData : PessoaData
    {
        
        public ClienteData(string stringConexao) : base(stringConexao) { }

        public Cliente Obtem(int codigo)
        {
            Cliente cliente = null;
            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandText = @"select * from pessoas p, clistar c where p.codigo = c.codigo and p.codigo = @codigo;";
                Cmd.Parameters.AddWithValue("@codigo", codigo);
                // comando que retorna valores
                Dr = Cmd.ExecuteReader();
                if (Dr.Read())
                {
                    cliente = new Cliente();
                    cliente.Codigo = Dr.GetInt32(0);
                    cliente.Nome = Dr.GetString(1);
                    cliente.Endereco = Dr.GetString(2);
                    cliente.Rg = Dr.GetString(4);
                    cliente.Cpf = Dr.GetString(5);
                    cliente.Credito = Dr.GetDecimal(6);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return cliente;
        }

        public List<Cliente> Listar()
        {
            List<Cliente> lista = null;

            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandText = @"select * from pessoas p, clientes c where p.codigo = c.codigo;";
                Dr = Cmd.ExecuteReader();

                lista = new List<Cliente>();
                while (Dr.Read())
                {
                    Cliente cliente = new Cliente();
                    cliente.Codigo = Dr.GetInt32(0);
                    cliente.Nome = Dr.GetString(1);
                    cliente.Endereco = Dr.GetString(2);
                    cliente.Rg = Dr.GetString(4);
                    cliente.Cpf = Dr.GetString(5);
                    cliente.Credito = Dr.GetDecimal(6);

                    lista.Add(cliente);
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
