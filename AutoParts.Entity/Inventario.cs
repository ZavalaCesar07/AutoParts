using System;
using System.Collections.Generic;
using System.Text;

namespace AutoParts.Entity
{
    public class Inventario
    {
        public int InventarioId { get; set; }
        public int StockActual { get; set; }
        public int StockMinimo { get; set; }
        public int StockMaximo { get; set; }

        public int ProductoId { get; set; }
        public int EstadoId { get; set; }
        public Inventario()
        {
            
        }
        public Inventario(int inventarioId, int stockActual, int stockMinimo, int stockMaximo, int productoId, int estadoId)
        {
            InventarioId = inventarioId;
            StockActual = stockActual;
            StockMinimo = stockMinimo;
            StockMaximo = stockMaximo;
            ProductoId = productoId;
            EstadoId = estadoId;
        }
    }
    
}