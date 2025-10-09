using Api.RequesApi.FacturaElectronicaController;
using Api.RequesApi.FacturaElectronicaJSONController;
using DAL.ModelControl.DBCliente;
using DAL.Models.DBCliente;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaElectronicaJSONController : ControllerBase
    {
        [HttpPost("")]
        [TokenAndDb]
        public async Task<IActionResult> CRUD_(FacturaElectronicaJSON facturaElectronicaJSON)
        {
            var respuesta =await FacturaElectronicaJSONControl.CRUD(facturaElectronicaJSON, 0);
            return Ok(respuesta);
        }
        [HttpPut("")]
        [TokenAndDb]
        public async Task<IActionResult> CRUD(FacturaElectronicaJSON facturaElectronicaJSON)
        {
            var respuesta = await FacturaElectronicaJSONControl.CRUD(facturaElectronicaJSON, 0);
            return Ok(respuesta);
        }
        [HttpDelete("{id}")]
        [TokenAndDb]
        public async Task<IActionResult> CRUD(int id)
        {
            FacturaElectronicaJSON facturaElectronicaJSON = new FacturaElectronicaJSON();
            var respuesta = await FacturaElectronicaJSONControl.CRUD(facturaElectronicaJSON, 2);
            return Ok(respuesta);
        }

        [HttpGet("{idventa}")]
        [TokenAndDb]
        public async Task<IActionResult> ConsultarIdVenta(int idventa)
        {
            var respuesta = await FacturaElectronicaJSONControl.Consultar_IdVenta(idventa);
            return Ok(respuesta);
        }
    }
}
