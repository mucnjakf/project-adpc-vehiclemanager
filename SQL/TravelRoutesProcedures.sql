USE VehicleManagerDB

CREATE PROC InsertTravelRoute
	@DateIssued DATE,
	@TimeIssued TIME,
	@Origin NVARCHAR(50),
	@Destination NVARCHAR(50),
	@KilometersTraveled REAL,
	@AverageSpeed REAL,
	@SpentFuel REAL
AS
	INSERT INTO TravelRoutes
	VALUES(@DateIssued, @TimeIssued, @Origin, @Destination, @KilometersTraveled, @AverageSpeed, @SpentFuel)

CREATE PROC GetTravelRoutes
AS
	SELECT * FROM TravelRoutes

CREATE PROC GetTravelRoute
	@Id INT
AS
	SELECT * FROM TravelRoutes
	WHERE Id = @Id

CREATE PROC DeleteTravelRoute
	@Id INT
AS
	DELETE FROM TravelWarrants
	WHERE TravelRouteId = @Id

	DELETE FROM TravelRoutes
	WHERE Id = @Id

CREATE PROC RestoreTravelRoute
	@Id INT,
	@DateIssued DATE,
	@TimeIssued TIME,
	@Origin NVARCHAR(50),
	@Destination NVARCHAR(50),
	@KilometersTraveled REAL,
	@AverageSpeed REAL,
	@SpentFuel REAL
AS
	IF NOT EXISTS (SELECT * FROM TravelRoutes WHERE Id = @Id)
		BEGIN
			SET IDENTITY_INSERT TravelRoutes ON
			INSERT INTO TravelRoutes(Id, DateIssued, TimeIssued, Origin, Destination, KilometersTraveled, AverageSpeed, SpentFuel)
			VALUES(@Id, @DateIssued, @TimeIssued, @Origin, @Destination, @KilometersTraveled, @AverageSpeed, @SpentFuel)
			SET IDENTITY_INSERT TravelRoutes OFF
		END
		
CREATE PROC DeleteAllTravelRoutes
AS
	DELETE FROM TravelRoutes
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		