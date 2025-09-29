using DAL.Models.DBCliente;

namespace Api.RequesApi.FacturaElectronicaJSONController
{
    public class InsertIntoRequest
    {
        public string nombreDB {  get; set; }

        public FacturaElectronicaJSON FacturaElectronicaJSON { get; set; }
    }
}
