using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPA
{
    class Manager
    {
        private static Producto[] productos = new Producto[0];

        internal static Producto[] Productos
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
            Producto[] aux = new Producto[productos.Length + 1];
            for (int i = 0; i < productos.Length; i++)
            {
                aux[i] = productos[i];
            }
            aux[aux.Length - 1] = productoAAgregar;
            productos = aux;
            idCount++;
        }

        public static bool IngresarProducto(int IdDelProducto, int cantidad)
        {
            for (int i = 0; i < productos.Length; i++)
            {

                if (productos[i].Id == IdDelProducto)
                {
                    productos[IdDelProducto].AgregarStock(cantidad);
                    return true;
                }
            }
            return false;
        }

        


          
        

        }
    }

