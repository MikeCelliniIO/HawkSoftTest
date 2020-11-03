CREATE PROCEDURE [dbo].[EditContact]
	@contactId int,
	@firstName varchar(100),
	@lastName varchar(100),
	@email varchar(320),
	@updateKey UNIQUEIDENTIFIER
AS
	/*We may not want to set every field on each update to avoid unnecessary writes, 
	could use dynamic SQL if that's the case, for now we'll settle with making sure
	at least one field has changed*/
	UPDATE Contact
	SET FirstName = @firstName,
		LastName = @lastName,
		Email = @email,
		UpdateKey = NEWID()
	WHERE Id = @contactId
	  AND UpdateKey = @updateKey
	  AND (FirstName <> @firstName OR LastName <> @lastName OR Email <> @email)
RETURN 0
