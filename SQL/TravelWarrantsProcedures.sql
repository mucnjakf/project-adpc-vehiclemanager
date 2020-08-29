USE VehicleManagerDB

CREATE PROC InsertTravelWarrant
	@WarrantStatus NVARCHAR(50),
	@DateIssued DATE,
	@TimeIssued TIME,
	@DriverId INT,
	@VehicleId INT,
	@FuelCostId INT,
	@TravelRouteId INT
AS
	INSERT INTO TravelWarrants
	VALUES(@WarrantStatus, @DateIssued, @TimeIssued, @DriverId, @VehicleId, @FuelCostId, @TravelRouteId)

CREATE PROC GetTravelWarrants
AS
	SELECT * FROM TravelWarrants

CREATE PROC UpdateTravelWarrant
	@WarrantStatus NVARCHAR(50),
	@DateIssued DATE,
	@TimeIssued TIME,
	@DriverId INT,
	@VehicleId INT,
	@FuelCostId INT,
	@TravelRouteId INT,
	@Id INT
AS
	UPDATE TravelWarrants
	SET WarrantStatus = @WarrantStatus, DateIssued = @DateIssued, TimeIssued = @TimeIssued, DriverId = @DriverId, VehicleId = @VehicleId, FuelCostId = @FuelCostId, TravelRouteId = @TravelRouteId
	WHERE Id = @Id
	
CREATE PROC DeleteTravelWarrant
	@Id INT
AS
	DELETE FROM TravelWarrants
	WHERE Id = @Id
	
CREATE PROC RestoreTravelWarrant
	@Id INT,
	@WarrantStatus NVARCHAR(50),
	@DateIssued DATE,
	@TimeIssued TIME,
	@DriverId INT,
	@VehicleId INT,
	@FuelCostId INT,
	@TravelRouteId INT
AS
	IF NOT EXISTS (SELECT * FROM TravelWarrants WHERE Id = @Id)
	BEGIN
		SET IDENTITY_INSERT TravelWarrants ON
		INSERT INTO TravelWarrants(Id, WarrantStatus, DateIssued, TimeIssued, DriverId, VehicleId, FuelCostId, TravelRouteId)
		VALUES(@Id, @WarrantStatus, @DateIssued, @TimeIssued, @DriverId, @VehicleId, @FuelCostId, @TravelRouteId)
		SET IDENTITY_INSERT TravelWarrants OFF
	END
	
CREATE PROC DeleteAllTravelWarrants
AS
	DELETE FROM TravelWarrants

--CREATE PROC GetTravelWarrants
--AS
--	SELECT Tw.IdTravelWarrant, Tw.WarrantStatus, Tw.DateIssued, Tw.TimeIssued, D.FirstName, D.LastName, V.Make, V.Model, Fc.Price, Tr.Destination
--	FROM TravelWarrants AS Tw
	
--	INNER JOIN Drivers AS D
--	ON D.IdDriver = Tw.DriverId

--	INNER JOIN Vehicles AS V
--	ON V.IdVehicle = Tw.VehicleId

--	INNER JOIN FuelCosts AS Fc
--	ON Fc.IdFuelCost = Tw.FuelCostId

--	INNER JOIN TravelRoutes AS Tr
--	ON Tr.IdTravelRoute = Tw.TravelRouteId
