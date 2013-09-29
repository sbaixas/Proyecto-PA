using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPA
{
    [Serializable]
    class Registro
    {
        private Producto producto;
        
        private Date fecha;

        private int precio;
        private double tamaño;
        private double peso;
        private string nombre;
        private int cantidad;

        public Registro(Producto producto, Date fecha, int cantidad)
        {
            this.producto = producto;

            this.fecha = fecha;

            this.tamaño = producto.Tamaño;

            this.precio = producto.Costo;

            this.peso = producto.Peso;

            this.nombre = producto.Nombre;

            this.cantidad = cantidad;
        }

        public Date Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public Producto Producto 
        {
            get { return producto; }
            set { producto = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public double Peso
        {
            get { return peso; }
            set { peso = value; }
        }

        public double Tamaño
        {
            get { return tamaño; }
            set { tamaño = value; }
        }

        public int Precio
        {
            get { return precio; }
            set { tamaño = value; }
        }

    }
}
