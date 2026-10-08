using System;
using System.Collections.Generic;
using System.Text;

namespace AutoParts.Entity
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DUI { get; set; }
        public string NIT { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }

        public Cliente()
        {

        }

        public Cliente(int clienteId, string nombre, string apellido, string dui, string nit, string telefono, string correo, string direccion)
        {
            ClienteId = clienteId;
            Nombre = nombre;
            Apellido = apellido;
            DUI = dui;
            NIT = nit;
            Telefono = telefono;
            Correo = correo;
            Direccion = direccion;
        }
    }
}
