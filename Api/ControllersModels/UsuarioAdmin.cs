namespace Api.ControllersModels
{
    public class UsuarioAdmin_cm
    {
        public required string Usuario {  get; set; }
        public required string Clave { get; set; }
        public int idTipoSistema { get; set; }
    }
}
