using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPA
{
    class Manager
    {
        private Producto[] productos;

        private int Idcount;

        public Manager()
        {
            productos = new Producto[0];

            Idcount = 0;
        }
        /************************agregar un nuevo tipo de producto*********************************************/
        public void agregarNuevoTipoDeProducto()
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
                string[] parametros = new string[6] {null, null,null,null,null, null };
                for (int i = 0; i < 6; i++){
                    string aux = null;
                    if (i ==0){aux = "el nombre";}
                    if (i == 1){aux = "el costo";}
                    if (i == 2){aux = "el tamaño";}
                    if (i == 3){aux = "el peso";}
                    if (i == 4){aux = "el color";}
                    if (i == 5){aux = "la categoria";}
                    Console.WriteLine("Inserte "+ aux +" del Producto:");
                    parametros[i] = Console.ReadLine();
                    Console.WriteLine("");
                }
                string nombre = parametros[0];
                int costo = Convert.ToInt32(parametros[1]);
                double tamaño = Convert.ToDouble(parametros[2]);
                double peso = Convert.ToDouble(parametros[3]);
                string color = parametros[4];
                string categoria = parametros[5];
                agregarProducto(new ProductoHoja(Idcount, costo, tamaño, peso, nombre, color, categoria, 0));
                Console.WriteLine("Se ha agregado un nuevo tipo producto");
               
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Lo hiso mal, hagalo denuevo");
                Console.WriteLine("Presione ENTER para continuar");
                Console.ReadLine();
                agregarNuevoTipoDeProducto();

            }
            Idcount++;
        }

        /************************agregar un nuevo tipo de producto*********************************************/
        /*se solo usa en el metodo de agregar nuevo tipo de producto*/
        private void agregarProducto(Producto productoAAgregar)
        {
            Producto[] aux = new Producto[productos.Length + 1];
            for (int i = 0; i < productos.Length; i++)
            {
                aux[i] = productos[i];
            }
            aux[aux.Length - 1] = productoAAgregar;
            productos = aux;
        }


        /********************************ingresar producto****************************************************/
        public void ingresarProducto()
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
                    bool correcto = false;
                    for (int i = 0; i < productos.Length; i++)
                    {

                        if (productos[i].Id == IdDelProducto)
                        {
                            Console.WriteLine("Ingresando Producto");
                            productos[IdDelProducto].AgregarStock(cantidad);
                            correcto = true;
                            Console.WriteLine("Producto Ingresado");
                            break;
                        }
                    }
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
            
            catch(Exception e){
                Console.WriteLine("Se produjo un Error , vuelba a intentarlo");
                Console.WriteLine("Presione ENTER Para Continuar");
                Console.ReadLine();
                }
            


        }

/********************************Mostrar productos en una tabla****************************************************/

        public void mostrarProductos()
        {
            
            Console.WriteLine("         ID         |       Nombre       |      Cantidad      |");
            for (int i = 0; i < productos.Length; i++)
            {
                string nombre, ID, Cantidad;
                ID = " " + productos[i].Id + "";
                //Se da un formato para que las columnas considan//
                while (ID.Length < 20)
                {
                    ID =ID + " ";
                    if (ID.Length < 20)
                    {
                        ID = " " + ID;
                    }
                }

                nombre = " " + productos[i].Nombre;
                
                while (nombre.Length < 20)
                {
                    nombre = nombre + " ";
                    if (nombre.Length < 20)
                    {
                        nombre= " " + nombre;
                    } 
                }

                Cantidad = " " + productos[i].Cantidad + "";
                while (Cantidad.Length < 20)
                {
                    Cantidad = Cantidad + " ";
                    if (Cantidad.Length < 20)
                    {
                        Cantidad= " " + Cantidad;
                    }
                   
                }
                Console.WriteLine(ID +"|"+ nombre +"|"+ Cantidad + "|");
             

            }
          
        }
/********************************Ver cualidades de un producto****************************************************/
        public void verCualidadesDeUnProducto()
        {
            Console.Clear();
            Console.WriteLine("Ingrese el Id Del Producto");
            Console.WriteLine("");
            int IdDelProducto = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            bool correcto = false;
            for (int i = 0; i < productos.Length; i++)
            {

                if (productos[i].Id == IdDelProducto)
                {
                    Console.Clear();
                    productos[IdDelProducto].imprimirDatos();
                    correcto = true;
                    break;
                }
            }
            if (!correcto)
            {
                Console.WriteLine("ERROR , no se encuentra el producto");
                Console.WriteLine("Presione ENTER Para Continuar");
                Console.ReadLine();
            }         
        }
    }
}
