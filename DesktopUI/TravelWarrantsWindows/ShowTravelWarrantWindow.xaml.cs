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

namespace DesktopUI.TravelWarrantsWindows
{
    /// <summary>
    /// Interaction logic for ShowTravelWarrantWindow.xaml
    /// </summary>
    public partial class ShowTravelWarrantWindow : Window
    {
        DriversSqlRepository driversSqlRepository;
        VehiclesSqlRepository vehiclesSqlRepository;
        FuelCostsSqlRepository fuelCostsSqlRepository;
        TravelRoutesSqlRepository travelRoutesSqlRepository;

        public ShowTravelWarrantWindow(TravelWarrant travelWarrant)
        {
            InitializeComponent();

            driversSqlRepository = new DriversSqlRepository();
            vehiclesSqlRepository = new VehiclesSqlRepository();
            fuelCostsSqlRepository = new FuelCostsSqlRepository();
            travelRoutesSqlRepository = new TravelRoutesSqlRepository();

            LoadDataToWindow(travelWarrant);
        }

        private void LoadDataToWindow(TravelWarrant travelWarrant)
        {
            // Travel Warrant

            LblIdTravelWarrant.Text = travelWarrant.Id.ToString();
            LblStatus.Text = travelWarrant.WarrantStatus;
            LblDateTravelWarrant.Text = travelWarrant.DateIssued.ToShortDateString();
            LblTimeTravelWarrant.Text = travelWarrant.TimeIssued.ToString();

            // Driver

            Driver driver = driversSqlRepository.ReadById(travelWarrant.DriverId);

            LblIdDriver.Text = driver.Id.ToString();
            LblFirstName.Text = driver.FirstName;
            LblLastName.Text = driver.LastName;
            LblPhoneNumber.Text = driver.PhoneNumber;
            LblDriversLicenceNumber.Text = driver.DriversLicenceNumber;

            // Vehicle

            Vehicle vehicle = vehiclesSqlRepository.ReadById(travelWarrant.VehicleId);

            LblIdVehicle.Text = vehicle.Id.ToString();
            LblMake.Text = vehicle.Make;
            LblModel.Text = vehicle.Model;
            LblYearOfManufacture.Text = vehicle.YearOfManufacture.ToString();
            LblInitialMileage.Text = vehicle.YearOfManufacture.ToString();
            LblAvailability.Text = vehicle.Available == true ? "Available" : "Not available";

            // Fuel Cost

            FuelCost fuelCost = fuelCostsSqlRepository.ReadById(travelWarrant.FuelCostId);

            LblIdFuelCost.Text = fuelCost.Id.ToString();
            LblDateIssuedFc.Text = fuelCost.DateIssued.ToShortDateString();
            LblTimeIssuedFc.Text = fuelCost.TimeIssued.ToString();
            LblPosition.Text = fuelCost.Position;
            LblAmount.Text = fuelCost.Amount.ToString();
            LblPrice.Text = fuelCost.Price.ToString();

            // Travel Route

            TravelRoute travelRoute = travelRoutesSqlRepository.ReadById(travelWarrant.TravelRouteId);

            LblIdTravelRoute.Text = travelRoute.Id.ToString();
            LblDateIssuedTr.Text = travelRoute.DateIssued.ToShortDateString();
            LblTimeIssuedTr.Text = travelRoute.TimeIssued.ToString();
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
    }
}
