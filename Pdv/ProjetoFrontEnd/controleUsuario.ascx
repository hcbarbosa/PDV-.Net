<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="controleUsuario.ascx.cs" Inherits="ProjetoFrontEnd.controleUsuario" %>

<asp:Panel ID="painelLogado" runat="server">
    Olá <asp:Label  runat="server" ID="lblUsuario"></asp:Label>

</asp:Panel>
<asp:Panel ID="painel" runat="server">
    <asp:TextBox ID="txtUsuario" runat="server" placeholder="Usuario"></asp:TextBox>    
    <asp:TextBox ID="txtSenha" runat="server" placeholder="Senha" TextMode="Password"></asp:TextBox>
    <asp:Button ID="btnEntrar" runat="server" Text="Entrar" OnClick="btnEntrar_Click" />
    <asp:Label ID="lblErro" runat="server"></asp:Label>
</asp:Panel>
