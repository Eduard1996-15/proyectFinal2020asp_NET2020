using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades_Compartidas
{
    public class Tramite
    {
        string descripcion;
        string nombre_tramite;
        Entidades nombre;
        int codigo;
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        public string Nombre_Tramite
        {
            get { return nombre_tramite; }
            set { nombre_tramite = value;}
        }
        public Entidades NombreEntidad
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public int Codigo
        {
            get { return codigo; }
            set
            {
                if (Convert.ToString(value).Length > 6)
                    throw new Exception("El codigo puede ser de hasta 6 caracteres");
                else
                    codigo = value;
            }
        }
        public Tramite(string pDescripcion, string pNombre_tramite, Entidades pNombre, int pCodigo)
        {
            Codigo = pCodigo;
            Descripcion = pDescripcion;
            Nombre_Tramite = pNombre_tramite;
            NombreEntidad = pNombre;
        }
    }
}
