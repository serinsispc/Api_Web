using Api.RequesApi.GetDataFactura_JSONController;
using DAL.Models.DBCliente;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ModelControl.DBCliente
{
    public class GetDataFactura_JSONControl
    {
        /// <summary>
        /// Versión ASÍNCRONA recomendada.
        /// Ejecuta el SP y devuelve el modelo GetDataFactura_JSON deserializado.
        /// Soporta wrapper como objeto, arreglo o payload directo.
        /// </summary>
        public static async Task<GetDataFactura_JSON> DataAsync(int idVenta)
        {
            try
            {
                var cn = new ConnectionSQL();
                // Recomendación: especificar esquema y usar parámetro cuando tu helper lo permita.
                var query = $"EXEC [dbo].[GetDataFactura_JSON] {idVenta}";

                var resp = await cn.EjecutarConsulta(query).ConfigureAwait(false);
                if (string.IsNullOrWhiteSpace(resp))
                    return new GetDataFactura_JSON();

                string jsonPayload = ExtraerPayload(resp);

                if (string.IsNullOrWhiteSpace(jsonPayload))
                    return new GetDataFactura_JSON();

                var data = JsonConvert.DeserializeObject<GetDataFactura_JSON>(jsonPayload);
                return data ?? new GetDataFactura_JSON();
            }
            catch
            {
                // Opcional: loguear ex.Message
                return new GetDataFactura_JSON();
            }
        }

        /// <summary>
        /// Intenta extraer el payload real desde:
        /// 1) objeto wrapper { "json": "..." }
        /// 2) arreglo wrapper [ { "json": "..." } ]
        /// 3) payload directo (ya listo para mapear)
        /// </summary>
        private static string ExtraerPayload(string resp)
        {
            var trimmed = resp?.Trim();
            if (string.IsNullOrEmpty(trimmed))
                return null;

            // Caso 1: Arreglo con una fila [{"json":"..."}]
            if (trimmed.StartsWith("["))
            {
                try
                {
                    var arr = JArray.Parse(trimmed);
                    if (arr.Count > 0)
                    {
                        var token = arr[0]["json"];
                        if (token != null)
                            return token.Type == JTokenType.String ? (string)token : token.ToString(Formatting.None);
                    }
                }
                catch
                {
                    // si falla, seguimos probando otras rutas
                }
            }

            // Caso 2: Objeto { "json": "..." }
            if (trimmed.StartsWith("{"))
            {
                try
                {
                    var obj = JObject.Parse(trimmed);
                    var token = obj["json"];
                    if (token != null)
                        return token.Type == JTokenType.String ? (string)token : token.ToString(Formatting.None);
                }
                catch
                {
                    // si no es wrapper, puede ser el payload directo
                }
            }

            // Caso 3: payload directo
            return trimmed;
        }
    
}
}
