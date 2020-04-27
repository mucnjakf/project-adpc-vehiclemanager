using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
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
    /// Interaction logic for EditVehicleWindow.xaml
    /// </summary>
    public partial class EditVehicleWindow : Window
    {
        VehiclesSqlRepository vehiclesSqlRepository;

        private Vehicle vehicle;

        public EditVehicleWindow(Vehicle vehicle)
        {
            InitializeComponent();

            vehiclesSqlRepository = new VehiclesSqlRepository();

            this.vehicle = vehicle;

            LoadVehicleToForm(vehicle);
        }

        private void LoadVehicleToForm(Vehicle vehicle)
        {
            TbMake.Text = vehicle.Make;
            TbModel.Text = vehicle.Model;
            TbYearOfManufacture.Text = vehicle.YearOfManufacture.ToString();
            TbInitialMileage.Text = vehicle.InitialMileage.ToString();
            CbAvailable.SelectedItem = vehicle.Available == true ? CbAvailable.SelectedItem = CbiAvailable : CbAvailable.SelectedItem = CbiNotAvailable;
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            UpdateVehicle();
        }

        private void UpdateVehicle()
        {
            if (TbMake.Text != string.Empty && TbModel.Text != string.Empty && TbYearOfManufacture.Text != string.Empty && TbInitialMileage.Text != string.Empty && CbAvailable.SelectedItem != null)
            {
                if (int.TryParse(TbYearOfManufacture.Text, out int yearOfManufacture) && int.TryParse(TbInitialMileage.Text, out int initialMileage))
                {
                    Vehicle updatedVehicle = new Vehicle()
                    {
                        Id = vehicle.Id,
                        Make = TbMake.Text,
                        Model = TbModel.Text,
                        YearOfManufacture = yearOfManufacture,
                        InitialMileage = initialMileage,
                        Available = CbiAvailable.IsSelected ? true : false
                    };

                    bool success = vehiclesSqlRepository.Update(updatedVehicle);

                    if (success)
                    {
                        MessageBox.Show("Success");
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Fail");
                    }
                }
                else
                {
                    MessageBox.Show("Year of manufacture and initial mileage must be numbers");
                }
            }
            else
            {
                MessageBox.Show("All input fields are required");
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
