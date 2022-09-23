using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CDUsuarios
    {
        public List<USUARIO> Listar()
        {
            List<USUARIO> lista = new List<USUARIO>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    string query = "SELECT ID_USUARIO,NOMBRES,APELLIDOS,CORREO,CLAVE,RESTABLECER, ACTIVO FROM USUARIO";
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new USUARIO()
                                {
                                    ID_USUARIO = Convert.ToInt32(dr["ID_USUARIO"]),
                                    NOMBRES = dr["NOMBRES"].ToString(),
                                   APELLIDOS = dr["APELLIDOS"].ToString(),
                                    CORREO = dr["CORREO"].ToString(),
                                    CLAVE = dr["CLAVE"].ToString(),
                                    RESTABLECER = Convert.ToBoolean(dr["RESTABLECER"]),
                                    ACTIVO = Convert.ToBoolean(dr["ACTIVO"]),
                                }
                                );
                        }
                    }
                }
            }
            catch
            {
                lista = new List<USUARIO>();
            }
            
            return lista;
        }

        public int Registrar(USUARIO obj, out string mensaje)
        {
            int idAutoGenerado = 0;

            mensaje = string.Empty;

            try{
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("SP_REGISTRARUSUARIO", oconexion);
                    cmd.Parameters.Add("@NOMBRES", SqlDbType.VarChar,100);
                    cmd.Parameters["@NOMBRES"].Value = obj.NOMBRES;
                    cmd.Parameters.Add("@APELLIDOS", SqlDbType.VarChar, 100);
                    cmd.Parameters["@APELLIDOS"].Value = obj.APELLIDOS;
                    cmd.Parameters.Add("@CORREO", SqlDbType.VarChar, 100);
                    cmd.Parameters["@CORREO"].Value = obj.CORREO;
                    cmd.Parameters.Add("@CLAVE", SqlDbType.VarChar, 100);
                    cmd.Parameters["@CLAVE"].Value = obj.CLAVE;
                    cmd.Parameters.Add("@ACTIVO", SqlDbType.Bit);
                    cmd.Parameters["@ACTIVO"].Value = obj.ACTIVO;
                    /*
                    cmd.Parameters.AddWithValue("@NOMBRES", obj.NOMBRES);
                    cmd.Parameters.AddWithValue("@APELLIDOS", obj.APELLIDOS);
                    cmd.Parameters.AddWithValue("@CORREO", obj.CORREO);
                    cmd.Parameters.AddWithValue("@CLAVE", obj.CLAVE);
                    cmd.Parameters.AddWithValue("@ACTIVO", obj.ACTIVO);
                    */
                    SqlParameter Mensaj = new SqlParameter("@MENSAJE", SqlDbType.VarChar, 500);
                    SqlParameter Result = new SqlParameter("@RESULTADO", SqlDbType.Int);
                    Mensaj.Direction = ParameterDirection.Output;
                    Result.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(Mensaj);
                    cmd.Parameters.Add(Result);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();


                    
                    idAutoGenerado = Convert.ToInt32(cmd.Parameters["@RESULTADO"].Value);
                    mensaje = cmd.Parameters["@MENSAJE"].Value.ToString();
                }
            }catch(Exception ex)
            {
                idAutoGenerado = 0;
                mensaje = ex.Message;

            }

            return idAutoGenerado;
        }

        public bool Editar(USUARIO obj, out string mensaje)
        {
            bool resultado = false;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("SP_EDITARUSUARIO", oconexion);
                    cmd.Parameters.AddWithValue("ID_USUARIO", obj.ID_USUARIO);
                    cmd.Parameters.AddWithValue("NOMBRES", obj.NOMBRES);
                    cmd.Parameters.AddWithValue("APELLIDOS", obj.APELLIDOS);
                    cmd.Parameters.AddWithValue("CORREO", obj.CORREO);
                    
                    cmd.Parameters.AddWithValue("ACTIVO", obj.ACTIVO);

                    SqlParameter Mensaj = new SqlParameter("@MENSAJE", SqlDbType.VarChar, 500);
                    SqlParameter Result = new SqlParameter("@RESULTADO", SqlDbType.Bit);
                    Mensaj.Direction = ParameterDirection.Output;
                    Result.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(Mensaj);
                    cmd.Parameters.Add(Result);
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();


                    
                    resultado = Convert.ToBoolean(cmd.Parameters["@RESULTADO"].Value);
                    mensaje = cmd.Parameters["@MENSAJE"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
               resultado= false;
                mensaje = ex.Message;

            }

            return resultado;

        }

        public bool Eliminar(int id, out string mensaje)
        {
            bool resultado = false;
            mensaje = string.Empty;

           
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("delete top (1) from usuario where ID_USUARIO = @id", oconexion);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    resultado = cmd.ExecuteNonQuery() > 0 ? true : false;

                }
            }

            catch (Exception ex)
            {
                resultado = false;
                mensaje = ex.Message;

            }

            return resultado;
        }
    }
}
