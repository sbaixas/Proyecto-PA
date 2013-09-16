using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPA
{
    class ProductoHoja : Producto
    {
/****************Getters y Setters******************/
        private string color;

        public string Color
        {
            get { return color; }
            set { color = value; }
        }
        private string categoria;

        public string Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }

        private int cantidad;

    


/****************Constructor******************/
        //Dando todos los datos//
        public ProductoHoja(int id, int costo, double tamaño, double peso, string nombre, string color, string categoria, int cantidad)
            :base(id, costo, tamaño, peso, nombre)
        {
            this.color = color;
            this.categoria = categoria;
            this.cantidad = cantidad;
        }

        //partiendo de un producto existente//
        public ProductoHoja(string nombre, Producto producto , string color, string categoria)
            : base(nombre , producto)
        {
            this.Nombre = nombre;
            this.color = color;
            this.categoria = categoria;
           
        }
/****************Descontar Stock******************/
        public override void DescontarStock(int cantidad)
        {
            this.cantidad -= cantidad;
        }
/****************agregar Stock******************/
        public override void AgregarStock(int cantidad)
        {
            this.cantidad += cantidad;
        }
/***************imprimir Datos**********************/
        public  override void imprimirDatos() {
            Console.WriteLine("Producto: "+ Nombre);
            Console.WriteLine("");
            Console.WriteLine("- Categoria: " + Categoria);
            Console.WriteLine("");
            Console.WriteLine("- Id: " + Id+"");
            Console.WriteLine("");
            Console.WriteLine("- Costo " + Costo+"");
            Console.WriteLine("");
            Console.WriteLine("- Tamaño: " + Tamaño+"");
            Console.WriteLine("");
            Console.WriteLine("- Peso: " +Peso+"" );
            Console.WriteLine("");
            Console.WriteLine("- Color: "+Color);
            Console.WriteLine("");
            Console.WriteLine("- Cantidad: " + Cantidad);
        }
    }
}
