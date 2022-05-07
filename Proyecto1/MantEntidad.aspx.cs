using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades_Compartidas;
using Logica;
using Persistencia;


public partial class MantEntidad : System.Web.UI.Page
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
        }
    }
    private void DesactivarLista()
    {
        lblDireccion.Visible = false;
        lblTelefono.Visible = false;    
        lblNombre.Visible = false;
        lblDireccion.Visible = false;
        txtNombreEnt.Visible = false;
        txtDireccion.Visible = false;
        txtTelefono.Visible = false;
        btnGuardar.Visible = false;
        btnDeleteTel.Visible = false;
        btnAggTel.Visible = false;
        listTelefonos.Visible = false;
        btnDelete.Visible = false;
        btnMod.Visible = false;
    }
    private void ActivarLista()
    {
        listTelefonos.Visible = true;
        lblDireccion.Visible = true;
        lblTelefono.Visible = true;
        lblNombre.Visible = true;
        lblDireccion.Visible = true;
        txtNombreEnt.Visible = true;
        txtDireccion.Visible = true;
        txtTelefono.Visible = true;
        btnGuardar.Visible = true;
        btnAggTel.Visible = true;
        btnDelete.Visible = true;
        btnMod.Visible = true;
    }
    private void Limpiarlista()
    {
        txtNombreEnt.Text = String.Empty;
        txtDireccion.Text = String.Empty;
        txtDireccion.Enabled = true;
        txtNombreEnt.Enabled = true;
    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        this.Limpiarlista();
        this.DesactivarLista();
        btnAgregar.Visible = false;
        btnModificar.Visible = false;
        btnEliminar.Visible = false;
        lblMsg.Visible = false;
        listTelefonos.Items.Clear();
        string nombreent = txtNombreEntidad.Text;
        try
        {
            if (txtNombreEntidad.Text.Length == 0)
            {
                throw new Exception("Este campo no puede estar vacio");
            }
            Entidades ent = LogicaEntidades.Buscar(nombreent);
            if (ent == null)
            {
                lblError.Visible = false;
                lblMsg.Visible = true;
                lblMsg.Text = "Entidad no encontrada, que desea realizar?";
                btnAgregar.Visible = true;
            }
            else
            {
                btnAgregar.Visible = false;
                lblError.Visible = false;
                lblMsg.Visible = true;
                lblMsg.Text = "Entidad encontrada, que desea realizar?";
                btnModificar.Visible = true;
                btnEliminar.Visible = true;
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
        btnGuardar.Visible = true;
        txtNombreEnt.Text = txtNombreEntidad.Text;
        txtNombreEnt.Enabled = false;
        txtTelefono.Enabled = true;
        btnAgregar.Visible = false;
        btnDeleteTel.Visible = true;
        btnDelete.Visible = false;
        btnMod.Visible = false;
        lblMsg.Visible = true;
        lblMsg.Text = "Agregue la nueva entidad";
    }
    protected void btnModificar_Click(object sender, EventArgs e)
    {
        this.ActivarLista();
        btnDeleteTel.Visible = true;
        btnGuardar.Visible = true;
        btnEliminar.Visible = false;
        btnDelete.Visible = false;
        btnGuardar.Visible = false;
        btnModificar.Visible = false;
        
        try
        {
            Entidades ent = LogicaEntidades.Buscar(txtNombreEntidad.Text);
            txtNombreEnt.Text = ent.Nombre;
            txtDireccion.Text = ent.Direccion;
            txtNombreEnt.Enabled = false;
            txtTelefono.Enabled = true;
            #region cargo telefonos para modificar
            List<Telefonos> tels = LogicaEntidades.CargoTelefonos(ent);
            List<int> telefonos = new List<int>();
            foreach (Telefonos tel in tels)
            {
                telefonos.Add(tel.Numero);
            }
            listTelefonos.DataSource = telefonos;
            listTelefonos.DataBind();
            #endregion
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
        btnMod.Visible = false;
        btnGuardar.Visible = false;
        txtNombreEnt.Text = txtNombreEntidad.Text;
        btnDelete.Visible = true;
        try
        {
            Entidades ent = LogicaEntidades.Buscar(txtNombreEntidad.Text);
            txtNombreEnt.Text = ent.Nombre;
            txtDireccion.Text = ent.Direccion;
            txtTelefono.Enabled = false;
            txtNombreEnt.Enabled = false;
            txtDireccion.Enabled = false;
            btnDeleteTel.Visible = false;
            btnAggTel.Visible = false;
            #region cargo telefonos
            List<Telefonos> tels = LogicaEntidades.CargoTelefonos(ent);
            List<int> telefonos = new List<int>();
            foreach (Telefonos tel in tels)
            {
                telefonos.Add(tel.Numero);
            }
            listTelefonos.DataSource = telefonos;
            listTelefonos.DataBind();
            listTelefonos.Enabled = false;
            #endregion
        }
        catch (Exception ex)
        {
            lblError.Visible = true;
            lblError.Text = ex.Message;
        }
    }
    protected void btnAggTel_Click(object sender, EventArgs e)
    {
        lblError.Text = String.Empty;
        int tele = Convert.ToInt32(txtTelefono.Text);
        if ((Convert.ToString(tele).Length) == 8 || (Convert.ToString(tele).Length) == 9)
        {
            lblMsg.Visible = false;
            try
            {
                int listatelefonos = Convert.ToInt32(txtTelefono.Text);
                ListItem telefonos = new ListItem(Convert.ToString(listatelefonos));
                if (listTelefonos.Items.Contains(telefonos))
                {
                    lblError.Visible = true;
                    lblError.Text = "El telefono esta repetido";
                    txtTelefono.Text = String.Empty;
                }
                else
                {
                    listTelefonos.Items.Add(telefonos);
                    txtTelefono.Text = String.Empty;
                }
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
            }
        }
        else
        {
            lblError.Visible = true;
            lblError.Text = "El telefono puede tener 7 u 8 caracteres";      
        }
    }
    protected void btnDeleteTel_Click(object sender, EventArgs e)
    {
        lblMsg.Visible = false;
        try
        {
            string telefono = listTelefonos.SelectedItem.Text;
            ListItem telefonos = new ListItem(telefono);
            listTelefonos.Items.Remove(telefonos);
        }
        catch (Exception ex)
        {
            lblError.Visible = true;
            lblError.Text = ex.Message;
        }
    }
    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        lblMsg.Visible = false;
        lblError.Text = String.Empty;
        try
        {
            if (txtDireccion.Text.Length == 0)
            {
                throw new Exception("La direccion no puede estar vacia");
            }
            if (listTelefonos.Items.Count == 0)
            {
                throw new Exception("Debe ingresar al menos un telefono para esta entidad");
            }
            else
            {
                string nombre_entidad = txtNombreEnt.Text;
                
                string direccion = txtDireccion.Text;
                List<Telefonos> telefonos_entidad = new List<Telefonos>();
                List<int> tel = new List<int>();
                try
                {
                    #region cargo lista de telefonos
                    foreach (var telefono in listTelefonos.Items)
                    {
                        ListItem fono = new ListItem(Convert.ToString(telefono));
                        int tele = Convert.ToInt32(fono.Text);
                        tel.Add(tele);
                    }
                    foreach (int telefono in tel)
                    {
                        Telefonos tels = new Telefonos(telefono);
                        telefonos_entidad.Add(tels);
                    }
                    #endregion
                    Entidades ent = new Entidades(direccion, nombre_entidad, telefonos_entidad);
                    LogicaEntidades.Agregar(ent);
                    foreach (Telefonos telefonos in telefonos_entidad)
                    {
                        LogicaEntidades.AgregarTelefono(ent, telefonos);
                    }
                    lblMsg.Visible = true;
                    lblMsg.Text = "Entidad agregada con exito";
                    txtNombreEntidad.Text = String.Empty;
                    this.DesactivarLista();
                }
                catch (Exception ex)
                {
                    lblError.Visible = true;
                    lblError.Text = ex.Message;
                }
            }
        }
        catch (Exception ex)
        {
            lblError.Visible = true;
            lblError.Text = ex.Message;
        }  
        }
    protected void btnMod_Click(object sender, EventArgs e)
    {
        lblMsg.Visible = false;
        lblError.Text = String.Empty;
        try
        {
            if (txtDireccion.Text.Length == 0)
            {
                throw new Exception("La direccion no puede estar vacia");
            }
            if (listTelefonos.Items.Count == 0)
            {
                throw new Exception("Debe ingresar al menos un telefono para esta entidad");
            }
            else
            {
                string nombre_entidad = txtNombreEnt.Text;
                string direccion = txtDireccion.Text;
                List<Telefonos> telefonos_entidad = new List<Telefonos>();
                List<int> tel = new List<int>();
                try
                {
                 #region cargo lista de telefonos
            foreach (var telefono in listTelefonos.Items)
            {
                ListItem fono = new ListItem(Convert.ToString(telefono));
                int tele = Convert.ToInt32(fono.Text);
                tel.Add(tele);
            }
            foreach (int telefono in tel)
            {
                Telefonos tels = new Telefonos(telefono);
                telefonos_entidad.Add(tels);
            }
            #endregion
                 Entidades ent = new Entidades(direccion, nombre_entidad, telefonos_entidad);
                 LogicaEntidades.Modificar(ent);
                 foreach (Telefonos telefonos in telefonos_entidad)
                    {
                        LogicaEntidades.EliminarTelefono(ent, telefonos);
                    }
                    foreach (Telefonos telefonos in telefonos_entidad)
                    {
                        LogicaEntidades.AgregarTelefono(ent, telefonos);   
                    }
                    lblMsg.Visible = true;
                    lblMsg.Text = "Entidad modificada con exito";
                    txtNombreEntidad.Text = String.Empty;
                    this.DesactivarLista();
                 }
                catch (Exception ex)
                {
                    lblError.Visible = true;
                    lblError.Text = ex.Message;
                }
            }  
        }
        catch (Exception ex)
        {
            lblError.Visible = true;
            lblError.Text = ex.Message;
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            string nombre_entidad = txtNombreEnt.Text;
            LogicaEntidades.Eliminar(nombre_entidad);
            this.DesactivarLista();
            txtNombreEntidad.Text = String.Empty;
            btnModificar.Visible = false;
            btnEliminar.Visible = false;
            lblMsg.Visible = true;
            lblMsg.Text = "Entidad eliminada con exito";
        }
        catch (Exception ex)
        {
            lblMsg.Visible = false;
            btnModificar.Visible = false;
            btnEliminar.Visible = false;
            this.DesactivarLista();
            lblError.Visible = true;
            lblError.Text = ex.Message;
        }
    }
}


