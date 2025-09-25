using Api.Class;
using Api.ControllersModels;
using Api.RequesApi.InformesController;
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
        [TokenAndDb]
        public async Task<ActionResult> FiltarDay(FiltarDayReques reques)
        {
            Informes? informes = new Informes();
            informes = await InformesControl.Filtrar_DAY(reques.yearFiltro,reques.monthFiltro,reques.day1Filtro,reques.day2Filtro);
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
    }
}
