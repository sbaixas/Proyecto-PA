using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPA
{
    class FluxManager
    {
        private static List<Registro> registro_venta = new List<Registro>();

        private static List<Registro> registro_ingreso = new List<Registro>();

        public static void Ingreso_producto(Producto producto_ingresado, Date fecha, int cantidad)
        {
           registro_ingreso.Add(new Registro(producto_ingresado, fecha, cantidad));
        }

        public static void Venta_producto(Producto producto_vendido, Date fecha, int cantidad)
        {
            registro_ingreso.Add(new Registro(producto_vendido, fecha, cantidad));
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
        public static void VerReportesDeVenta()
        {
            int largo = registro_venta.Count;
            int i;
            for (i = 0; i < largo; i++)
            {
                Registro a = registro_venta[i];
                Date b = a.Fecha;
                int cantidad = a.Cantidad;
                string fecha = b.Retornar_fecha();
                string nombre = a.Nombre;
                Console.WriteLine("el " + fecha + " se vendieron " + cantidad + " de " + nombre);           
            }
        }

        public static void VerReportesDeIngreso()
        {
            int largo = registro_ingreso.Count;
            int i;
            for (i = 0; i < largo; i++)
            {
                Registro a = registro_venta[i];
                Date b = a.Fecha;
                int cantidad = a.Cantidad;
                string fecha = b.Retornar_fecha();
                string nombre = a.Nombre;
                Console.WriteLine("el " + fecha + " se vendieron " + cantidad + " de " + nombre);
            }
        }
    }
}
