using DAL.Models;
using DAL.Models.DBCliente;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ModelControl.DBCliente
{
    public class FacturaElectronicaJSONControl
    {
        public static async Task<RespuestaCRUD> CRUD(FacturaElectronicaJSON factura,int funcion)
        {
            try
            {
                string json=JsonConvert.SerializeObject(factura);
                json = AjustarJSON.Ajustar(json);
                var cn = new ConnectionSQL();
                var query = $"EXEC dbo.CRUD_FacturaElectronicaJSON {funcion}, N'{json}'";
                var resp = await cn.EjecutarConsulta(query);
                return JsonConvert.DeserializeObject<RespuestaCRUD>(resp);
            }
            catch(Exception ex)
            {
                string msg = ex.Message;
                return new RespuestaCRUD { estado=false, idAfectado=0, mensaje=msg};
            }
        }

        public static async Task<RespuestaAPI> Consultar_IdVenta(int idventa)
        {
            try
            {
                var cn = new ConnectionSQL();
                var query = $"select *from FacturaElectronicaJSON where idventa={idventa}";
                var resp = await cn.EjecutarConsulta(query);
                if (resp != "[]")
                {
                    return new RespuestaAPI { data=resp, estado=true, mensaje="OK" };
                }
                else
                {
                    return new RespuestaAPI { data = null, mensaje = "Error", estado = false };
                }
                
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return new RespuestaAPI { estado = false, data = null, mensaje = msg };
            }
        }
    }
}
