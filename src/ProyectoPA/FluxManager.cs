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
        private static Date date;

        internal static Date Date
        {
            get { return FluxManager.date; }
            set { FluxManager.date = value; }
        }     

        private static List<Registro> registro_venta = new List<Registro>();

        internal static List<Registro> Registro_venta1
        {
            get { return FluxManager.registro_venta; }
            set { FluxManager.registro_venta = value; }
        }

        private static List<Registro> registro_ingreso = new List<Registro>();

        internal static List<Registro> Registro_ingreso1
        {
            get { return FluxManager.registro_ingreso; }
            set { FluxManager.registro_ingreso = value; }
        }

        private  static int balance = 0;

        //  se ingresa al historial un producto que se ingresa 
        public static void Ingreso_producto(int id, int cantidad, int costo)
        {
            foreach(ProductoHoja p in Manager.Productos)
            {
                if(p.Id == id)
                {
                    registro_ingreso.Add(new Registro(p, date, cantidad));
                    break;
                }
            }
            balance = balance - costo;
        }
        // se ingresa al historial un producto que se vende
        public static void Venta_producto(int id, int cantidad)
        {
            foreach (ProductoHoja p in Manager.Productos)
            {
                if (p.Id == id)
                {
                    registro_ingreso.Add(new Registro(p, date, cantidad));
                    int precio = p.Costo;
                    balance = balance + precio;
                    break;
                }
            }
            
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

        public static List<Registro> Ranking_producto()
        {
            List<Registro> ranking = new List<Registro>();
            foreach (Registro a in registro_venta)
            {
                string nombre1 = a.Nombre;
                int precio = a.Precio;
                int cantidad = a.Cantidad;
                int k = 0;
                foreach (Registro b in ranking)
                {
                    string nombre2 = b.Nombre;
                    if (nombre1 == nombre2)
                    {
                        k = 1;
                    }
                }
                if (k == 0)
                {
                    foreach (Registro c in registro_venta)
                    {
                        string nombre2 = c.Nombre;
                        if (nombre1 == nombre2)
                        {
                            cantidad = cantidad + c.Cantidad;
                        }
                    }
                }
            }
            int count = ranking.Count;
            Registro[] array = new Registro[count];
            ranking.CopyTo(array);

            for (int i = 0; i < count; i++)
            {
                Registro reg1 = array[i];
                Registro reg2 = array[i + 1];
                if (reg1.Cantidad < reg2.Cantidad)
                {
                    Registro aux = reg2;
                    array[i + 1] = reg1;
                    array[i] = aux;
                }
            }
            
            List<Registro> lista_final = new List<Registro>();
            foreach (Registro n in array)
            {
                lista_final.Add(n);
            }

            return lista_final;
        }
            
        
    }
}
