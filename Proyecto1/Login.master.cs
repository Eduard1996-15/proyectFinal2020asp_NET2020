using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades_Compartidas;
using Persistencia;
using Logica;

public partial class Login : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
            int ci = (int)Session["CI"];
            try
            {
                Usuario usuario = LogicaUsuario.Buscar(ci);
                string nombre = usuario.Nombre;
                Session["nombre"] = nombre;
                lblNombre.Text = nombre;
                lblError.Visible = false;
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
            }
        }
    }

