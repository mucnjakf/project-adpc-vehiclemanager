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
    /// Interaction logic for CreateVehicleWindow.xaml
    /// </summary>
    public partial class CreateVehicleWindow : Window
    {
        VehiclesSqlRepository vehiclesSqlRepository;

        public CreateVehicleWindow()
        {
            InitializeComponent();

            vehiclesSqlRepository = new VehiclesSqlRepository();
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            CreateVehicle();
        }

        private void CreateVehicle()
        {
            if (TbMake.Text != string.Empty && TbModel.Text != string.Empty && TbYearOfManufacture.Text != string.Empty && TbInitialMileage.Text != string.Empty && CbAvailable.SelectedItem != null)
            {
                if (int.TryParse(TbYearOfManufacture.Text, out int yearOfManufacture) && int.TryParse(TbInitialMileage.Text, out int initialMileage))
                {
                    Vehicle createdVehicle = new Vehicle()
                    {
                        Make = TbMake.Text,
                        Model = TbModel.Text,
                        YearOfManufacture = yearOfManufacture,
                        InitialMileage = initialMileage,
                        Available = CbiAvailable.IsSelected ? true : false
                    };

                    bool success = vehiclesSqlRepository.Create(createdVehicle);

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
