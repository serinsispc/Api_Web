using Api.RequesApi.FacturaElectronicaController;
using DAL.ModelControl.DBCliente;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class V_VentasPagosInternosController : ControllerBase
    {
        [HttpGet("{idventa}")]
        [TokenAndDb]
        public async Task<IActionResult> ConsultarIdVenta(int idventa)
        {
            var resp = await V_VentasPagosInternosControl.ListaPagos(idventa);
            return Ok(resp);
        }
    }
}
