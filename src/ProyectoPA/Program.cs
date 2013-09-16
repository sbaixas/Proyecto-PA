using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ProyectoPA
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager mng = new Manager();
            while (true) {
                Console.Clear();
                Console.WriteLine("¿Que desea Hacer?");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Opciones:");
                Console.WriteLine("");
                Console.WriteLine("1) Ver lista de productos");
                Console.WriteLine("");
                Console.WriteLine("2) Agregar un nuevo Tipo De Producto");
                Console.WriteLine("");
                Console.WriteLine("3) Ingresar productos");
                Console.WriteLine("");
                Console.WriteLine("4) Ver cualidades de un producto");
                Console.WriteLine("");
                Console.WriteLine("5) Salir");
                int opcion = Convert.ToInt32(Console.ReadLine());
                if (opcion == 1)
                {
                    Console.Clear();
                    mng.mostrarProductos();
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("Presione Enter Para Volver");
                    Console.ReadLine();
                   
                }
                if (opcion == 2)
                {
                    Console.Clear();
                    mng.agregarNuevoTipoDeProducto();
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("Presione Enter Para Volver");
                    Console.ReadLine();
                   
                }
                if (opcion == 3)
                {
                    Console.Clear();
                    mng.ingresarProducto();
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("Presione Enter Para Volver");
                    Console.ReadLine();
                    
                }
                if (opcion == 4)
                {
                    Console.Clear();
                    mng.verCualidadesDeUnProducto();
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("Presione Enter Para Volver");
                    Console.ReadLine();

                }
                if (opcion == 5)
                {
                    break;
                }
            }
         
        }
    }
}
