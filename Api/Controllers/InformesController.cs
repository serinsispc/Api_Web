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
    public class InformesController : ControllerBase
    {
        [HttpPost("FiltarDay")]
        public async Task<ActionResult> FiltarDay(string DBFiltro, FiltroInformes filtro)
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
                if (DBFiltro != null)
                {
                    /*ya hemos agregado el nombre de la base de datos a la variable global*/
                    ClassDBCliente.baseCliente = DBFiltro;
                }
                Informes? informes = new Informes();
                informes =await InformesControl.Filtrar_DAY(filtro);
                if (informes != null)
                {
                    return Ok(informes);
                }
                else
                {
                    var respuesta = new { mensaje = "no se encontro la configuracion de la DIAN" };
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
