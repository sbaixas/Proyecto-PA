using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPA
{
    class consoleMng
    {
        //Atributos//
        private optionTree current;
        private static int id;

        //Getters y Setters//
        public static int Id
        {
            get { return id; }
            set { id = value; }
        }

        //Contructor//
        public consoleMng()
        {
            optionTree raiz = new optionTree("main", null, Id);
            current = raiz;
            raiz.agregarHijo("primeraOpcion");
            raiz.agregarHijo("SegundaOpcion");
            raiz.agregarHijo("TerceraOpcion");
            raiz.agregarHijo("Salir");
            navegar();

        }

        //Metodos//
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
                        if (0 < opcion && opcion < current.SubOptions.Length)
                        {
                            retorno = opcion -1;
                            correcto = true;
                        }
                        else
                        {
                            Console.WriteLine("La Opcion Seleccionada no existe , presione ENTER para continuar");

                        }
                    }
                    catch
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
                seleccion = seleccionar();


                if (seleccion == -1)
                {
                    current = current.BackOption;
                }
                else
                {
                    if (!current.SubOptions[seleccion].Exe)
                    {
                        current = current.SubOptions[seleccion];
                    }
                    else
                    {
                        //ejecutar//
                    }
                }
                
            }
        }
        public void mostrarTodadLasOpciones()
        {
            Console.Clear();
            Console.WriteLine("nombre: " + current.Titulo);
            Console.WriteLine("option Id " + current.OptionId + "");
            Console.WriteLine("");
            Console.WriteLine("");
            optionTree aux = current;
            for (int i = 0; i < aux.SubOptions.Length; i++)
            {

                optionTree aux2 = aux.SubOptions[i];

                for (int j = 0; j < aux2.SubOptions.Length; j++)
                {
                    Console.WriteLine("nombre: " + aux2.SubOptions[j].Titulo);
                    Console.WriteLine("option Id " + aux2.SubOptions[j].OptionId + "");
                    Console.WriteLine("");
                }
                Console.WriteLine("-------------------------------------------------------------------");
            }

        }
    }
}
