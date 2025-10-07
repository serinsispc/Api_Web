using DAL.Models.DBCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ModelControl.DBCliente
{
    public class V_VentasPagosInternosControl
    {
        public static async Task<RespuestaAPI> ListaPagos(int idventa)
        {
            try
            {
                var cn = new ConnectionSQL();
                var query = $"select *from V_VentasPagosInternos where id={idventa}";
                string resp =await cn.EjecutarConsulta(query,true);
                if (resp != "[]")
                {
                    return new RespuestaAPI { data = resp, estado=true, mensaje="ok" };
                }
                else
                {
                    return new RespuestaAPI { mensaje="error", estado=false, data="error" };
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
