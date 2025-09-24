using Api.Class;
using Api.ControllersModels;
using Api.RequesApi;
using DAL;
using DAL.ModelControl;
using DAL.ModelControl.DBCliente;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistorialVentasController : ControllerBase
    {
        [HttpPost("FiltroDia")]
        public async Task<IActionResult> FiltroDia(FiltroDiaReques filtroDia)
        {
            // Obtener el token desde el encabezado Authorization
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            if (string.IsNullOrEmpty(token))
            {
                token = Request.Query["token"].ToString();
            }
            if (await ClassToken.VereficarToken(token))
            {
                ClassDBCliente.baseCliente = filtroDia.basedb;
                var reqDia = InformeFechasRequest.Dia(filtroDia.tabla, filtroDia.columna, filtroDia.fecha);
                string sqlDia = reqDia.ToSqlExec();
                var db = new ConnectionSQL();
                var ressultado =await db.EjecutarConsulta(sqlDia,true);
                return Ok(ressultado);
            }
            else
            {
                var error = new { mensaje = "¡El token no es válido!" };
                return Unauthorized(error); // Retorna JSON 401 Unauthorized
            }
        }
    }
}
