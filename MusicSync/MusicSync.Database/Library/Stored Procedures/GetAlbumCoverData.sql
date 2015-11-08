CREATE PROCEDURE [Library].[GetAlbumCoverData]
	@SqlError int output
AS
BEGIN
	begin try
		set @SqlError = 0;

		select 
			Id
			,Directory
			,WmCollectionId
			,Title
		from
			Library.Albums;
	end try

	begin catch
		set @SqlError = @@ERROR;
	end catch
END