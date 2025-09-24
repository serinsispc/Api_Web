using DAL.Models.Admin;
using System.Text.Json;

namespace DAL.ModelControl.Admin
{
    public class UsuarioAdminControl
    {
        public static UsuarioAdmin ConsultarUsuario(string usuario, string clave)
        {
            try
            {
                var resultado = Task.Run(async () =>
                {
                    // Evita inyección de SQL, aunque lo ideal es usar parámetros
                    string query = $"SELECT * FROM UsuarioAdmin WHERE cuentaUSuario = '{usuario}' AND claveUsuario = '{clave}'";

                    var cn = new ConnectionSQL();
                    string resp = await cn.EjecutarConsulta(query);

                    if (!string.IsNullOrEmpty(resp))
                    {
                        var usuario_ = JsonSerializer.Deserialize<UsuarioAdmin>(resp);
                        return usuario_ ?? new UsuarioAdmin();
                    }

                    return new UsuarioAdmin();
                }).Result;

                return resultado;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                // Puedes registrar ex.Message si deseas
                return new UsuarioAdmin();
            }
        }

    }
}
