using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    
    public class PRODUCTO
    {
        public int ID_PRODUCTO { get; set; }
        public string NOMBRE { get; set; }
        public string DESCRIPCION { get; set; }
        public MARCA oMARCA { get; set; }
        public CATEGORIA oCATEGORIA { get; set; }
        public decimal PRECIO { get; set; }
        public int STOCK { get; set; }
        public string RUTA_IMAGEN { get; set; }
        public string NOMBRE_IMAGEN { get; set; }
        public bool ACTIVO { get; set; }
    }
}
