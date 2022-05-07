using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Entidades_Compartidas;

public partial class RegistrarSolicitud : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            btnAgregar.Visible = false;
            lblError.Visible = false;
            lblNomCli.Visible = false;
            lblFecha.Visible = false;
            lblMinuto.Visible = false;
            lblHora.Visible = false;
            fecha1.Visible = false;
            ddlHora.Visible = false;
            ddlMinuto.Visible = false;
            lblNomTram.Visible = false;
            lblCodigo.Visible = false;
            lblDescripcion.Visible = false;
            lblNomEntidad.Visible = false;
            lblNombEmpleado.Visible = false;
            txtCodigo.Visible = false;
            txtNomEntidad.Visible = false;
            txtDescripcion.Visible = false;
            txtNomTram.Visible = false;
            txtEmpleado.Visible = false;
            txtNomCliente.Visible = false;
            ddlMinuto.Items.Clear();
            lblError.Text = String.Empty;
            ddlHora.Items.Clear();
            try
            {
                IList<Tramite> tramite = LogicaTramites.CargoTramite();
                var tramiteordenado = tramite.OrderBy(x => x.Nombre_Tramite);
                if (tramite == null)
                {
                    lblError.Visible = true;
                    throw new Exception("No hay tramites disponibles");
                    grdListaTramite.Visible = false;
                }
                else
                {
                    grdListaTramite.DataSource = tramiteordenado;
                    grdListaTramite.DataBind();           
                }
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
            }
        }
    }
    protected void grdListaTramite_SelectedIndexChanged(object sender, EventArgs e)
    {
        #region ddlhora
        List<int> hora = new List<int>();
        for (int i = 00; i <= 23; i++)
        {
            hora.Add(i);
        }
        ddlHora.DataSource = hora;
        ddlHora.DataBind();
        #endregion
        #region ddlminutos
        List<int> minutos = new List<int>();
        for (int i = 00; i <= 59; i++)
        {
            minutos.Add(i);
        }
        ddlMinuto.DataSource = minutos;
        ddlMinuto.DataBind();
        #endregion
        lblError.Text = String.Empty;
        txtNomCliente.Text = String.Empty;
        fecha1.SelectedDates.Clear();
        try
        {
            int codigo = Convert.ToInt32(grdListaTramite.SelectedRow.Cells[3].Text);
            string entidad = Convert.ToString(grdListaTramite.SelectedRow.Cells[1].Text);
            string tramite = Convert.ToString(grdListaTramite.SelectedRow.Cells[0].Text);
            string empleado = (string)Session["nombre"];
            txtEmpleado.Text = empleado;
            txtEmpleado.Enabled = false;
            this.Activo();
            Tramite tram = LogicaTramites.Buscar(codigo, entidad);
            txtNomTram.Text = tramite;
            txtCodigo.Text = Convert.ToString(codigo);
            txtDescripcion.Text = tram.Descripcion;
            txtNomEntidad.Text = entidad;
            txtCodigo.Enabled = false;
            txtDescripcion.Enabled = false;
            txtNomEntidad.Enabled = false;
            txtNomTram.Enabled = false;
        }
        catch (Exception ex)
        {
            lblError.Visible = true;
            lblError.Text = ex.Message;
        }
    }
    private void Activo()
    {
        lblFecha.Visible = true;
        lblMinuto.Visible = true;
        fecha1.Visible = true;
        ddlHora.Visible = true;
        lblHora.Visible = true;
        ddlMinuto.Visible = true;
        lblNomTram.Visible = true;
        lblCodigo.Visible = true;
        lblDescripcion.Visible = true;
        lblNomEntidad.Visible = true;
        lblNombEmpleado.Visible = true;
        txtEmpleado.Visible = true;
        txtCodigo.Visible = true;
        txtNomEntidad.Visible = true;
        txtDescripcion.Visible = true;
        txtNomTram.Visible = true;
        lblNomCli.Visible = true;
        txtNomCliente.Visible = true;
        btnAgregar.Visible = true;
    }
    private void Desactivo()
    {
        lblFecha.Visible = false;
        lblMinuto.Visible = false;
        fecha1.Visible = false;
        ddlHora.Visible = false;
        lblHora.Visible = false;
        ddlMinuto.Visible = false;
        lblNomTram.Visible = false;
        lblCodigo.Visible = false;
        lblDescripcion.Visible = false;
        lblNomEntidad.Visible = false;
        lblNombEmpleado.Visible = false;
        txtEmpleado.Visible = false;
        txtCodigo.Visible = false;
        txtNomEntidad.Visible = false;
        txtDescripcion.Visible = false;
        txtNomTram.Visible = false;
        lblNomCli.Visible = false;
        txtNomCliente.Visible = false;
        btnAgregar.Visible = false;
    }
    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        try
        {
            if (fecha1.SelectedDate < DateTime.Now)
            {
                throw new Exception("No puede seleccionar una fecha anterior a la actual");
            }
            DateTime fecha = fecha1.SelectedDate;
            int seg = 0;
            {
                TimeSpan hora = new TimeSpan(Convert.ToInt32(ddlHora.Text), Convert.ToInt32(ddlMinuto.Text), seg);
                fecha = fecha.Date + hora;
                int ci = (int)Session["CI"];
                Entidades ent = new Entidades(null, txtNomEntidad.Text, null);
                Tramite tramite = new Tramite(null, (txtNomTram.Text), ent, (Convert.ToInt32(txtCodigo.Text)));
                Usuario usu = new Usuario((txtEmpleado.Text), null, ci);
                string cliente = txtNomCliente.Text;
                if (cliente.Trim() == "")
                {
                    throw new Exception("Debe agregar el nombre de quien solicita");
                }
                else
                {
                    string estado = "ALTA";
                    SolicitudTramite solicitud = new SolicitudTramite((Convert.ToInt32(txtCodigo.Text)), fecha, usu, tramite, ent, estado, cliente);
                    int num = LogicaSolicitudTramite.AgregarSolicitudTramite(solicitud);
                    this.Desactivo();
                    lblError.Visible = true;
                    lblError.Text = "Solicitud agregada con exito, su numero de solicitud es: " + num;
                }
            }
        }
        catch (Exception ex)
        {
            lblError.Visible = true;
            lblError.Text = ex.Message;
        }
    }            
}