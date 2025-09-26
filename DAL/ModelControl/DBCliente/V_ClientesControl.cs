using DAL.Models.DBCliente;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ModelControl.DBCliente
{
    public class V_ClientesControl
    {
        public static async Task<List<V_Clientes>> Lista()
        {
            try
            {
                var db = new ConnectionSQL();
                var query = $"select *from V_Clientes";
                var resp = await db.EjecutarConsulta(query,true);
                return JsonConvert.DeserializeObject<List<V_Clientes>>(resp);
            }
            catch(Exception ex)
            {
                string msg = ex.Message;
                return new List<V_Clientes>();
            }
        }
    }
}
