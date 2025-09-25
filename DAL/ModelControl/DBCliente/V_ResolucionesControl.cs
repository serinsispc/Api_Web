using DAL.Models.DBCliente;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ModelControl.DBCliente
{
    public class V_ResolucionesControl
    {
        public static List<V_Resoluciones> Lista()
        {
            try 
            {
                var listaResoluciones=new List<V_Resoluciones>();
                listaResoluciones = Task.Run(async () =>
                {
                    var query = $"select *from V_Resoluciones";
                    var cn = new ConnectionSQL();
                    var resp = await cn.EjecutarConsulta(query,true);
                    return JsonConvert.DeserializeObject<List<V_Resoluciones>>(resp);
                }).Result;
                return listaResoluciones;
            }
            catch(Exception ex)
            {
                string msg = ex.Message;
                return new List<V_Resoluciones>();
            }
        }
    }
}
