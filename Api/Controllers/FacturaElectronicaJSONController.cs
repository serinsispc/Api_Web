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
        [HttpPost("InsertInto")]
        [TokenAndDb]
        public async Task<IActionResult> InsertInto(InsertIntoRequest reques)
        {
            var fe = reques.FacturaElectronicaJSON;
            var respuesta =await FacturaElectronicaJSONControl.InsertInto(fe);
            return Ok(respuesta);
        }
    }
}
