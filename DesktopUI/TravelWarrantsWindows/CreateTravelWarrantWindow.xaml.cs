using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using DesktopUI.CustomControls;
using DesktopUI.FuelCostsWindows;
using DesktopUI.TravelRoutesWindows;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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
using System.Xml;

namespace DesktopUI.TravelWarrantsWindows
{
    /// <summary>
    /// Interaction logic for CreateTravelWarrantWindow.xaml
    /// </summary>
    public partial class CreateTravelWarrantWindow : Window
    {
        DriversSqlRepository driversSqlRepository;
        VehiclesSqlRepository vehiclesSqlRepository;
        FuelCostsSqlRepository fuelCostsSqlRepository;
        TravelRoutesSqlRepository travelRoutesSqlRepository;
        TravelWarrantsSqlRepository travelWarrantsSqlRepository;

        public CreateTravelWarrantWindow()
        {
            InitializeComponent();

            driversSqlRepository = new DriversSqlRepository();
            vehiclesSqlRepository = new VehiclesSqlRepository();
            fuelCostsSqlRepository = new FuelCostsSqlRepository();
            travelRoutesSqlRepository = new TravelRoutesSqlRepository();
            travelWarrantsSqlRepository = new TravelWarrantsSqlRepository();

            TbDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
            TbTime.Text = DateTime.Now.ToString("HH:MM:ss");
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            CreateTravelWarrant();
        }

        private void CreateTravelWarrant()
        {
            if (CbStatus.Text != string.Empty && TbDate.Text != string.Empty && TbTime.Text != string.Empty && CbDrivers.Text != string.Empty && CbVehicles.Text != string.Empty)
            {
                if (DateTime.TryParse(TbDate.Text, out DateTime date) && (TimeSpan.TryParse(TbTime.Text, out TimeSpan time)))
                {
                    if (Regex.IsMatch(TbDate.Text, @"\d\d/\d\d/\d\d\d\d") && Regex.IsMatch(TbTime.Text, @"\d\d:\d\d:\d\d"))
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

                        TravelWarrant createdTravelWarrant = new TravelWarrant
                        {
                            WarrantStatus = CbStatus.Text,
                            DateIssued = date,
                            TimeIssued = time,
                            DriverId = driverId,
                            VehicleId = vehicleId,
                            FuelCostId = fuelCostId,
                            TravelRouteId = travelRouteId
                        };

                        vehiclesSqlRepository.UpdateVehicleAvailability(vehicleId, false);

                        bool success = travelWarrantsSqlRepository.Create(createdTravelWarrant);

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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDriversToComboBox();
            LoadVehiclesToComboBox();
        }

        private void LoadVehiclesToComboBox()
        {
            CbVehicles.ItemsSource = vehiclesSqlRepository.ReadAll().Where(v => v.Available != false);
        }

        private void LoadDriversToComboBox()
        {
            CbDrivers.ItemsSource = driversSqlRepository.ReadAll();
        }

        private void BtnCreateFuelCost_Click(object sender, RoutedEventArgs e)
        {
            CreateFuelCostWindow createFuelCostWindow = new CreateFuelCostWindow();
            createFuelCostWindow.Show();
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

        private void BtnCreateTravelRoute_Click(object sender, RoutedEventArgs e)
        {
            CreateTravelRouteWindow createTravelRouteWindow = new CreateTravelRouteWindow();
            createTravelRouteWindow.Show();
        }

        private void BtnImportTravelRouteFromXml_Click(object sender, RoutedEventArgs e)
        {
            ImportTravelRouteFromXml();
        }

        private void ImportTravelRouteFromXml()
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();

                if (openFileDialog.ShowDialog() == true)
                {
                    string filePath = openFileDialog.FileName;

                    XmlDocument doc = new XmlDocument();

                    doc.Load(filePath);

                    List<string> travelRouteData = new List<string>();

                    foreach (XmlNode node in doc.DocumentElement.ChildNodes)
                    {
                        travelRouteData.Add(node.InnerText);
                    }

                    DateTime dateIssued = DateTime.Parse(travelRouteData[0]);
                    TimeSpan timeIssued = TimeSpan.Parse(travelRouteData[1]);
                    string origin = travelRouteData[2];
                    string destination = travelRouteData[3];
                    float kilometersTraveled = float.Parse(travelRouteData[4]);
                    float averageSpeed = float.Parse(travelRouteData[5]);
                    float spentFuel = float.Parse(travelRouteData[6]);

                    TravelRoute travelRoute = new TravelRoute(dateIssued, timeIssued, origin, destination, kilometersTraveled, averageSpeed, spentFuel);

                    bool success = travelRoutesSqlRepository.Create(travelRoute);

                    if (success)
                    {
                        MessageBox.Show("Success");
                    }
                    else
                    {
                        MessageBox.Show("Fail");
                    }

                    LoadTravelRoutesToStackPanel();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnExportTravelRoutesToXml_Click(object sender, RoutedEventArgs e)
        {
            ExportTravelRoutesToXml();
        }

        private void ExportTravelRoutesToXml()
        {
            List<TravelRoute> travelRoutes = travelRoutesSqlRepository.ReadAll();

            DataSet ds = new DataSet("TravelRoutes");
            DataTable dt = new DataTable();

            ds.Tables.Add(dt);

            ds.Tables[0].TableName = "TravelRoute";

            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("DateIssued", typeof(string));
            dt.Columns.Add("TimeIssued", typeof(string));
            dt.Columns.Add("Origin", typeof(string));
            dt.Columns.Add("Destination", typeof(string));
            dt.Columns.Add("KilometersTraveled", typeof(float));
            dt.Columns.Add("AverageSpeed", typeof(float));
            dt.Columns.Add("SpentFuel", typeof(float));

            foreach (TravelRoute travelRoute in travelRoutes)
            {
                DataRow row = dt.Rows.Add();
                row.SetField("Id", travelRoute.Id);
                row.SetField("DateIssued", travelRoute.DateIssued.ToShortDateString());
                row.SetField("TimeIssued", travelRoute.TimeIssued);
                row.SetField("Origin", travelRoute.Origin);
                row.SetField("Destination", travelRoute.Destination);
                row.SetField("KilometersTraveled", travelRoute.KilometersTraveled);
                row.SetField("AverageSpeed", travelRoute.AverageSpeed);
                row.SetField("SpentFuel", travelRoute.SpentFuel);
            }

            ds.WriteXml("../../../DataForExport/TravelRoutes.xml");

            MessageBox.Show("Success");
        }
    }
}
