using System;
using System.Collections.Generic;
using System.Text;

namespace AutoParts.Entity
{
    public class Vehiculo
    {
        public int VehiculoId { get; set; }
        public string Anio { get; set; }}
        public string Cilindrada { get; set; }
        public string TipoMotor { get; set; }
        public int ModeloId { get; set; }

        public Vehiculo()
        {

        }

        public Vehiculo(int vehiculoId, string anio, string cilindrada, string tipoMotor, int modeloId)
        {
            VehiculoId = vehiculoId;
            Anio = anio;
            Cilindrada = cilindrada;
            TipoMotor = tipoMotor;
            ModeloId = modeloId;
        }
    }
}
