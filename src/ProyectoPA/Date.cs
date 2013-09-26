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

        public void cerrar_mes()
        {
            mes++;
        }

        public int Mes
        {
            get { return mes; }
            set { mes = value; }
        }

        public int Dia
        {
            get { return dia; }
            set { dia = value; }
        }

        public string Retornar_fecha()
        {
            string a = dia + "/" + mes + "/" + año;
            return a;
        }
    }
}
