namespace Api.RequesApi.V_TablaVentasController
{
    public class ExportarExcelFiltroRequest
    {
        public string nombreDB { get; set; }
        public DateTime fecha1 { get; set; }
        public DateTime fecha2 { get; set; }
    }
}
