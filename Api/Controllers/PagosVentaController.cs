using DAL.ModelControl.DBCliente;
using DAL.Models.DBCliente;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagosVentaController : ControllerBase
    {
        [HttpGet("{id}")]
        [TokenAndDb]
        public async Task<IActionResult> consultar_id(int id)
        {
            var resp = await PagosVentaControl.consultar_id(id);
            return Ok(resp);
        }

        [HttpPut("")]
        [TokenAndDb]
        public async Task<IActionResult> crud_pago(PagosVenta pagosVenta)
        {
            var resp = await PagosVentaControl.crud(pagosVenta,1);
            return Ok(resp);
        }
    }
}
