USE VehicleManagerDB

CREATE PROC InsertDriversDummyData AS
	SET IDENTITY_INSERT Drivers ON
	INSERT INTO Drivers(Id, FirstName, LastName, PhoneNumber, DriversLicenceNumber) VALUES (1, 'Neo', 'Collier', '202-555-0117', '505783263')
	INSERT INTO Drivers(Id, FirstName, LastName, PhoneNumber, DriversLicenceNumber) VALUES (2, 'Elisha', 'Amos', '202-555-0157', '466871999')
	INSERT INTO Drivers(Id, FirstName, LastName, PhoneNumber, DriversLicenceNumber) VALUES (3, 'Edison', 'Jacobson', '202-555-0135', '275203015')
	INSERT INTO Drivers(Id, FirstName, LastName, PhoneNumber, DriversLicenceNumber) VALUES (4, 'Derrick', 'Mcknight', '202-555-0132', '280990958')
	INSERT INTO Drivers(Id, FirstName, LastName, PhoneNumber, DriversLicenceNumber) VALUES (5, 'Safiyyah', 'Villarreal', '202-555-0192', '230630155')
	SET IDENTITY_INSERT Drivers OFF
	
CREATE PROC InsertVehiclesDummyData AS
	SET IDENTITY_INSERT Vehicles ON
	INSERT INTO Vehicles(Id, Make, Model, YearOfManufacture, InitialMileage, Available) VALUES (1, 'Audi', 'A3', 2004, 200000, 0)
	INSERT INTO Vehicles(Id, Make, Model, YearOfManufacture, InitialMileage, Available) VALUES (2, 'BMW', 'M4', 2010, 150000, 0)
	INSERT INTO Vehicles(Id, Make, Model, YearOfManufacture, InitialMileage, Available) VALUES (3, 'VolksWagen', 'Golf 7', 2017, 100000, 0)
	INSERT INTO Vehicles(Id, Make, Model, YearOfManufacture, InitialMileage, Available) VALUES (4, 'Renault', 'Megane', 2002, 350000, 0)
	INSERT INTO Vehicles(Id, Make, Model, YearOfManufacture, InitialMileage, Available) VALUES (5, 'Mercedes-Benz', 'CLS', 2020, 50000, 0)
	SET IDENTITY_INSERT Vehicles OFF

CREATE PROC InsertFuelCostsDummyData AS	
	SET IDENTITY_INSERT FuelCosts ON
	INSERT INTO FuelCosts(Id, DateIssued, TimeIssued, Position, Amount, Price) VALUES (1, '2001-01-01', '11:00:00', '5059 Cedar Lane', 100.12, 25.30)
	INSERT INTO FuelCosts(Id, DateIssued, TimeIssued, Position, Amount, Price) VALUES (2, '2002-02-02', '10:00:00', '3957 Atlantic Avenue', 200.123, 15.50)
	INSERT INTO FuelCosts(Id, DateIssued, TimeIssued, Position, Amount, Price) VALUES (3, '2003-03-03', '09:00:00', '2636 Laurel Lane', 300, 23.00)
	INSERT INTO FuelCosts(Id, DateIssued, TimeIssued, Position, Amount, Price) VALUES (4, '2004-04-04', '08:00:00', '3156 Front Street North', 400, 400.00)
	INSERT INTO FuelCosts(Id, DateIssued, TimeIssued, Position, Amount, Price) VALUES (5, '2005-05-05', '07:00:00', '2907 Grand Avenue', 90.212, 2.30)
	SET IDENTITY_INSERT FuelCosts OFF

CREATE PROC InsertTravelRoutesDummyData AS	
	SET IDENTITY_INSERT TravelRoutes ON
	INSERT INTO TravelRoutes(Id, DateIssued, TimeIssued, Origin, Destination, KilometersTraveled, AverageSpeed, SpentFuel) VALUES (1, '2023-01-01', '11:00:00', '5059 Cedar Lane', '5921 Essex Court', 120.32, 50.32, 123.23)
	INSERT INTO TravelRoutes(Id, DateIssued, TimeIssued, Origin, Destination, KilometersTraveled, AverageSpeed, SpentFuel) VALUES (2, '2032-02-02', '10:00:00', '3957 Atlantic Avenue', '3403 Orchard Avenue', 1100.32, 110.12, 342.43)
	INSERT INTO TravelRoutes(Id, DateIssued, TimeIssued, Origin, Destination, KilometersTraveled, AverageSpeed, SpentFuel) VALUES (3, '2043-03-03', '09:00:00', '2636 Laurel Lane', '2096 Route 30', 12.23, 1233.32, 543.54)
	INSERT INTO TravelRoutes(Id, DateIssued, TimeIssued, Origin, Destination, KilometersTraveled, AverageSpeed, SpentFuel) VALUES (4, '2045-04-04', '08:00:00', '3156 Front Street North', '2903 Woodland Drive', 2.12, 321.32, 23.31)
	INSERT INTO TravelRoutes(Id, DateIssued, TimeIssued, Origin, Destination, KilometersTraveled, AverageSpeed, SpentFuel) VALUES (5, '2054-05-05', '07:00:00', '2907 Grand Avenue', '3852 Arlington Avenue', 10000.12, 642.32, 11.23)
	SET IDENTITY_INSERT TravelRoutes OFF

CREATE PROC InsertTravelWarrantsDummyData AS	
	SET IDENTITY_INSERT TravelWarrants ON
	INSERT INTO TravelWarrants(Id, WarrantStatus, DateIssued, TimeIssued, DriverId, VehicleId, FuelCostId, TravelRouteId) VALUES (1, 'Open', '2053-01-01', ' 12:00:00', 1, 1, 1, 1)
	INSERT INTO TravelWarrants(Id, WarrantStatus, DateIssued, TimeIssued, DriverId, VehicleId, FuelCostId, TravelRouteId) VALUES (2, 'Closed', '2063-01-01', ' 12:00:00', 2, 2, 2, 2)
	INSERT INTO TravelWarrants(Id, WarrantStatus, DateIssued, TimeIssued, DriverId, VehicleId, FuelCostId, TravelRouteId) VALUES (3, 'Open', '2073-01-01', ' 12:00:00', 3, 3, 3, 3)
	INSERT INTO TravelWarrants(Id, WarrantStatus, DateIssued, TimeIssued, DriverId, VehicleId, FuelCostId, TravelRouteId) VALUES (4, 'Closed', '2083-01-01', ' 12:00:00', 4, 4, 4, 4)
	INSERT INTO TravelWarrants(Id, WarrantStatus, DateIssued, TimeIssued, DriverId, VehicleId, FuelCostId, TravelRouteId) VALUES (5, 'Open', '2093-01-01', ' 12:00:00', 5, 5, 5, 5)
	SET IDENTITY_INSERT TravelWarrants OFF

EXEC InsertDriversDummyData
EXEC InsertVehiclesDummyData
EXEC InsertFuelCostsDummyData
EXEC InsertTravelRoutesDummyData
EXEC InsertTravelWarrantsDummyData

SELECT * FROM Drivers
SELECT * FROM Vehicles
SELECT * FROM FuelCosts
SELECT * FROM TravelRoutes
SELECT * FROM TravelWarrants
