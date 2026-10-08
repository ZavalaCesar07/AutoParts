using System;

namespace AutoParts.Entidades
{
    public class Garantia
    {
        public int GarantiaId { get; set; }
        public int DetalleVentaId { get; set; }
        public int EmpleadoId { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public int CantidadReclamada { get; set; }
        public string DescripcionFalla { get; set; }
        public string ResultadoEvaluacion { get; set; }
        public DateTime? FechaResolucion { get; set; }
        public string Observaciones { get; set; }
        public int EstadoId { get; set; }

        public Garantia()
        {
        }

        public Garantia(int garantiaId, int detalleVentaId, int empleadoId, DateTime fechaSolicitud, int cantidadReclamada, string descripcionFalla, string resultadoEvaluacion, DateTime? fechaResolucion, string observaciones, int estadoId)
        {
            GarantiaId = garantiaId;
            DetalleVentaId = detalleVentaId;
            EmpleadoId = empleadoId;
            FechaSolicitud = fechaSolicitud;
            CantidadReclamada = cantidadReclamada;
            DescripcionFalla = descripcionFalla;
            ResultadoEvaluacion = resultadoEvaluacion;
            FechaResolucion = fechaResolucion;
            Observaciones = observaciones;
            EstadoId = estadoId;
        }
    }
}
