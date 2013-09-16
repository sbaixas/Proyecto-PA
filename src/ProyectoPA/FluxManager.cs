using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPA
{
    class FluxManager
    {
        private static List<Registro> registros = new List<Registro>();
        public static void AddLog(Producto productoVendido)
        {
           registros.Add(new Registro(productoVendido, DateTime.Now));
        }
        public static void VerHistorialDeMovimientos()
        {
        }
        public static void GraficarFlujosDeCaja()
        {
        }
        public static void GraficarBalances()
        {
        }
        public static void VerReportesDeSalida()
        {
        }
    }
}
