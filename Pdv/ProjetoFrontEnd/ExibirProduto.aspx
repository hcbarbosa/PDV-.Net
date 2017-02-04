<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaPrincipal.Master" AutoEventWireup="true" CodeBehind="ExibirProduto.aspx.cs" Inherits="ProjetoFrontEnd.ExibirProduto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:HiddenField ID="hdCodigo" runat="server" />

    <asp:Label ID="lblNm" runat="server" Text="Nome:"></asp:Label>
    <asp:Label ID="lblNome" runat="server"></asp:Label>
    <br /><br />
    <asp:Label ID="lblDesc" runat="server" Text="Descrição:"></asp:Label>
    <asp:Label ID="lblDesricao" runat="server"></asp:Label>
    <br /><br />
    <asp:Label ID="lblPr" runat="server" Text="Preço:"></asp:Label>
    <asp:Label ID="lblPreco" runat="server"></asp:Label>
    <br /><br />
    <asp:Label ID="lblEs" runat="server" Text="Estoque:"></asp:Label>
    <asp:Label ID="lblEstoque" runat="server"></asp:Label>
    <br /><br />
    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
    <asp:Button ID="btnExcluir" runat="server" Text="Excluir" OnClick="btnExcluir_Click" />
    <asp:Button ID="btnEditar" runat="server" Text="Editar" OnClick="btnEditar_Click" />

    

</asp:Content>
