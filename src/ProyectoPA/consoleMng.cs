using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPA
{
    //bozzo//
    class consoleMng
    {
        
        //Atributos//
        private optionTree current;
        private optionTree MenuPrincipal;
        private static int id;
        private static List<optionTree> todadLasOpciones;

        //Getters y Setters//
        public static int Id
        {
            get { return id; }
            set { id = value; }
        }
        public static List<optionTree> TodadLasOpciones
        {
            get { return consoleMng.todadLasOpciones; }
            set { consoleMng.todadLasOpciones = value; }
        }
        
        //Contructor (main del console manager)//
        public consoleMng()
        {
            Introduccion();
            TodadLasOpciones = new List<optionTree>();

            //se crea el primer menu//
            optionTree raiz = new optionTree("main","raiz", null, Id);
            MenuPrincipal = raiz;
            current = raiz;
            //testing//
            Manager.AgregarProducto(3000, 2033, 4544, "ferrari rojo", "rojo", "vehiculo");
            Manager.AgregarProducto(30000, 20534, 452, "platano", "verde", "fruta");
            Manager.AgregarProducto(30000, 204, 4533 , "playStation" , "azul" , "juegos");

            //se agregan las 2 subopciones principales//
            raiz.agregarHijo("Productos"," Manager");
            raiz.agregarHijo("Registro", "Flux Manager");

            //opciones para productos//
            raiz.SubOptions[0].agregarHijo("Agregar Producto", "Opciones De Producto");
            raiz.SubOptions[0].agregarHijo("Ingresar Producto", "Opciones De Producto");
            raiz.SubOptions[0].agregarHijo("Agregar Set De Productos", "Opciones De Producto");
            raiz.SubOptions[0].agregarHijo("Modificar Producto", "Opciones De Producto");
            raiz.SubOptions[0].agregarHijo("Mostrar Lista De Productos", "Opciones De Producto");
                //opciones para modificar producto//
                 raiz.SubOptions[0].SubOptions[3].agregarHijo("Modicar Nombre", "Modificar ProductoHoja");
                 raiz.SubOptions[0].SubOptions[3].agregarHijo("Modicar Costo", "Modificar ProductoHoja");
                 raiz.SubOptions[0].SubOptions[3].agregarHijo("Modicar Tamaño", "Modificar ProductoHoja");
                 raiz.SubOptions[0].SubOptions[3].agregarHijo("Modicar Peso", "Modificar ProductoHoja"); ;
                 raiz.SubOptions[0].SubOptions[3].agregarHijo("Modicar Color", "Modificar ProductoHoja");
                 raiz.SubOptions[0].SubOptions[3].agregarHijo("Modicar Categoria", "Modificar ProductoHoja");
                
           
            //opciones para registro//
            

            //se navega en el programa//
            navegar();

            //dejar como comentario si no se esta programando//
            //mostrarTodadLasOpciones();Console.ReadLine();//
            
            
        }

        //Introduccion//
        public void Introduccion() {
            for (int i = 0; i < 50; i++)
            {
                if (i == 26)
                {
                    Console.WriteLine("                                           PROYECTO PROGRAMACION AVANZADA");
                }
                if (i == 27){
                
                    Console.WriteLine("                                                              UNIVERSIDAD DE LOS ANDES");
                   
                }
                if (i == 47)
                {
                    Console.WriteLine(" POR:");
                    Console.WriteLine(" Sebastian Bozzo:");
                    Console.WriteLine(" Sebastian Baixas");
                    Console.WriteLine(" Matias Valenzuela");

                }
                if (i == 49)
                {
                    Console.WriteLine("                                              Presiona ENTER para comenzar");
                }
                Console.WriteLine("");
            }
            Console.ReadLine();

        }
        //Metodos para la navegacion en el programa//
        public int seleccionar()
        {
            bool correcto = false;
            int retorno = -2;
            while (!correcto)
            {
                string input = Console.ReadLine();
                if (input != "*")
                {
                    try
                    {
                        int opcion = Convert.ToInt32(input);

                        //Se revisa si la opcion tiene subopciones//
                        if (current.SubOptions != null)
                        {

                            //El numero insertado debe estar entre las opciones//
                            if (0 < opcion && opcion <= current.SubOptions.Length)
                            {
                                //Caso en que se tiene mas de una opcion//
                                if (current.SubOptions.Length != 1)
                                {
                                    
                                    if (opcion <= current.SubOptions.Length )
                                    {
                                        retorno = opcion - 1;
                                        correcto = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("La Opcion Seleccionada no existe , presione ENTER para continuar");
                                    }
                                }
                                //Caso en que solo hay una Opcion//
                                else
                                {
                                    retorno = opcion - 1;
                                    correcto = true;
                                }
                            }

                            else
                            {
                                Console.WriteLine("La Opcion Seleccionada no existe , presione ENTER para continuar");

                            }
                        }
                        else
                        {
                            Console.WriteLine("La Opcion Seleccionada no existe , presione ENTER para continuar");

                        }

                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Has ingresado mal , presione ENTER para continuar");

                    }
                }

                else
                {
                    correcto = true;
                    retorno = -1;
                }
            }
            Console.WriteLine(retorno);

            return retorno;
        }
        public void navegar()
        {
            int seleccion;
            while (true)
            {
               
                current.show();
                if (current.OptionId != 0)
                {
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("  HINT: Si quieres volver al menu anterior, presiona *");
                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("  HINT: Si quieres salir del programa, presiona *");
                }
                seleccion = seleccionar();


                if (seleccion == -1)
                {
                    if (current.OptionId == 0)
                    {
                        break;
                    }
                    else
                    {
                        current = current.BackOption;
                    }
                }
                else
                {

                    current = current.SubOptions[seleccion];
                    Console.Clear();
                    current.show();
                    ejecutarMetodo(current.OptionId);


                }
                

            }
            
            
        }
        public void VolverAlMenuPrincipal()
        {
            this.current = MenuPrincipal;
        }

        //Metodos para realizar acciones(En ejecuta metodo , se guardan los metodos que pueden ser alcanzados a travez de la consola)//
        public string[] pedirDatos(string[] nombreDeLosParametros ){
            string[] input = new string[nombreDeLosParametros.Length];
            for (int i = 0; i < nombreDeLosParametros.Length; i++)
			{
			 Console.WriteLine("");
             Console.WriteLine("Ingrese " + nombreDeLosParametros[i]);
             input[i] = Console.ReadLine();
			}
            return input;
        }
        public void ejecutarMetodo(int OpcionId)
        {
            bool realizacionDeUnaAccion = false;
            //para que no quede tan grande el metodo ejecutar metodo//
            if (8<= OpcionId && OpcionId <= 13)
            {
                ejecutarModificarProductoHoja(OpcionId);
            }
            if (3 <= OpcionId && OpcionId <= 4)
            {
                ejecutarAgregarOIngresarProductoHoja(OpcionId);
            }
            if (7== OpcionId)
            {
                ImprimirProductos(OpcionId);
            }
            //CUANDO SE TERMINE LA ACCION//
            if (realizacionDeUnaAccion)
            {
                {

                }
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Accion realizada con exito , presiona ENTER para volver al menu principal");
                Console.ReadLine();
                VolverAlMenuPrincipal();
            }
        }
        public bool ejecutarAgregarOIngresarProductoHoja(int OpcionId) {
            bool realizacionDeUnaAccion = false;
            //Productos//
            //Agregar Producto//
            if (OpcionId == 3)
            {
                try
                {
                    //int costo, double tamaño, double peso, string nombre, string color, string categoria//
                    string[] nombreParametros3 = new string[] { "costo", "tamaño", "peso", "nombre", "color", "categoria" };
                    string[] parametros3 = pedirDatos(nombreParametros3);
                    Manager.AgregarProducto(Convert.ToInt32(parametros3[0]), Convert.ToDouble(parametros3[1]), Convert.ToDouble(parametros3[2]), Convert.ToString(parametros3[3]), Convert.ToString(parametros3[4]), Convert.ToString(parametros3[5]));
                    realizacionDeUnaAccion = true;
                }
                catch (FormatException)
                {
                    realizacionDeUnaAccion = false;
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("Has Ingresado Mal, La accion no se ha realizado, presiona ENTER para volver al menu principal");
                    Console.ReadLine();
                    VolverAlMenuPrincipal();
                }
            }
            //FIN//

            //Ingresar Producto//
            if (OpcionId == 4)
            {
                try
                {
                    //int costo, double tamaño, double peso, string nombre, string color, string categoria//
                    string[] nombreParametros4 = new string[] { "Id Del Producto", "Cantidad del producto a Agregar" };
                    string[] parametros4 = pedirDatos(nombreParametros4);
                    if (Manager.IngresarProducto(Convert.ToInt32(parametros4[0]), Convert.ToInt32(parametros4[1])))
                    {
                        realizacionDeUnaAccion = true;
                    }
                    else
                    {
                        realizacionDeUnaAccion = false;
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("El producto señalado no existe presiona ENTER para volver al menu principal");
                        Console.ReadLine();
                        VolverAlMenuPrincipal();
                    }
                }
                catch (FormatException)
                {
                    realizacionDeUnaAccion = false;
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("Has Ingresado Mal, La accion no se ha realizado, presiona ENTER para volver al menu principal");
                    Console.ReadLine();
                    VolverAlMenuPrincipal();
                }
            }
            //FIN//


            
            return realizacionDeUnaAccion;
        }
        public bool ejecutarModificarProductoHoja(int OpcionId)
        {
            bool realizacionDeUnaAccion = false;

            //Modificar Nombre//
            if (OpcionId == 7)
            {
                try
                {
                    //int costo, double tamaño, double peso, string nombre, string color, string categoria//
                    string[] nombreParametros7 = new string[] { "Id del Producto", "Nuevo Nombre" };
                    string[] parametros7 = pedirDatos(nombreParametros7);
                    if (Manager.ModificarNombre(Convert.ToInt32(parametros7[0]), parametros7[1]))
                    {
                        realizacionDeUnaAccion = true;
                    }
                    else
                    {
                        realizacionDeUnaAccion = false;
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("El producto señalado no existe presiona ENTER para volver al menu principal");
                        Console.ReadLine();
                        VolverAlMenuPrincipal();
                    }
                }
                catch (FormatException)
                {
                    realizacionDeUnaAccion = false;
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("Has Ingresado Mal, La accion no se ha realizado, presiona ENTER para volver al menu principal");
                    Console.ReadLine();
                    VolverAlMenuPrincipal();
                }
            }
            //FIN//

            //Modificar Costo//
            if (OpcionId == 8)
            {
                try
                {
                    //int costo, double tamaño, double peso, string nombre, string color, string categoria//
                    string[] nombreParametros8 = new string[] { "Id del Producto", "Nuevo Costo" };
                    string[] parametros8 = pedirDatos(nombreParametros8);
                    if (Manager.ModificarCosto(Convert.ToInt32(parametros8[0]), Convert.ToInt32(parametros8[1])))
                    {
                        realizacionDeUnaAccion = true;
                    }
                    else
                    {
                        realizacionDeUnaAccion = false;
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("El producto señalado no existe presiona ENTER para volver al menu principal");
                        Console.ReadLine();
                        VolverAlMenuPrincipal();
                    }
                }
                catch (FormatException)
                {
                    realizacionDeUnaAccion = false;
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("Has Ingresado Mal, La accion no se ha realizado, presiona ENTER para volver al menu principal");
                    Console.ReadLine();
                    VolverAlMenuPrincipal();
                }
            }
            //FIN//

            //Modificar Tamaño//
            if (OpcionId == 9)
            {
                try
                {
                    //int costo, double tamaño, double peso, string nombre, string color, string categoria//
                    string[] nombreParametros9 = new string[] { "Id del Producto", "Nuevo Tamaño" };
                    string[] parametros9 = pedirDatos(nombreParametros9);
                    if (Manager.ModificarTamaño(Convert.ToInt32(parametros9[0]), Convert.ToDouble(parametros9[1])))
                    {
                        realizacionDeUnaAccion = true;
                    }
                    else
                    {
                        realizacionDeUnaAccion = false;
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("El producto señalado no existe presiona ENTER para volver al menu principal");
                        Console.ReadLine();
                        VolverAlMenuPrincipal();
                    }
                }
                catch (FormatException)
                {
                    realizacionDeUnaAccion = false;
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("Has Ingresado Mal, La accion no se ha realizado, presiona ENTER para volver al menu principal");
                    Console.ReadLine();
                    VolverAlMenuPrincipal();
                }
            }
            //FIN//

            //Modificar Peso//
            if (OpcionId == 10)
            {
                try
                {
                    //int costo, double tamaño, double peso, string nombre, string color, string categoria//
                    string[] nombreParametros10 = new string[] { "Id del Producto", "Nuevo Peso" };
                    string[] parametros10 = pedirDatos(nombreParametros10);
                    if (Manager.ModificarPeso(Convert.ToInt32(parametros10[0]), Convert.ToDouble(parametros10[1])))
                    {
                        realizacionDeUnaAccion = true;
                    }
                    else
                    {
                        realizacionDeUnaAccion = false;
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("El producto señalado no existe presiona ENTER para volver al menu principal");
                        Console.ReadLine();
                        VolverAlMenuPrincipal();
                    }
                }
                catch (FormatException)
                {
                    realizacionDeUnaAccion = false;
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("Has Ingresado Mal, La accion no se ha realizado, presiona ENTER para volver al menu principal");
                    Console.ReadLine();
                    VolverAlMenuPrincipal();
                }
            }
            //Modificar Color//
            if (OpcionId == 11)
            {
                try
                {
                    //int costo, double tamaño, double peso, string nombre, string color, string categoria//
                    string[] nombreParametros11 = new string[] { "Id del Producto", "Nuevo Color" };
                    string[] parametros11 = pedirDatos(nombreParametros11);
                    if (Manager.ModificarColor(Convert.ToInt32(parametros11[0]), parametros11[1]))
                    {
                        realizacionDeUnaAccion = true;
                    }
                    else
                    {
                        realizacionDeUnaAccion = false;
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("El producto señalado no existe presiona ENTER para volver al menu principal");
                        Console.ReadLine();
                        VolverAlMenuPrincipal();
                    }
                }
                catch (FormatException)
                {
                    realizacionDeUnaAccion = false;
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("Has Ingresado Mal, La accion no se ha realizado, presiona ENTER para volver al menu principal");
                    Console.ReadLine();
                    VolverAlMenuPrincipal();
                }
            }
            //FIN//

            //Modificar Categoria//
            if (OpcionId == 12)
            {
                try
                {
                    //int costo, double tamaño, double peso, string nombre, string color, string categoria//
                    string[] nombreParametros12 = new string[] { "Id del Producto", "Nuevo Categoria" };
                    string[] parametros12 = pedirDatos(nombreParametros12);
                    if (Manager.ModificarCategoria(Convert.ToInt32(parametros12[0]), parametros12[1]))
                    {
                        realizacionDeUnaAccion = true;
                    }
                    else
                    {
                        realizacionDeUnaAccion = false;
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("El producto señalado no existe presiona ENTER para volver al menu principal");
                        Console.ReadLine();
                        VolverAlMenuPrincipal();
                    }
                }
                catch (FormatException)
                {
                    realizacionDeUnaAccion = false;
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("Has Ingresado Mal, La accion no se ha realizado, presiona ENTER para volver al menu principal");
                    Console.ReadLine();
                    VolverAlMenuPrincipal();
                }
            }

            return realizacionDeUnaAccion;
        }
        public bool OpcionesDeSet(int OpcionId) {
            bool realizacionDeUnaAccion = false;
            //Productos//
            //Agregar Producto//
            if (OpcionId == 3)
            {
                try
                {
                    //int costo, double tamaño, double peso, string nombre, string color, string categoria//
                    string[] nombreParametros3 = new string[] { "costo", "tamaño", "peso", "nombre", "color", "categoria" };
                    string[] parametros3 = pedirDatos(nombreParametros3);
                   
                    realizacionDeUnaAccion = true;
                }
                catch (FormatException)
                {
                    realizacionDeUnaAccion = false;
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("Has Ingresado Mal, La accion no se ha realizado, presiona ENTER para volver al menu principal");
                    Console.ReadLine();
                    VolverAlMenuPrincipal();
                }
            }
            //FIN//
            return realizacionDeUnaAccion;
        }

        public bool ImprimirProductos(int OptionId) {
            bool realizacionDeUnaAccion = false;
            /*private static int idcount = 0;
        private int id;
        private int costo;
        private double tamaño;
        private double peso;
        private string nombre;
        private string imagePath;*/
            
                Console.Clear();
                string[] parametros = new string[] { "ID", "Nombre", "Costo", "Tamaño","Peso" };
                int[] formato = new int[] { 12, 30, 12, 12 ,12};
                int porteDeLaLinea = TableMaker.ImprimirParametros(parametros, formato);
                string[] ID = new string[Manager.Productos.Count];
                string[] Nombre = new string[Manager.Productos.Count];
                string[] Costo = new string[Manager.Productos.Count];
                string[] Tamaño = new string[Manager.Productos.Count];
                string[] Peso = new string[Manager.Productos.Count];
                for (int i = 0; i < Manager.Productos.Count; i++)
                {
                    ID[i] = Manager.Productos.ElementAt(i).Id + "";
                    Nombre[i] = Manager.Productos.ElementAt(i).Nombre;
                    Costo[i] = Manager.Productos.ElementAt(i).Costo + "";
                    Tamaño[i] = Manager.Productos.ElementAt(i).Tamaño + "";
                    Peso[i] = Manager.Productos.ElementAt(i).Peso + "";

                    ID[i] = TableMaker.darFormatoDeColumna(12, ID[i]);
                    Nombre[i] = TableMaker.darFormatoDeColumna(30, Nombre[i]);
                    Costo[i] = TableMaker.darFormatoDeColumna(12, Costo[i]);
                    Tamaño[i] = TableMaker.darFormatoDeColumna(12, Tamaño[i]);
                    Peso[i] = TableMaker.darFormatoDeColumna(12, Peso[i]);
                    string[] output = new string[] { ID[i], Nombre[i], Costo[i], Tamaño[i] , Peso[i] };
                    TableMaker.ImprimirFila(output);
                    Console.WriteLine("");
                }
                for (int i = 0; i < porteDeLaLinea; i++)
                {
                    Console.Write("-");
                }
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Presione ENTER para volver al menu principal");
                Console.ReadLine();
                VolverAlMenuPrincipal();
                
                
            

            return realizacionDeUnaAccion;
        }
        
        //metodos que sirven solo para quien modifique el programa//
        private void mostrarTodadLasOpciones()
        {
            Console.Clear();
            string[] parametros = new string[] { "OptionID", "Nombre", "Categoria", "Subopciones" };
            int[] formato = new int[] {12,30,30,12 };
            TableMaker.ImprimirParametros(parametros, formato);
            foreach (optionTree ot in TodadLasOpciones)
            {
                ot.showInfo();
                Console.WriteLine("");

            }
        }
    }
}
