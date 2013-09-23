using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPA
{
    class Manager
    {
        private static List<Producto> productos = new List<Producto>();

        internal static List<Producto> Productos
        {
            get { return Manager.productos; }
        }

        private static int idCount = 0;

        public static int IdCount
        {
            get { return Manager.idCount; }
        }       

        /************************agregar un nuevo tipo de producto*********************************************/
        public static void AgregarProducto(Producto productoAAgregar)
        {
            productos.Add(productoAAgregar);
        }

        public static void AgregarSet(Producto setAAgregar)
        {
            productos.Add(setAAgregar);
        }

        public static bool IngresarProducto(int IdDelProducto, int cantidad)
        {
            foreach (Producto p in productos)
            {

                if (p.Id == IdDelProducto)
                {
                    productos[IdDelProducto].AgregarStock(cantidad);
                    return true;
                }
            }
            return false;
        }

        


          
        

        }
    }

