USE VehicleManagerDB

CREATE PROC InsertFuelCost 
	@Date DATE,
	@Time TIME,
	@Position NVARCHAR(50),
	@Amount REAL,
	@Price MONEY
AS
	INSERT INTO FuelCosts
	VALUES(@Date, @Time, @Position, @Amount, @Price)

CREATE PROC GetFuelCosts
AS
	SELECT * FROM FuelCosts

CREATE PROC GetFuelCost
	@Id INT
AS
	SELECT * FROM FuelCosts
	WHERE Id = @Id
	
CREATE PROC DeleteFuelCost
	@Id INT
AS
	DELETE FROM TravelWarrants
	WHERE FuelCostId = @Id

	DELETE FROM FuelCosts
	WHERE Id = @Id
	
CREATE PROC RestoreFuelCost
	@Id INT,
	@Date DATE,
	@Time TIME,
	@Position NVARCHAR(50),
	@Amount REAL,
	@Price MONEY
AS
	IF NOT EXISTS(SELECT * FROM FuelCosts WHERE Id = @Id)
	BEGIN
		SET IDENTITY_INSERT FuelCosts ON
		INSERT INTO FuelCosts(Id, DateIssued, TimeIssued, Position, Amount, Price)
		VALUES(@Id, @Date, @Time, @Position, @Amount, @Price)
		SET IDENTITY_INSERT FuelCosts OFF
	END
	
CREATE PROC DeleteAllFuelCosts
AS
	DELETE FROM FuelCosts
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	