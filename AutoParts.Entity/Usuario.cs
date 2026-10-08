namespace AutoParts.Entidades
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public int EmpleadoId { get; set; }
        public int RolId { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
        public int? EstadoId { get; set; }

        public Usuario()
        {
        }

        public Usuario(int usuarioId, int empleadoId, int rolId, string nombreUsuario, string contrasena, int? estadoId)
        {
            UsuarioId = usuarioId;
            EmpleadoId = empleadoId;
            RolId = rolId;
            NombreUsuario = nombreUsuario;
            Contrasena = contrasena;
            EstadoId = estadoId;
        }
    }
}
