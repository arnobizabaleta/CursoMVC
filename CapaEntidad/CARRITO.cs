using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    /*

    CREATE TABLE CARRITO(
    ID_CARRITO INT PRIMARY KEY IDENTITY(1,1),
    IDCLIENTE INT REFERENCES CLIENTE(ID_CLIENTE),
    IDPRODUCTO INT REFERENCES PRODUCTO(ID_PRODUCTO),
    CANTIDAD INT)
     */
    public class CARRITO
    {
        public int  ID_CARRITO { get; set; }
        public CLIENTE oCLIENTE { get; set; }
        public PRODUCTO oPRODUCTO{ get; set; }
        public int CANTIDAD { get; set; }
    }
}
