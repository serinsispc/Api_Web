namespace Api.RequesApi.HistorialVentasReques
{
    public class FiltroMesesReques
    {
        public string nombreDB { get; set; }
        public string tabla { get; set; }
        public string columna { get; set; }
        public IEnumerable<int> meses { get; set; }
        public int anio { get; set; }
        public IEnumerable<int> anios { get; set; }
    }
}
