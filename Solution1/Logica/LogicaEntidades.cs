using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades_Compartidas;
using Persistencia;

namespace Logica
{
    public class LogicaEntidades
    {
        public static Entidades Buscar(string pNombre)
        {
            Entidades ent = PersistenciaEntidad.Buscar(pNombre);
            return ent;
        }
        public static void AgregarTelefono(Entidades pEnt, Telefonos pTelefono)
        {
            PersistenciaEntidad.Telefono((Entidades)pEnt, (Telefonos)pTelefono);
        }
        public static void Agregar(Entidades ent)
        {
            PersistenciaEntidad.AgregarEntidad(ent);
        }
        public static List<Telefonos> CargoTelefonos(Entidades pEntidad)
        {
            return PersistenciaEntidad.CargoTelefonos((Entidades)pEntidad);
        }
        public static void Modificar(Entidades pEntidad)
        {
            PersistenciaEntidad.Modificar((Entidades)pEntidad);
        }
        public static void EliminarTelefono(Entidades pEntidad, Telefonos pTelefono)
        {
            PersistenciaEntidad.EliminarTelefono((Entidades)pEntidad, (Telefonos)pTelefono);
        }
        public static void Eliminar(string pNombre)
        {
           PersistenciaEntidad.EliminarEntidad(pNombre);
        }
        public static List<Entidades> CargoEntidad()
        {
            return PersistenciaEntidad.CargoEntidades();
        }
    }
}
