using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ProyectoPA
{
    class CustomStreamManager
    {
        private static IFormatter formatter = new BinaryFormatter();
        public static void Guardar_Estado()
        {
            
            Stream stream = new FileStream("Manager.sav", FileMode.Create);
            formatter.Serialize(stream, Manager.Productos.ToArray());
            Stream stream1 = new FileStream("Manager1.sav", FileMode.Create);
            formatter.Serialize(stream1, Producto.IdCount);
            Stream stream4 = new FileStream("Manager2.sav", FileMode.Create);
            formatter.Serialize(stream4, Manager.Categorias.ToArray());
            stream4.Close();
            stream.Close();
            stream1.Close();
            Stream stream2 = new FileStream("Flux.sav", FileMode.Create);
            formatter.Serialize(stream2, FluxManager.Registro_ingreso1.ToArray());
            Stream stream3 = new FileStream("Flux1.sav", FileMode.Create);
            formatter.Serialize(stream3, FluxManager.Registro_venta1.ToArray());
            stream2.Close();
            stream3.Close();
        }

        public static void Cargar_Estado()
        {
                Stream stream = new FileStream("Manager.sav", FileMode.Open);
                Stream stream1 = new FileStream("Manager1.sav", FileMode.Open);
                Stream stream4 = new FileStream("Manager2.sav", FileMode.Open);
                string[] cats = (string[])formatter.Deserialize(stream4);
                Producto[] prods = (Producto[])formatter.Deserialize(stream);
                int countz = (int)formatter.Deserialize(stream1);
                stream4.Close();
                stream.Close();
                stream1.Close();
                Manager.Categorias = cats.ToList();
                Manager.Productos = prods.ToList();
                Producto.IdCount = countz;
                Stream stream2 = new FileStream("Flux.sav", FileMode.Open);
                Stream stream3 = new FileStream("Flux1.sav", FileMode.Open);
                Registro[] regIng = (Registro[])formatter.Deserialize(stream2);
                Registro[] regVen = (Registro[])formatter.Deserialize(stream3);
                stream2.Close();
                stream3.Close();
                FluxManager.Registro_ingreso1 = regIng.ToList();
                FluxManager.Registro_venta1 = regVen.ToList();
        }
    }
}
