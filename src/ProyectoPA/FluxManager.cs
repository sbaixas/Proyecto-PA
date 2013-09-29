using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPA
{
    [Serializable]
    class FluxManager
    {
        private static List<Registro> registro_venta = new List<Registro>();

        private static List<Registro> registro_ingreso = new List<Registro>();

        private int balance = 0;

        public static void Ingreso_producto(Producto producto_ingresado, Date fecha, int cantidad)
        {
           registro_ingreso.Add(new Registro(producto_ingresado, fecha, cantidad));
        }

        public static void Venta_producto(Producto producto_vendido, Date fecha, int cantidad)
        {
            registro_ingreso.Add(new Registro(producto_vendido, fecha, cantidad));
        }

        public List<Registro> Registro_venta
        {
            get { return registro_venta; }
            set { registro_venta = value; }
        }

        public List<Registro> Registro_ingreso
        {
            get { return registro_ingreso; }
            set { registro_ingreso = value; }
        }

        public int Balance
        {
            get { return balance; }
            set { balance = value; }
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
                Console.WriteLine("el " + fecha + " se ingresaron " + cantidad + " de " + nombre);
            }
        }

        // se imprime el historial de ingresos con fecha especificada por el usuario desde me1/año1 hasta mes2/año2
        public static void Ver_historial_con_fecha_ingresos(int mes1, int año1, int mes2, int año2)
        {
            int largo = registro_ingreso.Count;
            int i;
            for (i = 0; i < largo; i++)
            {
                Registro a = registro_ingreso[i];
                Date b = a.Fecha;
                int cantidad = a.Cantidad;
                string fecha = b.Retornar_fecha();
                string nombre = a.Nombre;
                int mes_producto = b.Mes;
                int año_producto = b.Año;

                if (año_producto >= año1 && año_producto <= año2)
                {
                    if (mes_producto >= mes1 && mes_producto <= mes2)
                    {
                        Console.WriteLine("el " + fecha + " se ingresaron " + cantidad + " de " + nombre);
                    }
                }
            }
        }

        // se imprime el historial de ventas con fecha especificada por el usuario desde me1/año1 hasta mes2/año2
        public static void Ver_historial_con_fecha_ventas(int mes1, int año1, int mes2, int año2)
        {
            int largo = registro_venta.Count;
            int i;
            for (i = 0; i < largo; i++)
            {
                Registro a = registro_ingreso[i];
                Date b = a.Fecha;
                int cantidad = a.Cantidad;
                string fecha = b.Retornar_fecha();
                string nombre = a.Nombre;
                int mes_producto = b.Mes;
                int año_producto = b.Año;

                if (año_producto >= año1 && año_producto <= año2)
                {
                    if (mes_producto >= mes1 && mes_producto <= mes2)
                    {
                        Console.WriteLine("el " + fecha + " se vendieron " + cantidad + " de " + nombre);
                    }
                }
            }
        }

    }
}
