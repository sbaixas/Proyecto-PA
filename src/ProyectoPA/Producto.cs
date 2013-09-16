using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPA
{
 /*Bozzo: image path me complico un poco , asi que lo saque del construsctor , y si se quiere poner, que se use el setter*/  
 /*Bozzo: hay un constructor que no usa parametros, para que sirve ?? */
    abstract class Producto
    {
/*******Atributos , Getter y Setters*******/
        private int costo;

        public int Costo
        {
            get { return costo; }
            set { costo = value; }
        }

        private int id, cantidad;

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

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        private string imagePath;

        public string ImagePath
        {
            get { return imagePath; }
            set { imagePath = value; }
        }
/****************************Constructores**************************************/
      
        //?????//
        public Producto() { }

       //Constructor pasandole todos los atributos//
        public Producto(int id, int costo, double tamaño, double peso, string nombre)
        {
            this.costo = costo;
            this.tamaño = tamaño;
            this.peso = peso;
            this.nombre = nombre;
        }
        //constructor pasandole el nombre y otro producto//
        public Producto(string nombre, Producto pBase)
        {
            this.nombre = nombre;
            this.costo = pBase.costo;
            this.tamaño = pBase.tamaño;
            this.peso = pBase.peso;
            this.imagePath = pBase.imagePath;
        }
        //????//
        public void Init(int id, int costo, double tamaño, double peso, string nombre, string imagePath)
        {
            this.costo = costo;
            this.tamaño = tamaño;
            this.peso = peso;
            this.imagePath = imagePath;
            this.nombre = nombre;
        }
        
        public virtual void DescontarStock(int cantidad)
        {
        }
        public virtual void AgregarStock(int cantidad)
        {
        }
        public virtual void imprimirDatos()
        {
        }
    }
}
