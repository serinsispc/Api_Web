using Api.Class;
using Api.ControllersModels;
using Api.RequesApi.LoginController;
using DAL.ModelControl;
using DAL.ModelControl.DBCliente;
using DAL.Models;
using DAL.Models.Admin;
using DAL.Models.DBCliente;
using DAL_P.Modelos;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Protocol;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost("Login")]
        [TokenAndDb]
        public async Task<IActionResult> Login(LoginReques_ reques)
        {
            if (reques.idTipoSistema == 1)
            {
                /*en esta parte verificamos el usuario en la base seleccionada de sistema pos*/
                v_Usuario _Usuario = new v_Usuario();
                _Usuario = v_UsuarioControl.ConsultarUser(reques.cuentaUSuario, reques.claveUsuario);
                if (_Usuario != null)
                {
                    RespuestaLogin respuestaLogin = new RespuestaLogin();
                    respuestaLogin.v_Usuario = _Usuario;
                    respuestaLogin.dbCliente = ClassDBCliente.baseCliente;
                    var result = respuestaLogin;
                    return Ok(result); // Retorna JSON 200 OK
                }
                else
                {
                    var error = new { mensaje = $"¡El usuario no se encuentra en la base de datos {reques.nombreDB}!" };
                    return Unauthorized(error); // Retorna JSON 401 Unauthorized
                }
            }
            else
            {
                /*en esta parte verificamos el usuario en la base seleccionada de párqueadero*/
                V_Usuario _Usuario = new V_Usuario();
                _Usuario = v_UsuarioControl.ConsultarUserP(reques.cuentaUSuario, reques.claveUsuario);
                if (_Usuario != null)
                {
                    RespuestaLoginParqueadero respuestaLogin = new RespuestaLoginParqueadero();
                    respuestaLogin.v_Usuariop = _Usuario;
                    respuestaLogin.dbCliente = ClassDBCliente.baseCliente;
                    var result = respuestaLogin;
                    return Ok(result); // Retorna JSON 200 OK
                }
                else
                {
                    var error = new { mensaje = $"¡El usuario no se encuentra en la base de datos {reques.nombreDB}!" };
                    return Unauthorized(error); // Retorna JSON 401 Unauthorized
                }
            }
        }
    }
}
