using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// pacotes que contem nossas informacoes necessarias para estabelecer conexoes
using System.Data;
using System.Data.SqlClient;

namespace ProjetoBackEnd.Data
{
    public class Conexao : IDisposable//enqto essa classe fica ativa ela esta executando normal, quando saio da execucao dela, nos
    //invocamos o metodo dispose que fecha a conexao
    {
        public SqlConnection Cnn { get; set; }// permiti voce estabeler uma conexao com o banco, é nele que vc coloca
        //as 4 informacoes necessarias ( local, usuario, senha, porta do banco)
        public SqlCommand Cmd { get; set; }// permiti voce executar comandos no banco (insert, update, select..)
        public SqlDataReader Dr { get; set; }//permiti voce ler os dados de resultado (select...)

        public Conexao(string stringConexao)//string de conexao é onde fica as 4 propriedades principais de uma conexao
        //exemplo 192.168.0.2:3306/nomedobanco?usuario?senha
        {
            Cnn = new SqlConnection();
            Cnn.ConnectionString = stringConexao;
            Cnn.Open();
        }

        public void Dispose()
        {
            try
            {
                Cnn.Close();
            }
            catch( Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
