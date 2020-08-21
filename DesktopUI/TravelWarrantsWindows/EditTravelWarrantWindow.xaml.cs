using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using DesktopUI.CustomControls;
using DesktopUI.FuelCostsWindows;
using DesktopUI.TravelRoutesWindows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for EditTravelWarrantWindow.xaml
    /// </summary>
    public partial class EditTravelWarrantWindow : Window
    {
        DriversSqlRepository driversSqlRepository;
        VehiclesSqlRepository vehiclesSqlRepository;
        FuelCostsSqlRepository fuelCostsSqlRepository;
        TravelRoutesSqlRepository travelRoutesSqlRepository;
        TravelWarrantsSqlRepository travelWarrantsSqlRepository;

        private TravelWarrant travelWarrant;

        public EditTravelWarrantWindow(TravelWarrant travelWarrant)
        {
            InitializeComponent();

            driversSqlRepository = new DriversSqlRepository();
            vehiclesSqlRepository = new VehiclesSqlRepository();
            fuelCostsSqlRepository = new FuelCostsSqlRepository();
            travelRoutesSqlRepository = new TravelRoutesSqlRepository();
            travelWarrantsSqlRepository = new TravelWarrantsSqlRepository();

            this.travelWarrant = travelWarrant;

            LoadTravelWarrantToWindow(travelWarrant);
        }

        private void LoadTravelWarrantToWindow(TravelWarrant travelWarrant)
        {
            CbStatus.Text = travelWarrant.WarrantStatus;
            TbDate.Text = travelWarrant.DateIssued.ToShortDateString();
            TbTime.Text = travelWarrant.TimeIssued.ToString();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDriversToComboBox();
            LoadVehiclesToComboBox();
        }
        private void LoadVehiclesToComboBox()
        {
            CbVehicles.ItemsSource = vehiclesSqlRepository.ReadAll();
        }

        private void LoadDriversToComboBox()
        {
            CbDrivers.ItemsSource = driversSqlRepository.ReadAll();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            LoadFuelCostsToStackPanel();
            LoadTravelRoutesToStackPanel();
        }

        private void LoadTravelRoutesToStackPanel()
        {
            SpTravelRoutes.Children.Clear();

            List<TravelRoute> travelRoutes = travelRoutesSqlRepository.ReadAll();

            foreach (TravelRoute travelRoute in travelRoutes)
            {
                TravelRoutePanel travelRoutePanel = new TravelRoutePanel(travelRoute);

                SpTravelRoutes.Children.Add(travelRoutePanel);
            }
        }

        private void LoadFuelCostsToStackPanel()
        {
            SpFuelCosts.Children.Clear();

            List<FuelCost> fuelCosts = fuelCostsSqlRepository.ReadAll();

            foreach (FuelCost fuelCost in fuelCosts)
            {
                FuelCostPanel fuelCostPanel = new FuelCostPanel(fuelCost);

                SpFuelCosts.Children.Add(fuelCostPanel);
            }
        }
        private void BtnCreateFuelCost_Click(object sender, RoutedEventArgs e)
        {
            CreateFuelCostWindow createFuelCostWindow = new CreateFuelCostWindow();
            createFuelCostWindow.Show();
        }

        private void BtnCreateTravelRoute_Click(object sender, RoutedEventArgs e)
        {
            CreateTravelRouteWindow createTravelRouteWindow = new CreateTravelRouteWindow();
            createTravelRouteWindow.Show();
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            UpdateTravelWarrant();
        }

        private void UpdateTravelWarrant()
        {
            if(CbStatus.Text != string.Empty && TbDate.Text != string.Empty && TbTime.Text != string.Empty)
            {
                if (DateTime.TryParse(TbDate.Text, out DateTime date) && (TimeSpan.TryParse(TbTime.Text, out TimeSpan time)))
                {
                    if ((Regex.IsMatch(TbDate.Text, @"\d\d/\d\d/\d\d\d\d") || Regex.IsMatch(TbDate.Text, @"\d/\d\d/\d\d\d\d")) && Regex.IsMatch(TbTime.Text, @"\d\d:\d\d:\d\d"))
                    {
                        int driverId = int.Parse(CbDrivers.Text.Substring(0, CbDrivers.Text.IndexOf(' ')));
                        int vehicleId = int.Parse(CbVehicles.Text.Substring(0, CbVehicles.Text.IndexOf(' ')));
                        int fuelCostId = 0;
                        int travelRouteId = 0;

                        foreach (FuelCostPanel fuelCostPanel in SpFuelCosts.Children)
                        {
                            if (fuelCostPanel.RbFcSelect.IsChecked == true)
                            {
                                fuelCostId = int.Parse(fuelCostPanel.LblId.Text);
                            }
                        }

                        foreach (TravelRoutePanel travelRoutePanel in SpTravelRoutes.Children)
                        {
                            if (travelRoutePanel.RbTrSelect.IsChecked == true)
                            {
                                travelRouteId = int.Parse(travelRoutePanel.LblId.Text);
                            }
                        }

                        TravelWarrant updatedTravelWarrant = new TravelWarrant
                        {
                            Id = travelWarrant.Id,
                            WarrantStatus = CbStatus.Text,
                            DateIssued = date,
                            TimeIssued = time,
                            DriverId = driverId,
                            VehicleId = vehicleId,
                            FuelCostId = fuelCostId,
                            TravelRouteId = travelRouteId
                        };

                        bool success = travelWarrantsSqlRepository.Update(updatedTravelWarrant);

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
                        MessageBox.Show("Date format must be: \"MM/dd/yyyy\"\nTime format must be: \"HH:MM:ss\"");
                    }
                }
                else
                {
                    MessageBox.Show("Date format must be: \"MM/dd/yyyy\"\nTime format must be: \"HH:MM:ss\"");
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
