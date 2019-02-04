using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMapsApp
{
    class Zona       
    {
        private String latitud;
        private String longitud;

        public String Latitud { get => latitud; set => latitud = value; }
        public String Longitud { get => longitud; set => longitud = value; }

        public Zona(String latitud, String longitud)
        {
            this.latitud = latitud;
            this.longitud = longitud;
        }
    }
}
