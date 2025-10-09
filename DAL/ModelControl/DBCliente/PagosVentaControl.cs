using DAL.Models.DBCliente;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        public static async Task<RespuestaCRUD> crud(PagosVenta pagosVenta, int funcion)
        {
            try
            {
                string json = JsonConvert.SerializeObject(pagosVenta);
                json = AjustarJSON.Ajustar(json);
                var cn = new ConnectionSQL();
                var query = $"EXEC CRUD_PagosVenta {funcion},N'{json}'";
                var resp = await cn.EjecutarConsulta(query);
                return JsonConvert.DeserializeObject<RespuestaCRUD>(resp);
            }
            catch (Exception ex) 
            {
                string error=ex.Message;
                return new RespuestaCRUD { estado=false, idAfectado=0, mensaje=error };
            }
        }
    }
}
