using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    /*
        CREATE TABLE USUARIO(
ID_USUARIO INT PRIMARY KEY IDENTITY(1,1),
NOMBRES VARCHAR(100),
APELLIDOS VARCHAR(100),
CORREO VARCHAR(100),
CLAVE VARCHAR(150),
RESTABLECER BIT DEFAULT 1,
ACTIVO BIT DEFAULT 1,
FECHA_REGISTRO DATETIME DEFAULT GETDATE())

     */
    public class USUARIO
    {
        public int ID_USUARIO { get; set; }
        public string NOMBRES { get; set; }
        public string APELLIDOS { get; set; }
        public string CORREO { get; set; }
        public string CLAVE { get; set; }
        public bool RESTABLECER { get; set; }
        public bool ACTIVO { get; set; }
    }
}
