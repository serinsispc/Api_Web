using DAL.Models.DBCliente;

namespace Api.RequesApi.FacturaElectronicaController
{
    public class CRUD_FacturaElectronicaRequest
    {
        public string nombreDB {  get; set; }
        public int Funcion {  get; set; }
        public FacturaElectronica facturaElectronica { get; set; }
    }
}
