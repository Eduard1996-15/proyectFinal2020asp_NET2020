using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Entidades_Compartidas;

namespace Persistencia
{
    public class PersistenciaEntidad
    {
        public static Entidades Buscar(string pNombre)
        {
            Entidades ent = null;
            SqlConnection oConexion = new SqlConnection(conexion.STR);
            SqlCommand oComando = new SqlCommand("SP_BUSCARENTIDAD", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;
            oComando.Parameters.AddWithValue("@NOMBRE", pNombre);
            try
            {
                oConexion.Open();
                SqlDataReader oReader = oComando.ExecuteReader();

                if (oReader.Read())
                {
                    string nombre = oReader[0].ToString();
                    string direccion = oReader[1].ToString();
                    List<Telefonos> telefono = null;
                    ent = new Entidades(direccion, nombre, telefono);
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
            return ent;
        }
        public static void AgregarEntidad(Entidades ent)
        {
            SqlConnection oConexion = new SqlConnection(conexion.STR);
            SqlCommand oComando = new SqlCommand("SP_AGREGARENTIDAD", oConexion)
            {
                CommandType = CommandType.StoredProcedure
            };

            oComando.Parameters.AddWithValue("@NOMBRE", ent.Nombre);
            oComando.Parameters.AddWithValue("@DIRECION", ent.Direccion);
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
                        throw new Exception("* Ya existe una entidad con este codigo\n* favor ingrese nuevamente.");
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
        public static void EliminarEntidad(string nom)
        {

            SqlConnection oConexion = new SqlConnection(conexion.STR);
            SqlCommand oComando = new SqlCommand("SP_ELIMINAR_ENTIDAD", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;
            oComando.Parameters.AddWithValue("@NOMBRE", nom);

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
                        throw new Exception("EXISTE SOLICITUD ASOCIADA NO SE ELIMINA");
                    case -2:
                        throw new Exception("ERROR AL ELIMINAR telefono");
                    case -3:
                        throw new Exception("ERROR EN  ELIMINAR TRAMITE");
                    case -4:
                        throw new Exception("ERROR EN ELIMINAR ENTIDAD");
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
        public static void Telefono(Entidades ent, Telefonos tel)
        {
            SqlConnection oConexion = new SqlConnection(conexion.STR);
            SqlCommand oComando = new SqlCommand("SP_AGREGARTELEFONO", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;
            oComando.Parameters.AddWithValue("@NOMBRE", ent.Nombre);
            oComando.Parameters.AddWithValue("@NUMERO", tel.Numero);

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
                        throw new Exception("El telefono ingresado ya existe");

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
        public static List<Telefonos> CargoTelefonos(Entidades pEntidades)
        {
            List<Telefonos> tel = new List<Telefonos>();
            SqlConnection oConexion = new SqlConnection(conexion.STR);
            SqlCommand oComando = new SqlCommand("SP_LISTARTELEFONOS", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;
            oComando.Parameters.AddWithValue("@NOMBRE", pEntidades.Nombre);
            try
            {
                oConexion.Open();
                SqlDataReader oReader = oComando.ExecuteReader();

                while (oReader.Read())
                {
                    int telefono = Convert.ToInt32(oReader[0]);
                    Telefonos fono = new Telefonos(telefono);
                    tel.Add(fono);
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
            return tel;
        }
        public static void Modificar(Entidades pEntidades)
        {
            SqlConnection oConexion = new SqlConnection(conexion.STR);
            SqlCommand oComando = new SqlCommand("SP_MODIFICARENTIDAD", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@NOMBRE", pEntidades.Nombre);
            oComando.Parameters.AddWithValue("@DIRECCION", pEntidades.Direccion);

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
                        throw new Exception("Error de edicion");
                }
            }
            finally
            {
                oConexion.Close();
            }
        }
        public static void EliminarTelefono(Entidades ent, Telefonos tel)
        {
            SqlConnection oConexion = new SqlConnection(conexion.STR);
            SqlCommand oComando = new SqlCommand("SP_ELIMINARTELEFONOS", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;
            oComando.Parameters.AddWithValue("@NOMBRE", ent.Nombre);
            oComando.Parameters.AddWithValue("@NUMERO", tel.Numero);

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
                        throw new Exception("Error de edicion");
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
        public static List<Entidades> CargoEntidades()
        {
            List<Entidades> ent = new List<Entidades>();
            SqlConnection oConexion = new SqlConnection(conexion.STR);
            SqlCommand oComando = new SqlCommand("SP_LISTADOENTIDADES", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;
            try
            {
                oConexion.Open();
                SqlDataReader oReader = oComando.ExecuteReader();

                while (oReader.Read())
                {
                    string nombre = (string)oReader["NOMBRE"];
                    string direccion = (string)oReader["DIRECION"];
                    Entidades entidades = new Entidades(direccion, nombre, null);
                    ent.Add(entidades);
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
            return ent;
        }
    }
}
