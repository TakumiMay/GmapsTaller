using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;

namespace GMapsApp
{
    class Ciudad
    {
        private double latitud;
        private double longitud;
        private string nombre;

        private static List<Zona> zonas;

        public double Latitud { get => latitud; set => latitud = value; }
        public double Longitud { get => longitud; set => longitud = value; }
        public string Nombre { get => nombre; set => nombre = value; }

        public List<Zona> GetZonas()
        {
            return zonas;
        }

        public static void SetZonas(List<Zona> value)
        {
            zonas = value;
        }

        public Ciudad(double latitud, double longitud, string nombre)
        {
            this.latitud = latitud;
            this.longitud = longitud;
            this.nombre = nombre;
            zonas = new List<Zona>();
            agregarZonas();
        }

        

        public static void agregarZonas()
        {
            
            String line;
            try
            {
                
                StreamReader sr = new StreamReader("..\\..\\bd.csv");

                line = sr.ReadLine();
                
                
                while ((line = sr.ReadLine()) != null)
                {
                    char[] caracteres = { ',', '('};
                    
                    string[] nuevaLinea = line.Split(' ');
                    double longitud = Double.Parse(nuevaLinea[1].TrimStart(caracteres));
                    double latitud = Double.Parse(nuevaLinea[2].TrimEnd(caracteres));
                    zonas.Add(new Zona(latitud, longitud));
                }

                sr.Close();
                
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception: " + e.Message);
                
            }
        }

        public static void escribir()
        {
            try
            {

                StreamWriter sw = new StreamWriter("..\\..\\ejemplo.txt", true);

                sw.WriteLine("\n- Hola de nuevo mundo!!");

                sw.WriteLine("- :D");

                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
    }
}
