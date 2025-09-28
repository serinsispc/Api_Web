using DAL.Models.DBCliente;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ModelControl.DBCliente
{
    public class TokenEmpresaControl
    {
        public static async Task<TokenEmpresa> Consultar()
        {
            try
            {
                var cn = new ConnectionSQL();
                var query = $"select *from tokenEmpresa";
                var resp=await cn.EjecutarConsulta(query);
                return JsonConvert.DeserializeObject<TokenEmpresa>(resp);
            }
            catch(Exception ex)
            {
                string msg = ex.Message;
                return new TokenEmpresa();
            }
        }
    }
}
