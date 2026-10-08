using System;

namespace AutoParts.Entidades
{
    public class ReemplazoGarantia
    {
        public int ReemplazoId { get; set; }
        public int GarantiaId { get; set; }
        public int EmpleadoId { get; set; }
        public DateTime FechaReemplazo { get; set; }
        public int Cantidad { get; set; }
        public string Observaciones { get; set; }

        public ReemplazoGarantia()
        {
        }

        public ReemplazoGarantia(int reemplazoId, int garantiaId, int empleadoId, DateTime fechaReemplazo, int cantidad, string observaciones)
        {
            ReemplazoId = reemplazoId;
            GarantiaId = garantiaId;
            EmpleadoId = empleadoId;
            FechaReemplazo = fechaReemplazo;
            Cantidad = cantidad;
            Observaciones = observaciones;
        }
    }
}
