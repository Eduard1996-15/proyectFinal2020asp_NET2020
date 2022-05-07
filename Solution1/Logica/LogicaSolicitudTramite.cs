using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades_Compartidas;
using Persistencia;

namespace Logica
{
    public class LogicaSolicitudTramite
    {
        public static SolicitudTramite BuscarEstado(int id)
        {
            return PersistenciaSolicitudTramite.BuscarEstado(id);
        }
        public static int AgregarSolicitudTramite(SolicitudTramite pSolicitud)
        {
            return PersistenciaSolicitudTramite.AgregarSolicitudTramite((SolicitudTramite)pSolicitud);
        }
        public static List<SolicitudTramite> ListarSolicitudxFecha(DateTime fechai, DateTime fechaf)
        {
            return PersistenciaSolicitudTramite.ListarSolicitudxFecha(fechai, fechaf);
        }
        public static List<SolicitudTramite> ListarSolicitudAlta()
        {
            return PersistenciaSolicitudTramite.ListarSolicitudAlta();
        }
        public static void ModificarEstadoSolicitud(int id, string estado)
        {
            PersistenciaSolicitudTramite.ModificarEstadoSolicitud(id, estado);
        }
        public static List<SolicitudTramite> ListarSolicitudAnulada(string nombre, int cod)
        {
            return PersistenciaSolicitudTramite.ListarSolicitudAnulada(nombre, cod);
        }
        public static List<SolicitudTramite> ListarSolicitudejecutada(string nombre, int cod)
        {
            return PersistenciaSolicitudTramite.ListarSolicitudEjecutada(nombre, cod);
        }
        public static List<SolicitudTramite> ListarSolicitudes(string nombre, int cod)
        {
            return PersistenciaSolicitudTramite.ListarSolicitudes(nombre, cod);
        }
        public static SolicitudTramite BuscarEmpleadoEnTramite(int pCedula)
        {
            SolicitudTramite p = PersistenciaSolicitudTramite.BuscarEmpleadoEnTramite(pCedula);
            return p;
        }
    }
}
