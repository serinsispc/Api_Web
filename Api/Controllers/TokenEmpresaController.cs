using Api.Class;
using DAL.ModelControl.DBCliente;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenEmpresaController : ControllerBase
    {
        [HttpPost("ConsultarToken")]
        [TokenAndDb]
        public async Task<IActionResult> ConsultarToken(DBReques reques)
        {
            var token =await TokenEmpresaControl.ConsultarToken();
            return Ok(token);
        }
    }
}
