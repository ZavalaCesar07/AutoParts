using System;
using System.Collections.Generic;
using System.Text;

namespace AutoParts.Entity
{
    public class Marca
    {
        public int MarcaId { get; set; }
        public string Nombre { get; set; }
        public int EstadoId { get; set; }
        public Marca()
        {
                
        }

        public Marca(int marcaId, string nombre, int estadoId)
        {
            MarcaId = marcaId;
            Nombre = nombre;
            EstadoId = estadoId;
        }
    }
}
