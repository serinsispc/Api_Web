using Api.Class;
using DAL.ModelControl.DBCliente;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class V_R_MediosDePago_MediosDePagoInternosController : ControllerBase
    {
        [HttpPost("Lista")]
        [TokenAndDb]
        public async Task<IActionResult>Lista(DBReques reques)
        {
            var resp = await V_R_MediosDePago_MediosDePagoInternosControl.Lista();
            return Ok(resp);
        }
    }
}
