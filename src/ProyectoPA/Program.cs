using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ProyectoPA
{
    class Program
    {
        static void Main(string[] args)
        {
            Date date = new Date(DateTime.Now);
            FluxManager.Date = date;
            consoleMng x = new consoleMng();
        }
    }
}
