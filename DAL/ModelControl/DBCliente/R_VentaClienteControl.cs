using DAL.Models.DBCliente;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ModelControl.DBCliente
{
    public class R_VentaClienteControl
    {
        public static async Task<RespuestaCRUD> CRUD(R_VentaCliente relacion,int funcion)
        {
            try
            {
                var cn = new ConnectionSQL();
                string json = JsonConvert.SerializeObject(relacion);
                json=AjustarJSON.Ajustar(json);
                var query = $"EXEC CRUD_R_VentaCliente N'{json}',{funcion}";
                var resp = await cn.EjecutarConsulta(query);
                return JsonConvert.DeserializeObject<RespuestaCRUD>(resp);
            }
            catch(Exception ex)
            {
                string msg = ex.Message;
                return new RespuestaCRUD() { estado=false, idAfectado=0, mensaje=msg};
            }
        }
        public static async Task<R_VentaCliente> ConsultarIdVenta(int idventa)
        {
            try
            {
                var cn =new ConnectionSQL();
                var query = $"select *from R_VentaCliente where idVenta={idventa}";
                var resp = await cn.EjecutarConsulta(query);
                return JsonConvert.DeserializeObject<R_VentaCliente>(resp);
            }
            catch(Exception ex)
            {
                string msg = ex.Message;
                return new R_VentaCliente();
            }
        }
    }
}
