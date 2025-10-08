using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RespuestaCRUD
    {
        public bool estado {  get; set; }
        public string mensaje { get; set; }
        public int idAfectado { get; set; }
    }
    public class RespuestaAPI
    {
        public bool estado { get; set; }
        public string mensaje { get; set; }
        public string? data { get; set; }
    }
}
