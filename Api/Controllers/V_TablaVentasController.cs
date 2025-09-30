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

        [HttpPost("ExportarExcelFiltro")]
        [TokenAndDb]
        public async Task<IActionResult> ExportarExcelFiltro(ExportarExcelFiltroRequest reques)
        {
            var ventas =V_TablaVentasControl.FiltrarExportarExcel(reques.fecha1,reques.fecha2);
            return Ok(ventas);
        }
    }
}
