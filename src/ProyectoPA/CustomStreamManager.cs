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
        }

        public static void Guardar_estado_FluxManager()
        {
            XmlSerializer mySerializer = new XmlSerializer(typeof(List<Registro>));

            StreamWriter myWriter = new StreamWriter("Flux.xml");
            mySerializer.Serialize(myWriter, FluxManager.Registro_ingreso1);
            StreamWriter myWriter1 = new StreamWriter("Flux1.xml");
            mySerializer.Serialize(myWriter1, FluxManager.Registro_venta1);
            myWriter.Close();
        }

        public static void Cargar_estado_FluxManager()
        {
            List<Registro> regIng;
            List<Registro> regVen;
            XmlSerializer mySerializer = new XmlSerializer(typeof(List<Registro>));

            FileStream myFileStream = new FileStream("Flux.xml", FileMode.Open);
            FileStream myFileStream1 = new FileStream("Flux1.xml", FileMode.Open);

            regIng = (List<Registro>)
            mySerializer.Deserialize(myFileStream);
            regVen = (List<Registro>)
            mySerializer.Deserialize(myFileStream1);

            FluxManager.Registro_ingreso1 = regIng;
            FluxManager.Registro_venta1 = regVen;
            FluxManager.Date = new Date(DateTime.Now);

            myFileStream.Close();
        }
    }
}
