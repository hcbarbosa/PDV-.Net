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
    class VendedorData : PessoaData
    {

         public VendedorData(string stringConexao) : base(stringConexao) { }
        

        public Vendedor Obtem(int codigo)
        {
            Vendedor vendedor = null;
            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandText = @"select * from pessoas p, vendedores v where p.codigo = v.codigo and p.codigo = @codigo;";
                Cmd.Parameters.AddWithValue("@codigo", codigo);
                // comando que retorna valores
                Dr = Cmd.ExecuteReader();
                if (Dr.Read())
                {
                    vendedor = new Vendedor();
                    vendedor.Codigo = Dr.GetInt32(0);
                    vendedor.Nome = Dr.GetString(1);
                    vendedor.Endereco = Dr.GetString(2);
                    vendedor.Usuario = Dr.GetString(4); //para pular o codigo da tabela vendedor soh pula o 3
                    vendedor.Senha = Dr.GetString(5);
                    vendedor.Comissao = Dr.GetDecimal(6);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return vendedor;
        }


        public Vendedor Obtem(string usuario, string senha)
        {
            Vendedor vendedor = null;
            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandText = @"select * from pessoas p, vendedores v where p.codigo = v.codigo and v.usuario = @usuario and v.senha = @senha;";
                Cmd.Parameters.AddWithValue("@usuario", usuario);
                Cmd.Parameters.AddWithValue("@senha", senha);
                // comando que retorna valores
                Dr = Cmd.ExecuteReader();
                if (Dr.Read())
                {
                    vendedor = new Vendedor();
                    vendedor.Codigo = Dr.GetInt32(0);
                    vendedor.Nome = Dr.GetString(1);
                    vendedor.Endereco = Dr.GetString(2);
                    vendedor.Usuario = Dr.GetString(4); //para pular o codigo da tabela vendedor soh pula o 3
                    vendedor.Senha = Dr.GetString(5);
                    vendedor.Comissao = Dr.GetDecimal(6);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return vendedor;
        }

        public List<Vendedor> Listar()
        {
            List<Vendedor> lista = null;

            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandText = @"select * from pessoas p, vendedores v where p.codigo = v.codigo;";
                Dr = Cmd.ExecuteReader();

                lista = new List<Vendedor>();
                while (Dr.Read())
                {
                    Vendedor vendedor = new Vendedor();
                    vendedor.Codigo= Dr.GetInt32(0);
                    vendedor.Nome = Dr.GetString(1);
                    vendedor.Endereco = Dr.GetString(2);
                    vendedor.Usuario = Dr.GetString(4);
                    vendedor.Senha = Dr.GetString(5);
                    vendedor.Comissao = Dr.GetDecimal(6);

                    lista.Add(vendedor);
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
