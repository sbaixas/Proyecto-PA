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
            Console.SetWindowSize(130, 50);
            Introduccion();
            TodadLasOpciones = new List<optionTree>();

            //se crea el primer menu//
            optionTree raiz = new optionTree("Enterprise Managment", "raiz", null, Id);
            MenuPrincipal = raiz;
            current = raiz;
            //testing//
            Manager.AgregarCategoria("cosa");
            Manager.AgregarProducto(3000, 2033, 4544, "ferrari rojo", "rojo", 0);
            Manager.AgregarProducto(30000, 20534, 452, "platano", "verde", 0);
            Manager.AgregarProducto(30000, 204, 4533, "playStation", "azul",0);

            //se agregan las 5 subopciones principales//
            raiz.agregarHijo("Productos", " Manager");
            raiz.agregarHijo("Registro", "Flux Manager");
            raiz.agregarHijo("Cargar/Guardad", " Main");
            raiz.agregarHijo("Comprar/Vender Productos", "Comprar/Vender");
            {//cargar/guardar//
                raiz.SubOptions[2].agregarHijo("Cargar", "Cargar/Guardar");
                raiz.SubOptions[2].agregarHijo("Guardar", "Cargar/Guardar");
            }
            {//Comprar o Vender//
                raiz.SubOptions[3].agregarHijo("Comprar", "Comprar/Vender");
                raiz.SubOptions[3].agregarHijo("Vender", "Comprar/Vender");
            }            
            //opciones para productos//
            {
                raiz.SubOptions[0].agregarHijo("Agregar Producto", "Opciones De Producto");
                raiz.SubOptions[0].agregarHijo("Agregar Set De Productos", "Opciones De Producto");  
                raiz.SubOptions[0].agregarHijo("Eliminar Producto", "Opciones De Producto");
                raiz.SubOptions[0].agregarHijo("Modificar Producto", "Opciones De Producto");
                raiz.SubOptions[0].agregarHijo("Modificar Set de Producto", "Opciones De Producto");
                raiz.SubOptions[0].agregarHijo("Agregar Categoria", "Opciones De Producto");
                raiz.SubOptions[0].agregarHijo("Eliminar Categoria", "Opciones De Producto");
                //Opciones Para Imprimir productos(Detalles/Todos)//
                {
                    raiz.SubOptions[0].agregarHijo("Mostrar Lista De Productos", "Opciones De Producto");
                    raiz.SubOptions[0].agregarHijo("Mostrar Lista De Categorias", "Opciones De Producto");
                    raiz.SubOptions[0].agregarHijo("Mostrar Detalles de Producto", "Opciones De Producto");
                    
                }
                //Opciones Para modificar set de productos(Detalles/Todos)//
                {
                    raiz.SubOptions[0].SubOptions[4].agregarHijo("Modicar Nombre", "Modificar set de productos");
                    raiz.SubOptions[0].SubOptions[4].agregarHijo("Agregar Producto al Set", "Modificar set de productos");
                    raiz.SubOptions[0].SubOptions[4].agregarHijo("Eliminar Producto Del Set", "Modificar set de productos");
                    raiz.SubOptions[0].SubOptions[4].agregarHijo("Modificar Descuento", "Modificar set de productos");
                }

                {//opciones para modificar producto//

                    raiz.SubOptions[0].SubOptions[3].agregarHijo("Modicar Nombre", "Modificar ProductoHoja");
                    raiz.SubOptions[0].SubOptions[3].agregarHijo("Modicar Costo", "Modificar ProductoHoja");
                    raiz.SubOptions[0].SubOptions[3].agregarHijo("Modicar Tamaño", "Modificar ProductoHoja");
                    raiz.SubOptions[0].SubOptions[3].agregarHijo("Modicar Peso", "Modificar ProductoHoja"); ;
                    raiz.SubOptions[0].SubOptions[3].agregarHijo("Modicar Color", "Modificar ProductoHoja");
                    raiz.SubOptions[0].SubOptions[3].agregarHijo("Modicar Categoria", "Modificar ProductoHoja");
                }
            }

            //opciones para registro//
            {
                raiz.SubOptions[1].agregarHijo("Ver historial De Ventas", "Opciones De Registro");
                raiz.SubOptions[1].agregarHijo("Ver Historial De Ingresos", "Opciones De Registro");
                raiz.SubOptions[1].agregarHijo("Ver Ranking", "Opciones De Registro");
                {//opciones de ver historial de ventas//
                    raiz.SubOptions[1].SubOptions[0].agregarHijo("Todo", "Historial De Ventas");
                    raiz.SubOptions[1].SubOptions[0].agregarHijo("Historial en Una Fecha En Particular", "Historial De Ventas");
                }
                {//opciones de ver historial de Ingresos//
                    raiz.SubOptions[1].SubOptions[1].agregarHijo("Todo", "Historial De Ingresos");
                    raiz.SubOptions[1].SubOptions[1].agregarHijo("Historial en Una Fecha En Particular", "Historial De Ingresos");
                }
            }
            //se navega en el programa//
            navegar();
            //dejar como comentario si no se esta programando//
            //mostrarTodadLasOpciones(); Console.ReadLine();//
        }

        //Introduccion//
        public void Introduccion()
        {
            for (int i = 0; i < 50; i++)
            {
                if (i == 26)
                {
                    Console.WriteLine("                                           PROYECTO PROGRAMACION AVANZADA");
                }
                if (i == 27)
                {

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

                                    if (opcion <= current.SubOptions.Length)
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
            return retorno;
        }
        public void navegar()
        {
            int seleccion;
            while (true)
            {

                showOption();
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
                    showOption();
                    ejecutarMetodo(current.OptionId);


                }


            }


        }//testing//
        public void VolverAlMenuPrincipal()
        {
            this.current = MenuPrincipal;
        }
        public void showOption()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("  " + current.Titulo);
            for (int l = 0; l < current.Titulo.Length + 4; l++)
            {
                Console.Write("-");
            }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");

            if (current.SubOptions != null)
            {
                Console.WriteLine(" Opciones:");
                string candidato = current.SubOptions[0].Titulo;
                for (int i = 0; i < current.SubOptions.Length; i++)
                {
                    if (candidato.Length <= current.SubOptions[i].Titulo.Length) { candidato = current.SubOptions[i].Titulo; }
                }
                if (candidato.Length < 10) { candidato = " Opciones:"; }
                for (int j = 0; j < candidato.Length + 6; j++)
                {
                    Console.Write("-");
                }

                for (int k = 0; k < current.SubOptions.Length; k++)
                {
                    if (current.SubOptions[k].Titulo == "Volver" || current.SubOptions[k].Titulo == "Salir")
                    {
                        Console.WriteLine("");
                        Console.WriteLine("");
                        Console.WriteLine("  *" + ") " + current.SubOptions[k].Titulo);
                    }

                    else
                    {
                        Console.WriteLine("");
                        Console.WriteLine("");
                        int aux = k + 1;
                        Console.WriteLine("  " + aux + "" + ") " + current.SubOptions[k].Titulo);
                    }
                }
            }
        }

        //Metodos para realizar acciones(en ejecutar metodo , se guardan los metodos que pueden ser alcanzados a travez de la consola)//
        public string[] pedirDatos(string[] nombreDeLosParametros)
        {
            string[] input = new string[nombreDeLosParametros.Length];
            for (int i = 0; i < nombreDeLosParametros.Length; i++)
            {
                Console.WriteLine("");
                Console.WriteLine("Ingrese " + nombreDeLosParametros[i]);
                input[i] = Console.ReadLine();
            }
            return input;
        }
        public string pedirDatos(string nombreDelParametro)
        {
            Console.WriteLine("");
            Console.WriteLine("Ingrese " + nombreDelParametro);
            string input = Console.ReadLine();
            return input;
        }
        public void ejecutarMetodo(int OpcionId)
        {
            bool realizacionDeUnaAccion = false;//se usara para propositos futuros//
            //ejecutarAgregarOIngresarProductos []//
            //modificar producto []//
            
            //para Productos//
            if (5 == OpcionId || 6 == OpcionId) { realizacionDeUnaAccion = cargarOguardar(OpcionId); }
            if (9 <= OpcionId && OpcionId <= 11) { realizacionDeUnaAccion = ejecutarAgregarOEliminarProductos(OpcionId); }
            if (23 <= OpcionId && OpcionId <= 28) { realizacionDeUnaAccion = ejecutarModificarProductoHoja(OpcionId); }
            if (7 == OpcionId || OpcionId == 8) { realizacionDeUnaAccion = comprarOVender(OpcionId); }
            if (16<= OpcionId && OpcionId <= 17) { realizacionDeUnaAccion = Imprimir(OpcionId); }
            if (19 <= OpcionId && OpcionId <= 22) { realizacionDeUnaAccion = modificarSetDeProductos(OpcionId); }
            if (14 == OpcionId || OpcionId == 15) { realizacionDeUnaAccion = ejecutarAgregarOEliminarCategoria(OpcionId); }
            if (31 <= OpcionId && OpcionId <= 35) { realizacionDeUnaAccion = Reportes(OpcionId); }

            //para Registro//
            //CUANDO SE TERMINE LA ACCION///  
        }
        public bool modificarSetDeProductos(int OpcionId) {
            bool realizacionDeUnaAccion = false;
            int nombre, agregarProducto, modificarDscto, eliminarSetDeProducto;
            agregarProducto = 10;
            modificarDscto = 22;
            eliminarSetDeProducto = 21;
            nombre = 19;

            //Modificar nombre//
            if (OpcionId == nombre)
            {
                {
                    try
                    {
                      
                        string[] nombreParametros = new string[] { "Id del Set De Productos", "Nuevo Nombre" };
                        string[] parametros = pedirDatos(nombreParametros);
                        if (Manager.ModificarNombre(Convert.ToInt32(parametros[0]), parametros[1]))
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
                    catch (IndexOutOfRangeException)
                    {
                        realizacionDeUnaAccion = false;
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("Has Ingresado Mal, La accion no se ha realizado, presiona ENTER para volver al menu principal");
                        Console.ReadLine();
                        VolverAlMenuPrincipal();
                    }
                }
            }
            //FIN//


            //agregar Producto//
            if (OpcionId == agregarProducto)
            {
                {
                    try
                    {                     
                        string[] nombreParametros = new string[] { "Id del set , Id Del Producto" , "Cantidad del producto a agregar al Set" };
                        string[] parametros = pedirDatos(nombreParametros);
                        if (Manager.ModificarSetAgregar(Convert.ToInt32(parametros[0]), Convert.ToInt32(parametros[1]), Convert.ToInt32(parametros[2])))
                        {
                            realizacionDeUnaAccion = true;
                        }
                        else
                        {
                            realizacionDeUnaAccion = false;
                            Console.Clear();
                            Console.WriteLine();
                            Console.WriteLine("Hubo un error al ingresar los datos, presione ENTER para continuar");
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
                    catch (IndexOutOfRangeException)
                    {
                        realizacionDeUnaAccion = false;
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("Has Ingresado Mal, La accion no se ha realizado, presiona ENTER para volver al menu principal");
                        Console.ReadLine();
                        VolverAlMenuPrincipal();
                    }
                }
            }
            //FIN//


            //Modificar Descuento//
            if (OpcionId == modificarDscto)
            {
                {
                    try
                    {                     
                        string[] nombreParametros = new string[] { "Id del set ,Nuevo Descuento" };
                        string[] parametros = pedirDatos(nombreParametros);
                        if (Manager.ModificarDescuento(Convert.ToInt32(parametros[0]), Convert.ToInt32(parametros[1])))
                        {
                            realizacionDeUnaAccion = true;
                        }
                        else
                        {
                            realizacionDeUnaAccion = false;
                            Console.Clear();
                            Console.WriteLine();
                            Console.WriteLine("Es probable que el set indicado no exista, presione ENTER para continuar");
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
                    catch (IndexOutOfRangeException)
                    {
                        realizacionDeUnaAccion = false;
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("Has Ingresado Mal, La accion no se ha realizado, presiona ENTER para volver al menu principal");
                        Console.ReadLine();
                        VolverAlMenuPrincipal();
                    }
                }
            }
            //FIN//


            
            //Eliminar Producto//
            if (OpcionId == eliminarSetDeProducto)
            {
                {
                    try
                    {                     
                        string[] nombreParametros = new string[] { "Id del set , Id del producto a eliminar" };
                        string[] parametros = pedirDatos(nombreParametros);
                        if (Manager.ModificarSetEliminar(Convert.ToInt32(parametros[0]), Convert.ToInt32(parametros[1])))
                        {
                            realizacionDeUnaAccion = true;
                        }
                        else
                        {
                            realizacionDeUnaAccion = false;
                            Console.Clear();
                            Console.WriteLine();
                            Console.WriteLine("El set o el producto señalado no existe, presione ENTER para continuar");
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
                    catch (IndexOutOfRangeException)
                    {
                        realizacionDeUnaAccion = false;
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("Has Ingresado Mal, La accion no se ha realizado, presiona ENTER para volver al menu principal");
                        Console.ReadLine();
                        VolverAlMenuPrincipal();
                    }
                }
            }
            //FIN//
            return realizacionDeUnaAccion;
        
        }
        public bool ejecutarAgregarOEliminarProductos(int OpcionId)
        {
            bool realizacionDeUnaAccion = false;
            int agregarProducto, AgregarSetDeProducto, eliminarProducto;
            agregarProducto = 9;
            AgregarSetDeProducto = 10;
            eliminarProducto = 11;
            //Productos//
            //Agregar Producto//
            if (OpcionId == agregarProducto)
            {
                {
                    {
                        try
                        {
                            //int costo, double tamaño, double peso, string nombre, string color, string categoria//
                            Console.WriteLine("");
                            Console.WriteLine("Recuerde un numero de categoria para el producto");
                            Console.WriteLine("");
                            mostrarTablaDeCategorias();
                            Console.WriteLine("");
                            Console.WriteLine("Presione ENTER para continuar");
                            Console.ReadLine();
                            Console.Clear();
                            string[] nombreParametros = new string[] { "Id de la categoria", "tamaño", "peso", "nombre", "color", "Costo" };
                            string[] parametros = pedirDatos(nombreParametros);
                            
                           realizacionDeUnaAccion = Manager.AgregarProducto(Convert.ToInt32(parametros[5]), Convert.ToDouble(parametros[1]), Convert.ToDouble(parametros[2]), Convert.ToString(parametros[3]), Convert.ToString(parametros[4]), Convert.ToInt32(parametros[0]));
                           if (!realizacionDeUnaAccion)
                           {
                            Console.Clear();
                            Console.WriteLine();
                            Console.WriteLine("Error , Has ingresado mal o es posible que la categoria seleccionada no exista, presiona ENTER para volver al menu principal");
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
                }
            }
            //FIN//

            //Agregar set de Productos//
            if (OpcionId == AgregarSetDeProducto)
            {
                {
                    {
                        try
                        {
                            string[] nombreParametros = new string[] { "Nombre del nuevo set", "Descuento" };
                            string[] parametrosFirst = pedirDatos(nombreParametros);
                            Console.Clear();
                            Console.WriteLine("");
                            Console.WriteLine("Ahora comenzaremos a agregar productos al nuevo set");
                            Console.WriteLine("Ingrese los productos que se agregaran al set de la forma" + "\"id del producto , cantidad que se desee agregar\"");
                            Console.WriteLine("Cuando termine de agregar los producto , escriba" + "\" exit\"");
                            List<int> ids = new List<int>();
                            List<int> cantidades = new List<int>();
                            while (true)
                            {
                                string input = Console.ReadLine();
                                if (input != "exit")
                                {

                                    string[] inputProcesed = input.Split(',');
                                    ids.Add(Convert.ToInt32(inputProcesed[0]));
                                    cantidades.Add(Convert.ToInt32(inputProcesed[1]));

                                }


                                else
                                {
                                    break;
                                }
                            }
                            if (ids.Count == cantidades.Count)
                            {
                                // public static void AgregarSet(int descuento, List<int> cantidades, List<int> ids, string nombre)//
                                Manager.AgregarSet(Convert.ToInt32(parametrosFirst[1]), cantidades, ids, parametrosFirst[0]);
                                realizacionDeUnaAccion = true;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Hubo un error en la ejecucion de la accion, Presiona ENTER para volver al menu principal");
                                Console.ReadLine();
                                VolverAlMenuPrincipal();
                            }
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
                    
                }
            }
            //FIN//
            
            //eliminar Producto//
            if (eliminarProducto == OpcionId)
            {
                try
                {
                    int id = Convert.ToInt32(pedirDatos("Id del Producto"));
                    Manager.EliminarProducto(id);
                    Console.Clear();
                    Console.WriteLine("");
                    Console.WriteLine(" Producto Eliminado, presiona ENTER para volver al menu principal");
                    Console.ReadLine();
                    VolverAlMenuPrincipal();
                    
                }
                catch( FormatException){
                    Console.Clear();
                    Console.WriteLine("");
                    Console.WriteLine("Has Ingresado Mal, La accion no se ha realizado, presiona ENTER para volver al menu principal");
                    Console.ReadLine();

                    VolverAlMenuPrincipal();
                }
                catch (IndexOutOfRangeException)
                {
                    Console.Clear();
                    Console.WriteLine("");
                    Console.WriteLine("El producto señalizado no existe presiona ENTER para volver al menu principal");
                    Console.ReadLine();
                    Console.Clear();
                    VolverAlMenuPrincipal();
                }
            }
            //FIN//

            return realizacionDeUnaAccion;
        }
        public bool ejecutarModificarProductoHoja(int OpcionId)
        {
            bool realizacionDeUnaAccion = false;
            int costo, peso, categoria, tamaño, nombre, color;
            costo = 24;
            peso = 26;
            categoria = 28;
            tamaño = 25;
            nombre = 23;
            color = 27;
            //Modificar Nombre//
            if (OpcionId == nombre)
            {
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
            }
            //FIN//

            //Modificar Costo//
            if (OpcionId == costo)
            {
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
            }
            //FIN//

            //Modificar Tamaño//
            if (OpcionId == tamaño)
            {
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
            }
            //FIN//

            //Modificar Peso//
            if (OpcionId == peso)
            {
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
            }
            //Modificar Color//
            if (OpcionId == color)
            {
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
            }
            //FIN//

            //Modificar Categoria//
            if (OpcionId == categoria)
            {
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
            }

            return realizacionDeUnaAccion;
        }
        public void imprimirTablaDeProductos()
        {
            string[] parametros = new string[] { "ID", "Nombre", "Costo", "Tamaño", "Peso" };
            int[] formato = new int[] { 12, 30, 12, 12, 12 };
            string linea = TableMaker.ImprimirParametros(parametros, formato);
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
                string[] output = new string[] { ID[i], Nombre[i], Costo[i], Tamaño[i], Peso[i] };
                TableMaker.ImprimirFila(output);
                Console.WriteLine("");
            }
            Console.WriteLine(linea);
        }
        public bool Imprimir(int OptionId)
        {
     
            bool realizacionDeUnaAccion = false;
            int imprimirTablaProductos, imprimirDetallesDeProducto, imprimirListaDeCategorias;
            imprimirTablaProductos = 16;
            imprimirDetallesDeProducto = 18;
            imprimirListaDeCategorias = 17;

            //Imprimir tabla de productos//
            if (OptionId == imprimirTablaProductos)
            {
                {
                    Console.Clear();
                    imprimirTablaDeProductos();
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("Presione ENTER para volver al menu principal");
                    Console.ReadLine();
                    VolverAlMenuPrincipal();
                    realizacionDeUnaAccion = true;
                }
            }
            //Imprimir Detalles de un Producto//
            if (OptionId == imprimirDetallesDeProducto)
            {
                {
                    try
                    {
                        Console.Clear();
                        int i = Convert.ToInt32(pedirDatos("Id Del Producto"));

                        Console.Clear();
                        Console.WriteLine("");
                        Console.WriteLine("  " + Manager.Productos.ElementAt(i).Nombre + "");
                        for (int j = 0; j < Manager.Productos.ElementAt(i).Nombre.Length + 2; j++)
                        {
                            Console.Write("-");
                        }
                        Console.WriteLine(" ");
                        Console.WriteLine(" - Id: " + Manager.Productos.ElementAt(i).Id + "");
                        Console.WriteLine("");
                        Console.WriteLine(" - Costo " + Manager.Productos.ElementAt(i).Costo + "");
                        Console.WriteLine("");
                        Console.WriteLine(" - Tamaño: " + Manager.Productos.ElementAt(i).Tamaño + "");
                        Console.WriteLine("");
                        Console.WriteLine(" - Peso: " + Manager.Productos.ElementAt(i).Peso + "");
                        Console.WriteLine("");
                        try
                        {//para producto hoja//
                            ProductoHoja x = (ProductoHoja)Manager.Productos.ElementAt(i);
                            Console.WriteLine(" - Categoria: " + x.Categoria);
                            Console.WriteLine("");
                            Console.WriteLine(" - Color: " + x.Color);
                            Console.WriteLine("");
                            Console.WriteLine(" - Cantidad: " + x.Cantidad);
                            if (x.Cantidad < 20)
                            {
                                Console.WriteLine("ADVERTENCIA: QUEDAN POCOS " + x.Nombre + "!");
                            }
                            Console.WriteLine("");
                            realizacionDeUnaAccion = true;
                        }
                        catch (InvalidCastException)
                        {
                            //si no es un producto hoja , es un set de producto y no , hay un error//
                            SetDeProducto x = (SetDeProducto)Manager.Productos.ElementAt(i);
                            Console.WriteLine(" - Descuento por el Set: " + x.Descuento);
                            Console.WriteLine("");
                            string[] titulo = new string[] { "Producto", "Candidad" };
                            int[] formato = new int[] { 30, 12 };
                            TableMaker.ImprimirParametros(titulo, formato);
                            for (int k = 0; k < x.Productos.Count; k++)
                            {
                                string[] columnas = new string[] { TableMaker.darFormatoDeColumna(30, x.Productos.ElementAt(k).Nombre), TableMaker.darFormatoDeColumna(12, x.Cantidades.ElementAt(k)) };
                                TableMaker.ImprimirFila(columnas);
                            }
                        }
                        Console.WriteLine("");
                        Console.WriteLine(" Presione ENTER para volver al menu principal");
                        Console.ReadLine();
                        realizacionDeUnaAccion = true;
                        VolverAlMenuPrincipal();
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        realizacionDeUnaAccion = false;
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("El elemento señalado no existe, presiona ENTER para volver al menu principal");
                        Console.ReadLine();
                        VolverAlMenuPrincipal();

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
                    catch (NullReferenceException)
                    {
                        realizacionDeUnaAccion = false;
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("El producto señalado no existe , presiona ENTER para volver al menu principal");
                        Console.ReadLine();
                        VolverAlMenuPrincipal();
                    }
                }
            }
            //mostrar categorias en tabla//
            if (OptionId == imprimirListaDeCategorias)
            {

                {
                    Console.Clear();
                    mostrarTablaDeCategorias();
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("Presione ENTER para volver al menu principal");
                    Console.ReadLine();
                    VolverAlMenuPrincipal();
                    realizacionDeUnaAccion = true;
                }
            }
            return realizacionDeUnaAccion;
        }
        public void mostrarTablaDeCategorias() {
                    string[] parametros = new string[] { "Numero De Categoria", " Nombre de La Categoria" };
                    int[] formato = new int[] { 15, 50 };
                    string linea = TableMaker.ImprimirParametros(parametros, formato);
                    string[] ID = new string[Manager.Categorias.Count];
                    string[] Nombre = new string[Manager.Categorias.Count];

                    for (int i = 0; i < Manager.Categorias.Count; i++)
                    {
                        ID[i] = i + "";
                        Nombre[i] = Manager.Categorias.ElementAt(i);
                        ID[i] = TableMaker.darFormatoDeColumna(15, ID[i]);
                        Nombre[i] = TableMaker.darFormatoDeColumna(50, Nombre[i]);

                        string[] output = new string[] { ID[i], Nombre[i] };
                        TableMaker.ImprimirFila(output);
                        Console.WriteLine("");
                    }
                    Console.WriteLine(linea);
        }
        public bool cargarOguardar(int optionId)
        {
            bool realizacionDeUnaAccion = false;
            int cargar, guardar;
            cargar = 5;
            guardar = 6;
            if (guardar == optionId)
            {
                CustomStreamManager.Guardar_estado_FluxManager();
                CustomStreamManager.Guardar_estado_Manager();
                for (int j = 0; j < (int)(Console.BufferHeight/2); j++)
                {
                    Console.WriteLine("");
                }
                for (int i = 0; i < (int)( Console.BufferWidth/2 - 14); i++)
                {
                    Console.Write(" ");
                    Console.Write("Estado Guardado");
                }
                Console.WriteLine(" Presione ENTER para continuar");
                Console.ReadLine();
                Console.Clear();
                realizacionDeUnaAccion = true;
                VolverAlMenuPrincipal();
            }
            if (cargar == optionId)
            {
                CustomStreamManager.Cargar_estado_Manager();
                CustomStreamManager.Cargar_estado_FluxManager();
                for (int j = 0; j < (int)(Console.BufferHeight / 2); j++)
                {
                    Console.WriteLine("");
                }
                for (int i = 0; i < (int)(Console.BufferWidth / 2 - 14); i++)
                {
                    Console.Write(" ");
                    
                }
                Console.Write("Estado Cargado");
                Console.WriteLine(" Presione ENTER para continuar");
                Console.ReadLine();
                Console.Clear();
                realizacionDeUnaAccion = true;
                VolverAlMenuPrincipal();
            }
            return realizacionDeUnaAccion;

        }
        public bool comprarOVender(int optionId)
        {
            bool realizacionDeUnaAccion = false;
            int comprar , vender;
            comprar = 7;
            vender = 8;
            if (comprar == optionId)
            {
                //Ingresar Producto//
                {
                    {
                        try
                        {
                            //int costo, double tamaño, double peso, string nombre, string color, string categoria//
                            string[] nombreParametros4 = new string[] { "Id Del Producto", "Cantidad del producto a Agregar" , "Costo del Producto (por unidad)"};
                            string[] parametros4 = pedirDatos(nombreParametros4);
                            if (Manager.IngresarProducto(Convert.ToInt32(parametros4[0]), Convert.ToInt32(parametros4[1])))
                            {
                               // FluxManager.Ingreso_producto(Convert.ToInt32(parametros4[0]), Convert.ToInt32(parametros4[1]), Convert.ToInt32(parametros4[2]));
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
                }
                //FIN//
                return realizacionDeUnaAccion;
                
            }
            if (vender == optionId)
            {
                
                for (int j = 0; j < (int)(Console.BufferHeight / 2); j++)
                {
                    Console.WriteLine("");
                }
                for (int i = 0; i < (int)(Console.BufferWidth / 2 - 14); i++)
                {
                    Console.Write(" ");
                    Console.Write("Estado Cargado");
                }
                Console.WriteLine(" Presione ENTER para continuar");
                Console.ReadLine();
                Console.Clear();
                realizacionDeUnaAccion = true;
                VolverAlMenuPrincipal();
            }
            return realizacionDeUnaAccion;

        }
        public bool ejecutarAgregarOEliminarCategoria(int OpcionId)
        {
            bool realizacionDeUnaAccion = false;
            int agregarCategoria, eliminarCategoria;
            agregarCategoria = 14;
            eliminarCategoria = 15;
            //Productos//
            //Agregar Categoria//
            if (OpcionId == agregarCategoria)
            {
                {
                    {
                        try
                        {
                            //int costo, double tamaño, double peso, string nombre, string color, string categoria//
                            
                            string parametros = pedirDatos("Nombre de la nueva categoria");
                            Manager.AgregarCategoria(parametros);
                            realizacionDeUnaAccion = true;
                            Console.Clear();
                            Console.WriteLine("");
                            Console.WriteLine(" Categoria agregada , presione ENTER para continuar");
                            Console.ReadLine();
                            Console.Clear();
                            VolverAlMenuPrincipal();
                            
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
                }
            }
            //FIN//

            //Eliminar Categoria//
            if (OpcionId == eliminarCategoria)
            {
                {
                    {
                        try
                        {
                            //int costo, double tamaño, double peso, string nombre, string color, string categoria//

                            string parametros = pedirDatos("Id de la categoria a eliminar");
                            Manager.EliminarCategorias(Convert.ToInt32(parametros));
                            realizacionDeUnaAccion = true;
                            Console.Clear();
                            Console.WriteLine("");
                            Console.WriteLine(" Categoria eliminada , presione ENTER para continuar");
                            Console.ReadLine();
                            Console.Clear();
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
                }
            }
            //FIN//

           
            return realizacionDeUnaAccion;
        }
        public bool Reportes(int OptionId)
        {
            bool RealizacionCorrecta = false;
            int verReporesDeVentaTodo, verReporesDeVentaParticular, verReporesDeIngresoTodo, verReporesDeIngresoParticular, verRanking;
            verRanking = 31;
            verReporesDeIngresoParticular = 35;
            verReporesDeIngresoTodo = 34;
            verReporesDeVentaParticular = 33;
            verReporesDeVentaTodo = 32;
            try
            {
                if (verReporesDeIngresoParticular == OptionId)
                {//(int mes1, int año1, int mes2, int año2)//
                    Console.WriteLine("");
                    Console.WriteLine("Ingrese la fecha inicial y final para ver el reporte");
                    string[] nombreParametros = new string[] { "Año de Inicio", "Mes De Inicio(del 1 al 12)", "Año final", "Mes final" };
                    string[] fechas = pedirDatos(nombreParametros);
                    Ver_historial_con_fecha_ingresos(Convert.ToInt32(fechas[0]), Convert.ToInt32(fechas[1]), Convert.ToInt32(fechas[2]), Convert.ToInt32(fechas[3]));
                    RealizacionCorrecta = true;
                    Console.Clear();
                    Console.WriteLine("");
                    Console.WriteLine(" Presione ENTER para volver");
                    Console.ReadLine();
                    Console.Clear();
                }
                if (verReporesDeVentaParticular == OptionId)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Ingrese la fecha inicial y final para ver el reporte");
                    string[] nombreParametros = new string[] { "Año de Inicio", "Mes De Inicio(del 1 al 12)", "Año final", "Mes final" };
                    string[] fechas = pedirDatos(nombreParametros);
                    Ver_historial_con_fecha_ventas(Convert.ToInt32(fechas[0]), Convert.ToInt32(fechas[1]), Convert.ToInt32(fechas[2]), Convert.ToInt32(fechas[3]));
                    RealizacionCorrecta = true;
                    Console.Clear();
                    Console.WriteLine("");
                    Console.WriteLine(" Presione ENTER para volver");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
            catch(FormatException){
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine(" Ingresaste mal las fechas , presiona ENTER para volver al menu principal");
                Console.ReadLine();
                Console.Clear();
                RealizacionCorrecta = false;
            }
            if (verReporesDeVentaTodo == OptionId)
            {
                VerReportesDeVenta();
                RealizacionCorrecta = true;
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine(" Presione ENTER para volver");
                Console.ReadLine();
                Console.Clear();
            }
            if (verReporesDeIngresoTodo == OptionId)
            {
                VerReportesDeIngreso();
                RealizacionCorrecta = true;
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine(" Presione ENTER para volver");
                Console.ReadLine();
                Console.Clear();
            }
            if (verRanking == OptionId)
            {
                Ranking_producto();
                RealizacionCorrecta = true;
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine(" Presione ENTER para volver");
                Console.ReadLine();
                Console.Clear();
            }


            VolverAlMenuPrincipal();

            return RealizacionCorrecta;
        }
        /*Esto lo hizo matias*/
        public void VerReportesDeVenta()
        {
            int largo = FluxManager.Registro_venta1.Count;
            int i;
            for (i = 0; i < largo; i++)
            {
                Registro a = FluxManager.Registro_venta1[i];
                Date b = a.Fecha;
                int cantidad = a.Cantidad;
                string fecha = b.Retornar_fecha();
                string nombre = a.Nombre;
                Console.WriteLine("el " + fecha + " se vendieron " + cantidad + " de " + nombre);
            }
        }
        public  void VerReportesDeIngreso()
        {
            int largo = FluxManager.Registro_ingreso1.Count;
            int i;
            for (i = 0; i < largo; i++)
            {
                Registro a = FluxManager.Registro_venta1[i];
                Date b = a.Fecha;
                int cantidad = a.Cantidad;
                string fecha = b.Retornar_fecha();
                string nombre = a.Nombre;
                Console.WriteLine("el " + fecha + " se ingresaron " + cantidad + " de " + nombre);
            }
        }
        // se imprime el historial de ingresos con fecha especificada por el usuario desde me1/año1 hasta mes2/año2
        public  void Ver_historial_con_fecha_ingresos(int mes1, int año1, int mes2, int año2)
        {
            int largo = FluxManager.Registro_ingreso1.Count;
            int i;
            for (i = 0; i < largo; i++)
            {
                Registro a = FluxManager.Registro_ingreso1[i];
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
        public void Ver_historial_con_fecha_ventas(int mes1, int año1, int mes2, int año2)
        {
            int largo = FluxManager.Registro_venta1.Count;
            int i;
            for (i = 0; i < largo; i++)
            {
                Registro a = FluxManager.Registro_ingreso1[i];
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
            foreach (Registro a in FluxManager.Registro_venta1)
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
                    foreach (Registro c in FluxManager.Registro_venta1)
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
        //FIN DE LO QUE HISO MATIAS//
        //metodos que sirven solo para quien modifique el programa//
        private void mostrarTodadLasOpciones()
        {
            Console.Clear();
            string[] parametros = new string[] { "OptionID", "Nombre", "Categoria", "Subopciones" };
            int[] formato = new int[] { 12, 50, 30, 12 };
            string linea = TableMaker.ImprimirParametros(parametros, formato);
            foreach (optionTree ot in TodadLasOpciones)
            {
                int numeroDeSubOpciones;
                if (ot.SubOptions != null)
                {
                    numeroDeSubOpciones = ot.SubOptions.Length;
                }
                else
                {
                    numeroDeSubOpciones = 0;
                }

                string ID, Nombre, categoria, subopciones;

                if (ot.BackOption == null)
                {

                    ot.Categoria = "raiz";

                }
                ID = TableMaker.darFormatoDeColumna(12, ot.OptionId);
                subopciones = TableMaker.darFormatoDeColumna(12, numeroDeSubOpciones);
                Nombre = TableMaker.darFormatoDeColumna(50, ot.Titulo);
                categoria = TableMaker.darFormatoDeColumna(30, ot.Categoria);
                string[] output = new string[] { ID, Nombre, categoria, subopciones };
                TableMaker.ImprimirFila(output);
                Console.WriteLine("");
            }
            Console.WriteLine(linea);
        }
        
    }
}
