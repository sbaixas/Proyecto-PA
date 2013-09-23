﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPA
{
    class SetDeProducto : Producto
    {
        private double descuento;

        public double Descuento
        {
            get { return descuento; }
            set { descuento = value; }
        }
        private int[] cantidades;

        public int[] Cantidades
        {
            get { return cantidades; }
            set { cantidades = value; }
        }
        private List<Producto> productos;

        public List<Producto> Productos
        {
            get { return productos; }
            set { productos = value; }
        }
        public SetDeProducto(int descuento, int[] cantidades, List<Producto> productos, string nombre, string imagePath)
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
            costo = (costo * (1 - descuento));
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
    }
}

