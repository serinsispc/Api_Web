using Api.RequesApi.TablaVentaController;
using DAL;
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

        [HttpPut("EditarConsecutivo")]
        [TokenAndDb]
        public async Task<IActionResult> EditarConsecutivo(EditarConsecutivoReques reques)
        {
            if (reques == null)
            {
                return BadRequest(new { mensaje = "Error no detectaron valores request." });
            }

            var idventa = reques.idventa;
            var consecutivo = reques.consecutivo;

            var venta = await TablaVentasControl.ConsultarId(idventa);
            if (venta == null)
            {
                return BadRequest(new { mensaje = $"Error, el idventa {idventa} no existe." });
            }

            venta.numeroVenta = consecutivo;

            var respCRUD = await TablaVentasControl.CRUD(venta, 1);
            if (!respCRUD.estado)
            {
                return BadRequest(new { mensaje = $"Error, no se edito el numero de la factura." });
            }

            return Ok(new { mensaje = $"OK, Numero de factura editado con exíto." });
        }
        [HttpPost("EditarEstadoFactura")]
        [TokenAndDb]
        public async Task<IActionResult> EditarEstadoFactura(EditarEstadoFacturaReques reques)
        {
            var respuesta = new RespuestaAPI();
            if (reques != null)
            {
                //consultamos el id de la tablaventa
                var tablaventa =await TablaVentasControl.ConsultarId(reques.idventa);
                if (tablaventa != null)
                {
                    tablaventa.estadoVenta = reques.estado;
                }
                //enviamos a guardar
                var crud =await TablaVentasControl.CRUD(tablaventa,1);
                if (crud.estado)
                {
                    respuesta = new RespuestaAPI() { data = "null", estado = true, mensaje = $"Estado factura editado con éxito." };
                }
                else
                {
                    respuesta = new RespuestaAPI() { data = "null", estado = false, mensaje = $"No se encontró el id venta # {reques.idventa}." };
                }
            }
            else
            {
                respuesta= new RespuestaAPI() { data="null", estado=false, mensaje="No se hallaron los datos del request." };
            }
            return Ok(respuesta);
        }
    }
}
