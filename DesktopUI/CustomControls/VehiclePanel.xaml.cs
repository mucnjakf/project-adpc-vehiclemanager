using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using DesktopUI.VehiclesWindows;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DesktopUI.CustomControls
{
    /// <summary>
    /// Interaction logic for VehiclePanel.xaml
    /// </summary>
    public partial class VehiclePanel : UserControl
    {
        readonly VehiclesSqlRepository vehiclesSqlRepository;
        readonly TravelRoutesSqlRepository travelRoutesSqlRepository;
        readonly ServicesSqlRepository servicesSqlRepository;
        readonly TravelWarrantsSqlRepository travelWarrantsSqlRepository;

        private readonly Vehicle vehicle;

        public VehiclePanel(Vehicle vehicle)
        {
            InitializeComponent();

            vehiclesSqlRepository = new VehiclesSqlRepository();
            travelWarrantsSqlRepository = new TravelWarrantsSqlRepository();
            travelRoutesSqlRepository = new TravelRoutesSqlRepository();
            servicesSqlRepository = new ServicesSqlRepository();
            serviceItemsSqlRepository = new ServiceItemsSqlRepository();

            this.vehicle = vehicle;

            SetVehicleValues();
        }

        private void SetVehicleValues()
        {
            LblMake.Text = vehicle.Make;
            LblModel.Text = vehicle.Model;
            LblAvailable.Text = vehicle.Available == true ? "Available" : "Not available";
        }

        private void BtnShow_Click(object sender, RoutedEventArgs e)
        {
            ShowVehicleWindow showVehicleWindow = new ShowVehicleWindow(vehicle);
            showVehicleWindow.Show();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            EditVehicleWindow editVehicleWindow = new EditVehicleWindow(vehicle);
            editVehicleWindow.Show();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            bool success = vehiclesSqlRepository.Delete(vehicle.Id);

            if (success)
            {
                MessageBox.Show("Success");
            }
            else
            {
                MessageBox.Show("Fail");
            }
        }

        private void BtnReport_Click(object sender, RoutedEventArgs e)
        {
            GenerateVehicleReport();
        }

        private void GenerateVehicleReport()
        {
            Vehicle v = vehiclesSqlRepository.ReadById(vehicle.Id);
            string make = v.Make;
            string model = v.Model;

            float currentlyTraveledKilometers = v.InitialMileage;

            float averageSpeed = 0;
            int counter = 0;

            List<TravelWarrant> travelWarrants = travelWarrantsSqlRepository.ReadAll();
            List<TravelRoute> travelRoutes = travelRoutesSqlRepository.ReadAll();

            foreach (TravelWarrant travelWarrant in travelWarrants)
            {
                if (travelWarrant.VehicleId == v.Id)
                {
                    TravelRoute travelRoute = travelRoutesSqlRepository.ReadById(travelWarrant.TravelRouteId);

                    currentlyTraveledKilometers += travelRoute.KilometersTraveled;
                    averageSpeed += travelRoute.AverageSpeed;
                    counter++;
                }
            }

            averageSpeed /= counter;

            var resourceName = Assembly.GetExecutingAssembly().GetManifestResourceNames().Where(q => q.Contains("Template.html")).FirstOrDefault();

            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    StringBuilder sb = new StringBuilder();
                    List<Service> services = servicesSqlRepository.ReadAll();

                    foreach (Service service in services)
                    {
                        if (service.Vehicle.Id == v.Id)
                        {
                            sb.Append("<table>\n");
                            sb.Append("<tr>\n");

                            foreach (ServiceItem serviceItem in service.ServiceItems)
                            {
                                sb.Append("<td></br>");
                                sb.Append("Service item\n");
                                sb.Append("</br>");
                                sb.Append(serviceItem.Name + "\n");
                                sb.Append("</br>");
                                sb.Append(serviceItem.Price + "\n");
                                sb.Append("</br>");
                                sb.Append("</td>\n");
                            }

                            sb.Append("</tr>\n");
                            sb.Append("</table>\n");
                        }
                    }

                    string html = reader.ReadToEnd().Replace("$$MAKE$$", make).Replace("$$MODEL$$", model).Replace("$$CTK$$", currentlyTraveledKilometers.ToString()).Replace("$$AVERAGESPEED$$", averageSpeed.ToString()).Replace("$$SERVICEITEMS$$", sb.ToString());

                    File.WriteAllText(@"../../../DataForExport/HtmlVehicleReport.html", html);
                }
            }
            MessageBox.Show("Success");
            
            System.Diagnostics.Process.Start(@"C:\Development\project-adpc-vehiclemanager\DataForExport/HtmlVehicleReport.html");
        }
    }
}