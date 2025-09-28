using DAL.Models.DBCliente;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ModelControl.DBCliente
{
    public class FacturaElectronicaControl
    {
        public static async Task<GetConsecutivoFacturaElectronica> ConsultarConsecutivo(int idresolucion)
        {
            try
            {
                var cn = new ConnectionSQL();
                var query = $"EXEC GetConsecutivoFacturaElectronica {idresolucion}";
                var resp = await cn.EjecutarConsulta(query);
                return JsonConvert.DeserializeObject<GetConsecutivoFacturaElectronica>(resp);
            }
            catch(Exception ex)
            {
                string msg = ex.ToString();
                return new GetConsecutivoFacturaElectronica { consecutivo=0 };
            }
        }
    }
}
