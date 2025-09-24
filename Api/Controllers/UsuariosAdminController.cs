using Api.Class;
using Api.ControllersModels;
using DAL.ModelControl;
using DAL.ModelControl.Admin;
using DAL.Models.Admin;
using Microsoft.AspNetCore.Mvc;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosAdminController : ControllerBase
    {
        [HttpPost("ConsultarUsuario")]
        public async Task<IActionResult> ConsultarUsuario(UsuarioAdmin_cm usuario)
        {
            // Obtener el token desde el encabezado Authorization
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            if (string.IsNullOrEmpty(token))
            {
                token = Request.Query["token"].ToString();
            }

            if (await ClassToken.VereficarToken(token))
            {
                ClassDBCliente.baseCliente = "DBAdminSerinsisPC";
                // Consultar usuario en la base de datos
                UsuarioAdmin Usuario_ = UsuarioAdminControl.ConsultarUsuario(usuario.Usuario, usuario.Clave);
                if (Usuario_!=null)
                {
                    UsuarioLogueadoAdmin ul=new UsuarioLogueadoAdmin();
                    ul.usuarioAdmin = Usuario_;
                    
                    /*en esta parte consultamos las bases de datos acignadas*/
                    List<V_UsuarioDB> usuarioDB = new List<V_UsuarioDB>();
                    usuarioDB = V_UsuarioDBControl.ListaDB(Convert.ToInt32(Usuario_.idUsuario), Convert.ToInt32(usuario.idTipoSistema));
                    if (usuarioDB.Count > 0)
                    {
                        ul.v_UsuarioDB = usuarioDB;
                    }
                    var result = ul;
                    return Ok(result); // Retorna JSON 200 OK
                }
                else
                {
                    var error = new { mensaje = "¡El usuario o clave incorrecto!" };
                    return BadRequest(error); // Retorna JSON 400 Bad Request
                }
            }
            else
            {
                var error = new { mensaje = "¡El token no es válido!" };
                return Unauthorized(error); // Retorna JSON 401 Unauthorized
            }
        }

    }
}
