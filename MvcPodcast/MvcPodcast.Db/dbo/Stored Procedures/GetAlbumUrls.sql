CREATE PROCEDURE [dbo].[GetAlbumUrls]
	@AlbumId bigint,
	@SqlError int output
AS
BEGIN
	set @SqlError = 0;

	begin try
		select
			Id
			,DisplayText
			,Url
		from
			AlbumUrls
		where
			AlbumId = @AlbumId;
	end try

	begin catch
		set @SqlError = @@ERROR;
	end catch
END