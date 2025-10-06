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
                var resp = cn.EjecutarConsulta(query,true);
                var 
            }
            catch(Exception ex)
            {
                string msg = ex.Message;
                return new RespuestaAPI { data=null, estado=false, mensaje=msg };
            }
        }
    }
}
