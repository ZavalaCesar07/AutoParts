using System;
using System.Collections.Generic;
using System.Text;

namespace AutoParts.Entity
{
    public class Proveedor
    {
        public int ProveedorId { get; set; }
        public string NombreEmpresa { get; set; }
        public string NIT { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Contacto { get; set; }
        public Proveedor()
        {
                
        }
        public Proveedor(int proveedorId, string nombreEmpresa, string nIT, string telefono, string correo, string contacto)
        {
            ProveedorId = proveedorId;
            NombreEmpresa = nombreEmpresa;
            NIT = nIT;
            Telefono = telefono;
            Correo = correo;
            Contacto = contacto;
        }
    }
}
