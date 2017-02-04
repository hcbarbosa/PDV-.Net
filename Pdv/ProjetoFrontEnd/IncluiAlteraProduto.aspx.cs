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
    public partial class IncluiAlteraProduto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //qualquer evento de botao executa o pageload novamente
            if (!IsPostBack)// é quando passa mais de uma vez pelo pageload
            {
                if (Request.QueryString["ID"] != null)
                {
                    int id = int.Parse(Request.QueryString["ID"].ToString());
                    string stringConexao = ConfigurationManager.ConnectionStrings["stringConexao"].ConnectionString;
                    ProdutoModel pModel = new ProdutoModel(stringConexao);
                    Produto produto = pModel.Obtem(id);
                    txtNome.Text = produto.Nome;
                    txtDescricao.Text = produto.Descricao;
                    txtPreco.Text = produto.Preco.ToString();
                    txtEstoque.Text = produto.Estoque.ToString();
                }
            }
         }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            Produto produto = new Produto();
            produto.Nome = txtNome.Text;
            produto.Descricao = txtDescricao.Text;
            produto.Estoque = int.Parse(txtEstoque.Text);
            produto.Preco = decimal.Parse(txtPreco.Text);
            produto.Status = 1;

            string stringConexao = ConfigurationManager.ConnectionStrings["stringConexao"].ConnectionString;

            ProdutoModel pModel = new ProdutoModel(stringConexao);
            bool resp = false;

            if (Request.QueryString["ID"] != null)
            {
                int id = int.Parse(Request.QueryString["ID"].ToString());
                produto.Id = id;
                resp = pModel.Editar(produto);

                if (resp)
                {
                    lblResp.Text = "Alteração de Produto realizado com sucesso.";
                    txtNome.Text = "";
                    txtDescricao.Text = "";
                    txtEstoque.Text = "";
                    txtPreco.Text = "";
                }
            }
            else
            {               
                resp = pModel.Inserir(produto);
                if (resp)
                {
                    lblResp.Text = "Cadastro de Produto realizado com sucesso.";
                    txtNome.Text = "";
                    txtDescricao.Text = "";
                    txtEstoque.Text = "";
                    txtPreco.Text = "";
                }
            }

            
        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            txtNome.Text = "";
            txtDescricao.Text = "";
            txtEstoque.Text = "";
            txtPreco.Text = "";
            lblResp.Text = "";
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListaProdutos.aspx");
        }
    }
}