using Api.Class;
using DAL.ModelControl.DBCliente;
using DAL.Models.DBCliente;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class V_ClientesController : ControllerBase
    {
        [HttpPost("Lista")]
        [TokenAndDb]
        public async Task<IActionResult> Lista(DBReques reques)
        {
            //llamamos al controlador que se encarga de hacer la consulta a al sql server
            var respuesta =await V_ClientesControl.Lista();
            return Ok(respuesta);
        }
    }
}
