using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using DesktopUI.CustomControls;
using DesktopUI.SharedWindows;
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
    /// Interaction logic for VehicleServicesMainMenu.xaml
    /// </summary>
    public partial class VehicleServicesMainMenu : Window
    {
        ServicesSqlRepository servicesSqlRepository;

        public VehicleServicesMainMenu()
        {
            InitializeComponent();

            servicesSqlRepository = new ServicesSqlRepository();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            LoadServicesToStackPanel();
        }

        private void LoadServicesToStackPanel()
        {
            SpVehicleServices.Children.Clear();

            List<Service> services = servicesSqlRepository.ReadAll();

            foreach (Service service in services)
            {
                ServicePanel servicePanel = new ServicePanel(service);

                SpVehicleServices.Children.Add(servicePanel);
            }
        }

        private void BtnBackToStart_Click(object sender, RoutedEventArgs e)
        {
            StartWindow startWindow = new StartWindow();
            startWindow.Show();
            Close();
        }

        private void BtnCreateVehicleService_Click(object sender, RoutedEventArgs e)
        {
            CreateVehicleServiceWindow createVehicleServiceWindow = new CreateVehicleServiceWindow();
            createVehicleServiceWindow.Show();
        }
    }
}
