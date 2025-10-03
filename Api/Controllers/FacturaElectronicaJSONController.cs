using Api.RequesApi.FacturaElectronicaController;
using Api.RequesApi.FacturaElectronicaJSONController;
using DAL.ModelControl.DBCliente;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaElectronicaJSONController : ControllerBase
    {
        [HttpPost("CRUD")]
        [TokenAndDb]
        public async Task<IActionResult> CRUD(InsertIntoRequest reques)
        {
            var fe = reques.FacturaElectronicaJSON;
            var respuesta =await FacturaElectronicaJSONControl.CRUD(fe,reques.Funcion);
            return Ok(respuesta);
        }

        [HttpPost("ConsultarIdVenta")]
        [TokenAndDb]
        public async Task<IActionResult> ConsultarIdVenta(ConsultarIdVentaRequest request)
        {
            var respuesta = await FacturaElectronicaJSONControl.Consultar_IdVenta(request.idventa);
            return Ok(respuesta);
        }
    }
}
