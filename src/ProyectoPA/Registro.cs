using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPA
{
    class Registro
    {
        private Producto producto;
        
        private DateTime fecha;

        public Registro(Producto producto, DateTime fecha)
        {
            this.producto = producto;
            this.fecha = fecha;
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public Producto Producto 
        {
            get { return producto; }
            set { producto = value; }
        }

    }
}
