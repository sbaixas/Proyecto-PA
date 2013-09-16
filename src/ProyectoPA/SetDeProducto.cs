using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPA
{
    class SetDeProducto : Producto
    {
        private List<Producto> prods;
        private double descuento;
        public SetDeProducto(int descuento, params Producto[] productos)
            :base(productos[0])
        {
            
        }
    }
}
