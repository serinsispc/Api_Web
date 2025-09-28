using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.DBCliente
{
    public class FacturaElectronica
    {
        public int id { get; set; }
        public int idVenta { get; set; }

        public string cufe { get; set; }
        public string numeroFactura { get; set; }
        public string fechaEmision { get; set; }

        // Se mantiene el nombre tal como está en la tabla/JSON
        public string fecahVensimiento { get; set; }

        public string dataQR { get; set; }
        public string imagenQR { get; set; }

        public int resolucion_id { get; set; }
        public string prefijo { get; set; }

        // Se mantiene el guion bajo tal como está en la tabla/JSON
        public int numero_factura { get; set; }
    }
}
