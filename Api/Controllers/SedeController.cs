using Api.Class;
using Api.ControllersModels;
using DAL.ModelControl;
using DAL.ModelControl.DBCliente;
using DAL.Models.DBCliente;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SedeController : ControllerBase
    {
        [HttpPost("ConsultarSede")]
        public async Task<ActionResult> ConsultarSede(EnviarDBCliente consultar)
        {
            // Obtener el token desde el encabezado Authorization
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            if (string.IsNullOrEmpty(token))
            {
                token = Request.Query["token"].ToString();
            }
            if(await ClassToken.VereficarToken(token))
            {
                /*cargamos el nombre de la base*/
                ClassDBCliente.baseCliente = consultar.dbCliente;
                Sede sede = new Sede();
                sede = await SedeControl.sede();
                string resp=JsonSerializer.Serialize(sede);
                return Ok(resp);
            }
            else
            {
                var error = new { mensaje = "¡El token no es válido!" };
                return Unauthorized(error); // Retorna JSON 401 Unauthorized
            }
        }
    }
}
