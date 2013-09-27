using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
    }
}
