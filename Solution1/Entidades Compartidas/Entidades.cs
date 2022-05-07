using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades_Compartidas
{
    public class Entidades
    {
        #region Atributos
        string direccion;
        string nombre;
        List<Telefonos> telefono;
        #endregion
        #region Propiedades
        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public List<Telefonos> Telefono
        {
            get { return telefono; }
            set
            {
                telefono = value;
            }
        }
        #endregion
        #region Constructores
        public Entidades(string pDireccion, string pNombre, List<Telefonos> pTelefono)
        {
            Direccion = pDireccion;
            Nombre = pNombre;
            telefono = new List<Telefonos>();
        }
        #endregion
    }
}
