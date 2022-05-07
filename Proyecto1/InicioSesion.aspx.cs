using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades_Compartidas;
using Logica;
using Persistencia;

public partial class InicioSesion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblError.Visible = false;
    }
    protected void btnInicio_Click(object sender, EventArgs e)
    {
        int cedula = 0;
        try
        {
            if (txtContraseña.Text.Trim().Count() == 0)
            {
                throw new Exception("Debe ingresar una contraseña para iniciar sesion");
            }
            if (txtCedula.Text.Trim().Count() == 0)
            {
                throw new Exception("El campo cedula no puede estar vacio");
            }
            else
            {
                try
                {
                    cedula = Convert.ToInt32(txtCedula.Text.Trim());
                }
                catch
                {
                    lblError.Visible = true;
                    lblError.Text = "La cedula solo puede estar compuesta de numeros";
                }
                if (cedula != 0)
                {
                    string password = txtContraseña.Text.Trim().ToLower();
                    Usuario usu = new Usuario(null, password, cedula);
                    Usuario check = LogicaUsuario.Buscar(cedula);
                    if (check == null)
                    {
                        throw new Exception("La cedula no existe en nuestra base de datos");
                    }
                    else
                    {
                        Usuario usuario = LogicaUsuario.Login(usu);
                        Session["CI"] = cedula;
                        Response.Redirect("Bienvenida.aspx", false);
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

}