using Api.RequesApi.FacturaElectronicaController;
using DAL.ModelControl.DBCliente;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaElectronicaController : ControllerBase
    {
        [HttpPost("ConsultarConsecutivo")]
        [TokenAndDb]
        public async Task<IActionResult> ConsultarConsecutivo(ConsultarConsecutivoReques reques)
        {
            int consecutivo = 0;
            var resp = await FacturaElectronicaControl.ConsultarConsecutivo(reques.idresolucion);
            if (resp != null)
            {
                consecutivo = resp.consecutivo;
            }
            return Ok(consecutivo);
        }
        [HttpPost("CRUD")]
        [TokenAndDb]
        public async Task<IActionResult> CRUD_FacturaElectronica(CRUD_FacturaElectronicaRequest reques)
        {
            var resp =await FacturaElectronicaControl.CRUD(reques.facturaElectronica,reques.Funcion);
            return Ok(resp);
        }
        [HttpPost("ConsultarCufe")]
        [TokenAndDb]
        public async Task<IActionResult> ConsultarCufe(ConsultarCufeRequest reques)
        {
            var fe =await FacturaElectronicaControl.ConsultarCufe(reques.cufe.ToString());
            return Ok(fe);
        }
        [HttpPost("ConsultarIdVenta")]
        [TokenAndDb]
        public async Task<IActionResult> ConsultarIdVenta(ConsultarIdVentaRequest reques)
        {
            var fe = await FacturaElectronicaControl.ConsultarIdVenta(reques.idventa);
            return Ok(fe);
        }
    }
}
