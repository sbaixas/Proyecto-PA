﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPA
{
    class Manager
    {
        //Atributos//
        private static List<Producto> productos = new List<Producto>();
        private static int idCount = 0;
        private static List<string> categorias = new List<string>();

        //Getters y Setters//
        public static List<Producto> Productos
        {
            get { return Manager.productos; }
            set { Manager.productos = value; }
        }
        public static int IdCount
        {
            get { return Manager.idCount; }
            set { Manager.idCount = value; }
        }
        public static List<string> Categorias
        {
            get { return Manager.categorias; }
            set { Manager.categorias = value; }
        }

        //Metodos//
        public static void AgregarCategoria(string nombre)
        {
            categorias.Add(nombre);
        }
        public static bool EliminarCategorias(int i)
        {
                foreach (string cat in categorias)
                {
                    if (cat == categorias[i])
                    {
                        categorias.Remove(cat);
                        return true;
                    }
                }
                return false;
        }
        public static bool AgregarProducto(int costo, double tamaño, double peso, string nombre, string color, int idcat)
        {
            try
            {
                productos.Add(new ProductoHoja(costo, tamaño, peso, nombre, color, categorias[idcat]));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool AgregarSet(int descuento, List<int> cantidades, List<int> ids, string nombre)
        {
            bool funcionCompleta = false;
            List<Producto> prods = new List<Producto>();
            foreach(Producto p in productos)
            {
                foreach(int i in ids)
                {
                    funcionCompleta = false;
                    if(p.Id == i)
                    {
                        prods.Add(p);
                        funcionCompleta = true;
                        break;
                    }

                }
            }
            productos.Add(new SetDeProducto(descuento, cantidades, prods, nombre, null));
            return funcionCompleta;
        }
        public static bool EliminarProducto(int id)
        {
            foreach (Producto p in productos)
            {
                if (p.Id == id)
                {
                    productos.Remove(p);
                    return true;
                }
            }
            return false;
        }
        public static bool IngresarProducto(int IdDelProducto, int cantidad)
        {
            try
            {
                foreach (Producto p in productos)
                {
                    if (p.Id == IdDelProducto)
                    {
                        productos[IdDelProducto].AgregarStock(cantidad);
                        return true;
                    }
                }
            }
            catch(IndexOutOfRangeException){
                return false;
            }
            return false;
        }
        public static bool Vender(int id, int cantidad)
        {
            foreach (Producto p in productos)
            {
                if (p.Id == id && p.quedan(cantidad))
                {
                    p.DescontarStock(cantidad);
                    return true;
                }
            }
            return false;
        }
            /*Metodos para modificar atributos, devuelven true si se efectuo la modificación, y false si no encontro al producto*/
            /*Metodos para modificar los atributos de los productos en general*/
        public static bool ModificarNombre(int id, string nombre)
        {
            foreach (Producto p in productos)
            {
                if (p.Id == id)
                {
                    p.Nombre = nombre;
                    return true;
                }
            }
            return false;
        }
            /*Metodos para modificar los atributos de los productos hoja SOLO USABLES CON PRODUCTOS HOJA*/
        public static bool ModificarCosto(int id, int costo)
        {
            foreach (ProductoHoja p in productos)
            {
                if (p.Id == id)
                {
                    p.Costo = costo;
                    return true;
                }
            }
            return false;
        }
        public static bool ModificarTamaño(int id, double tamaño)
        {
            foreach (ProductoHoja p in productos)
            {
                if (p.Id == id)
                {
                    p.Tamaño = tamaño;
                    return true;
                }
            }
            return false;
        }
        public static bool ModificarPeso(int id, double peso)
        {
            foreach (ProductoHoja p in productos)
            {
                if (p.Id == id)
                {
                    p.Peso = peso;
                    return true;

                }
            }
            return false;
        }
        public static bool ModificarColor(int id, string color)
        {
            foreach (ProductoHoja p in productos)
            {
                if (p.Id == id)
                {
                    p.Color = color;
                    return true;
                }
            }
            return false;
        }
        public static bool ModificarCategoria(int id, string categoria)
        {
            foreach (ProductoHoja p in productos)
            {
                if (p.Id == id)
                {
                    p.Categoria = categoria;
                    return true;
                }
            }
            return false;
        }
            /*Metodos para modificar los atributos de los sets de productos SOLO USABLES CON SET DE PRODUCTOS*/
        public static bool ModificarSetAgregar(int idset, int idproducto, int cantidad)
        {
            foreach (SetDeProducto s in productos)
            {
                if (s.Id == idset)
                {
                    foreach (Producto p in productos)
                    {
                        if (p.Id == idproducto)
                        {
                            s.AgregarProducto(p, cantidad);
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public static bool ModificarSetEliminar(int idset, int idproducto)
        {
            foreach (SetDeProducto s in productos)
            {
                if (s.Id == idset)
                {
                    s.EliminarProducto(idproducto);
                    return true;
                }
            }
            return false;
        }
        public static bool ModificarDescuento(int idset, int nuevoDescuento)
        {
            foreach (SetDeProducto s in productos)
            {
                if (s.Id == idset)
                {
                    s.Descuento = nuevoDescuento;
                    return true;
                }
            }
            return false;
        }
    }
}

