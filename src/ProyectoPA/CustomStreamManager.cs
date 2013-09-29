using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace ProyectoPA
{
    class CustomStreamManager
    {
        public static void Guardar_estado_Manager()
        {
            XmlSerializer mySerializer = new XmlSerializer(typeof(List<Registro>));
            XmlSerializer mySerializer1 = new XmlSerializer(typeof(int));
            StreamWriter myWriter = new StreamWriter("Manager.regM");
            mySerializer.Serialize(myWriter, FluxManager.Registro_ingreso1);
            StreamWriter myWriter1 = new StreamWriter("Manager1.regM");
            mySerializer1.Serialize(myWriter1, FluxManager.Registro_venta1);
            myWriter.Close();
            myWriter1.Close();
        }

        public static void Cargar_estado_Manager()
        {
            try
            {
                List<Producto> prods;
                int countz;
                XmlSerializer mySerializer = new XmlSerializer(typeof(List<Producto>));
                XmlSerializer mySerializer1 = new XmlSerializer(typeof(int));

                FileStream myFileStream = new FileStream("Manager.regM", FileMode.Open);
                FileStream myFileStream1 = new FileStream("Manager1.regM", FileMode.Open);

                prods = (List<Producto>)
                mySerializer.Deserialize(myFileStream);
                countz = (int)
                mySerializer1.Deserialize(myFileStream1);

                Manager.Productos = prods;
                Manager.IdCount = countz;

                myFileStream.Close();
                myFileStream1.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine("No se han guardado estados previamente");
            }
        }

        public static void Guardar_estado_FluxManager()
        {
            XmlSerializer mySerializer = new XmlSerializer(typeof(List<Registro>));

            StreamWriter myWriter = new StreamWriter("Flux.regF");
            mySerializer.Serialize(myWriter, FluxManager.Registro_ingreso1);
            StreamWriter myWriter1 = new StreamWriter("Flux1.regF");
            mySerializer.Serialize(myWriter1, FluxManager.Registro_venta1);
            myWriter.Close();
            myWriter1.Close();
        }

        public static void Cargar_estado_FluxManager()
        {
            try
            {
                List<Registro> regIng;
                List<Registro> regVen;
                XmlSerializer mySerializer = new XmlSerializer(typeof(List<Registro>));

                FileStream myFileStream = new FileStream("Flux.regF", FileMode.Open);
                FileStream myFileStream1 = new FileStream("Flux1.regF", FileMode.Open);

                regIng = (List<Registro>)
                mySerializer.Deserialize(myFileStream);
                regVen = (List<Registro>)
                mySerializer.Deserialize(myFileStream1);

                FluxManager.Registro_ingreso1 = regIng;
                FluxManager.Registro_venta1 = regVen;
                FluxManager.Date = new Date(DateTime.Now);

                myFileStream.Close();
                myFileStream1.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("No se han guardado estados previamente");
            }
        }
    }
}
