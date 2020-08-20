using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Xml;

namespace DesktopUI.SharedWindows
{
    /// <summary>
    /// Interaction logic for BackupAndRestoreWindow.xaml
    /// </summary>
    public partial class BackupAndRestoreWindow : Window
    {
        readonly DriversSqlRepository driversSqlRepository;
        readonly VehiclesSqlRepository vehiclesSqlRepository;
        readonly TravelRoutesSqlRepository travelRoutesSqlRepository;
        readonly FuelCostsSqlRepository fuelCostsSqlRepository;
        readonly TravelWarrantsSqlRepository travelWarrantsSqlRepository;

        public BackupAndRestoreWindow()
        {
            InitializeComponent();

            driversSqlRepository = new DriversSqlRepository();
            vehiclesSqlRepository = new VehiclesSqlRepository();
            travelRoutesSqlRepository = new TravelRoutesSqlRepository();
            fuelCostsSqlRepository = new FuelCostsSqlRepository();
            travelWarrantsSqlRepository = new TravelWarrantsSqlRepository();
        }

        private void BtnBackup_Click(object sender, RoutedEventArgs e)
        {
            BackupDatabase();
        }


        private void BtnRestore_Click(object sender, RoutedEventArgs e)
        {
            RestoreDatabase();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BackupDatabase()
        {
            XmlWriterSettings xmlSettings = new XmlWriterSettings()
            {
                Indent = true
            };
            XmlWriter xmlWriter = XmlWriter.Create(@"..\..\..\DatabaseBackup\DbBackup.xml", xmlSettings);

            xmlWriter.WriteStartDocument();

            xmlWriter.WriteStartElement("DatabaseBackup");

            xmlWriter = WriteDrivers(xmlWriter);
            xmlWriter = WriteVehicles(xmlWriter);
            xmlWriter = WriteTravelRoutes(xmlWriter);
            xmlWriter = WriteFuelCosts(xmlWriter);
            xmlWriter = WriteTravelWarrants(xmlWriter);
            
            xmlWriter.WriteEndElement();

            xmlWriter.Close();

            MessageBox.Show("Success");

            Close();
        }

        private XmlWriter WriteDrivers(XmlWriter xmlWriter)
        {
            List<Driver> drivers = driversSqlRepository.ReadAll();

            xmlWriter.WriteStartElement("Drivers");

            foreach (Driver driver in drivers)
            {
                xmlWriter.WriteStartElement("Driver");
                xmlWriter.WriteAttributeString("Id", driver.Id.ToString());

                xmlWriter.WriteStartElement("FirstName");
                xmlWriter.WriteString(driver.FirstName);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("LastName");
                xmlWriter.WriteString(driver.LastName);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("PhoneNumber");
                xmlWriter.WriteString(driver.PhoneNumber);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("DriversLicenceNumber");
                xmlWriter.WriteString(driver.DriversLicenceNumber);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteEndElement();
            }

            xmlWriter.WriteEndElement();

            return xmlWriter;
        }

        private XmlWriter WriteVehicles(XmlWriter xmlWriter)
        {
            List<Vehicle> vehicles = vehiclesSqlRepository.ReadAll();

            xmlWriter.WriteStartElement("Vehicles");

            foreach (Vehicle vehicle in vehicles)
            {
                xmlWriter.WriteStartElement("Vehicle");
                xmlWriter.WriteAttributeString("Id", vehicle.Id.ToString());

                xmlWriter.WriteStartElement("Make");
                xmlWriter.WriteString(vehicle.Make);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("Model");
                xmlWriter.WriteString(vehicle.Model);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("YearOfManufacture");
                xmlWriter.WriteString(vehicle.YearOfManufacture.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("InitialMileage");
                xmlWriter.WriteString(vehicle.InitialMileage.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("Available");
                xmlWriter.WriteString(vehicle.Available.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteEndElement();
            }

            xmlWriter.WriteEndElement();

            return xmlWriter;
        }

        private XmlWriter WriteTravelRoutes(XmlWriter xmlWriter)
        {
            List<TravelRoute> travelRoutes = travelRoutesSqlRepository.ReadAll();

            xmlWriter.WriteStartElement("TravelRoutes");

            foreach (TravelRoute travelRoute in travelRoutes)
            {
                xmlWriter.WriteStartElement("TravelRoute");
                xmlWriter.WriteAttributeString("Id", travelRoute.Id.ToString());

                xmlWriter.WriteStartElement("DateIssued");
                xmlWriter.WriteString(travelRoute.DateIssued.ToShortDateString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("TimeIssued");
                xmlWriter.WriteString(travelRoute.TimeIssued.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("Origin");
                xmlWriter.WriteString(travelRoute.Origin);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("Destination");
                xmlWriter.WriteString(travelRoute.Destination);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("KilometersTraveled");
                xmlWriter.WriteString(travelRoute.KilometersTraveled.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("AverageSpeed");
                xmlWriter.WriteString(travelRoute.AverageSpeed.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("SpentFuel");
                xmlWriter.WriteString(travelRoute.SpentFuel.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteEndElement();
            }

            xmlWriter.WriteEndElement();

            return xmlWriter;
        }

        private XmlWriter WriteFuelCosts(XmlWriter xmlWriter)
        {
            List<FuelCost> fuelCosts = fuelCostsSqlRepository.ReadAll();

            xmlWriter.WriteStartElement("FuelCosts");

            foreach (FuelCost fuelCost in fuelCosts)
            {
                xmlWriter.WriteStartElement("FuelCost");
                xmlWriter.WriteAttributeString("Id", fuelCost.Id.ToString());

                xmlWriter.WriteStartElement("DateIssued");
                xmlWriter.WriteString(fuelCost.DateIssued.ToShortDateString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("TimeIssued");
                xmlWriter.WriteString(fuelCost.TimeIssued.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("Position");
                xmlWriter.WriteString(fuelCost.Position);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("Amount");
                xmlWriter.WriteString(fuelCost.Amount.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("Price");
                xmlWriter.WriteString(fuelCost.Price.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteEndElement();
            }

            xmlWriter.WriteEndElement();

            return xmlWriter;
        }

        private XmlWriter WriteTravelWarrants(XmlWriter xmlWriter)
        {
            List<TravelWarrant> travelWarrants = travelWarrantsSqlRepository.ReadAll();

            xmlWriter.WriteStartElement("TravelWarrants");

            foreach (TravelWarrant travelWarrant in travelWarrants)
            {
                xmlWriter.WriteStartElement("TravelWarrant");
                xmlWriter.WriteAttributeString("Id", travelWarrant.Id.ToString());

                xmlWriter.WriteStartElement("WarrantStatus");
                xmlWriter.WriteString(travelWarrant.WarrantStatus);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("DateIssued");
                xmlWriter.WriteString(travelWarrant.DateIssued.ToShortDateString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("TimeIssued");
                xmlWriter.WriteString(travelWarrant.TimeIssued.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("DriverId");
                xmlWriter.WriteString(travelWarrant.DriverId.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("VehicleId");
                xmlWriter.WriteString(travelWarrant.VehicleId.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("TravelRouteId");
                xmlWriter.WriteString(travelWarrant.TravelRouteId.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("FuelCostId");
                xmlWriter.WriteString(travelWarrant.FuelCostId.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteEndElement();
            }

            xmlWriter.WriteEndElement();

            return xmlWriter;
        }

        private void RestoreDatabase()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;

                ReadDrivers(filePath);
                ReadVehicles(filePath);
                ReadTravelRoutes(filePath);
                ReadFuelCosts(filePath);
                ReadTravelWarrants(filePath);

                MessageBox.Show("Success");

                Close();
            }
        }

        private void ReadDrivers(string filePath)
        {
            XmlReader xmlReader = XmlReader.Create(filePath);

            xmlReader.ReadToFollowing("Driver");

            do
            {
                xmlReader.MoveToFirstAttribute();
                int id = int.Parse(xmlReader.Value);

                xmlReader.ReadToFollowing("FirstName");
                string firstName = xmlReader.ReadElementContentAsString();

                xmlReader.ReadToFollowing("LastName");
                string lastName = xmlReader.ReadElementContentAsString();

                xmlReader.ReadToFollowing("PhoneNumber");
                string phoneNumber = xmlReader.ReadElementContentAsString();

                xmlReader.ReadToFollowing("DriversLicenceNumber");
                string driversLicenceNumber = xmlReader.ReadElementContentAsString();

                Driver driver = new Driver()
                {
                    Id = id,
                    FirstName = firstName,
                    LastName = lastName,
                    PhoneNumber = phoneNumber,
                    DriversLicenceNumber = driversLicenceNumber
                };

                driversSqlRepository.Restore(driver);

            } while (xmlReader.ReadToFollowing("Driver"));

            xmlReader.Close();
        }

        private void ReadVehicles(string filePath)
        {
            XmlReader xmlReader = XmlReader.Create(filePath);

            xmlReader.ReadToFollowing("Vehicle");

            do
            {
                xmlReader.MoveToFirstAttribute();
                int id = int.Parse(xmlReader.Value);

                xmlReader.ReadToFollowing("Make");
                string make = xmlReader.ReadElementContentAsString();

                xmlReader.ReadToFollowing("Model");
                string model = xmlReader.ReadElementContentAsString();

                xmlReader.ReadToFollowing("YearOfManufacture");
                int yearOfManufacture = xmlReader.ReadElementContentAsInt();

                xmlReader.ReadToFollowing("InitialMileage");
                int initialMileage = xmlReader.ReadElementContentAsInt();

                xmlReader.ReadToFollowing("Available");
                bool available = bool.Parse(xmlReader.ReadElementContentAsString());

                Vehicle vehicle = new Vehicle()
                {
                    Id = id,
                    Make = make,
                    Model = model,
                    YearOfManufacture = yearOfManufacture,
                    InitialMileage = initialMileage,
                    Available = available
                };

                vehiclesSqlRepository.Restore(vehicle);

            } while (xmlReader.ReadToFollowing("Vehicle"));

            xmlReader.Close();
        }

        private void ReadTravelRoutes(string filePath)
        {
            XmlReader xmlReader = XmlReader.Create(filePath);

            xmlReader.ReadToFollowing("TravelRoute");

            do
            {
                xmlReader.MoveToFirstAttribute();
                int id = int.Parse(xmlReader.Value);

                xmlReader.ReadToFollowing("DateIssued");
                DateTime dateIssued = DateTime.Parse(xmlReader.ReadElementContentAsString());

                xmlReader.ReadToFollowing("TimeIssued");
                TimeSpan timeIssued = TimeSpan.Parse(xmlReader.ReadElementContentAsString());

                xmlReader.ReadToFollowing("Origin");
                string origin = xmlReader.ReadElementContentAsString();

                xmlReader.ReadToFollowing("Destination");
                string destination = xmlReader.ReadElementContentAsString();

                xmlReader.ReadToFollowing("KilometersTraveled");
                float kilometersTraveled = xmlReader.ReadElementContentAsFloat();

                xmlReader.ReadToFollowing("AverageSpeed");
                float averageSpeed = xmlReader.ReadElementContentAsFloat();

                xmlReader.ReadToFollowing("SpentFuel");
                float spentFuel = xmlReader.ReadElementContentAsFloat();

                TravelRoute travelRoute = new TravelRoute()
                {
                    Id = id,
                    DateIssued = dateIssued,
                    TimeIssued = timeIssued,
                    Origin = origin,
                    Destination = destination,
                    KilometersTraveled = kilometersTraveled,
                    AverageSpeed = averageSpeed,
                    SpentFuel = spentFuel
                };

                travelRoutesSqlRepository.Restore(travelRoute);

            } while (xmlReader.ReadToFollowing("TravelRoute"));

            xmlReader.Close();
        }

        private void ReadFuelCosts(string filePath)
        {
            XmlReader xmlReader = XmlReader.Create(filePath);

            xmlReader.ReadToFollowing("FuelCost");

            do
            {
                xmlReader.MoveToFirstAttribute();
                int id = int.Parse(xmlReader.Value);

                xmlReader.ReadToFollowing("DateIssued");
                DateTime dateIssued = DateTime.Parse(xmlReader.ReadElementContentAsString());

                xmlReader.ReadToFollowing("TimeIssued");
                TimeSpan timeIssued = TimeSpan.Parse(xmlReader.ReadElementContentAsString());

                xmlReader.ReadToFollowing("Position");
                string position = xmlReader.ReadElementContentAsString();

                xmlReader.ReadToFollowing("Amount");
                float amount = xmlReader.ReadElementContentAsFloat();

                xmlReader.ReadToFollowing("Price");
                decimal price = xmlReader.ReadElementContentAsDecimal();

                FuelCost fuelCost = new FuelCost()
                {
                    Id = id,
                    DateIssued = dateIssued,
                    TimeIssued = timeIssued,
                    Position = position,
                    Amount = amount,
                    Price = price
                };

                fuelCostsSqlRepository.Restore(fuelCost);

            } while (xmlReader.ReadToFollowing("FuelCost"));

            xmlReader.Close();
        }

        private void ReadTravelWarrants(string filePath)
        {
            XmlReader xmlReader = XmlReader.Create(filePath);

            xmlReader.ReadToFollowing("TravelWarrant");

            do
            {
                xmlReader.MoveToFirstAttribute();
                int id = int.Parse(xmlReader.Value);

                xmlReader.ReadToFollowing("WarrantStatus");
                string warrantStatus = xmlReader.ReadElementContentAsString();

                xmlReader.ReadToFollowing("DateIssued");
                DateTime dateIssued = DateTime.Parse(xmlReader.ReadElementContentAsString());

                xmlReader.ReadToFollowing("TimeIssued");
                TimeSpan timeIssued = TimeSpan.Parse(xmlReader.ReadElementContentAsString());

                xmlReader.ReadToFollowing("DriverId");
                int driverId = xmlReader.ReadElementContentAsInt();

                xmlReader.ReadToFollowing("VehicleId");
                int vehicleId = xmlReader.ReadElementContentAsInt();
                
                xmlReader.ReadToFollowing("TravelRouteId");
                int travelRouteId = xmlReader.ReadElementContentAsInt();
                
                xmlReader.ReadToFollowing("FuelCostId");
                int fuelCostId = xmlReader.ReadElementContentAsInt();

                TravelWarrant travelWarrant = new TravelWarrant()
                {
                    Id = id,
                    WarrantStatus = warrantStatus,
                    DateIssued = dateIssued,
                    TimeIssued = timeIssued,
                    DriverId = driverId,
                    VehicleId = vehicleId,
                    FuelCostId = fuelCostId,
                    TravelRouteId = travelRouteId
                };

                travelWarrantsSqlRepository.Restore(travelWarrant);

            } while (xmlReader.ReadToFollowing("TravelWarrant"));

            xmlReader.Close();
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to clear database?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                ClearDatabase();

                MessageBox.Show("Success");

                Close();
            }
        }

        private void ClearDatabase()
        {
            travelWarrantsSqlRepository.DeleteAll();
            travelRoutesSqlRepository.DeleteAll();
            fuelCostsSqlRepository.DeleteAll();
            driversSqlRepository.DeleteAll();
            vehiclesSqlRepository.DeleteAll();
        }
    }
}