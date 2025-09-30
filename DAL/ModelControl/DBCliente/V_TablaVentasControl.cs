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

        public static List<ExportarExcel> FiltrarExportarExcel(DateTime fecha1,DateTime fecha2 )
        {
            try
            {
                bool sonIguales = fecha1.Date == fecha2.Date;
                if (sonIguales) fecha2= fecha2.AddDays(1).Date;
                var ventas = new List<ExportarExcel>();
                ventas = Task.Run(async () => {
                    string query = $"EXEC ExportarExcel '{fecha1.ToShortDateString()}','{fecha2.ToShortDateString()}'";
                    var cn = new ConnectionSQL();
                    string resp = await cn.EjecutarConsulta(query,true);
                    return JsonConvert.DeserializeObject<List<ExportarExcel>>(resp);
                }).Result;
                return ventas;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return new List<ExportarExcel>();
            }
        }
    }
}
