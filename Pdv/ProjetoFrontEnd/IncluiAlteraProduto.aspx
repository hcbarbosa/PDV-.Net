<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaPrincipal.Master" AutoEventWireup="true" CodeBehind="IncluiAlteraProduto.aspx.cs" Inherits="ProjetoFrontEnd.IncluiAlteraProduto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <fieldset>
        <legend>Cadastro/Alteração de Produtos</legend>
            <asp:Label ID="lblNome" runat="server" Text="Nome:"></asp:Label>
            <br />
            <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblDescricao" runat="server" Text="Descrição:"></asp:Label>
            <br />
            <asp:TextBox ID="txtDescricao" runat="server" TextMode="MultiLine"></asp:TextBox>
            <br />
            <asp:Label ID="lblPreco" runat="server" Text="Preço:"></asp:Label>
            <br />
            <asp:TextBox ID="txtPreco" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblEstoque" runat="server" Text="Estoque:"></asp:Label>
            <br />
            <asp:TextBox ID="txtEstoque" runat="server" TextMode="Number"></asp:TextBox>
            <br />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />         

            <asp:Button ID="btnLimpar" runat="server" Text="Limpar" OnClick="btnLimpar_Click" />            

            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" />
            <br />
           <asp:Label ID="lblResp" runat="server" Text=""></asp:Label>
            

    </fieldset>   
</asp:Content>
