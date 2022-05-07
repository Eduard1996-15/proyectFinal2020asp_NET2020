using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades_Compartidas;
using Persistencia;

namespace Logica
{
    public class LogicaUsuario
    {
        public static Usuario Login(Usuario pUsuario)
        {
            Usuario p = PersistenciaUsuario.Login((Usuario) pUsuario);
            return p;
        }
        public static Usuario Buscar(int pCedula)
        {
            Usuario p = PersistenciaUsuario.BuscarUsuario(pCedula);
            return p;
        }
        public static void Agregar(Usuario unUsu)
        {
            PersistenciaUsuario.AgregarUsuario((Usuario) unUsu);
        }
        public static void Modificar(Usuario unUsu)
        {
            PersistenciaUsuario.Editar((Usuario)unUsu);
        }
        public static void Eliminar(int pCedula)
        {
            PersistenciaUsuario.Eliminar(pCedula);
        }
    }
}
