using DAL.Models.DBCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DAL.ModelControl.DBCliente
{
    public class ConfiguracionDianControl
    {
        public static ConfiguracionDian? Consultar()
        {
            try
            {
                var config = new ConfiguracionDian();
                 config = Task.Run(async() => {
                    string query = $"select *from ConfiguracionDian";
                    var cn =new ConnectionSQL();
                    string resp=await cn.EjecutarConsulta(query);
                    ConfiguracionDian? configuracion = new ConfiguracionDian();
                    configuracion=JsonSerializer.Deserialize<ConfiguracionDian>(resp);
                    return configuracion;
                }).Result;
                return config;
            }
            catch(Exception ex)
            {
                string msg = ex.Message;
                return new ConfiguracionDian();
            }
        }
    }
}
