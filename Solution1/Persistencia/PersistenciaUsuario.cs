using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Entidades_Compartidas;

namespace Persistencia
{
    public class PersistenciaUsuario
    {
        public static Usuario Login(Usuario pUsuario)
        {
            Usuario usu = null;
            SqlConnection oConexion = new SqlConnection(conexion.STR);
            SqlCommand oComando = new SqlCommand("SP_LOGUEO_USUARIO", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;
            oComando.Parameters.AddWithValue("@CI", pUsuario.Cedula);
            oComando.Parameters.AddWithValue("@CONTRASENIA", pUsuario.Password);
            try
            {
                oConexion.Open();
                SqlDataReader oReader = oComando.ExecuteReader();

                if (oReader.Read())
                {
                    string password = oReader[1].ToString();
                    int ci = Convert.ToInt32(oReader[0]);
                    usu = new Usuario(null, password, ci);
                }
                else
                {
                   throw new Exception("Contraseña incorrecta");
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
            return usu;
        }
        public static Usuario BuscarUsuario(int pCedula)
        {
            Usuario usu = null;
            SqlConnection oConexion = new SqlConnection(conexion.STR);
            SqlCommand oComando = new SqlCommand("SP_BUSCAR_USUARIO", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;
            oComando.Parameters.AddWithValue("@CI", pCedula);
            try
            {
                oConexion.Open();
                SqlDataReader oReader = oComando.ExecuteReader();

                if (oReader.Read())
                {
                    string password = oReader[1].ToString();
                    int ci = Convert.ToInt32(oReader[0]);
                    string nombre = oReader[2].ToString();
                    usu = new Usuario(nombre, password, ci);
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
            return usu;
        }
        public static void AgregarUsuario(Usuario unUsu)
        {
            SqlConnection oConexion = new SqlConnection(conexion.STR);
            SqlCommand oComando = new SqlCommand("SP_INGRESOUSUARIO", oConexion)
            {
                CommandType = CommandType.StoredProcedure
            };

            //@CI, @NOMBRE, @CALLE, @NUMERO, @BARRIO, @NUMERO_TEL
            oComando.Parameters.AddWithValue("@CI ", unUsu.Cedula);
            oComando.Parameters.AddWithValue("@CONTRASENIA ", unUsu.Password);
            oComando.Parameters.AddWithValue("@NOMBRECOMP ", unUsu.Nombre);
            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);


            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int oAfectados = (int)oComando.Parameters["@Retorno"].Value;

                if (oAfectados == -1)
                    throw new Exception("YA EXISTE UN USUARIO CON ESA CEDULA");
                else if (oAfectados == -2)
                    throw new Exception("ERROR DE INSERCION");


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
        public static void Eliminar(int pCedula)
        {
            SqlConnection oConexion = new SqlConnection(conexion.STR);
            SqlCommand oComando = new SqlCommand("SP_ELIMINAR_USUARIO", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;
            oComando.Parameters.AddWithValue("@CI", pCedula);

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
                        throw new Exception("ERROR EN ELIMINAR AL USUARIO");
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
        public static void Editar(Usuario unu)
        {
            SqlConnection _Conexion = new SqlConnection(conexion.STR);
            SqlCommand oComando = new SqlCommand("SP_MODIFICAR_USUARIO", _Conexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@CONTRASENIA", unu.Password);
            oComando.Parameters.AddWithValue("@NOMBRE_COMPLETO", unu.Nombre);
            oComando.Parameters.AddWithValue("@CI", unu.Cedula);


            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(_Retorno);

            try
            {
                _Conexion.Open();
                oComando.ExecuteNonQuery();

                int oAfectados = (int)oComando.Parameters["@Retorno"].Value;

                if (oAfectados == -1)
                    throw new Exception("ERROR DE EDICION");

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _Conexion.Close();
            }
        }
        public static Usuario BuscarEmpleadoEnTramite(int pCedula)
        {
            Usuario usu = null;
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
                    string password = oReader[1].ToString();
                    int ci = Convert.ToInt32(oReader[0]);
                    string nombre = oReader[2].ToString();
                    usu = new Usuario(nombre, password, ci);
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
            return usu;
        }
    }
}
