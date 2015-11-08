CREATE PROCEDURE [Library].[SaveSongLibraryInformation]
	@ArtistName VARCHAR(100),
	@AlbumTitle VARCHAR(100),
	@SongTrackingId UNIQUEIDENTIFIER = NULL,
	@SongTitle VARCHAR(100),
	@Duration FLOAT,
	@DateAdded DATETIME2,
	@ReleaseDate DATETIME2 = NULL,
	@TrackNumber INT,
	@SourceURL VARCHAR(MAX),
	@WmCollectionId varchar(MAX),
	@SqlError INT OUTPUT
AS
BEGIN
	SET @SqlError = 0;
	
	 BEGIN TRY
		-- Retrieve Artist ID
		DECLARE @ArtistId BIGINT;
		
		SELECT TOP 1 @ArtistId = Id
		FROM [Library].[Artists]
		WHERE Name = @ArtistName;

		IF (@ArtistId IS NULL)
		BEGIN
			-- The artist doesn't exist, so insert it
			INSERT INTO [Library].[Artists]
			(Name)
			VALUES
			(@ArtistName);

			SET @ArtistId = SCOPE_IDENTITY();
		END;

		-- Retrieve Album ID, and update album source directory as well
		DECLARE @AlbumId uniqueidentifier;

		-- Retrieve the directory path from the source URL
		declare @SourceDirectory varchar(max);
		SELECT @SourceDirectory = LEFT(@SourceURL,LEN(@SourceURL) - charindex('\',reverse(@SourceURL),1))

		SELECT TOP 1 @AlbumId = Id
		FROM [Library].[Albums]
		WHERE 
			Title = @AlbumTitle AND
			ArtistId = @ArtistId;

		if (@AlbumId IS NULL)
		BEGIN
			declare @AlbumInsertTable table (NewAlbumId uniqueidentifier);

			-- The album doesn't exist, so insert it
			INSERT INTO [Library].[Albums]
			(ArtistId, Title, Directory, WmCollectionId)
			output inserted.Id into @AlbumInsertTable
			VALUES
			(@ArtistId, @AlbumTitle, @SourceDirectory, @WMCollectionID);

			select top 1 @AlbumId = NewAlbumId from @AlbumInsertTable;
		END
		else
		begin
			update Library.Albums
			set [Directory] = @SourceDirectory
			where (Id = @AlbumId) and ((Directory != @SourceDirectory) or (WmCollectionId != @WMCollectionId));
		end;

		IF EXISTS (SELECT * FROM [Library].[Songs] WHERE TrackingId = @SongTrackingId)
		BEGIN
			-- Update the song
			UPDATE [Library].[Songs]
			SET
				Title = @SongTitle,
				AlbumId = @AlbumId,
				Duration = @Duration,
				DateAdded = @DateAdded,
				ReleaseDate = @ReleaseDate,
				TrackNumber = @TrackNumber,
				SourceURL = @SourceURL
			WHERE
				TrackingId = @SongTrackingId;
		END
		ELSE
		BEGIN
			-- Insert the song
			INSERT INTO [Library].[Songs]
			(
				Title, 
				TrackingId, 
				AlbumId, 
				Duration,
				DateAdded,
				ReleaseDate,
				TrackNumber,
				SourceURL
			)
			VALUES
			(
				@SongTitle, 
				@SongTrackingId, 
				@AlbumId, 
				@Duration,
				@DateAdded,
				@ReleaseDate,
				@TrackNumber,
				@SourceURL
			);
		END;

		-- Cleanup/remove any albums that don't have any songs associated to them
		DELETE FROM [Library].[Albums]
		FROM [Library].[Albums] AL
		WHERE AL.Id NOT IN (SELECT AlbumId FROM [Library].[Songs]);

		-- Cleanup/remove any artists that don't have any albums associated to them
		DELETE FROM [Library].[Artists]
		FROM [Library].[Artists] AR
		WHERE AR.Id NOT IN (SELECT ArtistId FROM [Library].[Albums]);
	END TRY

	BEGIN CATCH
		SET @SqlError = @@ERROR;
	END CATCH
END