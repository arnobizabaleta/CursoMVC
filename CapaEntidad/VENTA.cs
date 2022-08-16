using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    /*
     CREATE TABLE VENTA(
ID_VENTA INT PRIMARY KEY IDENTITY(1,1),
IDCLIENTE INT REFERENCES CLIENTE(ID_CLIENTE),
TOTAL_PRODUCTO INT,
MONTO_TOTAL DECIMAL(10,2),
CONTACTO VARCHAR(50),
ID_DISTRITO VARCHAR(10),
TELEFONO VARCHAR(50),
DIRECCION VARCHAR(500),
ID_TRANSACCION VARCHAR(50),
FECHA_VENTA DATETIME DEFAULT GETDATE())
     */
    public class VENTA
    {
        public int ID_VENTA { get; set; }
        public int ID_CLIENTE { get; set; }
        public int TOTAL_PRODUCTO { get; set; }
        public decimal MONTO_TOTAL { get; set; }
        public string CONTACTO { get; set; }
        public string ID_DISTRITO { get; set; }
        public string TELEFONO { get; set; }
        public string DIRECCION { get; set; }

        public string FECHA_TEXTO { get; set; }
        public string ID_TRANSACCION { get; set; }

        public List<DETALLE_VENTA> oDETALLE_VENTA { get; set; }
    }
}
