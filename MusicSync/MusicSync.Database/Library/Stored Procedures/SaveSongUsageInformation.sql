CREATE PROCEDURE [Library].[SaveSongUsageInformation]
	@MachineId BIGINT,
	@SongTrackingId UNIQUEIDENTIFIER,
	@ArtistName VARCHAR(MAX),
	@AlbumTitle VARCHAR(MAX),
	@SongTitle VARCHAR(MAX),
	@LastPlayed DATETIME = NULL,
	@SqlError INT OUTPUT
AS
BEGIN
	SET @SqlError = 0;

	BEGIN TRY
		-- Check to see if we already have a usage record that matches the
		-- song tracking ID to machine ID
		DECLARE @SongUsageId BIGINT;

		SELECT TOP 1 @SongUsageId = U.Id
		FROM [Library].[Usage] U
		WHERE
			MachineId = @MachineId AND
			SongTrackingId = @SongTrackingId;

		print 'Song usage ID = ' + cast(@SongUsageId as VARCHAR(MAX));

		IF (@SongUsageId IS NULL)
		BEGIN
			-- We don't have a matching usage record, so we need to insert a
			-- new one.

			-- Pull the song ID we're looking for from the Songs table
			DECLARE @SongId BIGINT;

			SELECT TOP 1 @SongId = S.Id
			FROM [Library].[Songs] S
				JOIN [Library].[Albums] AL ON S.AlbumId = AL.Id
				JOIN [Library].[Artists] AR ON AL.ArtistId = AR.Id
			WHERE
				S.Title = @SongTitle AND
				AL.Title = @AlbumTitle AND
				AR.Name = @ArtistName;

			-- If we didn't find the song in the Songs table, set an error
			-- code and bail.
			IF (@SongId IS NULL)
			BEGIN
				SET @SqlError = 1;
				RETURN;
			END;

			-- Insert the usage record
			INSERT INTO [Library].[Usage]
			(
				MachineId,
				SongTrackingId,
				LastPlayed,
				SongId
			)
			VALUES
			(
				@MachineId,
				@SongTrackingId,
				@LastPlayed,
				@SongId
			);
		END
		ELSE
		BEGIN
			-- We found a matching usage record. Update the existing record.
			-- Update the existing record.
			UPDATE [Library].[Usage]
			SET
				LastPlayed = @LastPlayed
			FROM [Library].[Usage] U
				JOIN [Library].[Songs] S on U.SongId = S.Id
			WHERE
				U.Id = @SongUsageId;
		END;
	END TRY

	BEGIN CATCH
		SET @SqlError = @@ERROR;
	END CATCH
END