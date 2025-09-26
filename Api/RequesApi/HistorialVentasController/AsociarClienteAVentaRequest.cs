namespace Api.RequesApi.HistorialVentasController
{
    public class AsociarClienteAVentaRequest
    {
        public string nombreDB { get; set; }
        public int idVenta { get; set; }
        public int idCliente { get; set; }
    }
}
