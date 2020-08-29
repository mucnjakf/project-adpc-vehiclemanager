USE VehicleManagerDB

CREATE PROC InsertVehicle 
    @Make NVARCHAR(50),
    @Model NVARCHAR(50),
	@YearOfManufacture INT,
	@InitialMileage INT,
	@Available BIT  
AS
	INSERT INTO Vehicles
	VALUES(@Make, @Model, @YearOfManufacture, @InitialMileage, @Available)

CREATE PROC GetVehicles 
AS
	SELECT * FROM Vehicles

CREATE PROC GetVehicle
	@Id INT
AS
	SELECT * FROM Vehicles
	WHERE Id = @Id

CREATE PROC UpdateVehicle
	@Make NVARCHAR(50),
    @Model NVARCHAR(50),
	@YearOfManufacture INT,
	@InitialMileage INT,
	@Available BIT,
	@Id INT
AS
	UPDATE Vehicles	
	SET Make = @Make, Model = @Model, YearOfManufacture = @YearOfManufacture, InitialMileage = @InitialMileage, Available = @Available
	WHERE Id = @Id

CREATE PROC DeleteVehicle
	@Id INT
AS
	DELETE FROM TravelWarrants WHERE VehicleId = @Id
	DELETE FROM Services WHERE Vehicle_Id = @Id
	DELETE FROM Vehicles WHERE Id = @Id
	
CREATE PROC RestoreVehicle
	@Id INT,
	@Make NVARCHAR(50),
    @Model NVARCHAR(50),
	@YearOfManufacture INT,
	@InitialMileage INT,
	@Available BIT
AS
	IF NOT EXISTS (SELECT * FROM Vehicles WHERE Id = @Id)
		BEGIN
			SET IDENTITY_INSERT Vehicles ON
			INSERT INTO Vehicles(Id, Make, Model, YearOfManufacture, InitialMileage, Available)
			VALUES(@Id, @Make, @Model, @YearOfManufacture, @InitialMileage, @Available)
			SET IDENTITY_INSERT Vehicles OFF
		END

CREATE PROC DeleteAllVehicles
AS
	DELETE FROM ServiceItems
	DELETE FROM Services
	DELETE FROM Vehicles

CREATE PROC UpdateVehicleAvailability
	@IdVehicle INT,
	@Available BIT
AS
	UPDATE Vehicles
	SET Available = @Available
	WHERE IdVehicle = @IdVehicle