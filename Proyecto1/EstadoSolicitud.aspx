<%@ Page Title="" Language="C#" MasterPageFile="~/Login.master" AutoEventWireup="true" CodeFile="EstadoSolicitud.aspx.cs" Inherits="EstadoSolicitud" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style6
        {
            width: 44%;
            height: 13px;
        }
        .style8
        {
            width: 221px;
        }
        .style9
        {
            width: 210px;
        }
        .style10
        {
            width: 61%;
            height: 229px;
        }
        .style11
        {
            width: 231px;
            height: 197px;
        }
        .style12
        {
            width: 524px;
            height: 197px;
        }
        .style13
        {
            width: 231px;
            height: 22px;
        }
        .style14
        {
            width: 524px;
            height: 22px;
        }
        .style15
        {
            height: 22px;
        }
        .style16
        {
            height: 197px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <em><strong><span class="style5">Estado de una solicitud</span></strong></em><br />
    </p>
    <table align="center" class="style6">
        <tr>
            <td class="style9">
                <strong><em>
                <asp:Label ID="lblEntidad" runat="server" CssClass="style5" 
                    Text="Seleccione la entidad"></asp:Label>
                </em></strong>
            </td>
            <td class="style8">
                <asp:DropDownList ID="ddlEntidades" runat="server" AutoPostBack="True">
                </asp:DropDownList>
            </td>
            <td>
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" 
                    onclick="btnBuscar_Click" />
            </td>
        </tr>
    </table>
    <p>
        <asp:GridView ID="GVentidades" runat="server" AutoGenerateSelectButton="True" 
            BackColor="Black" CellPadding="4" CssClass="auto-style8" ForeColor="Black" 
            GridLines="None" OnSelectedIndexChanged="GVEntidades_SelectedIndexChanged" 
            style="margin-left: 414px" Width="518px">
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>
    </p>
    <table align="center" class="style10">
        <tr>
            <td class="style13">
                <strong><em>
                <asp:Label ID="lblTexto1" runat="server" CssClass="style5" 
                    Text="Cual desea ver?"></asp:Label>
                </em></strong>
            </td>
            <td class="style14">
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem Value="Todos"></asp:ListItem>
                    <asp:ListItem Value="Ejecutados"></asp:ListItem>
                    <asp:ListItem>Anulados</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="style15">
                <asp:Button ID="btnVer" runat="server" Text="Ver" onclick="btnVer_Click" />
            </td>
        </tr>
        <tr>
            <td class="style11">
            </td>
            <td class="style12">
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField HeaderText="ID" DataField="Codigo_Tramite" />
                        <asp:BoundField HeaderText="Empleado" DataField="NombreEmpleado" />
                        <asp:BoundField HeaderText="Fecha" DataField="Fecha_Hora" />
                        <asp:BoundField HeaderText="Nombre del solicitante" DataField="NombreCliente" />
                        <asp:BoundField HeaderText="Estado" DataField="Estado" />
                        <asp:BoundField HeaderText="Entidad" DataField="DatosEntidad" />
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
            </td>
            <td class="style16">
            </td>
        </tr>
    </table>
    <p>
        <strong><em>
        <asp:Label ID="lblError" runat="server" CssClass="style5" Text="Label"></asp:Label>
        </em></strong>
    </p>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>

