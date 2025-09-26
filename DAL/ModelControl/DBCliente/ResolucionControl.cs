using DAL.Models.DBCliente;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ModelControl.DBCliente
{
    public class ResolucionControl
    {
        public static async Task<Resolucion> ConsultarIdResolucion(int idResolucion) 
        {
            try
            {
                var query = $"select *from Resoluciones where idResolucion={idResolucion}";
                var cn =new ConnectionSQL();
                string respuesta= await cn.EjecutarConsulta(query);
                return JsonConvert.DeserializeObject<Resolucion>(respuesta);
            }
            catch (Exception ex) 
            { 
                string msg = ex.Message;
                return new Resolucion();
            }
        }
    }
}
