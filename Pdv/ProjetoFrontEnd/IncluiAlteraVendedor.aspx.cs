using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using ProjetoBackEnd.Entity;
using ProjetoBackEnd.Model;

using System.Configuration;


namespace ProjetoFrontEnd
{
    public partial class IncluiAlteraVendedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            Vendedor vendedor = new Vendedor();

            vendedor.Nome = txtNome.Text;
            vendedor.Endereco = txtEndereco.Text;
            vendedor.Comissao = Convert.ToDecimal(txtComissao.Text);
            vendedor.Usuario = txtUsuario.Text;
            vendedor.Senha = txtSenha.Text;

            string strCnn = ConfigurationManager.ConnectionStrings["stringConexao"].ConnectionString;

            VendedorModel model = new VendedorModel(strCnn);

            if (Request.QueryString["id"] != null)
            {
                vendedor.Codigo = Convert.ToInt32(Request.QueryString["id"]);
                model.Editar(vendedor);
            }
            else
            {
                model.Inserir(vendedor);
            }
            
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
              
        }
    }
}