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
            /*
            Manager.AgregarProducto(3000, 2033, 4544, "ferrari rojo", "rojo", "vehiculo");
            Manager.AgregarProducto(30000, 20534, 452, "platano", "verde", "fruta");
            Manager.AgregarProducto(30000, 204, 4533, "playStation", "azul", "juegos");*/

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
                    raiz.SubOptions[0].agregarHijo("Mostrar Detalles de Producto", "Opciones De Producto");
                }
                //Opciones Para modificar set de productos(Detalles/Todos)//
                {
                    raiz.SubOptions[0].SubOptions[5].agregarHijo("Modicar Nombre", "Modificar set de productos");
                    raiz.SubOptions[0].SubOptions[5].agregarHijo("Agregar Producto al Set", "Modificar set de productos");
                    raiz.SubOptions[0].SubOptions[5].agregarHijo("Eliminar Producto Del Set", "Modificar set de productos");
                    raiz.SubOptions[0].SubOptions[5].agregarHijo("Modificar Descuento", "Modificar set de productos");
                }

                {//opciones para modificar producto//

                    raiz.SubOptions[0].SubOptions[4].agregarHijo("Modicar Nombre", "Modificar ProductoHoja");
                    raiz.SubOptions[0].SubOptions[4].agregarHijo("Modicar Costo", "Modificar ProductoHoja");
                    raiz.SubOptions[0].SubOptions[4].agregarHijo("Modicar Tamaño", "Modificar ProductoHoja");
                    raiz.SubOptions[0].SubOptions[4].agregarHijo("Modicar Peso", "Modificar ProductoHoja"); ;
                    raiz.SubOptions[0].SubOptions[4].agregarHijo("Modicar Color", "Modificar ProductoHoja");
                    raiz.SubOptions[0].SubOptions[4].agregarHijo("Modicar Categoria", "Modificar ProductoHoja");
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
                    raiz.SubOptions[1].SubOptions[1].agregarHijo("En Una Fecha En Particular", "Historial De Ingresos");
                    raiz.SubOptions[1].SubOptions[1].agregarHijo("Historial en Una Fecha En Particular", "Historial De Ingresos");
                }
            }
            //se navega en el programa//
            navegar();
            //dejar como comentario si no se esta programando//
            mostrarTodadLasOpciones(); Console.ReadLine();
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


        }
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
            bool realizacionDeUnaAccion = false;
            //ejecutarAgregarOIngresarProductos []//
            //modificar producto []//
            
            //para Productos//
            if(5 == OpcionId || 6 == OpcionId){cargarOguardar(OpcionId);}
            if (9<= OpcionId && OpcionId <= 11){ejecutarAgregarOEliminarProductos(OpcionId);}
            if (22 <= OpcionId && OpcionId <= 27) {ejecutarModificarProductoHoja(OpcionId); }
            if (5 <= OpcionId && OpcionId <= 6) { comprarOVender(OpcionId); }

            //para Registro//

            //CUANDO SE TERMINE LA ACCION///
            if (realizacionDeUnaAccion)
            {   Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Accion realizada con exito , presiona ENTER para volver al menu principal");
                Console.ReadLine();
                VolverAlMenuPrincipal();
            } 
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
                            string[] nombreParametros3 = new string[] { "costo", "tamaño", "peso", "nombre", "color", "Id de la categoria" };
                            string[] parametros3 = pedirDatos(nombreParametros3);
                           realizacionDeUnaAccion = Manager.AgregarProducto(Convert.ToInt32(parametros3[0]), Convert.ToDouble(parametros3[1]), Convert.ToDouble(parametros3[2]), Convert.ToString(parametros3[3]), Convert.ToString(parametros3[4]), Convert.ToInt32(parametros3[5]));
                            
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
                                    try
                                    {
                                        string[] inputProcesed = input.Split(',');
                                        ids.Add(Convert.ToInt32(inputProcesed[0]));
                                        cantidades.Add(Convert.ToInt32(inputProcesed[1]));
                                    }
                                    catch (Exception)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Lo has hecho mal, puedes volver a intentarlo, Presiona ENTER para continuar");
                                        Console.ReadLine();
                                        Console.Clear();
                                    }

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
                        VolverAlMenuPrincipal();
                    }
                }
            }
            //FIN//

            return realizacionDeUnaAccion;
        }
        public bool ejecutarModificarProductoHoja(int OpcionId)
        {
            bool realizacionDeUnaAccion = false;
            int costo, peso, categoria, tamaño, nombre, color;
            costo = 23;
            peso = 25;
            categoria = 27;
            tamaño = 24;
            nombre = 22;
            color = 26;
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
        public bool Imprimir(int OptionId)
        {
            bool realizacionDeUnaAccion = false;
            int imprimirTablaDeProductos, imprimirDetallesDeProducto;
            imprimirTablaDeProductos = 0;
            imprimirDetallesDeProducto = 0;

            //Imprimir tabla de productos//
            if (OptionId == imprimirTablaDeProductos)
            {
                {
                    Console.Clear();
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
            return realizacionDeUnaAccion;
        }
        public bool cargarOguardar(int optionId)
        {
            bool realizacionDeUnaAccion = false;
            int cargar, guardar;
            cargar = 5;
            guardar = 6;
            if (guardar == optionId)
            {
                CustomStreamManager.Guardar_Estado();
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
                CustomStreamManager.Cargar_Estado();
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
        public bool comprarOVender(int optionId)
        {
            bool realizacionDeUnaAccion = false;
            int comprar , vender;
            comprar = 5;
            vender = 6;
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
                for (int j = 0; j < (int)(Console.BufferHeight / 2); j++)
                {

                    Console.WriteLine("");
                }
                for (int i = 0; i < (int)(Console.BufferWidth / 2 - 14); i++)
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
