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
        public static async Task<string> ConsultarToken()
        {
            try
            {
                var cn = new ConnectionSQL();
                var query = $"select *from tokenEmpresa";
                var resp=await cn.EjecutarConsulta(query);
                var token = JsonConvert.DeserializeObject<TokenEmpresa>(resp);

                return token.Token.ToString();
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return error;
            }
        }
    }
}
