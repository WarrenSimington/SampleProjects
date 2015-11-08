CREATE PROCEDURE [Library].[GetCurrentlyListeningTo]
	@MinSongsListenedTo int,
	@WithinLastXDays int,
	@SqlError int output
AS
BEGIN
	set @SqlError = 0;

	begin try
		set @SqlError = 0;

		if ((select count(*) from Library.Usage) = 0)
		begin
		  goto no_data;
		end;

		declare @CurrentlyListeningToCutoff datetime2 = DATEADD(DAY, -@WithinLastXDays, GETDATE());
		
		create table #CurrentlyListeningToResults
		(
			AlbumId uniqueidentifier,
			ArtistName varchar(max),
			AlbumTitle varchar(max),
			LastPlayed datetime,
			SongCount int
		);

		while ((select count(*) from #CurrentlyListeningToResults) = 0)
		begin
			insert into #CurrentlyListeningToResults
			select S.AlbumId, AR.Name, AL.Title, MAX(U.LastPlayed) as 'Last Play Time', COUNT(*) as 'Song Count'
			from Library.Songs S
				join Library.Usage U on S.Id = U.SongId
				join Library.Albums AL on S.AlbumId = AL.Id
				join Library.Artists AR on AL.ArtistId = AR.Id
			where
				U.LastPlayed > @CurrentlyListeningToCutoff 
			group by S.AlbumId, AR.Name, AL.Title
			having COUNT(*) >= @MinSongsListenedTo
			order by MAX(U.LastPlayed) desc;

			-- Make sure that the minimum of songs listened to is 1
			if (@MinSongsListenedTo > 1)
			begin
				set @MinSongsListenedTo = @MinSongsListenedTo - 1;
			end
			else
				set @MinSongsListenedTo = 1;

			-- If we haven't found any songs listened to, and the minimum song count is 1,
			-- start extending the days until we find something
			if (@MinSongsListenedTo = 1)
				set @CurrentlyListeningToCutoff = DATEADD(day, -1, @CurrentlyListeningToCutoff);
		end;

		select * from #CurrentlyListeningToResults
		order by LastPlayed desc;

		drop table #CurrentlyListeningToResults

		no_data:
			print('No data in library usage table.');
	end try

	begin catch
		set @SqlError = @@ERROR;
	end catch
END