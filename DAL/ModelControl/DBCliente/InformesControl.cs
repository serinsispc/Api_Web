using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DAL.ModelControl.DBCliente
{
    public class InformesControl
    {
        public static async Task<Informes> Filtrar_DAY(FiltroInformes filtros)
        {
            try
            {
                string query = $"EXEC Informe_day {filtros.yearFiltro},{filtros.monthFiltro},{filtros.day1Filtro},{filtros.day2Filtro}";
                var db = new ConnectionSQL();
                var resp = db.EjecutarConsulta(query,true);
                var informe = JsonSerializer.Deserialize<Informes>(resp.ToString());
                return informe;
            }
            catch(Exception ex)
            {
                string msg = ex.Message;
                return null;
            }
        }
    }
}
