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
            // To write to a file, create a StreamWriter object.
            StreamWriter myWriter = new StreamWriter("Flux.xml");
            mySerializer.Serialize(myWriter, fmanager);
            myWriter.Close();
        }

        public static FluxManager Cargar_estado_FluxManager()
        {
            FluxManager fmanager;
            // Construct an instance of the XmlSerializer with the type
            // of object that is being deserialized.
            XmlSerializer mySerializer = new XmlSerializer(typeof(FluxManager));
            // To read the file, create a FileStream.
            FileStream myFileStream = new FileStream("Flux.xml", FileMode.Open);
            // Call the Deserialize method and cast to the object type.
            fmanager = (FluxManager)
            mySerializer.Deserialize(myFileStream);

            myFileStream.Close();

            return fmanager;
        }
    }
}
