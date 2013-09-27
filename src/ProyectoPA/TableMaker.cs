using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPA
{
    //bozzo//
    class TableMaker
    {
        static public string darFormatoDeColumna(int anchoDeColumna , string palabra) {
            string ret = palabra;
            while (ret.Length < anchoDeColumna)
            {
                ret = ret + " ";
                if (ret.Length < anchoDeColumna)
                {
                    ret = " " + ret;
                }
            } 
            return ret;
        }
        static public string darFormatoDeColumna(int anchoDeColumna, int palabra)
        {
            string ret;
            if (palabra == null)
            {
                ret = "0";
            }
            ret = palabra + "";
            while (ret.Length < anchoDeColumna)
            {
                ret = ret + " ";
                if (ret.Length < anchoDeColumna)
                {
                    ret = " " + ret;
                }
            }
            return ret;
        }
        static public string ImprimirFila(string[] columnas) {
            Console.Write(" |");
            for (int i = 0; i < columnas.Length ; i++)
            { 
                Console.Write(columnas[i]+"|");
            }  
            return null;
        }
        static public int ImprimirParametros(string[] columnas , int[] formato)
        {
            //devuelve el porte de la linea para no tener que calcularlo al final//

            for (int i = 0; i < columnas.Length; i++)
            {
                columnas[i] = darFormatoDeColumna(formato[i], columnas[i]);

            }

            Console.WriteLine("");
            int porteDeLalinea = 1 + columnas.Length;
            for (int i = 0; i < columnas.Length; i++)
            {
                porteDeLalinea += columnas[i].Length;
            }
            Console.Write(" ");
            for (int l = 0; l < porteDeLalinea; l++)
            {
                Console.Write("-");
            }
            Console.WriteLine("");

            
            Console.Write(" |");
            for (int j = 0; j < columnas.Length; j++)
            {
                Console.Write(columnas[j] + "|");
            }
            
            Console.WriteLine("");
            Console.Write(" ");
            for (int l = 0; l < porteDeLalinea; l++)
            {
                Console.Write("-");
            }
            Console.WriteLine("");
            
            return porteDeLalinea;
        }
    }
}
