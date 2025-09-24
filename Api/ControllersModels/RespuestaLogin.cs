using DAL.ModelControl;
using DAL.Models.DBCliente;

namespace Api.ControllersModels
{
    public class RespuestaLogin
    {
        public string dbCliente {  get; set; }
        public v_Usuario v_Usuario { get; set; }
    }
}
