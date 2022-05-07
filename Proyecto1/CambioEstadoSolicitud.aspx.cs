using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Entidades_Compartidas;

public partial class EstadoSolicitud : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblError.Visible = false;
        this.CargoGrilla();
    }
    protected void GVsolicitudes_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Anulada")
        {
            try
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GVsolicitudes.Rows[rowIndex];
            int id = Convert.ToInt32(row.Cells[1].Text);
            string estado = "ANULADA";
            LogicaSolicitudTramite.ModificarEstadoSolicitud(id, estado);
            lblError.Visible = true;
            lblError.Text = "Solicitud actualizada a ANULADA con exito";
        }
        catch (Exception ex)
        {
            lblError.Visible = true;
            lblError.Text = ex.Message;
        }    
        }
        if (e.CommandName == "Ejecutada")
        {
            try
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GVsolicitudes.Rows[rowIndex];
            int id = Convert.ToInt32(row.Cells[1].Text);
            string estado = "EJECUTADA";
            LogicaSolicitudTramite.ModificarEstadoSolicitud(id, estado);
            lblError.Visible = true;
            lblError.Text = "Solicitud actualizada a EJECUTADA con exito";
        }
        catch (Exception ex)
        {
            lblError.Visible = true;
            lblError.Text = ex.Message;
        }
        }
        this.CargoGrilla();
    }
    private void CargoGrilla()
    {
        try
        {
            GVsolicitudes.DataSource = LogicaSolicitudTramite.ListarSolicitudAlta();
            if (GVsolicitudes.DataSource == null)
            {
                throw new Exception("No hay solicitudes de tramite realizadas");
            }
            GVsolicitudes.DataBind();
        }
        catch (Exception ex)
        {
            lblError.Visible = true;
            lblError.Text = ex.Message;
        }
    }
}