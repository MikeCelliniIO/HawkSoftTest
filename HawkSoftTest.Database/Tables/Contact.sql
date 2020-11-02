CREATE TABLE [dbo].[Contact]
(
	Id INT NOT NULL IDENTITY,
	UserId INT NOT NULL,
	FirstName VARCHAR(100) NOT NULL,
	LastName VARCHAR(100) NOT NULL,
	Email VARCHAR(320),
	PrimaryPhone CHAR(10),
	SecondaryPhone CHAR(10),
	AddressLine1 VARCHAR(200),
	AddressLine2 VARCHAR(200),
	AddressCity VARCHAR(100),
	AddressState CHAR(2),
	AddressZip5 SMALLINT,
	AddressZip4 SMALLINT,
	CONSTRAINT PK_Contact PRIMARY KEY (Id),
	CONSTRAINT FK_User FOREIGN KEY (UserId) REFERENCES [User](Id)
)
