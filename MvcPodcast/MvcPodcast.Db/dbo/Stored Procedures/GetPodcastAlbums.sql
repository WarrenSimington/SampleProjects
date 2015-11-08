CREATE PROCEDURE [dbo].[GetPodcastAlbums]
	@ArticleId bigint,
	@SqlError int output
AS
BEGIN
	set @SqlError = 0;

	begin try
		select
			AL.Id
			,AL.Artist
			,AL.Caption
			,AL.CoverImageFileName
			,isnull(AL.Label, '') as 'Label'
			,AL.Title
			,AL.[Year]
		from 
			Albums AL
			join Podcasts P on AL.Id = P.Album1Id or AL.Id = P.Album2Id
		where
			P.ArticleId = @ArticleId;
	end try

	begin catch
		set @SqlError = @@ERROR;
	end catch
END