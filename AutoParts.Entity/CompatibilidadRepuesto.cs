using System;
using System.Collections.Generic;
using System.Text;

namespace AutoParts.Entity
{
    public class CompatibilidadRepuesto
    {
        public int CompatibilidadRepuestoId { get; set; }
        public int ProductoId { get; set; }
        public int VehiculoId { get; set; }

        public CompatibilidadRepuesto()
        {

        }

        public CompatibilidadRepuesto(int compatibilidadRepuestoId, int productoId, int vehiculoId)
        {
            CompatibilidadRepuestoId = compatibilidadRepuestoId;
            ProductoId = productoId;
            VehiculoId = vehiculoId;
        }
    }
}
