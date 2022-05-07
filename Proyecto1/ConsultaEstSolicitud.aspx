<%@ Page Title="" Language="C#" MasterPageFile="~/Publico.master" AutoEventWireup="true" CodeFile="ConsultaEstSolicitud.aspx.cs" Inherits="ConsultaEstSolicitud" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style2
        {
            color: #FFFFFF;
        }
        .style3
        {
            width: 100%;
        }
        .style4
        {
            width: 592px;
        }
        .style5
        {
            width: 333px;
        }
        .style6
        {
            width: 713px;
            text-align: right;
        }
        .style7
        {
            text-align: left;
        }
        .style8
        {
            color: #FFFFFF;
            text-decoration: underline;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <em><strong><span class="style2">Consulta del estado de una solicitud</span></strong></em></p>
    <p>
        <br />
        <strong><em>
        <asp:Label ID="lblError" runat="server" CssClass="style2" Text="Label"></asp:Label>
        </em></strong>
    </p>
    <table class="style3">
        <tr>
            <td class="style4">
                <strong><em>
                <asp:Label ID="lblCodigo" runat="server" CssClass="style2" 
                    Text="Ingrese el codigo por favor"></asp:Label>
                </em></strong>
            </td>
            <td class="style5">
                <asp:TextBox ID="txtCodigo" runat="server" Width="264px"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" 
                    onclick="btnBuscar_Click" />
            </td>
        </tr>
    </table>
    <table class="style3">
        <tr>
            <td class="style6">
                <strong><em>
                <asp:Label ID="lblText" runat="server" CssClass="style8" 
                    Text="El estado de su solicitud es:    "></asp:Label>
                </em></strong>
            </td>
            <td class="style7">
                <strong><em>
                <asp:Label ID="lblEstado" runat="server" CssClass="style2" Text="Label"></asp:Label>
                </em></strong>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <br />
    <br />
</asp:Content>

