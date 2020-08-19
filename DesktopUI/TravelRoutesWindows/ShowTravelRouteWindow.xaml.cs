using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml;

namespace DesktopUI.TravelRoutesWindows
{
    /// <summary>
    /// Interaction logic for ShowTravelRoutesWindow.xaml
    /// </summary>
    public partial class ShowTravelRouteWindow : Window
    {
        private TravelRoute travelRoute;

        public ShowTravelRouteWindow(TravelRoute travelRoute)
        {
            InitializeComponent();

            this.travelRoute = travelRoute;

            LoadTravelRouteValues(travelRoute);
        }

        private void LoadTravelRouteValues(TravelRoute travelRoute)
        {
            LblId.Text = travelRoute.Id.ToString();
            LblDateIssued.Text = travelRoute.DateIssued.ToShortDateString();
            LblTimeIssued.Text = travelRoute.TimeIssued.ToString();
            LblOrigin.Text = travelRoute.Origin;
            LblDestination.Text = travelRoute.Destination;
            LblKilometersTraveled.Text = travelRoute.KilometersTraveled.ToString();
            LblAverageSpeed.Text = travelRoute.AverageSpeed.ToString();
            LblSpentFuel.Text = travelRoute.SpentFuel.ToString();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnExportToXml_Click(object sender, RoutedEventArgs e)
        {
            ExportTravelRouteToXml();
        }

        private void ExportTravelRouteToXml()
        {
            XmlWriterSettings xmlSettings = new XmlWriterSettings()
            {
                Indent = true
            };
            XmlWriter xmlWriter = XmlWriter.Create(@"..\..\..\DataForExport\TravelRoute.xml", xmlSettings);

            xmlWriter.WriteStartDocument();

            xmlWriter.WriteStartElement("TravelRoute");
            xmlWriter.WriteAttributeString("Id", travelRoute.Id.ToString());

            xmlWriter.WriteStartElement("DateIssued");
            xmlWriter.WriteString(travelRoute.DateIssued.ToShortDateString());
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("TimeIssued");
            xmlWriter.WriteString(travelRoute.TimeIssued.ToString());
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("Origin");
            xmlWriter.WriteString(travelRoute.Origin.ToString());
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("Destination");
            xmlWriter.WriteString(travelRoute.Destination.ToString());
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("KilometersTraveled");
            xmlWriter.WriteString(travelRoute.KilometersTraveled.ToString());
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("AverageSpeed");
            xmlWriter.WriteString(travelRoute.AverageSpeed.ToString());
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("SpentFuel");
            xmlWriter.WriteString(travelRoute.SpentFuel.ToString());
            xmlWriter.WriteEndElement();

            xmlWriter.WriteEndElement();

            xmlWriter.Close();

            MessageBox.Show("Success");
            Close();
        }
    }
}