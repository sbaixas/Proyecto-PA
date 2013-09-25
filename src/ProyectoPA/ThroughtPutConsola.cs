using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPA
{
    class ThroughtPutConsola
    {
        //Clase encargada de escribir y recibir parametros en la consola
        public static void Init()
        {
            while (true)
            {
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
                    mostrarProductos();
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("Presione Enter Para Volver");
                    Console.ReadLine();

                }
                if (opcion == 2)
                {
                    Console.Clear();
                    AgregarProducto();
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("Presione Enter Para Volver");
                    Console.ReadLine();

                }
                if (opcion == 3)
                {
                    Console.Clear();
                    ingresarProducto();
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("Presione Enter Para Volver");
                    Console.ReadLine();

                }
                if (opcion == 4)
                {
                    Console.Clear();
                    verCualidadesDeUnProducto();
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
        /************************agregar un nuevo tipo de producto*********************************************/
        private static void AgregarProducto()
        {

            Console.Clear();
            Console.WriteLine("");

            Console.WriteLine("Escriba los atributos del tipo de producto que desea agregar de la forma");
            Console.WriteLine(" nombre, costo, tamaño, peso , color, categoria");
            Console.WriteLine("");
            try
            {
                //int id, int costo, double tamaño, double peso, string nombre, string color, string categoria, int cantidad//


                //insertar los parametros en el orden: nombre, costo, tamaño , peso , color , categoria, los demas parametros los fija el programa//
                string[] parametros = new string[6] { null, null, null, null, null, null };
                for (int i = 0; i < 6; i++)
                {
                    string aux = null;
                    if (i == 0) { aux = "el nombre"; }
                    if (i == 1) { aux = "el costo"; }
                    if (i == 2) { aux = "el tamaño"; }
                    if (i == 3) { aux = "el peso"; }
                    if (i == 4) { aux = "el color"; }
                    if (i == 5) { aux = "la categoria"; }
                    Console.WriteLine("Inserte " + aux + " del Producto:");
                    parametros[i] = Console.ReadLine();
                    Console.WriteLine("");
                }
                string nombre = parametros[0];
                int costo = Convert.ToInt32(parametros[1]);
                double tamaño = Convert.ToDouble(parametros[2]);
                double peso = Convert.ToDouble(parametros[3]);
                string color = parametros[4];
                string categoria = parametros[5];
                Console.WriteLine("Se ha agregado un nuevo tipo producto");
                Manager.AgregarProducto(costo, tamaño, peso, nombre, color, categoria);

            }
            catch
            {
                Console.WriteLine("Ha ingresado mal , Presione ENTER para volver a intentarlo.");
                Console.ReadLine();
                AgregarProducto();
            }

        }

        /********************************Mostrar productos en una tabla****************************************************/

        private static void mostrarProductos()
        {
            Producto[] productos = Manager.Productos.ToArray();
            Console.WriteLine("         ID         |       Nombre       |      Cantidad      |");
            foreach(ProductoHoja p in productos)
            {
                string nombre, ID, Cantidad;
                ID = " " + p.Id + "";
                //Se da un formato para que las columnas considan//
                while (ID.Length < 20)
                {
                    ID = ID + " ";
                    if (ID.Length < 20)
                    {
                        ID = " " + ID;
                    }
                }

                nombre = " " + p.Nombre;

                while (nombre.Length < 20)
                {
                    nombre = nombre + " ";
                    if (nombre.Length < 20)
                    {
                        nombre = " " + nombre;
                    }
                }

                Cantidad = " " + p.Cantidad + "";
                while (Cantidad.Length < 20)
                {
                    Cantidad = Cantidad + " ";
                    if (Cantidad.Length < 20)
                    {
                        Cantidad = " " + Cantidad;
                    }
                }
                Console.WriteLine(ID + "|" + nombre + "|" + Cantidad + "|");
            }
        }
        /********************************Ver cualidades de un producto****************************************************/
        private static void verCualidadesDeUnProducto()
        {
            try
            {
                List <Producto> productos = Manager.Productos;
                Console.Clear();
                Console.WriteLine("Ingrese el Id Del Producto");
                Console.WriteLine("");
                int IdDelProducto = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                bool correcto = false;
                foreach (Producto p in productos)
                {
                    if (p.Id == IdDelProducto)
                    {
                        Console.Clear();
                        p.imprimirDatos();
                        correcto = true;
                        break;
                    }
                }
                if (!correcto)
                {
                    Console.WriteLine("ERROR , no se encuentra el producto");

                }
            }
            catch
            {
                Console.WriteLine("Ha ingresado mal , Presione ENTER para volver a intentarlo.");
                Console.ReadLine();
                verCualidadesDeUnProducto();
            }
        }
        /********************************ingresar producto****************************************************/
        public static void ingresarProducto()
        {
            try
            {

                Console.Clear();
                Console.WriteLine("Ingresar un Producto");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Opciones:");
                Console.WriteLine("");
                Console.WriteLine("1) Ver lista de productos");
                Console.WriteLine("");
                Console.WriteLine("2) ingresar Id del producto");
                Console.WriteLine("");
                Console.WriteLine("3) Cancelar");
                int opcion = Convert.ToInt32(Console.ReadLine());
                if (opcion == 1)
                {
                    Console.Clear();
                    mostrarProductos();
                    Console.WriteLine("");
                    Console.WriteLine("Presione Enter Para Volver");
                    Console.ReadLine();
                    ingresarProducto();
                }
                if (opcion == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Ingrese el Id Del Producto");
                    Console.WriteLine("");
                    int IdDelProducto = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    Console.WriteLine("Ingrese la cantidad a agregar");
                    int cantidad = Convert.ToInt32(Console.ReadLine());
                    bool correcto = Manager.IngresarProducto(IdDelProducto, cantidad);
                    if (correcto == false)
                    {
                        Console.WriteLine("ERROR: no se ha agregado el producto ,puede que halla ingresado mal el producto , o que no exista");
                        Console.ReadLine();
                    }
                }
                if (opcion == 3)
                {
                    Console.Clear();
                }
            }

            catch
            {
                Console.WriteLine("Ha ingresado mal , Presione ENTER para volver a intentarlo.");
                Console.ReadLine();
                ingresarProducto();
            }
        }
    }
}
