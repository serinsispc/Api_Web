using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ModelControl.DBCliente
{
    public class payment_methodsControl
    {
        public static async Task<RespuestaAPI> Lista_payment()
        {
            try
            {
                var query = $"SELECT *FROM payment_methods WHERE state=1";
                var cn = new ConnectionSQL();
                var resp= await cn.EjecutarConsulta(query,true);
                if (resp != "[]")
                {
                    return new RespuestaAPI { data = resp, estado = true, mensaje = "ok" };
                }
                else
                {
                    return new RespuestaAPI { mensaje="error", estado=false, data=null };
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return new RespuestaAPI { data=null, estado=false, mensaje="error" };
            }
        }
    }
}
