<%@ Page Title="" Language="C#" MasterPageFile="~/Login.master" AutoEventWireup="true" CodeFile="RegistrarSolicitud.aspx.cs" Inherits="RegistrarSolicitud" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style6
        {
            width: 59%;
            height: 22px;
        }
        .style7
        {
            width: 371px;
        }
        .style9
        {
            width: 42%;
        }
        .style10
        {
            width: 59%;
            height: 95px;
        }
        .style11
        {
            width: 493px;
        }
        .style12
        {
            width: 42%;
            height: 204px;
        }
        .style13
        {
            width: 100%;
            height: 204px;
        }
        .style14
        {
            width: 32%;
            height: 6px;
        }
        .style15
        {
            width: 493px;
            color: #FFFFFF;
        }
        .style16
        {
            width: 64%;
        }
        .style17
        {
            width: 64%;
            height: 204px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <br />
        <em><strong><span class="style5">Registrar solicitud</span></strong></em></p>
    <p class="style3">
        <strong><em>
        <asp:Label ID="lblMsg" runat="server" CssClass="style5" 
            Text="Seleccione el tramite para agendar una cita."></asp:Label>
        </em></strong>
        <asp:GridView ID="grdListaTramite" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" ForeColor="#333333" GridLines="None" Height="104px" 
            HorizontalAlign="Center" Width="573px" 
            onselectedindexchanged="grdListaTramite_SelectedIndexChanged" 
            AllowSorting="True">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField HeaderText="Nombre del tramite" DataField="Nombre_Tramite" 
                    ReadOnly="True" SortExpression="Nombre_Tramite" />
                <asp:BoundField HeaderText="Entidad" DataField="NombreEntidad.Nombre" 
                    ReadOnly="True" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                <asp:BoundField DataField="codigo" HeaderText="Codigo" />
                <asp:CommandField SelectText="Seleccionar tramite" ShowSelectButton="True" />
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
        <strong><em>
        <asp:Label ID="lblError" runat="server" CssClass="style5" Text="Label"></asp:Label>
        </em></strong>
    </p>
    <table align="center" class="style10">
        <tr>
            <td class="style15">
                <strong>
                <asp:Label ID="lblNombEmpleado" runat="server" Text="Nombre del Empleado"></asp:Label>
                </strong>
            </td>
            <td>
                <asp:TextBox ID="txtEmpleado" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style11">
                <strong>
                <asp:Label ID="lblNomTram" runat="server" CssClass="style5" 
                    Text="Nombre del tramite"></asp:Label>
                </strong>
            </td>
            <td>
                <asp:TextBox ID="txtNomTram" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style11">
                <strong>
                <asp:Label ID="lblNomEntidad" runat="server" CssClass="style5" 
                    Text="Nombre Entidad"></asp:Label>
                </strong>
            </td>
            <td>
                <asp:TextBox ID="txtNomEntidad" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style11">
                <strong>
                <asp:Label ID="lblDescripcion" runat="server" CssClass="style5" 
                    Text="Descripcion"></asp:Label>
                </strong>
            </td>
            <td>
                <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style11">
                <strong>
                <asp:Label ID="lblCodigo" runat="server" CssClass="style5" Text="Codigo"></asp:Label>
                </strong>
            </td>
            <td>
                <asp:TextBox ID="txtCodigo" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style11">
                <strong>
                <asp:Label ID="lblNomCli" runat="server" CssClass="style5" 
                    Text="Nombre del solicitante"></asp:Label>
                </strong></td>
            <td>
                <asp:TextBox ID="txtNomCliente" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
    <br />
    <table align="center" class="style6">
        <tr>
            <td class="style9">
                <strong><em>
                <asp:Label ID="lblFecha" runat="server" CssClass="style5" 
                    Text="Seleccione fecha"></asp:Label>
                </em></strong>
            </td>
            <td class="style16">
                <strong><em>
                <asp:Label ID="lblHora" runat="server" CssClass="style5" 
                    Text="Seleccione hora"></asp:Label>
                </em></strong>
            </td>
            <td class="style7">
                <strong><em>
                <asp:Label ID="lblMinuto" runat="server" CssClass="style5" 
                    Text="Seleccione minutos"></asp:Label>
                </em></strong>
            </td>
        </tr>
        <tr>
            <td class="style12">
                <asp:Calendar ID="fecha1" runat="server" BackColor="White" 
                    BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" 
                    DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" 
                    ForeColor="#003399" Height="200px" ShowGridLines="True" Width="220px" 
                    EnableTheming="True">
                    <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                    <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                    <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                    <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" 
                        Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                    <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                    <WeekendDayStyle BackColor="#CCCCFF" />
                </asp:Calendar>
            </td>
            <td class="style17">
                <asp:DropDownList ID="ddlHora" runat="server" Height="62px" 
                     Width="39px">
                    <asp:ListItem Value="0"></asp:ListItem>
                    <asp:ListItem Value="23"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="style13">
                <asp:DropDownList ID="ddlMinuto" runat="server" Height="62px" Width="39px">
                    <asp:ListItem Value="00"></asp:ListItem>
                    <asp:ListItem Value="59"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    <br />
    <table align="center" class="style14">
        <tr>
            <td>
                <asp:Button ID="btnAgregar" runat="server" onclick="btnAgregar_Click" 
                    Text="Agregar solicitud" />
            </td>
        </tr>
    </table>
    <p>
        &nbsp;</p>
</asp:Content>

