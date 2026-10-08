namespace AutoParts.Entidades
{
    public class Puesto
    {
        public int PuestoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int EstadoId { get; set; }

        public Puesto()
        {
        }

        public Puesto(int puestoId, string nombre, string descripcion, int estadoId)
        {
            PuestoId = puestoId;
            Nombre = nombre;
            Descripcion = descripcion;
            EstadoId = estadoId;
        }
    }
}
