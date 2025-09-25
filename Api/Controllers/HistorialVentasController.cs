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
        [HttpPost("FiltroDias")]
        public async Task<IActionResult> FiltroDias(FiltroDiasReques filtroDias)
        {
            // Obtener el token desde el encabezado Authorization
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            if (string.IsNullOrEmpty(token))
            {
                token = Request.Query["token"].ToString();
            }
            if (await ClassToken.VereficarToken(token))
            {
                ClassDBCliente.baseCliente = filtroDias.basedb;
                var reqDia = InformeFechasRequest.RangoDias(filtroDias.tabla, filtroDias.columna, filtroDias.fecha1,filtroDias.fecha2);
                string sqlDia = reqDia.ToSqlExec();
                var db = new ConnectionSQL();
                var ressultado = await db.EjecutarConsulta(sqlDia, true);
                return Ok(ressultado);
            }
            else
            {
                var error = new { mensaje = "¡El token no es válido!" };
                return Unauthorized(error); // Retorna JSON 401 Unauthorized
            }
        }
        [HttpPost("FiltroMes")]
        public async Task<IActionResult> FiltroMes(FiltroMesReques filtromes)
        {
            // Obtener el token desde el encabezado Authorization
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            if (string.IsNullOrEmpty(token))
            {
                token = Request.Query["token"].ToString();
            }
            if (await ClassToken.VereficarToken(token))
            {
                ClassDBCliente.baseCliente = filtromes.basedb;
                var reqDia = InformeFechasRequest.Mes_(filtromes.tabla, filtromes.columna, filtromes.anio,filtromes.mes);
                string sqlDia = reqDia.ToSqlExec();
                var db = new ConnectionSQL();
                var ressultado = await db.EjecutarConsulta(sqlDia, true);
                return Ok(ressultado);
            }
            else
            {
                var error = new { mensaje = "¡El token no es válido!" };
                return Unauthorized(error); // Retorna JSON 401 Unauthorized
            }
        }
        [HttpPost("FiltroMeses")]
        public async Task<IActionResult> FiltroMeses(FiltroMesesReques filtromeses)
        {
            // Obtener el token desde el encabezado Authorization
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            if (string.IsNullOrEmpty(token))
            {
                token = Request.Query["token"].ToString();
            }
            if (await ClassToken.VereficarToken(token))
            {
                ClassDBCliente.baseCliente = filtromeses.basedb;
                var reqDia = InformeFechasRequest.Meses_(filtromeses.tabla, filtromeses.columna, filtromeses.meses, filtromeses.anio);
                string sqlDia = reqDia.ToSqlExec();
                var db = new ConnectionSQL();
                var ressultado = await db.EjecutarConsulta(sqlDia, true);
                return Ok(ressultado);
            }
            else
            {
                var error = new { mensaje = "¡El token no es válido!" };
                return Unauthorized(error); // Retorna JSON 401 Unauthorized
            }
        }
        [HttpPost("FiltroNumeroFactura")]
        public async Task<IActionResult> FiltroNumeroFactura(FiltroNumerofacturaReques filtro)
        {
            // Obtener el token desde el encabezado Authorization
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            if (string.IsNullOrEmpty(token))
            {
                token = Request.Query["token"].ToString();
            }
            if (await ClassToken.VereficarToken(token))
            {
                ClassDBCliente.baseCliente = filtro.NombreDB;
                var ressultado = V_TablaVentasControl.ConsultarNumeroFactura(filtro.NumeroFactura);
                return Ok(ressultado);
            }
            else
            {
                var error = new { mensaje = "¡El token no es válido!" };
                return Unauthorized(error); // Retorna JSON 401 Unauthorized
            }
        }
        [HttpPost("FiltroNombreCliente")]
        public async Task<IActionResult> FiltroNombreCliente(FiltroNombreClienteReques filtro)
        {
            // Obtener el token desde el encabezado Authorization
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            if (string.IsNullOrEmpty(token))
            {
                token = Request.Query["token"].ToString();
            }
            if (await ClassToken.VereficarToken(token))
            {
                ClassDBCliente.baseCliente = filtro.NombreDB;
                var ressultado = V_TablaVentasControl.ConsultarNombreCliente(filtro.NombreCliente);
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
