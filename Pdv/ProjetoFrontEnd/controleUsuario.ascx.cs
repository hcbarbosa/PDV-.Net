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
    public partial class controleUsuario : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Vendedor vendedor = Session["vendedor"] as Vendedor;

            if (vendedor == null)
            {
                painel.Visible = true;
                painelLogado.Visible = false;
            }
            else
            {
                painelLogado.Visible = true;
                painel.Visible = false;

                lblUsuario.Text = vendedor.Nome;
            }

        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            string strCnn =ConfigurationManager.ConnectionStrings["stringConexao"].ConnectionString;

            VendedorModel model = new VendedorModel(strCnn);

            Vendedor vendedor = model.Obtem(txtUsuario.Text, txtSenha.Text);

            if (vendedor != null)
            {
                Session["vendedor"] = vendedor;
                Response.Redirect("listaProdutos.aspx");
            }
            else
            {
                lblErro.Text = "Voce é voce??? É aqui !";
            }

        }
    }
}