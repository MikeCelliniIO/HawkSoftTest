CREATE PROCEDURE [dbo].[GetContactsForUser]
	@filter AS VARCHAR(max) = NULL
	,@userId AS INT
AS
BEGIN
	SELECT 
		FirstName, 
		LastName, 
		Email 
	FROM Contact 
	WHERE 
		(
			@filter IS NULL OR 
			FirstName LIKE '%' + @filter + '%' OR
			LastName LIKE '%' + @filter + '%' OR
			Email LIKE '%' + @filter + '%'
		) AND
		UserId = @userId 
	ORDER BY 
		LastName, 
		FirstName
END
