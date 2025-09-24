using DAL.Models.DBCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DAL.ModelControl.DBCliente
{
    public class SedeControl
    {
         public static async Task<Sede> sede()
        {
            try
            {
                string query = $"Select *from Sede";
                var cn =new ConnectionSQL();
                string resp=await cn.EjecutarConsulta(query);
                Sede? sede = new Sede();
                sede= JsonSerializer.Deserialize<Sede>(resp);
                return sede;
            }
            catch(Exception ex)
            {
                string msg = ex.Message;
                return new Sede();
            }
        }
    }
}
