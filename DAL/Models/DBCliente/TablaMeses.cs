using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.DBCliente
{
    public class TablaMeses
    {
        public int? Id { get; set; } // NULLABLE
        public int? NumeroMes { get; set; } // NULLABLE
        public string NombreMes { get; set; }
    }
}
