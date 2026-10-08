using System;
using System.Collections.Generic;
using System.Text;

namespace AutoParts.Entity
{
    public class Empleado
    {
        public int EmpleadoId { get; set; }
        public int PuestoId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DUI { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public int EstadoId { get; set; }

        public Empleado()
        {

        }

        public Empleado(int empleadoId, int puestoId, string nombre, string apellido, string dUI, string telefono, string correo, string direccion, int estadoId)
        {
            EmpleadoId = empleadoId;
            PuestoId = puestoId;
            Nombre = nombre;
            Apellido = apellido;
            DUI = dUI;
            Telefono = telefono;
            Correo = correo;
            Direccion = direccion;
            EstadoId = estadoId;
        }
    }
}
