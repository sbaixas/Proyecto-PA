using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPA
{
    [Serializable]
    static class FluxManager
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

        public static void VerHistorialDeMovimientos()
        {
        }
        public static void GraficarFlujosDeCaja()
        {
        }
        public static void GraficarBalances()
        {
        }

       

      

        public static void Cerrar_mes()
        {
            date.cerrar_mes();
        }
        
            
        
    }
}
