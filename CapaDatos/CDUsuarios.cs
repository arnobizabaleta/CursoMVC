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
    }
}
