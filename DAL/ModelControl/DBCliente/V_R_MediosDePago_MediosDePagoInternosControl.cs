using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ModelControl.DBCliente
{
    public class V_R_MediosDePago_MediosDePagoInternosControl
    {
        public static async Task<RespuestaAPI> Lista()
        {
            try
            {
                var cn = new ConnectionSQL();
                var query = $"SELECT *FROM V_R_MediosDePago_MediosDePagoInternos";
                var RESP = await cn.EjecutarConsulta(query,true);
                if (RESP != "[]")
                {
                    return new RespuestaAPI { data=RESP, estado=true, mensaje="ok"};
                }
                else
                {
                    return new RespuestaAPI { data = null, estado = true, mensaje = "ok" };
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                return new RespuestaAPI { data=null, estado=false, mensaje=error };
            }
        }
    }
}
