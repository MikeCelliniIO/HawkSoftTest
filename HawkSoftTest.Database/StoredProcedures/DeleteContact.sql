CREATE PROCEDURE [dbo].[DeleteContact]
	@contactId int
AS
	DELETE FROM Contact WHERE Id = @contactId;
RETURN 0
