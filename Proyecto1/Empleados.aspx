<%@ Page Title="" Language="C#" MasterPageFile="~/Login.master" AutoEventWireup="true" CodeFile="Empleados.aspx.cs" Inherits="Empleados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style4
    {
        color: #FFFFFF;
    }
    .style5
    {
        text-align: right;
    }
    .style6
    {
        width: 40%;
        height: 44px;
    }
    .style9
    {
        width: 200px;
    }
    .style10
    {
        width: 200px;
        color: #FFFFFF;
    }
        .style12
    {
        width: 80%;
        height: 110px;
    }
        .style19
        {
            width: 185px;
        }
        .style20
        {
            width: 185px;
            color: #FFFFFF;
            text-align: center;
        }
        .style21
        {
            width: 185px;
            text-align: center;
        }
    .style23
    {
        width: 200px;
        color: #FFFFFF;
        text-align: center;
        height: 23px;
    }
        .style26
        {
            text-decoration: underline;
            color: #FFFFFF;
            font-size: small;
        }
        .style27
        {
            width: 246px;
            text-align: center;
        }
        .style28
        {
            width: 246px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center" class="style6">
    <tr>
        <td class="style9">
            &nbsp;</td>
        <td class="style10">
            <strong><em>Inserte su CI por favor</em></strong></td>
        <td class="style9">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style10">
            <strong><em>Cedula:</em></strong></td>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <td class="style9">
            <asp:TextBox ID="txtCI" runat="server" Width="186px"></asp:TextBox>
        </td>
        <td class="style9">
            <asp:Button ID="btnBuscar" runat="server" onclick="btnBuscar_Click" 
                Text="Buscar" />
        </td>
    </tr>
</table>
    <em><strong>
    <asp:Label ID="lblMsg" runat="server" CssClass="style4" Text="Mensaje"></asp:Label>
    </strong></em><strong><em>
    <br />
    </em></strong>
    <span class="style9">
    <table align="center" class="style10">
        <tr>
            <td>
                <asp:Button ID="btnAgregar" runat="server"  
                    Text="Agregar" onclick="btnAgregar_Click1" />
            </td>
            <td>
                <asp:Button ID="btnModificar" runat="server" 
                    Text="Modificar" onclick="btnModificar_Click" />
            </td>
            <td>
                <asp:Button ID="btnEliminar" runat="server"  
                    Text="Eliminar" Visible="False" onclick="btnEliminar_Click" />
            </td>
        </tr>
    </table>
    </span>
    <br />
<table align="center" class="style12">
    <tr>
        <td class="style20">
            <strong><em>
            <asp:Label ID="lblCi" runat="server" Text="Cedula"></asp:Label>
            </em></strong>
        </td>
        <td class="style21">
            <asp:TextBox ID="txtCedula" runat="server" Width="177px"></asp:TextBox>
        </td>
        <td class="style27" align="center">
            &nbsp;</td>
        <td class="style21">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style20">
            <strong><em>
            <asp:Label ID="lblContraseña" runat="server" Text="Contraseña"></asp:Label>
            </em></strong>
        </td>
        <td class="style21">
            <asp:TextBox ID="txtContraseña" runat="server" Width="176px" 
                TextMode="Password"></asp:TextBox>
        </td>
        <td class="style27" align="center">
            <strong><em>
            <asp:Label ID="lblAviso" runat="server" CssClass="style26" 
                Text="**La contraseña sera guardada en minusculas**"></asp:Label>
            </em></strong></td>
        <td class="style21">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style20">
            <strong><em>
            <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
            </em></strong>
        </td>
        <td class="style21">
            <asp:TextBox ID="txtNombre" runat="server" Width="174px"></asp:TextBox>
        </td>
        <td class="style28" align="center">
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar cambios" 
                onclick="btnGuardar_Click" />
        </td>
        <td class="style21">
            <asp:Button ID="btnGuardarMOD" runat="server" Text="Guardar cambios" 
                onclick="btnGuardarMOD_Click" />
        </td>
    </tr>
    <tr>
        <td class="style19">
            &nbsp;</td>
        <td class="style19">
            <asp:Button ID="btnDelete" runat="server" onclick="btnDelete_Click" 
                Text="Eliminar " />
        </td>
        <td class="style28" align="center">
            &nbsp;</td>
        <td class="style19">
            &nbsp;</td>
    </tr>
    </table>
<strong><em>
<br />
<asp:Label ID="lblError" runat="server" CssClass="style4" Text="Label"></asp:Label>
</em></strong>
<br />
    <table align="center" class="style6">
    <tr>
        <td class="style23">
            &nbsp;</td>
    </tr>
</table>

</asp:Content>

