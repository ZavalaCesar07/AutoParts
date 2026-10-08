using System;
using System.Collections.Generic;
using System.Text;

namespace AutoParts.Entity
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string Nombre { get; set; }

        public int EstadoId { get; set; }
        public Categoria()
        {
                
        }
        public Categoria(int categoriaId, string nombre, int estadoId)
        {
            CategoriaId = categoriaId;
            Nombre = nombre;
            EstadoId = estadoId;
        }
    }

}
