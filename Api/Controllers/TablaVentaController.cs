using Api.RequesApi.TablaVentaController;
using DAL.ModelControl.DBCliente;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TablaVentaController : ControllerBase
    {
        [HttpPut("AgregarObservicio")]
        [TokenAndDb]
        public async Task<IActionResult> AgregarObservicio(AgregarObservicioReques reques)
        {
            if(reques == null)
            {
                return BadRequest(new {mensaje="Error no detectaron valores request."});
            }

            var idventa = reques.idventa;
            var obcerbacion = reques.observacion;

            var venta =await TablaVentasControl.ConsultarId(idventa);
            if(venta == null)
            {
                return BadRequest(new { mensaje = $"Error, el idventa {idventa} no existe." });
            }

            venta.observacionVenta = obcerbacion;

            var respCRUD =await TablaVentasControl.CRUD(venta,1);
            if (!respCRUD.estado)
            {
                return BadRequest(new { mensaje = $"Error, no se agrego la observacion." });
            }

            return Ok(new { mensaje = $"OK, Observacion agregada con exíto." });
        }
    }
}
