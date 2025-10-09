using Api.Class;
using DAL.ModelControl.DBCliente;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class payment_methodsController : ControllerBase
    {
        [HttpGet("")]
        [TokenAndDb]
        public async Task<IActionResult> Lista_payment()
        {
            var resp = await payment_methodsControl.Lista_payment();
            return Ok(resp);
        }
    }
}
