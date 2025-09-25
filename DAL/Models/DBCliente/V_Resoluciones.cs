using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.DBCliente
{
    public class V_Resoluciones
    {
        public int id { get; set; }

        public string nombreRosolucion { get; set; } = string.Empty;
        public string prefijo { get; set; } = string.Empty;

        public int idResolucion { get; set; }
        public string numeroResolucion { get; set; } = string.Empty;
        public string fechaAvilitacion { get; set; } = string.Empty;

        // Campos que marcaste como "yes" (permiten NULL) los dejo como nullable
        public string? vigencia { get; set; }

        public string desde { get; set; } = string.Empty;
        public string? hasta { get; set; }
        public string? caja { get; set; }

        public int? consecutivoInicial { get; set; }
        public int? consecutivo { get; set; }
        public int? estado { get; set; }

        public string estadoText { get; set; } = string.Empty;

        public string? technical_key { get; set; }
    }
}
