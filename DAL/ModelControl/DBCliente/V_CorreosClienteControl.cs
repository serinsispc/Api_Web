using DAL.Models.DBCliente;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ModelControl.DBCliente
{
    public class V_CorreosClienteControl
    {
        public static async Task<List<V_CorreosCliente>> ListaIDCliente(int idcliente)
        {
            try 
            {
                var cn = new ConnectionSQL();
                var query = $"select *from V_CorreosCliente where idCliente={idcliente}";
                var resp = await cn.EjecutarConsulta(query,true);
                return JsonConvert.DeserializeObject<List<V_CorreosCliente>>(resp);
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return new List<V_CorreosCliente>();
            }
        }
    }
}
