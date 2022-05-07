using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Entidades_Compartidas;

public partial class Inicio : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["Usuario"] = null;
        if (!IsPostBack)
        {
            GVentidades.Visible = true;
            GVtramite.Visible = false;
            lbltramites.Visible = false;
            lblentidades.Text = "ENTIDADES PUBLICAS";
            GVentidades.DataSource = LogicaEntidades.CargoEntidad();
            GVentidades.DataBind();
            lstTelefonos.Visible = false;
            lblMensaje.Visible = false;
        }
    }
    protected void GVEntidades_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Ver")
        {
            try
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GVentidades.Rows[rowIndex];
                string entidad = Convert.ToString(row.Cells[1].Text);
                Entidades ent = LogicaEntidades.Buscar(entidad);
                lstTelefonos.Visible = true;
                #region cargo telefonos
                List<Telefonos> tels = LogicaEntidades.CargoTelefonos(ent);
                List<int> telefonos = new List<int>();
                foreach (Telefonos tel in tels)
                {
                    telefonos.Add(tel.Numero);
                }
                
                #endregion
                if (telefonos.Count == 0)
                {
                    lstTelefonos.Visible = false;
                    lblMensaje.Visible = true;
                    lblMensaje.Text = "La entidad no tiene telefonos asociados";
                }
                else
                {
                    lblMensaje.Visible = true;
                    lblMensaje.Text = "Los telefonos de la entidad " + entidad + " son: ";
                    lstTelefonos.DataSource = telefonos;
                    lstTelefonos.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblerror.Visible = true;
                lblerror.Text = ex.Message;
            }
        }
        if (e.CommandName == "Seleccionar")
        {
            GVentidades.Visible = true;
            GVtramite.Visible = true;
            GVtramite.DataSource = null;
            GVtramite.DataBind();
            lblerror.Text = String.Empty;
            lblentidades.Visible = false;
            lstTelefonos.Visible = false;
            lblMensaje.Visible = false;
            lbltramites.Visible = true;
            lbltramites.Text = "TRAMITES DE ESTA ENTIDAD ";
            try
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GVentidades.Rows[rowIndex];
                string no = Convert.ToString(row.Cells[1].Text);
                Entidades en = LogicaEntidades.Buscar(no);
                Tramite t = LogicaTramites.BuscarxNombre(en);
                if (t == null)
                {
                    lblerror.Text = "No hay tramites";
                }
                else
                {
                    GVtramite.DataSource = LogicaTramites.ListaTramitexNombreEnt(en);
                    GVtramite.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblerror.Visible = true;
                lblerror.Text = ex.Message;
            }
        }
    }
    /*protected void GVEntidades_SelectedIndexChanged(object sender, EventArgs e)
    {
        GVentidades.Visible = true;
        GVtramite.Visible = true;
        GVtramite.DataSource = null;
        GVtramite.DataBind();
        lblerror.Text = String.Empty;
        lblentidades.Visible = false;
        lstTelefonos.Visible = false;
        lblMensaje.Visible = false;
        lbltramites.Text = "TRAMITES DE ESTA ENTIDAD ";
        try
        {
            string no = Convert.ToString(GVentidades.SelectedRow.Cells[1].Text);
            Entidades en = LogicaEntidades.Buscar(no);
            Tramite t = LogicaTramites.BuscarxNombre(en);
            if (t == null)
            {
                lblerror.Text = "No hay tramites";
            }
            else
            {
                GVtramite.DataSource = LogicaTramites.ListaTramitexNombreEnt(en);
                GVtramite.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblerror.Visible = true;
            lblerror.Text = ex.Message;
        }
    }
     */
}