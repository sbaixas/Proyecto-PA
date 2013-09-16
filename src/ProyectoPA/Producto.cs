using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPA
{
    
    abstract class Producto
    {
        private int costo;

        public int Costo
        {
            get { return costo; }
            set { costo = value; }
        }

        private int id;

        public int Id
        {
            get { return id; }
        }

        private double tamaño;

        public double Tamaño
        {
            get { return tamaño; }
            set { tamaño = value; }
        }

        private double peso;

        public double Peso
        {
            get { return peso; }
            set { peso = value; }
        }

        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private string imagePath;

        public string ImagePath
        {
            get { return imagePath; }
            set { imagePath = value; }
        }

        public Producto() { }
        public Producto(int id, int costo, double tamaño, double peso, string nombre, string imagePath)
        {
            this.costo = costo;
            this.tamaño = tamaño;
            this.peso = peso;
            this.imagePath = imagePath;
            this.nombre = nombre;
        }
        public Producto(string nombre, Producto pBase)
        {
            this.nombre = nombre;
            this.costo = pBase.costo;
            this.tamaño = pBase.tamaño;
            this.peso = pBase.peso;
            this.imagePath = pBase.imagePath;
        }
        public void Init(int id, int costo, double tamaño, double peso, string nombre, string imagePath)
        {
            this.costo = costo;
            this.tamaño = tamaño;
            this.peso = peso;
            this.imagePath = imagePath;
            this.nombre = nombre;
        }
        public abstract void DescontarStock(int cantidad)
        {
        }
    }
}
