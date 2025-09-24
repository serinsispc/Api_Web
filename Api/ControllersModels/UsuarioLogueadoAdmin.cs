using DAL.Models.Admin;

namespace Api.ControllersModels
{
    public class UsuarioLogueadoAdmin
    {
        public UsuarioAdmin usuarioAdmin { get; set; }
        public List<V_UsuarioDB> v_UsuarioDB { get; set; }
    }
}
