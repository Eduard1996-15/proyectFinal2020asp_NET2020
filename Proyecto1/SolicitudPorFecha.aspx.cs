using System;
using System.Collections.Generic;
using System.Linq;
using Logica;
using Entidades_Compartidas;

public partial class SolicitudPorFecha : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblError.Visible = false;
    }
    protected void btnVer_Click(object sender, EventArgs e)
    {
        DateTime dt = new DateTime(01, 01, 0001);
        try
        {
            if (Calendar1.SelectedDate == dt)
            {
                throw new Exception("Usted no selecciono ninguna fecha en el calendario de la izquierda");
            }
            else if (Calendar2.SelectedDate == dt)
            {
                throw new Exception("Usted no selecciono ninguna fecha en el calendario de la derecha");
            }
            else if (Calendar1.SelectedDate > Calendar2.SelectedDate)
            {
                throw new Exception("La segunda fecha seleccionada no puede ser anterior a la primera");
            }
            else
            {
                IList<SolicitudTramite> sol_tramite = LogicaSolicitudTramite.ListarSolicitudxFecha(Calendar1.SelectedDate, Calendar2.SelectedDate);
                var sol_tramite_ordenado = sol_tramite.OrderBy(x => x.Fecha_Hora);
                GVSolicitudTramite.DataSource = sol_tramite_ordenado;
                GVSolicitudTramite.DataBind();
            }          
        }
        catch (Exception ex)
        {
            lblError.Visible = true;
            lblError.Text = ex.Message;
        }
    }
}