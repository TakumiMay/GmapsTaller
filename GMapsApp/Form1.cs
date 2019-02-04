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
        private GMapOverlay markersOverlay;
        private GMarkerGoogle marker;

        public Form1()
        {
            ciudad = new Ciudad(3.42158, -76.5205, "Cali");
            InitializeComponent();
            markersOverlay = new GMapOverlay("markers");
            marker = new GMarkerGoogle(new PointLatLng(0, 0),
              GMarkerGoogleType.green_small);
            markersOverlay.Markers.Add(marker);
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            double longitud = Double.Parse(txtLongitud.Text);
            double latitud = Double.Parse(txtLatitud.Text);
            PointLatLng point = new PointLatLng(latitud, longitud);
            marker = new GMarkerGoogle(point, GMarkerGoogleType.green_small);
            markersOverlay.Markers.Add(marker);
            gMap.Overlays.Add(markersOverlay);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gMap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            gMap.Position = new GMap.NET.PointLatLng(ciudad.Latitud, ciudad.Longitud);

            for (int i = 0; i < ciudad.GetZonas().Count; i++)
            {
                double longi = ciudad.GetZonas()[i].Longitud;
                double lat = ciudad.GetZonas()[i].Latitud;
                marker = new GMarkerGoogle(new PointLatLng(lat, longi), GMarkerGoogleType.green_small);


                markersOverlay.Markers.Add(marker);
                gMap.Overlays.Add(markersOverlay);
                gMap.Update();
                //MessageBox.Show("longitud "+longi + " latitud" + lat);            
            }
        }
    }
}
    
