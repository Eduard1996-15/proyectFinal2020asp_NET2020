<%@ Page Title="" Language="C#" MasterPageFile="~/Login.master" AutoEventWireup="true" CodeFile="MantEntidad.aspx.cs" Inherits="MantEntidad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">


        .style6
        {
            width: 65%;
            height: 23px;
        }
        .style7
        {
            width: 372px;
        }
        .style9
        {
            width: 256px;
            color: #FFFFFF;
        }
        .style12
        {
            width: 65%;
            height: 4px;
        }
        .style13
        {
            width: 372px;
            text-align: center;
        }
        .style8
        {
            width: 256px;
        }
        .style10
        {
            width: 254px;
            color: #FFFFFF;
        }
        .style15
        {
            width: 309px;
            height: 28px;
            text-align: center;
        }
        .style16
        {
            width: 436px;
            height: 28px;
        }
        .style17
        {
            height: 28px;
        }
        .style18
        {
            width: 40%;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <br />
        <em><strong><span class="style5">Manejo de entidades</span></strong></em></p>
    <table class="style6" align="center">
        <tr>
            <td class="style18">
                &nbsp;</td>
            <td class="style9">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <table class="style12" align="center">
        <tr>
            <td class="style13">
                <strong><em>
                <asp:Label ID="lblIdentificador" runat="server" CssClass="style5" 
                    Text="Ingrese nombre de entidad"></asp:Label>
                </em></strong>
            </td>
            <td class="style8">
                <asp:TextBox ID="txtNombreEntidad" runat="server" Width="223px"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" onclick="btnBuscar_Click" 
                     />
            </td>
        </tr>
    </table>
    <strong><em>
<br />
<asp:Label ID="lblMsg" runat="server" CssClass="style5" Text="Label"></asp:Label>
    <br />
    <asp:Label ID="lblError" runat="server" CssClass="style5" Text="Label"></asp:Label>
</em></strong>
<br />
    <p class="style5">
        <span class="style9">
        <table align="center" class="style10">
            <tr>
                <td>
                    <asp:Button ID="btnAgregar" runat="server"  
                        Text="Agregar entidad" onclick="btnAgregar_Click"  />
                </td>
                <td>
                    <asp:Button ID="btnModificar" runat="server" 
                        Text="Modificar entidad" onclick="btnModificar_Click"  />
                </td>
                <td>
                    <asp:Button ID="btnEliminar" runat="server" 
                         Text="Eliminar entidad" 
                        Visible="False" onclick="btnEliminar_Click"  />
                </td>
            </tr>
        </table>
        </span>
    </p>
    <table align="center" class="style12">
        <tr>
            <td class="style15">
                <strong><em>
                <asp:Label ID="lblNombre" runat="server" CssClass="style5" 
                    Text="Nombre de la entidad"></asp:Label>
                </em></strong>
            </td>
            <td class="style16">
                <asp:TextBox ID="txtNombreEnt" runat="server" Width="188px"></asp:TextBox>
            </td>
            <td class="style17">
            </td>
        </tr>
        <tr>
            <td class="style15">
                <strong><em>
                <asp:Label ID="lblDireccion" runat="server" CssClass="style5" 
                    Text="Direccion"></asp:Label>
                </em></strong>
            </td>
            <td class="style16">
                <asp:TextBox ID="txtDireccion" runat="server" Width="188px" 
                    ></asp:TextBox>
            </td>
            <td class="style17">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style15">
                <strong><em>
                <asp:Label ID="lblTelefono" runat="server" CssClass="style5" 
                    Text="Telefono"></asp:Label>
                </em></strong>
            </td>
            <td class="style16">
                <asp:TextBox ID="txtTelefono" runat="server" Width="188px" 
                    ></asp:TextBox>
            </td>
            <td class="style17">
                <asp:Button ID="btnAggTel" runat="server" 
                    Text="Agregar telefono" onclick="btnAggTel_Click" />
                <asp:Button ID="btnDeleteTel" runat="server" 
                    Text="Quitar telefono" onclick="btnDeleteTel_Click"  />
            </td>
        </tr>
        <tr>
            <td class="style15">
                &nbsp;</td>
            <td class="style16">
                <span class="style9">
                <asp:ListBox ID="listTelefonos" runat="server" Rows="5" Width="168px">
                </asp:ListBox>
                </span>
            </td>
            <td class="style17">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style15">
                &nbsp;</td>
            <td class="style16">
                <asp:Button ID="btnGuardar" runat="server"  Text="Agregar Entidad" onclick="btnGuardar_Click" 
                     />
                <asp:Button ID="btnMod" runat="server" onclick="btnMod_Click" 
                    Text="Modificar Entidad" />
                <asp:Button ID="btnDelete" runat="server" onclick="btnDelete_Click" 
                    Text="Eliminar Entidad" />
            </td>
            <td class="style17">
                &nbsp;</td>
        </tr>
        </table>
    <p>
    </p>
</asp:Content>

