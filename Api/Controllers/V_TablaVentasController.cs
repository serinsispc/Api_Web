using Api.RequesApi.V_TablaVentasController;
using DAL.ModelControl.DBCliente;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class V_TablaVentasController : ControllerBase
    {
        [HttpGet("ConsultarID")]
        [TokenAndDb]
        public async Task<IActionResult> ConsultarID(ConsultarIDReques reques)
        {
            var venta = V_TablaVentasControl.ConsultarID(reques.idventa);
            return Ok(venta);
        }
    }
}
