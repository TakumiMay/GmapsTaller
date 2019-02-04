using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMapsApp
{
    class Zona       
    {
        private double latitud;
        private double longitud;

        public double Latitud { get => latitud; set => latitud = value; }
        public double Longitud { get => longitud; set => longitud = value; }

        public Zona(double latitud, double longitud)
        {
            this.latitud = latitud;
            this.longitud = longitud;
        }
    }
}
