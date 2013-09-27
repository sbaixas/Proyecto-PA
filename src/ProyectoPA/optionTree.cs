using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPA
{
    class optionTree
    {
        //atributos//
        private optionTree[] subOptions;
        private string titulo;
        private int optionId;
        private optionTree backOption;
        private bool exe;



        //Getters y Setters//
        public optionTree[] SubOptions
        {
            get { return subOptions; }
            set { subOptions = value; }
        }
        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }
        public int OptionId
        {
            get { return optionId; }
            set { optionId = value; }
        }
        public optionTree BackOption
        {
            get { return backOption; }
            set { backOption = value; }
        }
        public bool Exe
        {
            get { return exe; }
            set { exe = value; }
        }

        //Constructor//
        public optionTree(string titulo, optionTree padre, int id)
        {
            exe = false;
            optionId = ConsoleMng.Id;
            ConsoleMng.Id++;
            this.titulo = titulo;
            subOptions = null;
        }

        //Metodos//
        public void showInfo()
        {

            Console.WriteLine("Titulo: " + titulo);
            Console.WriteLine("");
            Console.WriteLine("OptionID = " + optionId);
            Console.WriteLine("");
            if (backOption != null)
            {

                Console.WriteLine("padre =" + backOption.titulo);

            }
            else
            {
                Console.WriteLine("padre = soy la raiz :)");

            }

            Console.WriteLine("");
            if (subOptions != null)
            {

                Console.WriteLine("numero de hijos = " + subOptions.Length);

            }
            else
            {
                Console.WriteLine("numero de hijos = 0");
            }
            Console.WriteLine("");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("");
        }

        public void agregarHijo(string nombreDeLaNuevaSubOpsion)
        {

            if (subOptions == null)
            {
                subOptions = new optionTree[1];
                subOptions[0] = new optionTree(nombreDeLaNuevaSubOpsion, this, ConsoleMng.Id);
                subOptions[0].backOption = this;
            }
            else
            {
                optionTree[] aux = new optionTree[subOptions.Length + 1];
                for (int i = 0; i < subOptions.Length; i++)
                {
                    aux[i] = subOptions[i];
                }
                aux[aux.Length - 1] = new optionTree(nombreDeLaNuevaSubOpsion, this, ConsoleMng.Id);
                aux[aux.Length - 1].BackOption = this;
                this.subOptions = aux;
            }

        }

        public void show()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("  " + titulo);
            for (int l = 0; l < titulo.Length + 4; l++)
            {
                Console.Write("-");
            }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");

            if (subOptions != null)
            {
                Console.WriteLine(" Opciones:");
                string candidato = subOptions[0].titulo;
                for (int i = 0; i < subOptions.Length; i++)
                {
                    if (candidato.Length <= subOptions[i].titulo.Length) { candidato = subOptions[i].titulo; }
                }
                if (candidato.Length < 10) { candidato = " Opciones:"; }
                for (int j = 0; j < candidato.Length + 6; j++)
                {
                    Console.Write("-");
                }
                for (int k = 0; k < subOptions.Length; k++)
                {
                    if (subOptions[k].titulo == "Volver" || subOptions[k].titulo == "Salir")
                    {
                        Console.WriteLine("");
                        Console.WriteLine("");
                        Console.WriteLine("  *" + ") " + subOptions[k].titulo);
                    }

                    else
                    {
                        Console.WriteLine("");
                        Console.WriteLine("");
                        Console.WriteLine("  " + subOptions[k].optionId + "" + ") " + subOptions[k].titulo);
                    }
                }
            }
        }

        public void dejarComoExe()
        {
            this.exe = true;
        }

    }
}
