CREATE PROCEDURE [dbo].[GetArticles]
	@SqlError int output
AS
BEGIN
	set @SqlError = 0;

	begin try
		select
			AR.Id
			,AR.PostDateTime
			,AR.BodyText
			,P.DownloadDisplayText
			,P.DownloadUrl
		from 
			Articles AR
			left join Podcasts P on AR.Id = P.ArticleId
		order by AR.PostDateTime desc
	end try

	begin catch
		set @SqlError = @@ERROR;	
	end catch
END
