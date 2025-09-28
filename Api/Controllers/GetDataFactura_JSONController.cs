using Api.RequesApi.GetDataFactura_JSONController;
using DAL.ModelControl.DBCliente;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetDataFactura_JSONController : ControllerBase
    {
        [HttpPost("ConsultarFactura_ID")]
        [TokenAndDb]
        public async Task<IActionResult> ConsultarFactura_ID(ConsultarFactura_IDReques reques)
        {
            var getData =await GetDataFactura_JSONControl.DataAsync(reques.idventa);

            return Ok(getData);
        }
    }
}
