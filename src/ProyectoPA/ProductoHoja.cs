using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPA
{
    [Serializable]
    public class ProductoHoja : Producto
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

        public int Cantidad
        {
            get { return cantidad; }
        }

    


/****************Constructor******************/
        //Dando todos los datos//
        public ProductoHoja(int costo, double tamaño, double peso, string nombre, string color, string categoria)
            :base(costo, tamaño, peso, nombre)
        {
            this.color = color;
            this.categoria = categoria;
            this.cantidad = 0;
        }

        //partiendo de un producto existente//
        public ProductoHoja(string nombre, Producto producto , string color, string categoria)
            : base(nombre , producto)
        {
            this.Nombre = nombre;
            this.color = color;
            this.categoria = categoria;
            this.cantidad = 0;
           
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
            base.imprimirDatos();
            Console.WriteLine("- Categoria: " + this.Categoria);
            Console.WriteLine("");
            Console.WriteLine("- Color: "+this.Color);
            Console.WriteLine("");
            if (this.cantidad <= 10)
            {
                Console.WriteLine("- Cantidad: " + this.Cantidad + "CUIDADO! QUEDAN POCAS UNIDADES");
            }
            Console.WriteLine("- Cantidad: " + this.Cantidad);
            Console.WriteLine("--------------------------------------");
        }
        public override bool quedan(int cuantos)
        {
            if (cantidad < cuantos)
            {
                return false;
            }
            return true;
        }
    }
}
