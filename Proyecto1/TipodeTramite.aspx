<%@ Page Title="" Language="C#" MasterPageFile="~/Login.master" AutoEventWireup="true" CodeFile="TipodeTramite.aspx.cs" Inherits="TipodeTramite" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style6
        {
            width: 100%;
        }
        .style7
        {
            width: 504px;
        }
        .style9
        {
            width: 256px;
            color: #FFFFFF;
        }
        .style10
        {
            width: 254px;
            color: #FFFFFF;
        }
        .style11
        {
            width: 255px;
        }
        .style12
        {
            width: 61%;
            height: 55px;
        }
        .style13
        {
            width: 309px;
        }
        .style14
        {
            width: 261px;
        }
        .style15
        {
            width: 309px;
            height: 28px;
        }
        .style16
        {
            width: 261px;
            height: 28px;
        }
        .style17
        {
            height: 28px;
        }
        .style19
        {
            width: 57%;
        }
        .style20
        {
            width: 341px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p class="style4">
        <br />
    </p>
    <p class="style5">
        <strong><em>Tipo de tramite</em></strong></p>
    <table class="style6">
        <tr>
            <td class="style19">
                &nbsp;</td>
            <td class="style9">
                <strong><em>Entidad</em></strong></td>
            <td class="style10">
                <strong><em>Código del tipo de tramite</em></strong></td>
        </tr>
    </table>
    <br />
    <table class="style6">
        <tr>
            <td class="style19">
                <strong><em>
                <asp:Label ID="lblIdentificador" runat="server" CssClass="style5" 
                    Text="Seleccione entidad y ingrese el codigo"></asp:Label>
                </em></strong>
            </td>
            <td class="style20">
                <asp:DropDownList ID="ddlEntidades" runat="server">
                </asp:DropDownList>
            </td>
            <td class="style11">
                <asp:TextBox ID="txtCodeTramite" runat="server" Width="223px"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" 
                    onclick="btnBuscar_Click" />
            </td>
        </tr>
    </table>
    <strong><em>
<br />
<asp:Label ID="lblMsg" runat="server" CssClass="style5" Text="Label"></asp:Label>
</em></strong>
<br />
    <p class="style5">
        <span class="style9">
        <table align="center" class="style10">
            <tr>
                <td>
                    <asp:Button ID="btnAgregar" runat="server"  
                        Text="Agregar tipo de tramite" onclick="btnAgregar_Click" />
                </td>
                <td>
                    <asp:Button ID="btnModificar" runat="server" 
                        Text="Modificar tipo de tramite" onclick="btnModificar_Click" />
                </td>
                <td>
                    <asp:Button ID="btnEliminar" runat="server" 
                         Text="Eliminar tipo de tramite" 
                        Visible="False" onclick="btnEliminar_Click" />
                </td>
            </tr>
        </table>
    <strong><em>
<asp:Label ID="lblError" runat="server" CssClass="style5" Text="Label"></asp:Label>
</em></strong>
        </span>
    </p>
    <table align="center" class="style12">
        <tr>
            <td class="style15">
                <strong><em>
                <asp:Label ID="lblNombreTramite" runat="server" CssClass="style5" 
                    Text="Nombre del tramite"></asp:Label>
                </em></strong>
            </td>
            <td class="style16">
                <asp:TextBox ID="txtNombreTram" runat="server" Width="188px"></asp:TextBox>
            </td>
            <td class="style17">
            </td>
        </tr>
        <tr>
            <td class="style15">
                <strong><em>
                <asp:Label ID="lblCodigo" runat="server" CssClass="style5" Text="Codigo"></asp:Label>
                </em></strong>
            </td>
            <td class="style16">
                <asp:TextBox ID="txtCodigo" runat="server" Width="188px"></asp:TextBox>
            </td>
            <td class="style17">
            </td>
        </tr>
        <tr>
            <td class="style15">
                <strong><em>
                <asp:Label ID="lblEntidad" runat="server" CssClass="style5" 
                    Text="Entidad a la que corresponde"></asp:Label>
                </em></strong>
            </td>
            <td class="style16">
                <asp:TextBox ID="txtEntidad" runat="server" Width="188px"></asp:TextBox>
            </td>
            <td class="style17">
            </td>
        </tr>
        <tr>
            <td class="style13">
                <strong><em>
                <asp:Label ID="lblDescripcion" runat="server" CssClass="style5" 
                    Text="Descripcion del tramite"></asp:Label>
                </em></strong>
            </td>
            <td class="style14">
                <asp:TextBox ID="txtDescripcion" runat="server" Width="188px"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnAdd" runat="server" onclick="btnAdd_Click" Text="Agregar" />
                <asp:Button ID="btnBorrar" runat="server" onclick="btnBorrar_Click" 
                    Text="Eliminar tramite" />
                <asp:Button ID="btnMod" runat="server" onclick="btnMod_Click" 
                    Text="Modificar tramite" />
            </td>
        </tr>
    </table>
    <br />
</asp:Content>

