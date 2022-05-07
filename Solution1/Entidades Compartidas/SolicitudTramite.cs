using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades_Compartidas
{
    public class SolicitudTramite
    {
        int id;
        DateTime fecha_hora;
        Usuario empleado;
        Tramite nomTramite;
        Entidades nomEnt;
        string estado;
        string nomCliente;
        public Tramite Nombretramite
        {
            set
            {
                nomTramite = value;
            }
            get
            {
                return nomTramite;
            }
        }
        public Entidades NombreEntidad
        {
            set
            {
                nomEnt = value;
            }
            get
            {
                return nomEnt;
            }
        }
        public string NombreCliente
        {
            get { return nomCliente; }
            set { nomCliente = value; }
        }
        public int Codigo_Tramite
        {
            get { return id; }
            set { id = value; }
        }
        public Usuario Empleado
        {
            get { return empleado; }
            set { empleado = value; }
        }
        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        public DateTime Fecha_Hora
        {
            get { return fecha_hora; }
            set { fecha_hora = value; }
        }
        public string DatosEntidad
        {
            get { return NombreEntidad.Nombre; }
        }
        public string NombreEmpleado
        {
            get { return Empleado.Nombre; }
        }
        public SolicitudTramite(int pId, DateTime pFecha_hora, Usuario pUsu, Tramite ptramite, Entidades pnomEntidad, string pestado, string pnomc)
        {
            Codigo_Tramite = pId;
            Empleado = pUsu;
            Fecha_Hora = pFecha_hora;
            Nombretramite = ptramite;
            NombreEntidad = pnomEntidad;
            Estado = pestado;
            NombreCliente = pnomc;

        }
    }
}
