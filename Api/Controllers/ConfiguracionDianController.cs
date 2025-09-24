using Api.Class;
using Api.ControllersModels;
using DAL.ModelControl;
using DAL.ModelControl.DBCliente;
using DAL.Models.DBCliente;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfiguracionDianController : ControllerBase
    {
        [HttpPost("ConsultarConfiguracionDian")]
        public async Task<ActionResult> ConsultarConfiguracionDian(EnviarDBCliente enviarDB)
        {
            // Obtener el token desde el encabezado Authorization
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            if (string.IsNullOrEmpty(token))
            {
                token = Request.Query["token"].ToString();
            }
            if (await ClassToken.VereficarToken(token))
            {
                /*En esta parte, como ya hemos verificado que el token es válido, entonces validamos si el 
                 * parámetro del nombre de la base de datos viene vacío.*/
                if (enviarDB != null)
                {
                    /*ya hemos agregado el nombre de la base de datos a la variable global*/
                    ClassDBCliente.baseCliente = enviarDB.dbCliente;
                }
                ConfiguracionDian? configuracionDian = new ConfiguracionDian();
                configuracionDian =ConfiguracionDianControl.Consultar();
                if(configuracionDian != null)
                {
                    return Ok(configuracionDian);
                }
                else
                {
                    var respuesta = new { mensaje = "no se encontro la configuracion de la DIAN" };
                    return new JsonResult(respuesta);
                }
            }
            else
            {
                var respuesta = new { mensaje="el token no es valido" };
                return new JsonResult(respuesta);
            }
        }
    }
}
