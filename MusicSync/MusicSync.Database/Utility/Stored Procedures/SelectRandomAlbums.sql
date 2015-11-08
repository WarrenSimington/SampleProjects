CREATE PROCEDURE [Utility].[SelectRandomAlbums]
	@NoOfAlbumsToPick INT
AS
BEGIN
	SELECT TOP (@NoOfAlbumsToPick) 
		AR.Name AS 'Artist'
		, AL.Title AS 'Album'
	FROM [Library].[Albums] AL
		JOIN [Library].[Artists] AR on AL.ArtistId = AR.Id
	ORDER BY NEWID();
END