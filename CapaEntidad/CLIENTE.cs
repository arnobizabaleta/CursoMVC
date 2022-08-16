using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    /*
     CREATE TABLE CLIENTE(
ID_CLIENTE INT PRIMARY KEY IDENTITY(1,1),
NOMBRES VARCHAR(100),
APELLIDOS VARCHAR(100),
CORREO VARCHAR(100),
CLAVE VARCHAR(150),
RESTABLECER BIT DEFAULT 0,
FECHA_REGISTRO DATETIME DEFAULT GETDATE(
     */
    public class CLIENTE
    {
        public int ID_CLIENTE { get; set;}
        public string NOMBRES { get; set; }
        public string APELLIDOS { get; set; }

        public string CORREO { get; set; }
        public string CLAVE { get; set; }

        public bool RESTABLECER { get; set; }
    }
}
