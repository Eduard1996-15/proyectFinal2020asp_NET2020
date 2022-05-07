<%@ Page Title="" Language="C#" MasterPageFile="~/Publico.master" AutoEventWireup="true" CodeFile="InicioSesion.aspx.cs" Inherits="InicioSesion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">


    .style5
    {
        width: 53%;
    }
    .style8
    {
        width: 248px;
        color: #FFFFFF;
    }
    .style7
    {
        width: 235px;
    }
    .style6
    {
        width: 248px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        &nbsp;</p>
    <strong><em>
    <asp:Label ID="lblError" runat="server" CssClass="style1" Text="Label" 
        style="color: #FFFFFF"></asp:Label>
    </em></strong>
    <br />
<table align="center" class="style5">
    <tr>
        <td class="style8">
            Cedula</td>
        <td class="style7">
            <asp:TextBox ID="txtCedula" runat="server"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style8">
            Contraseña</td>
        <td class="style7">
            <asp:TextBox ID="txtContraseña" runat="server" TextMode="Password" 
                ></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style6">
            &nbsp;</td>
        <td class="style7">
            &nbsp;</td>
        <td>
            <asp:Button ID="btnInicio" runat="server" Text="Inicie Sesion" 
                onclick="btnInicio_Click" />
        </td>
    </tr>
</table>
    </asp:Content>

