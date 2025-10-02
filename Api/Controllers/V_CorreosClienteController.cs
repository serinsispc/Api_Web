using DAL.ModelControl.DBCliente;
using DAL.Models.DBCliente;
using DocumentFormat.OpenXml.Office2021.Excel.RichDataWebImage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class V_CorreosClienteController : ControllerBase
    {
        [HttpPost("ListaIdCliente")]
        [TokenAndDb]
        public async Task<IActionResult> ListaIdCliente(ListaIdClienteRequest request)
        {
            var respuesta = await V_CorreosClienteControl.ListaIDCliente(request.idcliente);
            return Ok(respuesta);
        }
    }
    public class ListaIdClienteRequest
    {
        public string nombreDB { get; set; }
        public int idcliente { get; set; } 
    }
}
