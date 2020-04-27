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

namespace DesktopUI.VehiclesWindows
{
    /// <summary>
    /// Interaction logic for VehiclesMainMenu.xaml
    /// </summary>
    public partial class VehiclesMainMenu : Window
    {
        VehiclesSqlRepository vehiclesSqlRepository = new VehiclesSqlRepository();

        public VehiclesMainMenu()
        {
            InitializeComponent();

            vehiclesSqlRepository = new VehiclesSqlRepository();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            LoadVehiclesToStackPanel();
        }

        private void LoadVehiclesToStackPanel()
        {
            SpVehicles.Children.Clear();

            List<Vehicle> vehicles = vehiclesSqlRepository.ReadAll();

            foreach (Vehicle vehicle in vehicles)
            {
                VehiclePanel vehiclePanel = new VehiclePanel(vehicle);

                SpVehicles.Children.Add(vehiclePanel);
            }
        }

        private void BtnBackToStart_Click(object sender, RoutedEventArgs e)
        {
            StartWindow startWindow = new StartWindow();
            startWindow.Show();
            Close();
        }

        private void BtnCreateVehicle_Click(object sender, RoutedEventArgs e)
        {
            CreateVehicleWindow createVehicleWindow = new CreateVehicleWindow();
            createVehicleWindow.Show();
        }
    }
}
