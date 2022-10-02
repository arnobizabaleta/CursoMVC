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
   public  class CD_CATEGORIA
    {
        public List<CATEGORIA> Listar()
        {
            List<CATEGORIA> lista = new List<CATEGORIA>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    string query = "SELECT ID_CATEGORIA,DESCRIPCION,ACTIVO FROM CATEGORIA";
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new CATEGORIA()
                                {
                                    ID_CATEGORIA = Convert.ToInt32(dr["ID_CATEGORIA"]),
                                    DESCRIPCION = dr["DESCRIPCION"].ToString(),
                                    ACTIVO = Convert.ToBoolean(dr["ACTIVO"])
                                }
                                );
                        }
                    }
                }
            }
            catch
            {
                lista = new List<CATEGORIA>();//Retornando lista vacía
            }

            return lista;
        }

        public int Registrar(CATEGORIA obj, out string mensaje)
        {
            int idAutoGenerado = 0;

            mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("SP_REGISTRARCATEGORIA", oconexion);
                    cmd.Parameters.Add("@DESCRIPCION", SqlDbType.VarChar, 100);
                    cmd.Parameters["@DESCRIPCION"].Value = obj.DESCRIPCION;
                    cmd.Parameters.Add("@ACTIVO", SqlDbType.Bit);
                    cmd.Parameters["@ACTIVO"].Value = obj.ACTIVO;
                  
                    
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
            }
            catch (Exception ex)
            {
                idAutoGenerado = 0;
                mensaje = ex.Message;

            }

            return idAutoGenerado;
        }

        public bool Editar(CATEGORIA obj, out string mensaje)
        {
            bool resultado = false;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("SP_EDITARCATEGORIA", oconexion);
                    cmd.Parameters.AddWithValue("ID_CATEGORIA", obj.ID_CATEGORIA);
                    cmd.Parameters.AddWithValue("DESCRIPCION", obj.DESCRIPCION);
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
                resultado = false;
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
                    SqlCommand cmd = new SqlCommand("SP_ELIMINARCATEGORIA", oconexion);
                    cmd.Parameters.AddWithValue("ID_CATEGORIA", id);
                    

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
                resultado = false;
                mensaje = ex.Message;

            }

            return resultado;

        }
    }
}
