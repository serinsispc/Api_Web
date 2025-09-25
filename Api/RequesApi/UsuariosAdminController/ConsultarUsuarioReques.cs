namespace Api.RequesApi.UsuariosAdminController
{
    public class ConsultarUsuarioReques
    {
        public required string nombreDB {  get; set; }
        public required string Usuario { get; set; }
        public required string Clave { get; set; }
        public int idTipoSistema { get; set; }
    }
}
