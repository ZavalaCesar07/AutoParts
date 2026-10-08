namespace AutoParts.Entidades
{
    public class Rol
    {
        public int RolId { get; set; }
        public string Nombre { get; set; }

        public Rol()
        {
        }

        public Rol(int rolId, string nombre)
        {
            RolId = rolId;
            Nombre = nombre;
        }
    }
}
