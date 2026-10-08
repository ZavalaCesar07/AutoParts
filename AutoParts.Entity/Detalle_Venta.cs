using System;
using System.Collections.Generic;
using System.Text;

namespace AutoParts.Entity
{
    public class Detalle_Venta
    {
        public int DetalleVentaId { get; set; }
        public int VentaId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Descuento { get; set; }
        public decimal SubTotal { get; set; }
        public int DiasGarantiaVenta { get; set; }

        public Detalle_Venta()
        {

        }

        public Detalle_Venta(int detalleVentaId, int ventaId, int productoId, int cantidad, decimal precioUnitario, decimal descuento, decimal subTotal, int diasGarantiaVenta)
        {
            DetalleVentaId = detalleVentaId;
            VentaId = ventaId;
            ProductoId = productoId;
            Cantidad = cantidad;
            PrecioUnitario = precioUnitario;
            Descuento = descuento;
            SubTotal = subTotal;
            DiasGarantiaVenta = diasGarantiaVenta;
        }
    }
}
