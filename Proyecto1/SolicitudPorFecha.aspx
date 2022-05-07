<%@ Page Title="" Language="C#" MasterPageFile="~/Login.master" AutoEventWireup="true" CodeFile="SolicitudPorFecha.aspx.cs" Inherits="SolicitudPorFecha" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style6
        {
            width: 100%;
        }
        .style7
        {
            width: 535px;
        }
        .style8
        {
            color: #FFFFFF;
            font-size: x-large;
        }
        .style9
        {
            width: 428px;
        }
        .style10
        {
            margin-left: 0px;
        }
        .style11
        {
            width: 24%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <span class="style5"><em><strong>Listado de solicitudes por fecha</strong></em></span><br />
    </p>
    <table class="style6">
        <tr>
            <td class="style11">
                <strong><em>
                <asp:Label ID="lblSeleccionar" runat="server" CssClass="style8" 
                    Text="Seleccione una fecha por favor"></asp:Label>
                </em></strong>
            </td>
            <td class="style9" align="center">
                <asp:Calendar ID="Calendar1" runat="server" BackColor="White" 
                    BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" 
                    Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" 
                    Width="200px" CssClass="style10" ShowGridLines="True">
                    <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                    <NextPrevStyle VerticalAlign="Bottom" />
                    <OtherMonthDayStyle ForeColor="#808080" />
                    <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                    <SelectorStyle BackColor="#CCCCCC" />
                    <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                    <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <WeekendDayStyle BackColor="#FFFFCC" />
                </asp:Calendar>
            </td>
            <td align="center">
                <asp:Calendar ID="Calendar2" runat="server" BackColor="White" 
                    BorderColor="#999999" CellPadding="4" CssClass="auto-style4" 
                    DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" 
                    Height="171px" Width="202px" ShowGridLines="True">
                    <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                    <NextPrevStyle VerticalAlign="Bottom" />
                    <OtherMonthDayStyle ForeColor="#808080" />
                    <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                    <SelectorStyle BackColor="#CCCCCC" />
                    <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                    <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <WeekendDayStyle BackColor="#FFFFCC" />
                </asp:Calendar>
            </td>
            <td>
                <asp:Button ID="btnVer" runat="server" Text="Ver" onclick="btnVer_Click" />
            </td>
        </tr>
    </table>
    <p>
        <asp:GridView ID="GVSolicitudTramite" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" ForeColor="#333333" GridLines="None" 
            HorizontalAlign="Center">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField HeaderText="Nombre del solicitante" DataField="NombreCliente" />
                <asp:BoundField HeaderText="ID" DataField="Codigo_Tramite" />
                <asp:BoundField DataField="Fecha_Hora" HeaderText="Fecha y hora" />
                <asp:BoundField HeaderText="CI Empleado" DataField="Empleado.cedula" />
                <asp:BoundField DataField="Estado" HeaderText="Estado" />
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
        <strong>
        <asp:Label ID="lblError" runat="server" CssClass="style5" Text="Label"></asp:Label>
        </strong>
    </p>
    <p>
    </p>
</asp:Content>

