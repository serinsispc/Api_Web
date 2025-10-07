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
        [HttpPost("Lista_payment")]
        [TokenAndDb]
        public async Task<IActionResult> Lista_payment(DBReques reques)
        {
            var resp = await payment_methodsControl.Lista_payment();
            return Ok(resp);
        }
    }
}
