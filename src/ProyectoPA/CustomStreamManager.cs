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
        public static void Guardar_estado_Manager()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("Manager.sav", FileMode.Create);
            formatter.Serialize(stream, Manager.Productos.ToArray());
            Stream stream1 = new FileStream("Manager1.sav", FileMode.Create);
            formatter.Serialize(stream1, Producto.IdCount);
            stream.Close();
        }

        public static void Cargar_estado_Manager()
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream("Manager.sav", FileMode.Open);
                Stream stream1 = new FileStream("Manager.sav", FileMode.Open);
                Producto[] prods = (Producto[])formatter.Deserialize(stream);
                int countz = (int)formatter.Deserialize(stream1);
                stream.Close();
                Manager.Productos = prods.ToList();
                Producto.IdCount = countz;
            }
            catch(Exception e)
            {
                Console.WriteLine("No se han guardado estados previamente");
            }
        }

        public static void Guardar_estado_FluxManager()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("Flux.sav", FileMode.Create);
            formatter.Serialize(stream, FluxManager.Registro_ingreso1.ToArray());
            Stream stream1 = new FileStream("Flux1.sav", FileMode.Create);
            formatter.Serialize(stream1, FluxManager.Registro_venta1.ToArray());
            stream.Close();
        }

        public static void Cargar_estado_FluxManager()
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream("Flux.sav", FileMode.Open);
                Stream stream1 = new FileStream("Flux1.sav", FileMode.Open);
                Registro[] regIng = (Registro[])formatter.Deserialize(stream);
                Registro[] regVen = (Registro[])formatter.Deserialize(stream1);
                stream.Close();
                FluxManager.Registro_ingreso1 = regIng.ToList();
                FluxManager.Registro_venta1 = regVen.ToList();
               
            }
            catch (Exception e)
            {
                Console.WriteLine("No se han guardado estados previamente");
            }
        }
    }
}
