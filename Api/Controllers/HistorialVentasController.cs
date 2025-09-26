using Api.Class;
using Api.ControllersModels;
using Api.RequesApi.HistorialVentasController;
using Api.RequesApi.HistorialVentasReques;
using DAL;
using DAL.ModelControl;
using DAL.ModelControl.DBCliente;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistorialVentasController : ControllerBase
    {
        [HttpPost("FiltroDia")]
        [TokenAndDb]
        public async Task<IActionResult> FiltroDia(FiltroDiaReques reques)
        {
            var reqDia = InformeFechasRequest.Dia(reques.tabla, reques.columna, reques.fecha);
            string sqlDia = reqDia.ToSqlExec();
            var db = new ConnectionSQL();
            var ressultado = await db.EjecutarConsulta(sqlDia, true);
            return Ok(ressultado);
        }
        [HttpPost("FiltroDias")]
        [TokenAndDb]
        public async Task<IActionResult> FiltroDias(FiltroDiasReques reques)
        {
            var reqDia = InformeFechasRequest.RangoDias(reques.tabla, reques.columna, reques.fecha1, reques.fecha2);
            string sqlDia = reqDia.ToSqlExec();
            var db = new ConnectionSQL();
            var ressultado = await db.EjecutarConsulta(sqlDia, true);
            return Ok(ressultado);
        }
        [HttpPost("FiltroMes")]
        [TokenAndDb]
        public async Task<IActionResult> FiltroMes(FiltroMesReques reques)
        {
            var reqDia = InformeFechasRequest.Mes_(reques.tabla, reques.columna, reques.anio, reques.mes);
            string sqlDia = reqDia.ToSqlExec();
            var db = new ConnectionSQL();
            var ressultado = await db.EjecutarConsulta(sqlDia, true);
            return Ok(ressultado);
        }
        [HttpPost("FiltroMeses")]
        [TokenAndDb]
        public async Task<IActionResult> FiltroMeses(FiltroMesesReques reques)
        {
            var reqDia = InformeFechasRequest.Meses_(reques.tabla, reques.columna, reques.meses, reques.anio);
            string sqlDia = reqDia.ToSqlExec();
            var db = new ConnectionSQL();
            var ressultado = await db.EjecutarConsulta(sqlDia, true);
            return Ok(ressultado);
        }
        [HttpPost("FiltroNumeroFactura")]
        [TokenAndDb]
        public async Task<IActionResult> FiltroNumeroFactura(FiltroNumerofacturaReques reques)
        {
            var ressultado = V_TablaVentasControl.ConsultarNumeroFactura(reques.NumeroFactura);
            return Ok(ressultado);
        }
        [HttpPost("FiltroNombreCliente")]
        [TokenAndDb]
        public async Task<IActionResult> FiltroNombreCliente(FiltroNombreClienteReques reques)
        {
            var ressultado = V_TablaVentasControl.ConsultarNombreCliente(reques.NombreCliente);
            return Ok(ressultado);
        }
        [HttpPost("ListaResoluciones")]
        [TokenAndDb]
        public async Task<IActionResult> ListaResoluciones(ListaResolucionesReques reques)
        {
            return Ok(V_ResolucionesControl.Lista());
        }
        [HttpPost("ConsultarResolucionIdResolucion")]
        [TokenAndDb]
        public async Task<IActionResult> ConsultarResolucionIdResolucion(ConsultarResolucionIdResolucionReques reques)
        {
            var resolucion =await ResolucionControl.ConsultarIdResolucion(reques.IdResolucion);
            return Ok(resolucion);
        }
        [HttpPost("EditarIdResolucion")]
        [TokenAndDb]
        public async Task<IActionResult> EditarIdResolucion(EditarIdResolucionReques reques)
        {
            var venta =await TablaVentasControl.ConsultarId(reques.idventa);
            venta.idResolucion= reques.idresolucion;
            var respuesta =await TablaVentasControl.CRUD(venta,1);
            return Ok(respuesta);
        }
    }
}
