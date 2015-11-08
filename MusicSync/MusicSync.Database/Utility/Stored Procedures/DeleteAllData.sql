CREATE PROCEDURE [Utility].[DeleteAllData]
	@Confirm bit
AS
BEGIN
	if @Confirm = 1
	begin
		begin transaction TransDeleteAll
		
		begin try
		
			delete from Library.Usage;
			delete from Library.Workstations;
			delete from Library.Songs;
			delete from Library.Albums;
			delete from Library.Artists;

			commit transaction TransDeleteAll
		end try

		begin catch
			rollback transaction TransDeleteAll
		end catch
	end;
END