using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPA
{
    class Manager
    {
        private static List<Producto> productos;//Tipos de productos
        private static List<Existencia> existencias;//Productos Existentes
        public static void Crear(int costo, double tamaño, double peso, string color, string imagePath, string categoría)
        {
            
        }
        public static void Crear(Producto producto)
        {

        }
        public static void Ingresar(Producto producto)
        {

        }
        public static void CrearSet(params Producto[] producto)
        {

        }
        public static string GenerarReporte()
        {
            return null;
        }
        public static void verStock()
        {

        }
        public static void modificarProducto()//Funcionalidad Adicional
        {

        }
        public static void Vender()
        {
            FluxManager.AddLog(null);
        }
        public static string GenerarRankingDeProductos()//Funcionalidad Adicional De Reporte
        {
            return null;
        }
        public static string GenerarRankingDeCategorias()//Funcionalidad Adicional De Reporte
        {
            return null;
        }
        public static void Guardar(string path)
        {
        }
        public static void Cargar(string path)
        {
        }
    }
}
