using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPA
{
    class Registro
    {
        Producto producto;
        DateTime fecha;
        public Registro(Producto producto, DateTime fecha)
        {
            this.producto = producto;
            this.fecha = fecha;
        }
    }
}
