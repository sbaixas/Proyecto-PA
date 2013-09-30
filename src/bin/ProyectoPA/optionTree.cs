using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPA
{   
    //bozzo//
    class optionTree
    {
        //atributos//
        private optionTree[] subOptions;
        private string titulo;
        private int optionId;
        private optionTree backOption;
        private string categoria;
        

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
        public string Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }

        //Constructor//
        public optionTree(string titulo, string categoria, optionTree padre, int id)
        {
            
            optionId = consoleMng.Id;
            consoleMng.Id++;
            this.titulo = titulo;
            this.categoria = categoria;
            subOptions = null;
            consoleMng.TodadLasOpciones.Add(this);
        }

        //Metodos//
       

        public void agregarHijo(string nombreDeLaNuevaSubOpsion , string categoriaDeLaNuevaOpcion)
        {

            if (subOptions == null)
            {
                subOptions = new optionTree[1];
                subOptions[0] = new optionTree(nombreDeLaNuevaSubOpsion, categoriaDeLaNuevaOpcion, this, consoleMng.Id);
                subOptions[0].backOption = this;
            }
            else
            {
                optionTree[] aux = new optionTree[subOptions.Length + 1];
                for (int i = 0; i < subOptions.Length; i++)
                {
                    aux[i] = subOptions[i];
                }
                aux[aux.Length - 1] = new optionTree(nombreDeLaNuevaSubOpsion, categoriaDeLaNuevaOpcion , this, consoleMng.Id);
                aux[aux.Length - 1].BackOption = this;
                this.subOptions = aux;
            }
            

        }

       

    }
}
