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
        public async Task<ActionResult> ListaMeses(string nombreDB)
        {
            // Obtener el token desde el encabezado Authorization
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            if (string.IsNullOrEmpty(token))
            {
                token = Request.Query["token"].ToString();
            }
            if (await ClassToken.VereficarToken(token))
            {
                if (nombreDB != null)
                {
                    ClassDBCliente.baseCliente = nombreDB;
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
                else
                {
                    var respuesta = new { mensaje = "no se a detectado el nombre de la base de datos" };
                    return new JsonResult(respuesta);
                }
            }
            else
            {
                var respuesta = new { mensaje = "el token no es valido" };
                return new JsonResult(respuesta);
            }
        }
    }
}
