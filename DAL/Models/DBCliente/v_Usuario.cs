using DAL.ModelControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.DBCliente
{
    public class v_Usuario:ClassDBCliente
    {
        public int? id { get; set; }
        public Guid? guidUsuario { get; set; }
        public int? idTipoUsuario { get; set; }
        public int? idEstadoAI { get; set; }
        public string nombreTipoUsuario { get; set; } // varchar(-1) => string (sin longitud limitada en C#)
        public string nombreEstadoAi { get; set; }
        public string identificacionUsuario { get; set; }
        public string nombreUsuario { get; set; }
        public string telefonoUsuario { get; set; }
        public string cuentaUsuario { get; set; }
        public string claveUsuario { get; set; }
    }

}
