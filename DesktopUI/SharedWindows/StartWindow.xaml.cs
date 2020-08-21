using DesktopUI.DriversWindows;
using DesktopUI.TravelWarrantsWindows;
using DesktopUI.VehicleServicesWindows;
using DesktopUI.VehiclesWindows;
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

namespace DesktopUI.SharedWindows
{
    /// <summary>
    /// Interaction logic for StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
        }

        private void BtnDrivers_Click(object sender, RoutedEventArgs e)
        {
            DriversMainMenu driversMainMenu = new DriversMainMenu();
            driversMainMenu.Show();
            Close();
        }

        private void BtnVehicles_Click(object sender, RoutedEventArgs e)
        {
            VehiclesMainMenu vehiclesMainMenu = new VehiclesMainMenu();
            vehiclesMainMenu.Show();
            Close();
        }

        private void BtnTravelWarrants_Click(object sender, RoutedEventArgs e)
        {
            TravelWarrantsMainMenu travelWarrantsMainMenu = new TravelWarrantsMainMenu();
            travelWarrantsMainMenu.Show();
            Close();
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnBackupRestoreClearDatabase_Click(object sender, RoutedEventArgs e)
        {
            BackupAndRestoreWindow backupAndRestoreWindow = new BackupAndRestoreWindow();
            backupAndRestoreWindow.ShowDialog();
        }

        private void BtnVehicleService_Click(object sender, RoutedEventArgs e)
        {
            VehicleServicesMainMenu vehicleServicesMainMenu = new VehicleServicesMainMenu();
            vehicleServicesMainMenu.Show();
            Close();
        }
    }
}
