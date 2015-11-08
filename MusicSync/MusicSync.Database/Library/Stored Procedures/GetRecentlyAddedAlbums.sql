CREATE PROCEDURE [Library].[GetRecentlyAddedAlbums]
	@ReturnWithinLastXDays int,
	@SqlError int output
AS
BEGIN
	set @SqlError = 0;

	begin try
		declare @RecentlyAddedCutoffDate datetime2 = DATEADD(DAY, -@ReturnWithinLastXDays, GETDATE());

		select S.AlbumId, AL.Title, AR.Name, MAX(S.DateAdded) as 'Date Added'
		from 
			Library.Songs S
				join Library.Albums AL on S.AlbumId = AL.Id
				join Library.Artists AR on AL.ArtistId = AR.Id
		group by S.AlbumId, AL.Title, AR.Name
		having MAX(S.DateAdded) > @RecentlyAddedCutoffDate
		order by MAX(S.DateAdded) desc;
	end try

	begin catch
		set @SqlError = @@ERROR;
	end catch
END