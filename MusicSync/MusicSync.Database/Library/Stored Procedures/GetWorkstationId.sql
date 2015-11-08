CREATE PROCEDURE [Library].[GetWorkstationId]
	@WorkstationName VARCHAR(25),
	@Result INT OUTPUT,
	@SqlError INT OUTPUT
AS
BEGIN
	SET @SqlError = 0;
	
	BEGIN TRY
		-- Pull the existing workstation ID from the database (if it exists)
		SELECT TOP 1 @Result = Id
		FROM [Library].[Workstations]
		WHERE Name = @WorkstationName;

		-- If the ID doesn't exist for the workstation in the database, insert
		-- a record for the workstation and retrieve the ID
		IF (@Result IS NULL)
		BEGIN
			INSERT INTO [Library].Workstations
			(Name)
			VALUES
			(@WorkstationName);

			SET @Result = SCOPE_IDENTITY();
		END;
	END TRY

	BEGIN CATCH
		SET @SqlError = @@ERROR;
	END CATCH
END