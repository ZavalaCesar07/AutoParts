using System;
using System.Collections.Generic;
using System.Text;

namespace AutoParts.Entity
{
    public class Detalle_Compra
    {
        public int DetalleCompraId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioCosto { get; set; }
        public decimal Subtotal { get; set; }

        public int CompraId { get; set; }
        public int ProductoId { get; set; }
        public Detalle_Compra()
        {
            
        }
        public Detalle_Compra(int detalleCompraId, int cantidad, decimal precioCosto, decimal subtotal, int compraId, int productoId)
        {
            DetalleCompraId = detalleCompraId;
            Cantidad = cantidad;
            PrecioCosto = precioCosto;
            Subtotal = subtotal;
            CompraId = compraId;
            ProductoId = productoId;
        }
    }
}
