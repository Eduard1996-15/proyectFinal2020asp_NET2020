using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades_Compartidas;
using Logica;
using Persistencia;

public partial class Empleados : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblError.Text = String.Empty; 
        if (!IsPostBack)
        {
            this.Desactivar();
        }
    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        int ci = 0;
        string nombre = (string)Session["nombre"];
        try
        {
            ci = Convert.ToInt32(txtCI.Text);
            if (Convert.ToString(ci).Length != 7)
            {
                throw new Exception("La CI debe contener 7 digitos");
            }
            if (txtCI.Text.Trim().Count() == 0)
            {
                throw new Exception("El campo cedula no puede estar vacio");
            }
            else
            {
                Usuario usuario = LogicaUsuario.Buscar(ci);
                if (usuario == null)
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Empleado no encontrado, que desea realizar?";
                    btnAgregar.Visible = true;
                }
                else
                {
                    SolicitudTramite usu = LogicaSolicitudTramite.BuscarEmpleadoEnTramite(ci);
                    if (usu != null)
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "Empleado encontrado pero con solicitudes asociadas, no se puede eliminar pero si modificar";
                        btnModificar.Visible = true;
                        btnEliminar.Visible = false;
                    }
                    else
                    {

                        lblMsg.Visible = true;
                        lblMsg.Text = "Empleado encontrado, que desea realizar?";
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
    private void Desactivar()
    {
        lblAviso.Visible = false;
        lblMsg.Visible = false;
        lblError.Visible = false;
        txtCedula.Visible = false;
        txtContraseña.Visible = false;
        txtNombre.Visible = false;
        btnAgregar.Visible = false;
        btnModificar.Visible = false;
        btnEliminar.Visible = false;
        btnDelete.Visible = false;
        lblCi.Visible = false;
        lblContraseña.Visible = false;
        lblNombre.Visible = false;
        btnGuardar.Visible = false;
        btnGuardarMOD.Visible = false;
    }
    private void ActivarAgg()
    {
        lblAviso.Visible = true;
        lblError.Visible = true;
        txtCedula.Visible = true;
        txtContraseña.Visible = true;
        txtNombre.Visible = true;
        btnModificar.Visible = false;
        btnEliminar.Visible = false;
        btnDelete.Visible = false;
        btnGuardarMOD.Visible = false;
        lblCi.Visible = true;
        lblContraseña.Visible = true;
        lblNombre.Visible = true;
        btnGuardar.Visible = true;
    }
    private void ModyDelete()
    {
        lblError.Visible = true;
        txtCedula.Visible = true;
        txtContraseña.Visible = true;
        txtNombre.Visible = true;
        btnAgregar.Visible = false;
        btnModificar.Visible = true;
        btnEliminar.Visible = true;
        lblCi.Visible = true;
        lblContraseña.Visible = true;
        lblNombre.Visible = true;
        btnGuardarMOD.Visible = true;
        btnGuardar.Visible = false;
    }
    private void Limpio()
    {
        btnGuardarMOD.Visible = false;
        txtCI.Enabled = true;
        txtCI.Text = String.Empty;
        lblMsg.Visible = false;
        txtCedula.Visible = false;
        txtContraseña.Visible = false;
        txtNombre.Visible = false;
        txtCedula.Text = String.Empty;
        txtNombre.Text = String.Empty;
        txtContraseña.Text = String.Empty;
        btnAgregar.Visible = false;
        btnModificar.Visible = false;
        btnEliminar.Visible = false;
        btnDelete.Visible = false;
        lblCi.Visible = false;
        lblContraseña.Visible = false;
        lblNombre.Visible = false;
        btnGuardar.Visible = false;
    }
    protected void btnAgregar_Click1(object sender, EventArgs e)
    {
        this.ActivarAgg();
        txtCI.Enabled = false;
        btnAgregar.Visible = false;
        txtContraseña.Enabled = true;
        txtNombre.Enabled = true;
        txtCedula.Text = txtCI.Text;
        txtCedula.Enabled = false;
    }
    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        try
        {
            int cedula = Convert.ToInt32(txtCedula.Text);
            string password = txtContraseña.Text.Trim().ToLower();//convierto la contrasenia en minuscula antes de guardarla
            string nombre = txtNombre.Text;
            Usuario unUsu = new Usuario(nombre, password, cedula);
            if (password.Trim() == Convert.ToString(cedula).Trim())
            {
                lblError.Text ="La contraseña no puede ser igual a la cedula";
            }
            else
            {
                LogicaUsuario.Agregar(unUsu);
                lblError.Visible = true;
                lblError.Text = "Empleado agregado con exito";
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
        this.Limpio();
        lblAviso.Visible = false;
    }
    protected void btnModificar_Click(object sender, EventArgs e)
    {
        this.ModyDelete();
        lblAviso.Visible = true;
        lblMsg.Text = "Modifique la informacion del empleado";
        txtCI.Enabled = false;
        txtCedula.Text = txtCI.Text;
        try
        {
            Usuario usu = LogicaUsuario.Buscar(Convert.ToInt32(txtCedula.Text));
            txtNombre.Text = usu.Nombre;
        }
        catch (Exception ex)
        {
            lblError.Visible = true;
            lblError.Text = ex.Message;
        }
        lblAviso.Visible = false;
        txtNombre.Enabled = false;
        txtCedula.Enabled = false;
        btnModificar.Visible = false;
        btnEliminar.Visible = false;
    }
    protected void btnGuardarMOD_Click(object sender, EventArgs e)
    {
        try
        {
            int cedula = Convert.ToInt32(txtCedula.Text);
            string password = txtContraseña.Text.Trim().ToLower();
            string nombre = txtNombre.Text;
            Usuario unUsu = new Usuario(nombre, password, cedula);
            if (password.Trim() == Convert.ToString(cedula).Trim())
            {
                lblError.Text = "La contraseña no puede ser igual a la cedula";
            }
            else
            {
                LogicaUsuario.Modificar(unUsu);
                lblError.Visible = true;
                lblError.Text = "Empleado modificado con exito";
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
        this.Limpio();
    }
    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            this.ActivarAgg();
            btnDelete.Visible = true;
            int cedula = Convert.ToInt32(txtCI.Text);
            Usuario usu = LogicaUsuario.Buscar(cedula);
            txtCedula.Text = Convert.ToString(cedula);
            txtNombre.Text = usu.Nombre;
            txtContraseña.Text = usu.Password;
            txtContraseña.Enabled = false;
            txtNombre.Enabled = false;
            txtCI.Enabled = false;
            txtCedula.Enabled = false;
            btnGuardar.Visible = false;
        }
        catch(Exception ex)
        {
            lblError.Visible = true;
            lblError.Text = ex.Message;
        }
        
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            int cedula = Convert.ToInt32(txtCI.Text);
            LogicaUsuario.Eliminar(cedula);
            lblError.Visible = true;
            lblError.Text = "Empleado eliminado con exito";
        }
        catch (Exception ex)
        {
            lblError.Visible = true;
            lblError.Text = ex.Message;
        }
        this.Limpio();
    }
}