using DAL.ModelControl.DBCliente;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class V_ResolucionesController : ControllerBase
    {
        [HttpPost("ConsultarIdResolucion")]
        [TokenAndDb]
        public async Task<IActionResult> ConsultarIdResolucion(ConsultarIdResolucionRequest request)
        {
            var reslolucion = V_ResolucionesControl.ConsultarIdResolucion(request.idResolucion);
            return Ok(reslolucion);
        }
    }
    public class ConsultarIdResolucionRequest
    {
        public string nombreDB { get; set; }
        public int idResolucion { get; set; }
    }
}
