using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using DesktopUI.CustomControls;
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

namespace DesktopUI.VehicleServicesWindows
{
    /// <summary>
    /// Interaction logic for ShowVehicleServiceWindow.xaml
    /// </summary>
    public partial class ShowVehicleServiceWindow : Window
    {
        VehiclesSqlRepository vehiclesSqlRepository;
        ServiceItemsSqlRepository servicesItemsSqlRepository;

        public ShowVehicleServiceWindow(Service service)
        {
            InitializeComponent();

            vehiclesSqlRepository = new VehiclesSqlRepository();
            servicesItemsSqlRepository = new ServiceItemsSqlRepository();

            LoadDataToWindow(service);
        }

        private void LoadDataToWindow(Service service)
        {
            // Service

            LblIdService.Text = service.Id.ToString();
            LblDate.Text = service.DateIssued.ToShortDateString();
            LblTime.Text = service.TimeIssued.ToString();

            // Vehicle

            Vehicle vehicle = vehiclesSqlRepository.ReadById(service.Vehicle.Id);

            LblIdVehicle.Text = vehicle.Id.ToString();
            LblMake.Text = vehicle.Make;
            LblModel.Text = vehicle.Model;
            LblYearOfManufacture.Text = vehicle.YearOfManufacture.ToString();
            LblInitialMileage.Text = vehicle.InitialMileage.ToString();
            LblAvailability.Text = vehicle.Available == true ? "Available" : "Not available";

            // Service Items

            foreach (ServiceItem serviceItem in service.ServiceItems)
            {
                ServiceItemPanel serviceItemPanel = new ServiceItemPanel(serviceItem);

                serviceItemPanel.ChBxServiceItem.Visibility = Visibility.Hidden;
                serviceItemPanel.BtnEdit.Visibility = Visibility.Hidden;
                serviceItemPanel.BtnDelete.Visibility = Visibility.Hidden;

                SpServiceItems.Children.Add(serviceItemPanel);
            }
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
