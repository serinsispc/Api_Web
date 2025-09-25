namespace Api.RequesApi.LoginController
{
    public class LoginReques_
    {
        public int? idUsuario { get; set; }
        public Guid? guidUsuario { get; set; }
        public string nombreUsuario { get; set; }
        public string cedulaUsuario { get; set; }
        public string celularUsuario { get; set; }
        public string cuentaUSuario { get; set; }
        public string claveUsuario { get; set; }
        public int? idTipoUSuario { get; set; }
        public string nombreDB { get; set; }
        public int idTipoSistema { get; set; }
    }
}
