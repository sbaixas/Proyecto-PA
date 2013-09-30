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
        //atributos//
        private static Date date;
        private static List<Registro> registro_venta = new List<Registro>();
        private static List<Registro> registro_ingreso = new List<Registro>();
        private static int balance = 0;

       //Getters y Setters//
        internal static Date Date
        {
            get { return FluxManager.date; }
            set { FluxManager.date = value; }
        }     
        internal static List<Registro> Registro_venta
        {
            get { return FluxManager.registro_venta; }
            set { FluxManager.registro_venta = value; }
        }
        internal static List<Registro> Registro_ingreso
        {
            get { return FluxManager.registro_ingreso; }
            set { FluxManager.registro_ingreso = value; }
        }

        //metodos//
        //  se ingresa al historial un producto que se ingresa 
        public static void Ingreso_producto(int id, int cantidad, int costo)
        {
            foreach(Producto p in Manager.Productos)
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
            foreach (Producto p in Manager.Productos)
            {
                if (p.Id == id)
                {
                    registro_venta.Add(new Registro(p, date, cantidad));
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
        public static bool Cerrar_mes()
        {
            bool ret = false;
            date.cerrar_mes();
            ret = true;
            return ret;
        }
        
            
        
    }
}
