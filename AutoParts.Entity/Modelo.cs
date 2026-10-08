using System;
using System.Collections.Generic;
using System.Text;

namespace AutoParts.Entity
{
    public class Modelo
    {
        public int ModeloId { get; set; }
        public string Nombre { get; set; }
        public int EstadoId { get; set; }

        public Modelo()
        {

        }

        public Modelo(int modeloId, string nombre, int estadoId)
        {
            ModeloId = modeloId;
            Nombre = nombre;
            EstadoId = estadoId;
        }
    }
}
