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
        [HttpPost("ConsultarIdVenta")]
        [TokenAndDb]
        public async Task<IActionResult> ConsultarIdVenta(ConsultarIdVentaRequest reques)
        {
            var resp = await V_VentasPagosInternosControl.ListaPagos(reques.idventa);
            return Ok(resp);
        }
    }
}
