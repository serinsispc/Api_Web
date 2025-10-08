using DAL.Models.DBCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ModelControl.DBCliente
{
    public class PagosVentaControl
    {
        public static async Task<RespuestaAPI> consultar_id(int id)
        {
            try
            {
                var cn = new ConnectionSQL();
                var query = $"SELECT *FROM PagosVenta WHERE id={id}";
                var resp = await cn.EjecutarConsulta(query);
                if (resp != "[]")
                {
                    return new RespuestaAPI { data = resp, estado=true, mensaje="ok" };
                }
                else
                {
                    return new RespuestaAPI { mensaje="error", estado=false, data=null };
                }
            }
            catch(Exception ex)
            {
                string msg = ex.Message;
                return new RespuestaAPI { data=null, estado=false, mensaje=msg };
            }
        }
    }
}
