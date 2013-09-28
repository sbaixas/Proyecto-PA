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
        public static void GuardarEstadoManager(string @path, List<Producto> productos)
        {
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(fs);
            //
        }

        public static void Guardar_estado_FluxManager(FluxManager fmanager)
        {
            XmlSerializer mySerializer = new XmlSerializer(typeof(FluxManager));

            StreamWriter myWriter = new StreamWriter("Flux.xml");
            mySerializer.Serialize(myWriter, fmanager);
            myWriter.Close();
        }

        public static FluxManager Cargar_estado_FluxManager()
        {
            FluxManager fmanager;
  
            XmlSerializer mySerializer = new XmlSerializer(typeof(FluxManager));

            FileStream myFileStream = new FileStream("Flux.xml", FileMode.Open);
 
            fmanager = (FluxManager)
            mySerializer.Deserialize(myFileStream);

            myFileStream.Close();

            return fmanager;
        }
    }
}
