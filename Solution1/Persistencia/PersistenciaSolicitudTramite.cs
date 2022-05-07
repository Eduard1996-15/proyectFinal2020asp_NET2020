using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Entidades_Compartidas;

namespace Persistencia
{
    public class PersistenciaSolicitudTramite
    {
        public static SolicitudTramite BuscarEstado(int id)
        {
            SolicitudTramite sol = new SolicitudTramite(id, DateTime.Today, null, null, null, null, null);
            SqlConnection oConexion = new SqlConnection(conexion.STR);
            SqlCommand oComando = new SqlCommand("SP_BUSCAR_ESTADO_SOLICITUD", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;
            oComando.Parameters.AddWithValue("@ID", id);
            try
            {
                oConexion.Open();
                SqlDataReader oReader = oComando.ExecuteReader();

                if (oReader.Read())
                {
                    DateTime fecha = DateTime.Today;
                    string estado = (string)oReader["ESTADO"];

                    sol = new SolicitudTramite(id, fecha, null, null, null, estado, null);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConexion.Close();
            }
            return sol;
        }
        public static SolicitudTramite BuscarEmpleadoEnTramite(int pCedula)
        {
            SolicitudTramite sol = null;
            SqlConnection oConexion = new SqlConnection(conexion.STR);
            SqlCommand oComando = new SqlCommand("SP_BUSCAREMPLEADOENTRAMITE", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;
            oComando.Parameters.AddWithValue("@CI", pCedula);
            try
            {
                oConexion.Open();
                SqlDataReader oReader = oComando.ExecuteReader();

                if (oReader.Read())
                {
                    Usuario usu = PersistenciaUsuario.BuscarUsuario((int)oReader["EMPLEADO"]);
                        int ide = (int)oReader["ID"];
                        DateTime fecha = (DateTime)oReader["FECHA_HORA"];
                        string nom = (string)oReader["NOMBRE_SOLICITA"];
                        string estado = (string)oReader["ESTADO"];
                        string nomentidad = (string)oReader["NOMBRE_ENT"];
                        Tramite t = PersistenciaTramites.BuscarTramite((int)oReader["CODIGO_TRAMITE"], nomentidad);
                        sol = new SolicitudTramite(ide, fecha, usu, t, t.NombreEntidad, estado, nom);
                    
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConexion.Close();
            }
            return sol;
        }
        public static int AgregarSolicitudTramite(SolicitudTramite pSolicitud)
        {
            SqlConnection oConexion = new SqlConnection(conexion.STR);
            SqlCommand oComando = new SqlCommand("SP_AGREGAR_SOLICITUD_TRAMITES", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@EMP", pSolicitud.Empleado.Cedula);
            oComando.Parameters.AddWithValue("@TIPO_TRAMITE", pSolicitud.Codigo_Tramite);
            oComando.Parameters.AddWithValue("@FECHA_HORA", pSolicitud.Fecha_Hora);
            oComando.Parameters.AddWithValue("@NOMBRE_SOLICITA", pSolicitud.NombreCliente);
            oComando.Parameters.AddWithValue("@ESTADO", pSolicitud.Estado);
            oComando.Parameters.AddWithValue("@NOMBREENT", pSolicitud.NombreEntidad.Nombre);


            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                switch ((int)oRetorno.Value)
                {
                    case -1:
                        throw new Exception("YA EXISTE UNA SOLICITUD CREADA POR ESTE CLIENTE PARA ESTA FECHA Y ESTA ENTIDAD");
                    default:
                        throw new Exception("ERROR EN BASE DE DATOS");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                oConexion.Close();
            }
        }
        public static List<SolicitudTramite> ListarSolicitudxFecha(DateTime fechai, DateTime fechaf)
        {
            List<SolicitudTramite> listasol = new List<SolicitudTramite>();
            SqlDataReader oReader;
            SqlConnection oConexion = new SqlConnection(conexion.STR);
            SqlCommand oComando = new SqlCommand("SP_LISTADO_ALTAS", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;
            oComando.Parameters.AddWithValue("@FECHAINICIO", fechai);
            oComando.Parameters.AddWithValue("@FECHAFINAL", fechaf);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        Usuario usu = PersistenciaUsuario.BuscarUsuario((int)oReader["EMPLEADO"]);
                        int ide = (int)oReader["ID"];
                        DateTime fecha = (DateTime)oReader["FECHA_HORA"];
                        string nom = (string)oReader["NOMBRE_SOLICITA"];
                        string estado = (string)oReader["ESTADO"];
                        string nomentidad = (string)oReader["NOMBRE_ENT"];
                        Tramite t = PersistenciaTramites.BuscarTramite((int)oReader["CODIGO_TRAMITE"], nomentidad);
                        SolicitudTramite S = new SolicitudTramite(ide, fecha, usu, t, t.NombreEntidad, estado, nom);
                        listasol.Add(S);

                    }

                    oReader.Close();
                }
                else
                {
                    throw new Exception("-Error en base de Datos \nNo hay Solicitudes en esa fecha ");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                oConexion.Close();
            }
            return listasol;

        }
        public static List<SolicitudTramite> ListarSolicitudAlta()
        {

            List<SolicitudTramite> listasol = new List<SolicitudTramite>();
            SqlDataReader oReader;
            SqlConnection oConexion = new SqlConnection(conexion.STR);
            SqlCommand oComando = new SqlCommand("SP_LISTADOSOLICITUDTRAMITE_ALTAS", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {

                        Usuario usu = PersistenciaUsuario.BuscarUsuario((int)oReader["EMPLEADO"]);
                        int ide = (int)oReader["ID"];
                        DateTime fecha = (DateTime)oReader["FECHA_HORA"];
                        string nom = (string)oReader["NOMBRE_SOLICITA"];
                        string estado = (string)oReader["ESTADO"];
                        string nomentidad = (string)oReader["NOMBRE_ENT"];
                        Tramite t = PersistenciaTramites.BuscarTramite((int)oReader["CODIGO_TRAMITE"], nomentidad);
                        SolicitudTramite S = new SolicitudTramite(ide, fecha, usu, t, t.NombreEntidad, estado, nom);
                        listasol.Add(S);

                    }

                    oReader.Close();
                }
                else
                {
                    throw new Exception("-Error en base de Datos \n ");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                oConexion.Close();
            }
            return listasol;

        }
        public static void ModificarEstadoSolicitud(int id, string estado)
        {
            SqlConnection oConexion = new SqlConnection(conexion.STR);
            SqlCommand oComando = new SqlCommand("SP_MODIFICAR_ESTADO", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@ID", id);
            oComando.Parameters.AddWithValue("@ESTADO", estado);
            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);
            try
            {

                oConexion.Open();
                oComando.ExecuteNonQuery();
                switch ((int)oRetorno.Value)
                {
                    case -1:
                        throw new Exception("Error de modificacion ");
                }
            }
            finally
            {
                oConexion.Close();
            }
        }
        public static List<SolicitudTramite> ListarSolicitudAnulada(string nombre, int cod)
        {

            List<SolicitudTramite> listasol = new List<SolicitudTramite>();
            SqlDataReader oReader;
            SqlConnection oConexion = new SqlConnection(conexion.STR);
            SqlCommand oComando = new SqlCommand("SP_LISTADOSOLICITUDTRAMITEANULADA", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@NOMBRE", nombre);
            oComando.Parameters.AddWithValue("@CODE", cod);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {


                        int ide = (int)oReader["ID"];
                        int ci = (int)oReader["EMPLEADO"];
                        int codigo = (int)oReader["CODIGO_TRAMITE"];
                        DateTime fecha = (DateTime)oReader["FECHA_HORA"];
                        string nom = (string)oReader["NOMBRE_SOLICITA"];
                        string estado = (string)oReader["ESTADO"];
                        string nomentidad = (string)oReader["NOMBRE_ENT"];
                        Entidades n = PersistenciaEntidad.Buscar(nomentidad);
                        Tramite t = PersistenciaTramites.BuscarTramite(codigo, nomentidad);
                        Usuario usu = PersistenciaUsuario.BuscarUsuario(ci);
                        SolicitudTramite S = new SolicitudTramite(ide, fecha, usu, t, n, estado, nom);
                        listasol.Add(S);

                    }

                    oReader.Close();
                }
                else
                {
                    throw new Exception("No hay solicitudes asociadas a este tramite \n ");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                oConexion.Close();
            }
            return listasol;

        }
        public static List<SolicitudTramite> ListarSolicitudEjecutada(string nombre, int cod)
        {

            List<SolicitudTramite> listasol = new List<SolicitudTramite>();
            SqlDataReader oReader;
            SqlConnection oConexion = new SqlConnection(conexion.STR);
            SqlCommand oComando = new SqlCommand("SP_LISTADOSOLICITUDTRAMITEEJECUTADA", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@NOMBRE", nombre);
            oComando.Parameters.AddWithValue("@CODE", cod);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {


                        int ide = (int)oReader["ID"];
                        int ci = (int)oReader["EMPLEADO"];
                        int codigo = (int)oReader["CODIGO_TRAMITE"];
                        DateTime fecha = (DateTime)oReader["FECHA_HORA"];
                        string nom = (string)oReader["NOMBRE_SOLICITA"];
                        string estado = (string)oReader["ESTADO"];
                        string nomentidad = (string)oReader["NOMBRE_ENT"];
                        Entidades n = PersistenciaEntidad.Buscar(nomentidad);
                        Tramite t = PersistenciaTramites.BuscarTramite(codigo, nomentidad);
                        Usuario usu = PersistenciaUsuario.BuscarUsuario(ci);
                        SolicitudTramite S = new SolicitudTramite(ide, fecha, usu, t, n, estado, nom);
                        listasol.Add(S);

                    }

                    oReader.Close();
                }
                else
                {
                    throw new Exception("No hay solicitudes asociadas a este tramite \n ");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                oConexion.Close();
            }
            return listasol;

        }
        public static List<SolicitudTramite> ListarSolicitudes(string nombre, int cod)
        {

            List<SolicitudTramite> listasol = new List<SolicitudTramite>();
            SqlDataReader oReader;
            SqlConnection oConexion = new SqlConnection(conexion.STR);
            SqlCommand oComando = new SqlCommand("SP_VERTODASLASSOLICITUDES", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;
            oComando.Parameters.AddWithValue("@CODIGO", cod);
            oComando.Parameters.AddWithValue("@NOMBRE", nombre);
            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {

                        Usuario usu = PersistenciaUsuario.BuscarUsuario((int)oReader["EMPLEADO"]);
                        int ide = (int)oReader["ID"];
                        DateTime fecha = (DateTime)oReader["FECHA_HORA"];
                        string nom = (string)oReader["NOMBRE_SOLICITA"];
                        string estado = (string)oReader["ESTADO"];
                        string nomentidad = (string)oReader["NOMBRE_ENT"];
                        Tramite t = PersistenciaTramites.BuscarTramite((int)oReader["CODIGO_TRAMITE"], nomentidad);
                        SolicitudTramite S = new SolicitudTramite(ide, fecha, usu, t, t.NombreEntidad, estado, nom);
                        listasol.Add(S);

                    }

                    oReader.Close();
                }
                else
                {
                    throw new Exception("No hay solicitudes asociadas a este tramite \n ");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                oConexion.Close();
            }
            return listasol;

        }
    }
}
