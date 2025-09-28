using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.DBCliente
{
    public class TokenEmpresa
    {
        public int Id { get; set; }
        public Guid IdEmpresa { get; set; }
        public string Token { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; }
    }
}
