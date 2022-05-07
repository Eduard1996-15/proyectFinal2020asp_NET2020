<%@ Page Title="" Language="C#" MasterPageFile="~/Login.master" AutoEventWireup="true" CodeFile="CambioEstadoSolicitud.aspx.cs" Inherits="EstadoSolicitud"
 EnableEventValidation="False" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <span class="style5"><strong><em>Estado de una solicitud</em></strong></span><br />
    </p>
    <em><strong>
    <asp:Label ID="lblMsg" runat="server" CssClass="style5" 
        Text="Seleccione una solicitud para modificar su estado."></asp:Label>
    <br />
    </strong>
    <asp:GridView ID="GVsolicitudes" runat="server" AutoGenerateColumns="False" CellPadding="4" 
        CssClass="auto-style8" ForeColor="#333333" 
        style="margin-left: 419px" Width="699px" onrowcommand="GVsolicitudes_RowCommand" 
        >
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="NombreCliente" HeaderText="Nombre Cliente" />
            <asp:BoundField DataField="Codigo_Tramite" HeaderText="Codigo del tramite" />
            <asp:BoundField DataField="Estado" HeaderText="Estado" />
            <asp:BoundField DataField="Fecha_Hora" HeaderText="Fecha" />
            <asp:buttonfield buttontype="Button" 
            commandname="Anulada"
            headertext="Anulada" 
            text="Anulada"/>
            <asp:buttonfield buttontype="Button" 
            commandname="Ejecutada"
            headertext="Ejecutada" 
            text="Ejecutada"/>
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
    </em>
    <p>
        <strong><em>
        <asp:Label ID="lblError" runat="server" CssClass="style5" Text="Label"></asp:Label>
        </em></strong>
    </p>
</asp:Content>

