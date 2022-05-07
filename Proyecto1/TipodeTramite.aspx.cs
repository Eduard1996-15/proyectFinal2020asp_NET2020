using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades_Compartidas;
using Logica;
using Persistencia;

public partial class TipodeTramite : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnAgregar.Visible = false;
            btnEliminar.Visible = false;
            btnModificar.Visible = false;
            lblError.Visible = false;
            lblMsg.Visible = false;
            this.DesactivarLista();
            this.Limpiarlista();
            #region cargo entidades
            List<Entidades> ent = LogicaEntidades.CargoEntidad();
            List<string> entidades = new List<string>();
            foreach (Entidades entidad in ent)
            {
                entidades.Add(entidad.Nombre);
            }
            ddlEntidades.DataSource = entidades;
            ddlEntidades.DataBind();
            #endregion
        }
    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        this.Limpiarlista();
        this.DesactivarLista();
        btnAgregar.Visible = false;
        btnModificar.Visible = false;
        btnEliminar.Visible = false;
        lblMsg.Visible = false;
        int code = 0;
        string nombre = ddlEntidades.SelectedValue.ToString();
        try
        {
            if (txtCodeTramite.Text.Length == 0)
            {
                throw new Exception("El codigo no puede estar vacio");
            }
            else if (txtCodeTramite.Text.Length > 6)
            {
                throw new Exception("El codigo no puede ser de mas de 6 digitos");
            }
            else
            {
                try
                {
                    code = Convert.ToInt32(txtCodeTramite.Text);
                }
                catch
                {
                    throw new Exception("El codigo no puede estar compuesto por letras");
                }
                if (nombre.Length == 0)
                {
                    throw new Exception("El nombre no puede estar vacio");
                }
                Entidades ent = LogicaEntidades.Buscar(nombre);
                if (ent == null)
                {
                    throw new Exception("Esta entidad no existe");
                }
                else
                {
                    Tramite tram = LogicaTramites.Buscar(code, nombre);
                    if (tram == null)
                    {
                        lblError.Visible = false;
                        lblMsg.Visible = true;
                        lblMsg.Text = "Tramite no encontrado, que desea realizar?";
                        btnAgregar.Visible = true;
                    }
                    else
                    {
                        btnAgregar.Visible = false;
                        lblError.Visible = false;
                        lblMsg.Visible = true;
                        lblMsg.Text = "Tramite encontrado, que desea realizar?";
                        btnModificar.Visible = true;
                        btnEliminar.Visible = true;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblError.Visible = true;
            lblError.Text = ex.Message;
        }
    }
    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        this.ActivarLista();
        btnAdd.Visible = true;
        txtCodigo.Text = txtCodeTramite.Text;
        txtCodigo.Enabled = false;
        txtEntidad.Text = ddlEntidades.SelectedValue.ToString();
        txtEntidad.Enabled = false;
        btnAgregar.Visible = false;
        btnBorrar.Visible = false;
        btnMod.Visible = false;
        lblMsg.Text = "Agregue el nuevo tramite";
    }
    private void DesactivarLista()
    {
        lblNombreTramite.Visible = false;
        lblCodigo.Visible = false;
        lblEntidad.Visible = false;
        lblDescripcion.Visible = false;
        txtNombreTram.Visible = false;
        txtCodigo.Visible = false;
        txtEntidad.Visible = false;
        txtDescripcion.Visible = false;
        btnAdd.Visible = false;
        btnBorrar.Visible = false;
        btnMod.Visible = false;
    }
    private void ActivarLista()
    {
        lblNombreTramite.Visible = true;
        lblCodigo.Visible = true;
        lblEntidad.Visible = true;
        lblDescripcion.Visible = true;
        txtNombreTram.Visible = true;
        txtCodigo.Visible = true;
        txtEntidad.Visible = true;
        txtDescripcion.Visible = true;     
    }
    private void Limpiarlista()
    {
        txtNombreTram.Text = String.Empty;
        txtCodigo.Text = String.Empty;
        txtEntidad.Text = String.Empty;
        txtDescripcion.Text = String.Empty;
        txtDescripcion.Enabled = true;
        txtEntidad.Enabled = true;
        txtCodigo.Enabled = true;
        txtNombreTram.Enabled = true;
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            string nombre_entidad = ddlEntidades.SelectedValue.ToString();
            int codigo = Convert.ToInt32(txtCodigo.Text);
            string descripcion = txtDescripcion.Text;
            string nombre_tramite = txtNombreTram.Text;
            if (nombre_tramite.Trim() == "")
            {
                throw new Exception("El nombre del tramite no puede estar vacio");
            }
            if (descripcion.Trim() == "")
            {
                throw new Exception("La descripcion no puede estar vacia");
            }
            else
            {
                Entidades unae = new Entidades(null, nombre_entidad, null);
                Tramite tram = new Tramite(descripcion, nombre_tramite, unae, codigo);
                LogicaTramites.Agregar(tram, codigo, unae);
                lblError.Visible = true;
                lblError.Text = "Tramite agregado con exito";
                lblMsg.Visible = false;
                this.DesactivarLista();
                btnAdd.Visible = false;
                txtCodeTramite.Text = String.Empty;
            }
        }
        catch (Exception ex)
        {
            lblError.Visible = true;
            lblError.Text = ex.Message;
        }
    }
    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        this.ActivarLista();
        try
        {
            txtEntidad.Text = ddlEntidades.SelectedValue.ToString();
            int codigo = Convert.ToInt32(txtCodeTramite.Text);
            string entidad = txtEntidad.Text;
            Tramite tram = LogicaTramites.Buscar(codigo, entidad);
            txtNombreTram.Text = tram.Nombre_Tramite;
            txtDescripcion.Text = tram.Descripcion;
            txtCodigo.Text = txtCodeTramite.Text;
        }
        catch (Exception ex)
        {
            lblError.Visible = true;
            lblError.Text = ex.Message;
        }
        txtNombreTram.Enabled = false;
        txtCodigo.Enabled = false;
        txtEntidad.Enabled = false;
        txtDescripcion.Enabled = false;
        btnBorrar.Visible = true;
        btnModificar.Visible = false;
        btnEliminar.Visible = false;
        txtCodeTramite.Text = String.Empty;
     //   txtNombreEntidad.Text = String.Empty;
        lblMsg.Visible = false;
    }
    protected void btnModificar_Click(object sender, EventArgs e)
    {
        this.ActivarLista();
        btnBorrar.Visible = false;
        btnAdd.Visible = false;
        txtCodigo.Text = txtCodeTramite.Text;
        txtCodigo.Enabled = false;
        txtEntidad.Text = ddlEntidades.SelectedValue.ToString();
        txtEntidad.Enabled = false;
        try
        {
            int codigo = Convert.ToInt32(txtCodeTramite.Text);
            string entidad = txtEntidad.Text;
            Entidades ent = new Entidades(null, entidad, null);
            Tramite tram = LogicaTramites.Buscar(codigo, entidad);
            txtNombreTram.Text = tram.Nombre_Tramite;
            txtDescripcion.Text = tram.Descripcion;
            txtCodigo.Text = txtCodeTramite.Text;
        }
        catch (Exception ex)
        {
            lblError.Visible = true;
            lblError.Text = ex.Message;
        }
        lblMsg.Text = "Modifique los datos del tramite";
        btnModificar.Visible = false;
        btnEliminar.Visible = false;
        btnMod.Visible = true;
        txtCodeTramite.Text = String.Empty;
     //   txtNombreEntidad.Text = String.Empty;
        lblMsg.Visible = false;
    }
    protected void btnBorrar_Click(object sender, EventArgs e)
    {
        try
        {
            string nombre_entidad = txtEntidad.Text;
            int codigo = Convert.ToInt32(txtCodigo.Text);
            string descripcion = txtDescripcion.Text;
            string nombre_tramite = txtNombreTram.Text;
            LogicaTramites.Eliminar(codigo);
            lblError.Visible = true;
            lblError.Text = "Tramite eliminado con exito";
            this.DesactivarLista();
        }
        catch (Exception ex)
        {
            lblError.Visible = true;
            lblError.Text = ex.Message;
        }
    }
    protected void btnMod_Click(object sender, EventArgs e)
    {
        try
        {
            string nombre_entidad = txtEntidad.Text;
            int codigo = Convert.ToInt32(txtCodigo.Text);
            string descripcion = txtDescripcion.Text;
            string nombre_tramite = txtNombreTram.Text;
            if (nombre_tramite.Trim() == "")
            {
                throw new Exception("El nombre del tramite no puede estar vacio");
            }
            if (descripcion.Trim() == "")
            {
                throw new Exception("La descripcion no puede estar vacia");
            }
            Entidades unae = new Entidades(null, nombre_entidad, null);
            Tramite tram = new Tramite(descripcion, nombre_tramite, unae, codigo);
            LogicaTramites.Modificar(tram, unae, codigo);
            lblError.Visible = true;
            lblError.Text = "Tramite modificado con exito";
            this.DesactivarLista();
        }
        catch (Exception ex)
        {
            lblError.Visible = true;
            lblError.Text = ex.Message;
        }
    }
}