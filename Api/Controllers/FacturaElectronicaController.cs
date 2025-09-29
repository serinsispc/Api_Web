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
            var resp =await FacturaElectronicaControl.CRUD(reques.FacturaElectronica,reques.Funcion);
            return Ok(resp);
        }
    }
}
