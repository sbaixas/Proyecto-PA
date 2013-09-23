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
            :base(costo, tamaño, peso, nombre)
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
            Cantidad += cantidad;
        }
/***************imprimir Datos**********************/
        public  override void imprimirDatos() {
            base.imprimirDatos();
            Console.WriteLine("- Categoria: " + this.Categoria);
            Console.WriteLine("");
            Console.WriteLine("- Color: "+this.Color);
            Console.WriteLine("");
            Console.WriteLine("- Cantidad: " + this.Cantidad);
        }
    }
}
