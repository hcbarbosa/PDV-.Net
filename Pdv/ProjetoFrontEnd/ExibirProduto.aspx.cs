using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using ProjetoBackEnd.Entity;
using ProjetoBackEnd.Model;

namespace ProjetoFrontEnd
{
    public partial class ExibirProduto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string stringConexao = ConfigurationManager.ConnectionStrings["stringConexao"].ConnectionString;
            if (Request.QueryString["ID"].ToString() != null)
            {
                int id = int.Parse(Request.QueryString["ID"].ToString());
                ProdutoModel pModel = new ProdutoModel(stringConexao);
                Produto produto = pModel.Obtem(id);

                lblNome.Text = produto.Nome;
                lblDesricao.Text = produto.Descricao;
                lblPreco.Text = produto.Preco.ToString();
                lblEstoque.Text = produto.Estoque.ToString();
                hdCodigo.Value = produto.Id.ToString();
            }

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListaProdutos.aspx");
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            if (hdCodigo.Value != null)
            {
                string stringConexao = ConfigurationManager.ConnectionStrings["stringConexao"].ConnectionString;
                ProdutoModel pModel = new ProdutoModel(stringConexao);

                int id = int.Parse(hdCodigo.Value);
                pModel.Excluir(pModel.Obtem(id));

                Response.Redirect("ListaProdutos.aspx");
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            Response.Redirect("IncluiAlteraProduto.aspx?ID="+hdCodigo.Value);
        }
    }
}