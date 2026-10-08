using System;
using System.Collections.Generic;
using System.Text;

namespace AutoParts.Entity
{
    public class Venta
    {
        public int VentaId { get; set; }
        public int ClienteId { get; set; }
        public int EmpleadoId { get; set; }
        public string NumeroFactura { get; set; }
        public DateTime FechaVenta { get; set; }
        public decimal Total { get; set; }

        public Venta()
        {

        }

        public Venta(int ventaId, int clienteId, int empleadoId, string numeroFactura, DateTime fechaVenta, decimal total)
        {
            VentaId = ventaId;
            ClienteId = clienteId;
            EmpleadoId = empleadoId;
            NumeroFactura = numeroFactura;
            FechaVenta = fechaVenta;
            Total = total;
        }
    }
}
