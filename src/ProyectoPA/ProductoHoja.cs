using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPA
{
    class ProductoHoja : Producto
    {
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
            set { cantidad = value; }
        }
        public ProductoHoja(int id, int costo, double tamaño, double peso, string nombre, string imagePath, string color, string categoria, int cantidad)
            :base(id, costo, tamaño, peso, nombre, imagePath)
        {
            this.color = color;
            this.categoria = categoria;
            this.cantidad = cantidad;
        }
        public override void DescontarStock(int cantidad)
        {
            this.cantidad -= cantidad;
        }
    }
}
