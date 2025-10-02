using DAL.Models.DBCliente;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ModelControl.DBCliente
{
    public class NotasCreditoControl
    {
        public static async Task<RespuestaCRUD> CRUD(NotasCredito notasCredito,int funcion)
        {
            try
            {
                string json = JsonConvert.SerializeObject(notasCredito);
                json = AjustarJSON.Ajustar(json);
                var cn = new ConnectionSQL();
                var query = $"EXEC CRUD_NotasCreditoJSON N'{json}',{funcion}";
                var resp = await cn.EjecutarConsulta(query);
                return JsonConvert.DeserializeObject<RespuestaCRUD>(resp);
            }
            catch(Exception ex)
            {
                string msg = ex.Message;
                return new RespuestaCRUD { estado=false, idAfectado=0, mensaje=msg };
            }
        }
    }
}
