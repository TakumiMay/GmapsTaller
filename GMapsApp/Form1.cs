using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GMapsApp
{
    public partial class Form1 : Form
    {
        private Ciudad ciudad;

        public Form1()
        {
            ciudad = new Ciudad(3.42158, -76.5205, "Cali");
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gMap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            gMap.Position = new GMap.NET.PointLatLng(ciudad.Latitud, ciudad.Longitud);



            GMapOverlay markersOverlay = new GMapOverlay("markers");

            for (int i = 0; i < ciudad.GetZonas().Count; i++)
            {
                double longi = Double.Parse(ciudad.GetZonas()[i].Longitud.Substring(7));
                double lat = Double.Parse(ciudad.GetZonas()[i].Latitud.Substring(7));
                
                GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(lat, longi),
              GMarkerGoogleType.green_small);
                marker.IsVisible = true;
                markersOverlay.Markers.Add(marker);
                gMap.Overlays.Add(markersOverlay);
            }



        }
    }
}
