using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Entidades_Compartidas;

namespace Persistencia
{
    public class PersistenciaTramites
    {
        public static Tramite BuscarTramite(int codigo, string nombreent)
        {
            Tramite tramite = null;
            SqlConnection oConexion = new SqlConnection(conexion.STR);
            SqlCommand oComando = new SqlCommand("SP_BUSCARTTRAMITE", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;
            oComando.Parameters.AddWithValue("@NOMBRE", nombreent);
            oComando.Parameters.AddWithValue("@CODIGO", codigo);
            try
            {
                oConexion.Open();
                SqlDataReader oReader = oComando.ExecuteReader();

                if (oReader.Read()) 
                {
                    string descripcion = (string)oReader["DESCRIPCION"];
                    int code = (int)oReader["CODIGO"];
                    Entidades n = PersistenciaEntidad.Buscar((string)oReader["NOMBRE_ENTIDAD"]);
                    string nombretramite = (string)oReader["NOMBRETRAM"];
                    tramite = new Tramite(descripcion, nombretramite, n, code);
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
            return tramite;
        }
        public static Tramite BuscarTramitexNombre(Entidades entidad)
        {
            Tramite tramite = null;
            
            SqlConnection oConexion = new SqlConnection(conexion.STR);
            SqlCommand oComando = new SqlCommand("SP_VER_TRAMITEXNOMBRE", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;
            oComando.Parameters.AddWithValue("@NOMBRE_ENTIDAD", entidad.Nombre);
            try
            {
                oConexion.Open();
                SqlDataReader oReader = oComando.ExecuteReader();

                if (oReader.Read())
                {
                    string descripcion = (string)oReader["DESCRIPCION"];
                    int code = (int)oReader["CODIGO"];
                    entidad.Nombre = (string)oReader["NOMBRE_ENTIDAD"];
                    string nombretramite = (string)oReader["NOMBRETRAM"];
                    tramite = new Tramite(descripcion, nombretramite, entidad, code);
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
            return tramite;
        }
        public static void AgregarTramite(Tramite pTramite, int pCodigo, Entidades pEntidad)
        {
            SqlConnection oConexion = new SqlConnection(conexion.STR);
            SqlCommand oComando = new SqlCommand("SP_AGREGARTRAMITE", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@DESCRIPCION", pTramite.Descripcion);
            oComando.Parameters.AddWithValue("@CODIGO", pCodigo);
            oComando.Parameters.AddWithValue("@NOMBRE_ENTIDAD", pEntidad.Nombre);
            oComando.Parameters.AddWithValue("@NOMBRETRAM", pTramite.Nombre_Tramite);

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
                        throw new Exception("Ya existe un tramite con este codigo");
                }

            }
            finally
            {
                oConexion.Close();
            }
        }
        public static void EliminarTramite(int pCodigo)
        {
            SqlConnection oConexion = new SqlConnection(conexion.STR);
            SqlCommand oComando = new SqlCommand("SP_ELIMINARTRAMITE", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@CODIGO", pCodigo);
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
                        throw new Exception("Ha ocurrido un error inesperado");
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

        }
        public static void ModificarTramite(Tramite pTramite, Entidades pEntidad, int pCodigo)
        {
            SqlConnection oConexion = new SqlConnection(conexion.STR);
            SqlCommand oComando = new SqlCommand("SP_MODIFICARTRAMITE", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@DESCRIPCION", pTramite.Descripcion);
            oComando.Parameters.AddWithValue("@CODIGO", pCodigo);
            oComando.Parameters.AddWithValue("@NOMBRE_ENTIDAD", pEntidad.Nombre);
            oComando.Parameters.AddWithValue("@NOMBRETRAM", pTramite.Nombre_Tramite);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);
            try
            {

                oConexion.Open();
                oComando.ExecuteNonQuery();
                switch ((int)oRetorno.Value)
                {
                    case -2:
                        throw new Exception("Esta entidad no existe");
                }
            }
            finally
            {
                oConexion.Close();
            }
        }
        public static List<Tramite> CargoTramite()
        {
            List<Tramite> tramite = new List<Tramite>();
            Entidades ent;
            SqlConnection oConexion = new SqlConnection(conexion.STR);
            SqlCommand oComando = new SqlCommand("SP_LISTAR_TRAMITES", oConexion);

            oComando.CommandType = CommandType.StoredProcedure;
            try
            {
                oConexion.Open();
                SqlDataReader oReader = oComando.ExecuteReader();
               
                while (oReader.Read())
                {
                    string descripcion = (string)oReader["DESCRIPCION"];
                    int codigo = (int)oReader["CODIGO"];
                    ent=PersistenciaEntidad.Buscar((string)oReader["NOMBRE_ENTIDAD"]);
                    string nombreent=ent.Nombre;
                    string nombretramite = (string)oReader["NOMBRETRAM"];
                    Tramite tram = new Tramite(descripcion, nombretramite, ent,codigo);
                    tramite.Add(tram);
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
            return tramite;
        }
        public static List<Tramite> ListaTramitexNombreEnt(Entidades entidad)
        {
            List<Tramite> tramite = new List<Tramite>();
            SqlConnection oConexion = new SqlConnection(conexion.STR);
            SqlCommand oComando = new SqlCommand("SP_VER_TRAMITEXNOMBRE", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;
            oComando.Parameters.AddWithValue("@NOMBRE_ENTIDAD", entidad.Nombre);
            try
            {
                oConexion.Open();
                SqlDataReader oReader = oComando.ExecuteReader();

                while (oReader.Read())
                {
                    string descripcion = (string)oReader["DESCRIPCION"];
                    int code = (int)oReader["CODIGO"];
                    entidad.Nombre = (string)oReader["NOMBRE_ENTIDAD"];
                    string nombretramite = (string)oReader["NOMBRETRAM"];
                    Tramite tram = new Tramite(descripcion, nombretramite, entidad, code);
                    tramite.Add(tram);
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
            return tramite;
        }
     }
   }

