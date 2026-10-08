namespace AutoParts.Entidades
{
    public class Estado
    {
        public int EstadoId { get; set; }
        public string Nombre { get; set; }

        public Estado()
        {
        }

        public Estado(int estadoId, string nombre)
        {
            EstadoId = estadoId;
            Nombre = nombre;
        }
    }
}
