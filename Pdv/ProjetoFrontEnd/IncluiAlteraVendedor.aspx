<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaPrincipal.Master" AutoEventWireup="true" CodeBehind="IncluiAlteraVendedor.aspx.cs" Inherits="ProjetoFrontEnd.IncluiAlteraVendedor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <fieldset>
        <legend>Cadastro de vendedor</legend>
        <asp:Label ID="lblNome" runat="server" Text="Nome:"></asp:Label>
        <br />
        <asp:TextBox ID="txtNome" runat="server" Width="185px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Nome obrigatório" ControlToValidate="txtNome" ForeColor="Red" SetFocusOnError="True" ToolTip="Digite o nome">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="lblEndereco" runat="server" Text="Endereco:"></asp:Label>
        <br />
        <asp:TextBox ID="txtEndereco" runat="server" TextMode="MultiLine" Width="185px"></asp:TextBox>
        <br />
        <asp:Label ID="lblComissao" runat="server" Text="Comissao:"></asp:Label>
        <br />
        <asp:TextBox ID="txtComissao" runat="server"  Width="187px" ></asp:TextBox>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Comissão obrigatória" ControlToValidate="txtComissao" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>

        <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Valor fora da faixa" ControlToValidate="txtComissao" ForeColor="Red" MaximumValue="35,99" MinimumValue="0,1" SetFocusOnError="True"></asp:RangeValidator>

        <br />
        <asp:Label ID="lblUsuario" runat="server" Text="Usuario:"></asp:Label>
        <br />
        <asp:TextBox ID="txtUsuario" runat="server" Width="185px"></asp:TextBox>
        <br />
        <asp:Label ID="lblSenha" runat="server" Text="Senha:"></asp:Label>
        <br />
        <asp:TextBox ID="txtSenha" runat="server" TextMode="Password" Width="185px"></asp:TextBox>
        <br />
        <asp:Label ID="lblSenha1" runat="server" Text="Confirme a senha:"></asp:Label>
        <br />
        <asp:TextBox ID="txtSenha1" runat="server" TextMode="Password" Width="182px"></asp:TextBox>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtSenha" ControlToValidate="txtSenha1" ErrorMessage="Senhas são diferentes" ForeColor="Red" SetFocusOnError="True"></asp:CompareValidator>
        <br />        
        <br />
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
        <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" />
    </fieldset>


</asp:Content>
