using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DesktopUI.CustomControls
{
    /// <summary>
    /// Interaction logic for VehiclePanel.xaml
    /// </summary>
    public partial class VehiclePanel : UserControl
    {
        VehiclesSqlRepository vehiclesSqlRepository;

        private Vehicle vehicle;

        public VehiclePanel(Vehicle vehicle)
        {
            InitializeComponent();

            vehiclesSqlRepository = new VehiclesSqlRepository();

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
    }
}
