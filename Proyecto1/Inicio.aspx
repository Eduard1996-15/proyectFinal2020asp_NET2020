<%@ Page Title="" Language="C#" MasterPageFile="~/Publico.master" AutoEventWireup="true" CodeFile="Inicio.aspx.cs" Inherits="Inicio" EnableEventValidation="False"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

    .style3
    {
        width: 69%;
            height: 435px;
        }
    .style6
    {
        text-align: center;
        color: #FFFFFF;
    }
        .style7
        {
            width: 62%;
            height: 406px;
        }
        .style8
        {
            color: #FFFFFF;
        }
        .style10
        {
            width: 575px;
        }
        .style11
        {
            width: 575px;
            height: 23px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style3" align="center">
        <tr>
            <td class="style6">
    <table align="center" class="style7">
        <tr>
            <td align="center" class="style10">
                <strong>
                <asp:Label ID="lblentidades" runat="server" CssClass="style8"></asp:Label>
                </strong>
                <asp:GridView ID="GVentidades" runat="server" 
                    BackColor="Black" CellPadding="4" CssClass="auto-style8" ForeColor="Black" 
                    GridLines="None" 
                    Width="564px" AutoGenerateColumns="False" Height="213px" 
                    onrowcommand="GVEntidades_RowCommand"
                    >
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:ButtonField Text="Seleccionar" HeaderText="Seleccionar entidad" 
                             commandname="Seleccionar" />
                        <asp:BoundField DataField="Nombre" HeaderText="Entidad" />
                        <asp:BoundField DataField="Direccion" HeaderText="Direccion" />
                        <asp:ButtonField ButtonType="Button" HeaderText="Telefonos" 
                            Text="Ver Telefonos" commandname="Ver" />
                    </Columns>
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
                <strong>
                <asp:Label ID="lblMensaje" runat="server" Text="Label"></asp:Label>
                </strong>
                <br />
                <asp:ListBox ID="lstTelefonos" runat="server" Height="26px" Width="179px"></asp:ListBox>
                <br />
            </td>
        </tr>
        <tr>
            <td align="center" class="style10">
                <strong>
                <asp:Label ID="lbltramites" runat="server" CssClass="style8"></asp:Label>
                </strong>
                <asp:GridView ID="GVtramite" runat="server" BackColor="White" 
                    BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" 
                    CssClass="auto-style9" ForeColor="#33CC33" GridLines="Horizontal" 
                    Width="518px" 
                    AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="Nombre_Tramite" HeaderText="Nombre del tramite" />
                        <asp:BoundField DataField="Codigo" HeaderText="Codigo" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#333333" />
                    <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="White" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                    <SortedAscendingHeaderStyle BackColor="#487575" />
                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                    <SortedDescendingHeaderStyle BackColor="#275353" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="center" class="style11">
                <strong>
                <asp:Label ID="lblerror" runat="server" CssClass="style8"></asp:Label>
                </strong>
            </td>
        </tr>
    </table>
            </td>
        </tr>
        <tr>
            <td class="style6">
                <asp:Button ID="btnLogin" runat="server" PostBackUrl="~/InicioSesion.aspx" 
                    Text="Login" />
            </td>
        </tr>
        <tr>
            <td class="style6">
                <asp:Button ID="btnConsulta" runat="server" 
                    PostBackUrl="~/ConsultaEstSolicitud.aspx" 
                    Text="Consultar estado de solicitud" />
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
        </tr>
    </table>
    <br />
    </asp:Content>

