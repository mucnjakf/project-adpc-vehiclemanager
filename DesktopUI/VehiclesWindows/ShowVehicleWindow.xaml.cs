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

namespace DesktopUI.VehiclesWindows
{
    /// <summary>
    /// Interaction logic for ShowVehicleWindow.xaml
    /// </summary>
    public partial class ShowVehicleWindow : Window
    {
        public ShowVehicleWindow(Vehicle vehicle)
        {
            InitializeComponent();

            LoadVehicleValues(vehicle);
        }

        private void LoadVehicleValues(Vehicle vehicle)
        {
            LblId.Text = vehicle.Id.ToString();
            LblMake.Text = vehicle.Make;
            LblModel.Text = vehicle.Model;
            LblYearOfManufacture.Text = vehicle.YearOfManufacture.ToString();
            LblInitialMileage.Text = vehicle.InitialMileage.ToString();
            LblAvailability.Text = vehicle.Available == true ? "Available" : "Not available";
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
