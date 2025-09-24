using DAL.ModelControl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DAL
{
    public class ConnectionSQL : ClassDBCliente
    {
        public static string connectionString = string.Empty;
        public static void ConexionBase(string db)
        {
            connectionString = $"data source =www.serinsispc.com; initial catalog ={db}; user id =emilianop; password =Ser1ns1s@2020*";
        }
        public async Task<string> EjecutarConsulta(string consulta,[Optional] bool lista_)
        {
            ConexionBase(baseCliente);

            string respuesta = "Error";
            using (var conexion = new SqlConnection(connectionString))
            {
                await conexion.OpenAsync();
                using (var cmd = new SqlCommand(consulta, conexion))
                {
                    cmd.CommandType = CommandType.Text;

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        // Convertir DataTable a Lista de Diccionarios antes de serializar
                        var lista = new List<Dictionary<string, object>>();
                        foreach (DataRow row in dt.Rows)
                        {
                            var dict = new Dictionary<string, object>();
                            foreach (DataColumn col in dt.Columns)
                            {
                                dict[col.ColumnName] = row[col] == DBNull.Value ? null : row[col];
                            }
                            lista.Add(dict);
                        }

                        // Serializar la lista de diccionarios en JSON
                        respuesta = JsonSerializer.Serialize(lista, new JsonSerializerOptions { WriteIndented = true });
                        if (lista_ == false)
                        {
                            respuesta = JsonSerializer.Serialize(lista.FirstOrDefault(), new JsonSerializerOptions { WriteIndented = true });
                        }
                    }
                }
            }
            return respuesta;
        }
    }
}
