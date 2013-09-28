using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPA
{
    class Date
    {
        private DateTime fecha;
        private int mes;
        private int año;
        private int dia;

        public Date(DateTime fecha)
        {
            this.fecha = fecha;
            this.mes = fecha.Month;
            this.dia = fecha.Day;
            this.año = fecha.Year;
        }

        // Cierra el mes contable  // 
        public void cerrar_mes()
        {
            mes++;
            if (mes==13)
            {
                mes=1;
                año++;
            }
        }

        public int Mes
        {
            get { return mes; }
            set { mes = value; }
        }

        //    Retorna un string con la fecha    //
        public string Retornar_fecha()
        {
            string a =  mes + "/" + año;
            return a;
        }
    }
}
