using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPA
{
    class Registro
    {
        Existencia existencia;
        DateTime fecha;
        public Registro(Existencia existencia, DateTime fecha)
        {
            this.existencia = existencia;
            this.fecha = fecha;
        }
    }
}
