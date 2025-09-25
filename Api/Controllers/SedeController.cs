using Api.Class;
using Api.RequesApi.SedeController;
using DAL.ModelControl;
using DAL.ModelControl.DBCliente;
using DAL.Models.DBCliente;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SedeController : ControllerBase
    {
        [HttpPost("ConsultarSede")]
        [TokenAndDb]
        public async Task<ActionResult> ConsultarSede(ConsultarSedeReques reques)
        {
            Sede sede = new Sede();
            sede = await SedeControl.sede();
            string resp = JsonSerializer.Serialize(sede);
            return Ok(resp);
        }
    }
}
