using DAL.Models.DBCliente;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DAL.ModelControl.DBCliente
{
    public class TablaMesesControl
    {
        public static List<TablaMeses>? ListaMeses()
        {
            try
            {
                var meses = new List<TablaMeses>();
                meses = Task.Run(async () => {
                    string query = $"select *from TablaMeses";
                    var cn = new ConnectionSQL();
                    string resp = await cn.EjecutarConsulta(query,true);
                    var meses = JsonConvert.DeserializeObject<List<TablaMeses>>(resp);
                    return meses;
                }).Result;
                return meses;
            }
            catch(Exception ex)
            {
                string msg = ex.Message;
                return null;
            }
        }
    }
}
