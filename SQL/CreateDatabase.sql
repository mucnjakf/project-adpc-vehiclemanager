DROP DATABASE VehicleManagerDB

CREATE DATABASE VehicleManagerDB

USE VehicleManagerDB

CREATE TABLE Drivers
(
	Id INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	FirstName NVARCHAR(50),
	LastName NVARCHAR(50),
	PhoneNumber NVARCHAR(50),
	DriversLicenceNumber NVARCHAR(50)
);

CREATE TABLE Vehicles
(
	Id INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Make NVARCHAR(50),
	Model NVARCHAR(50),
	YearOfManufacture INT,
	InitialMileage INT,
	Available BIT
);

CREATE TABLE FuelCosts
(
	Id INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	DateIssued DATE,
	TimeIssued TIME,
	Position NVARCHAR(50),
	Amount FLOAT(24),
	Price MONEY
);

CREATE TABLE TravelRoutes
(
	Id INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	DateIssued DATE,
	TimeIssued TIME,
	Origin NVARCHAR(50),
	Destination NVARCHAR(50),
	KilometersTraveled FLOAT(24),
	AverageSpeed FLOAT(24),
	SpentFuel FLOAT(24)
);

CREATE TABLE TravelWarrants
(
	Id INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	WarrantStatus NVARCHAR(50),
	DateIssued DATE,
	TimeIssued TIME,
	DriverId INT FOREIGN KEY REFERENCES Drivers(Id),
	VehicleId INT FOREIGN KEY REFERENCES Vehicles(Id),
	FuelCostId INT FOREIGN KEY REFERENCES FuelCosts(Id),
	TravelRouteId INT FOREIGN KEY REFERENCES TravelRoutes(Id)
);

