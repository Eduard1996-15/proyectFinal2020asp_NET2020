using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Entidades_Compartidas;


public partial class ConsultaEstSolicitud : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblError.Visible = false;
        lblEstado.Text = String.Empty;
        lblText.Visible = false;
    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        lblError.Visible = false;
        if (txtCodigo.Text.Trim().Count() == 0)
        {
            lblError.Visible = true;
            lblError.Text = "Ingrese un codigo para realizar la busqueda por favor";
        }
        else
        {
            try
            {
              int id = Convert.ToInt32(txtCodigo.Text);
              SolicitudTramite s = LogicaSolicitudTramite.BuscarEstado(id);
              if (s.Estado == null)
                {
                    lblError.Visible = true;
                    lblError.Text = "No hay Solicitud con este codigo";
                }
             else
                {
                    lblError.Visible = false;
                    lblText.Visible = true;
                    lblEstado.Text = Convert.ToString(s.Estado);
                }

            }
            catch
            {
                lblError.Visible = true;
                lblError.Text = "Solo se pueden ingresar numeros";
            }
        }
    }
}
