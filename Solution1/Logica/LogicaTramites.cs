using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades_Compartidas;
using Persistencia;

namespace Logica
{
    public class LogicaTramites
    {
        public static Tramite Buscar(int pCodigo, string pNombreent)
        {
            Tramite tram = PersistenciaTramites.BuscarTramite(pCodigo, pNombreent);
            return tram;
        }
        public static Tramite BuscarxNombre(Entidades pEntidad)
        {
            Tramite tram = PersistenciaTramites.BuscarTramitexNombre(pEntidad);
            return tram;
        }       
        public static void Agregar(Tramite pTramite, int pCodigo , Entidades pNombreent)
        {
            PersistenciaTramites.AgregarTramite(pTramite, pCodigo, pNombreent);
        }       
        public static void Eliminar(int pCodigo)
        {
            PersistenciaTramites.EliminarTramite(pCodigo);
        }
        public static void Modificar(Tramite pTramite, Entidades pNombreent, int pCodigo)
        {
            PersistenciaTramites.ModificarTramite(pTramite, pNombreent, pCodigo);
        }
        public static List<Tramite> CargoTramite()
        {
            return PersistenciaTramites.CargoTramite();
        }
        public static List<Tramite> ListaTramitexNombreEnt(Entidades pEntidad)
        {
            return PersistenciaTramites.ListaTramitexNombreEnt(pEntidad);
        }
    }
}
