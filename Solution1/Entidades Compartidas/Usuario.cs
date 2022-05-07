using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades_Compartidas
{
    public class Usuario
    {
        int cedula;
        string password;
        string nombre;
        public int Cedula
        {
            get { return cedula; }
            set
            {
                if (Convert.ToString(value).Length != 7)
                    throw new Exception("La cedula debe ser de 7 digitos");
                else
                    cedula = value;
            }
        }
        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (value == " " || value == "")
                {
                    throw new Exception("\n\n\tEl nombre no puede ser vacio");
                }

                nombre = value;
            }
        }
        public string Password
        {
            get { return password; }
            set {
                if (value == " " || value == "")
                {
                    throw new Exception("\n\n\tEl nombre no puede ser vacio");
                }

                password = value;
            }
        }
        public Usuario(string pNombre, string pPassword, int pCedula)
        {
            Cedula = pCedula;
            Nombre = pNombre;
            Password = pPassword;
        }
    }
}

