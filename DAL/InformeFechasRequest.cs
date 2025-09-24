using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DAL
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ModoFecha
    {
        dia,
        rango_dias,
        mes,
        meses
    }

    public class InformeFechasRequest
    {
        // Requeridos siempre
        [JsonProperty("tabla")]
        public string Tabla { get; set; }

        [JsonProperty("columna")]
        public string Columna { get; set; }

        [JsonProperty("modo")]
        public ModoFecha Modo { get; set; }

        // Opcionales según el modo (usar formato "yyyy-MM-dd" en fechas)
        [JsonProperty("fecha")]
        public string Fecha { get; set; }           // modo: dia

        [JsonProperty("desde")]
        public string Desde { get; set; }           // modo: rango_dias

        [JsonProperty("hasta")]
        public string Hasta { get; set; }           // modo: rango_dias

        [JsonProperty("anio")]
        public int? Anio { get; set; }              // modo: mes  (o meses con un solo año)

        [JsonProperty("mes")]
        public int? Mes { get; set; }               // modo: mes

        [JsonProperty("anios")]
        public List<int> Anios { get; set; }        // modo: meses (varios años)

        [JsonProperty("meses")]
        public List<int> Meses { get; set; }        // modo: meses (varios meses)

        // ===== Helpers =====

        public static InformeFechasRequest Dia(string tabla, string columna, DateTime fecha)
        {
            return new InformeFechasRequest
            {
                Tabla = tabla,
                Columna = columna,
                Modo = ModoFecha.dia,
                Fecha = fecha.ToString("yyyy-MM-dd")
            };
        }

        public static InformeFechasRequest RangoDias(string tabla, string columna, DateTime desde, DateTime hasta)
        {
            return new InformeFechasRequest
            {
                Tabla = tabla,
                Columna = columna,
                Modo = ModoFecha.rango_dias,
                Desde = desde.ToString("yyyy-MM-dd"),
                Hasta = hasta.ToString("yyyy-MM-dd")
            };
        }

        public static InformeFechasRequest Mes_(string tabla, string columna, int anio, int mes)
        {
            return new InformeFechasRequest
            {
                Tabla = tabla,
                Columna = columna,
                Modo = ModoFecha.mes,
                Anio = anio,
                Mes = mes
            };
        }

        public static InformeFechasRequest Meses_(string tabla, string columna, IEnumerable<int> meses, int? anio = null, IEnumerable<int> anios = null)
        {
            return new InformeFechasRequest
            {
                Tabla = tabla,
                Columna = columna,
                Modo = ModoFecha.meses,
                Meses = meses != null ? new List<int>(meses) : null,
                Anio = anio,
                Anios = anios != null ? new List<int>(anios) : null
            };
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(
                this,
                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }
            );
        }

        public string ToSqlExec()
        {
            var json = ToJson();
            var jsonEscapado = json.Replace("'", "''");
            return $"EXEC dbo.Informe_Fechas_Dinamico N'{jsonEscapado}'";
        }
    }
}
