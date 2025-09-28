using DAL.Models.DBCliente;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ModelControl.DBCliente
{
    public class V_TablaVentasControl
    {
        public static List<V_TablaVentas> ConsultarNumeroFactura(int numero)
        {
            try
            {
                var ventas = new List<V_TablaVentas>();
                ventas = Task.Run(async () => {
                    string query = $"select *from V_TablaVentas where numeroVenta={numero}";
                    var cn = new ConnectionSQL();
                    string resp = await cn.EjecutarConsulta(query,true);
                    return JsonConvert.DeserializeObject<List<V_TablaVentas>>(resp);
                }).Result;
                return ventas;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return new List<V_TablaVentas>();
            }
        }
        public static List<V_TablaVentas> ConsultarNombreCliente(string nombreCliente)
        {
            try
            {
                var ventas = new List<V_TablaVentas>();
                ventas = Task.Run(async () => {
                    string query = $"select *from V_TablaVentas where nombreCliente like '%{nombreCliente}%'";
                    var cn = new ConnectionSQL();
                    string resp = await cn.EjecutarConsulta(query, true);
                    return JsonConvert.DeserializeObject<List<V_TablaVentas>>(resp);
                }).Result;
                return ventas;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return new List<V_TablaVentas>();
            }
        }
        public static V_TablaVentas ConsultarID(int idventa)
        {
            try
            {
                var ventas = new V_TablaVentas();
                ventas = Task.Run(async () => {
                    string query = $"select *from V_TablaVentas where id={idventa}";
                    var cn = new ConnectionSQL();
                    string resp = await cn.EjecutarConsulta(query);
                    return JsonConvert.DeserializeObject<V_TablaVentas>(resp);
                }).Result;
                return ventas;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return new V_TablaVentas();
            }
        }
    }
}
