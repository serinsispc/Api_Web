using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AjustarJSON
    {
        public static string Ajustar(string json)
        {
            return (json ?? string.Empty).Replace("'", "''");
        }
    }
}
