using DAL.ModelControl.DBCliente;
using DAL.Models.DBCliente;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotasCreditoController : ControllerBase
    {
        [HttpPost("CRUD")]
        [TokenAndDb]
        public async Task<IActionResult> CRUD(CRUDRequest request)
        {
            var respuesta = await NotasCreditoControl.CRUD(request.NotasCredito, request.funcion);
            return Ok(respuesta);
        }
        public class CRUDRequest
        {
            public string nombreDB {  get; set; }
            public int funcion {  get; set; }
            public NotasCredito NotasCredito { get; set; }
        }
    }
}
