using Api.Class;
using Api.RequesApi.ConfiguracionDianController;
using DAL.ModelControl;
using DAL.ModelControl.DBCliente;
using DAL.Models.DBCliente;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfiguracionDianController : ControllerBase
    {
        [HttpPost("ConsultarConfiguracionDian")]
        [TokenAndDb]
        public async Task<ActionResult> ConsultarConfiguracionDian(ConsultarConfiguracionDianReques reques)
        {
            ConfiguracionDian? configuracionDian = new ConfiguracionDian();
            configuracionDian = ConfiguracionDianControl.Consultar();
            if (configuracionDian != null)
            {
                return Ok(configuracionDian);
            }
            else
            {
                var respuesta = new { mensaje = "no se encontro la configuracion de la DIAN" };
                return new JsonResult(respuesta);
            }
        }
    }
}
