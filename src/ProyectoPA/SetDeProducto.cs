using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPA
{
    class SetDeProducto : Producto
    {
        public double descuento;

        public double Descuento
        {
            get { return descuento; }
            set { descuento = value; }
        }
        public List<int> cantidades;

        public List<int> Cantidades
        {
            get { return cantidades; }
            set { cantidades = value; }
        }
        public List<Producto> productos;

        public List<Producto> Productos
        {
            get { return productos; }
            set { productos = value; }
        }
        public SetDeProducto(int descuento, List<int> cantidades, List<Producto> productos, string nombre, string imagePath)
            :base()
        {
            int costo = 0;
            double tamaño = 0, peso = 0;
            this.productos = productos;
            this.cantidades = cantidades;
            for (int i = 0; i < productos.Count; i++)
            {
                costo += (productos[i].Costo * cantidades[i]);
                tamaño += (productos[i].Tamaño * cantidades[i]);
                peso += (productos[i].Peso * cantidades[i]);
            }
            costo = (costo * ((100 - descuento)/100));
            base.Init(costo, tamaño, peso, nombre, imagePath);
        }
        public override void DescontarStock(int cantidad)
        {
            int count = 0;
            foreach (Producto p in productos)
            {
                    p.DescontarStock(cantidad*cantidades[count]);
                    count++;
            }
        }
        public override void AgregarStock(int cantidad)
        {
            int count = 0;
            foreach (Producto p in productos)
            {
                p.AgregarStock(cantidad * cantidades[count]);
                count++;
            }
        }
        public override void imprimirDatos()
        {
            base.imprimirDatos();
            for (int i = 0; i < productos.Count; i++)
            {
                Console.WriteLine("- Producto: " + this.productos[i].Nombre + " X " + cantidades[i]);
                Console.WriteLine("");
            }
            Console.WriteLine("--------------------------------------");

        }
        public void AgregarProducto(Producto p, int c)
        {
            this.productos.Add(p);
            this.cantidades.Add(c);
        }
        public void EliminarProducto(int id)
        {
            for (int i = 0; i < productos.Count; i++ )
            {
                if (productos[i].Id == id)
                {
                    productos.Remove(productos[i]);
                    cantidades.Remove(cantidades[i]);
                }
            }
        }
    }
}

