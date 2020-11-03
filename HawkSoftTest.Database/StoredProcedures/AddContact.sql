CREATE PROCEDURE [dbo].[AddContact]
	@userId int,
	@firstName varchar(100),
	@lastName varchar(100),
	@email varchar(320)
AS
	INSERT INTO Contact (UserId, FirstName, LastName, Email)
	VALUES (@userId, @firstName, @lastName, @email);
RETURN 0
