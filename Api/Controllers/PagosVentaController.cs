using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagosVentaController : ControllerBase
    {
        public class requestpv
        {
            public string nombreDB {  get; set; }
        }
        [HttpGet("consultar-id")]
        [TokenAndDb]
        public async Task<IActionResult> consultar_id(requestpv request)
        {
            return Ok();
        }
    }
}
