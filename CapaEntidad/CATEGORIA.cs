using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    /*CREATE TABLE CATEGORIA(
     ID_CATEGORIA INT PRIMARY KEY  IDENTITY(1,1),
     DESCRIPCION VARCHAR(100),
    ACTIVO BIT DEFAULT 1,
    FECHA_REGISTRO DATETIME DEFAULT GETDATE())
    */
    public class CATEGORIA
    {
        public int ID_CATEGORIA { get; set; }
        public string DESCRIPCION { get; set; }
        public bool ACTIVO { get; set; }
        
    }
}
