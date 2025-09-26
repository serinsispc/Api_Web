using DAL.Models.DBCliente;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ModelControl.DBCliente
{
    public class TablaVentasControl
    {
        public static async Task<RespuestaCRUD> CRUD(TablaVentas tventa,int funcion)
        {
            try
            {
                string json=JsonConvert.SerializeObject(tventa);
                json = AjustarJSON.Ajustar(json);
                var cn = new ConnectionSQL();
                var query = $"EXEC CRUD_TablaVentas N'{json}',{funcion}";
                var respuesta = await cn.EjecutarConsulta(query);
                return JsonConvert.DeserializeObject<RespuestaCRUD>(respuesta);
            }
            catch(Exception ex)
            {
                string msg = ex.Message;
                return new RespuestaCRUD{ estado = false, mensaje = msg, idAfectado = 0 };
            }
        }
        public static async Task<TablaVentas> ConsultarId(int id)
        {
            try
            {
                var query = $"select *from TablaVentas where id={id}";
                var cn = new ConnectionSQL();
                var respuesta =await cn.EjecutarConsulta(query);
                return JsonConvert.DeserializeObject<TablaVentas>(respuesta);
            }
            catch (Exception ex) {
            string msg = ex.Message;
                return new TablaVentas();
            }
        }
    }
}
