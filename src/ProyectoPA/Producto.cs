using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPA
{
    
    class Producto
    {
        private string tipo;
        private int costo;

        private double tamaño;

        private double peso;

        private string color;

        private string imagePath;

        private string categoría;

        public Producto(string tipo, int costo, double tamaño, double peso, string color, string imagePath, string categoría)
        {
            this.tipo = tipo;
            this.costo = costo;
            this.tamaño = tamaño;
            this.peso = peso;
            this.color = color;
            this.imagePath = imagePath;
            this.categoría = categoría;
        }
        public Producto(Producto pBase)
        {
            this.tipo = pBase.tipo;
            this.costo = pBase.costo;
            this.tamaño = pBase.tamaño;
            this.peso = pBase.peso;
            this.color = pBase.color;
            this.imagePath = pBase.imagePath;
            this.categoría = pBase.categoría;
        }
    }
}
