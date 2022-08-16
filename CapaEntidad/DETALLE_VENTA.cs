using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{

    public class DETALLE_VENTA
    {
        public int ID_DETALLE_VENTA { get; set; }
        public int ID_VENTA { get; set; }
        public PRODUCTO oPRODUCTO { get; set; }
        public int CANTIDAD { get; set; }
        public decimal TOTAL { get; set; }
        public string ID_TRANSACCION { get; set; }
    }
}
