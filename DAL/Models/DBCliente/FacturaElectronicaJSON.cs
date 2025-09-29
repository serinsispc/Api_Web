using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.DBCliente
{
    public class FacturaElectronicaJSON
    {
        /// <summary>
        /// Identificador único del registro
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Identificador de la venta asociada
        /// </summary>
        public int IdVenta { get; set; }

        /// <summary>
        /// JSON completo de la factura electrónica
        /// </summary>
        public string FacturaJSON { get; set; }
    }
}
