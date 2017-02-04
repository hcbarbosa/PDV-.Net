<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaPrincipal.Master" AutoEventWireup="true" CodeBehind="ListaProdutos.aspx.cs" Inherits="ProjetoFrontEnd.ListaProdutos" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1><asp:Literal ID="Literal1" Text="<%$ resources: titulo %>" runat="server"></asp:Literal></h1>
    <asp:HyperLink ID="hlNovo" runat="server" NavigateUrl="~/IncluiAlteraProduto.aspx" meta:resourcekey="hlNovoResource1">Novo</asp:HyperLink>
    <br /><br />
    <asp:Repeater ID="listaProdutos" runat="server">
        <HeaderTemplate>
            <table border="1">
                <tr>
                    <th><asp:Literal ID="Literal2" Text="<%$ resources: id %>" runat="server"></asp:Literal></th>
                    <th><asp:Literal ID="Literal3" Text="<%$ resources: nome %>" runat="server"></asp:Literal></th>
                    <th><asp:Literal ID="Literal4" Text="<%$ resources: preco %>" runat="server"></asp:Literal></th>
                    <th><asp:Literal ID="Literal5" Text="<%$ resources: exibir %>" runat="server"></asp:Literal></th>
               </tr> 
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                    <td><%# DataBinder.Eval(Container.DataItem, "Id") %></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "Nome") %></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "Preco") %></td>
                    <td><asp:HyperLink ID="hlExibir" runat="server" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "Id","ExibirProduto.aspx?ID={0}") %>' meta:resourcekey="hlExibirResource1">Exibir
                        </asp:HyperLink>
                    </td>
           </tr> 
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
 
    </asp:Repeater>
 </asp:Content>
