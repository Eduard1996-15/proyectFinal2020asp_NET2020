using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades_Compartidas;
using Logica;

public partial class EstadoSolicitud : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DropDownList1.Visible = false;
            btnVer.Visible = false;
            lblTexto1.Visible = false;
            GridView2.Visible = false;
            lblError.Visible = false;
            #region cargoentidades
            List<Entidades> ent = LogicaEntidades.CargoEntidad();
            List<string> nom_ent = new List<string>();
            foreach (Entidades entidad in ent)
            {
                nom_ent.Add(entidad.Nombre);
            }
            #endregion
            ddlEntidades.DataSource = nom_ent;
            ddlEntidades.DataBind();     
        }
        if (IsPostBack)
        {
            DropDownList1.Visible = false;
            btnVer.Visible = false;
            lblTexto1.Visible = false;
            GVentidades.Visible = false;
            GridView2.Visible = false;
            lblError.Visible = false;
        }
    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        GVentidades.Visible = true;
        GVentidades.SelectedIndex = -1;
        GVentidades.DataSource = null;
        GVentidades.DataBind();
        try
        {
            string nom = Convert.ToString(ddlEntidades.SelectedItem.Value);
            Entidades ent = new Entidades(null, nom, null);
            List<Tramite> tram = LogicaTramites.ListaTramitexNombreEnt(ent);
            if (tram.Count == 0)
            {
                throw new Exception("No hay tramites en esta entidad");
            }
            GVentidades.DataSource = tram;
            GVentidades.DataBind();
        }
        catch (Exception ex)
        {
            lblError.Visible = true;
            lblError.Text = ex.Message;
        }
    }

    protected void GVEntidades_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList1.Visible = true;
        btnVer.Visible = true;
        lblTexto1.Visible = true;
        GridView2.Visible = false;
        GVentidades.Visible = true;
        GridView2.DataSource = null;
        GridView2.DataBind();
    }

    protected void btnVer_Click(object sender, EventArgs e)
    {
        GVentidades.Visible = true;
        GridView2.Visible = true;
        DropDownList1.Visible = true;
        btnVer.Visible = true;
        lblTexto1.Visible = true;
        try
        {
            string nom = Convert.ToString(ddlEntidades.SelectedValue);
            int cod = Convert.ToInt32(GVentidades.SelectedRow.Cells[3].Text);
            if (cod == 0)
            {
                throw new Exception("Usted no ha seleccionado ningun tramite para ver");
            }
            if (DropDownList1.SelectedIndex == 0)
            {
                GridView2.DataSource = LogicaSolicitudTramite.ListarSolicitudes(nom, cod);
                GridView2.DataBind();
            }
            else if (DropDownList1.SelectedIndex == 1)
            {
                GridView2.DataSource = LogicaSolicitudTramite.ListarSolicitudejecutada(nom, cod);
                GridView2.DataBind();
            }
            else if (DropDownList1.SelectedIndex == 2)
            {
                GridView2.DataSource = LogicaSolicitudTramite.ListarSolicitudAnulada(nom, cod);
                GridView2.DataBind();
            }
        }
        catch (Exception ex)
        {
            GridView2.Visible = false;
            lblError.Visible = true;
            lblError.Text = ex.Message;
        }
        

    }
}