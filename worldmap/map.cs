using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using LiveCharts.WinForms;

namespace worldmap
{
    public partial class map : Form
    {
        public map()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Class1 class1 = new Class1();
            int[] color = class1.color;
            GeoMap geoMap = new GeoMap();
            //Random random = new Random();
            //gives value
            Dictionary<string, double> values = new Dictionary<string, double>();

            // creat province
            for (int i = 1; i < 65; i++) { 
                String x = i.ToString();
                if (i < 10)
                {
                    x = "0" + x;
                }
                values[x] = color[i];
            }
            
            //change default color
            //geoMap.DefaultLandFill = new SolidColorBrush(Colors.Transparent);

            //change heat color
            GradientStopCollection collection = new GradientStopCollection();
            collection.Add(new GradientStop() { Color = System.Windows.Media.Color.FromArgb(64, 64, 64, 0), Offset = 0 });
            collection.Add(new GradientStop() { Color = System.Windows.Media.Color.FromArgb(128, 128, 128, 0), Offset = 0.5 });
            collection.Add(new GradientStop() { Color = System.Windows.Media.Color.FromArgb(255, 255, 255, 0), Offset = 1 });
            
            geoMap.GradientStopCollection = collection;
            //geoMap.map
            //change boundary color
            //geoMap.LandStroke = new SolidColorBrush(Colors.Black);
            
            geoMap.HeatMap = values;
            geoMap.Hoverable = true;
            geoMap.Source = $"{Application.StartupPath}\\vietnam.xml";
            this.Controls.Add(geoMap);
            geoMap.Dock = DockStyle.Fill;
        }
    }
    // Binh Phuoc-Dak Nong
    // Son La - Thanh Hoa
}
