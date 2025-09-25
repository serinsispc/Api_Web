using Api.Class;
using DAL;
using DAL.ModelControl;
using DAL.ModelControl.DBCliente;
using DAL.Models.DBCliente;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TablaMesesController : ControllerBase
    {
        [HttpPost("ListaMeses")]
        [TokenAndDb]
        public async Task<ActionResult> ListaMeses(string nombreDB)
        {
            List<TablaMeses>? tablaMeses = new List<TablaMeses>();
            tablaMeses = TablaMesesControl.ListaMeses();
            if (tablaMeses != null)
            {
                return Ok(tablaMeses);
            }
            else
            {
                var respuesta = new { mensaje = "no se encontro la table de los meses" };
                return new JsonResult(respuesta);
            }
        }
    }
}
