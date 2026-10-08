using System;
using System.Collections.Generic;
using System.Text;

namespace AutoParts.Entity
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public string CodigoOEM { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioVenta { get; set; }
        public int TiempoGarantia { get; set; }

        public int CategoriaId { get; set; }
        public int EstadoId { get; set; }
        public Producto()
        {
                
        }
        public Producto(int productoId, string codigoOEM, string nombre, string descripcion, decimal precioVenta, int tiempoGarantia, int categoriaId, int estadoId)
        {
            ProductoId = productoId;
            CodigoOEM = codigoOEM;
            Nombre = nombre;
            Descripcion = descripcion;
            PrecioVenta = precioVenta;
            TiempoGarantia = tiempoGarantia;
            CategoriaId = categoriaId;
            EstadoId = estadoId;
        }
    }
}
