CREATE TABLE [dbo].[PetSitter]
(
	[ID] INT IDENTITY NOT NULL,
	[LastName] NVARCHAR (60) NOT NULL,
	[FirstName] NVARCHAR (60) NOT NULL,
	[BirthDate] datetime2 NOT NULL,
	[Email] NVARCHAR (60) NOT NULL,
	[HashPasswd] NVARCHAR(MAX) NOT NULL,
	[Salt] varbinary(16) NOT NULL,
	[PetPreference] NVARCHAR(60),
	CONSTRAINT [PK_PetSitter] PRIMARY KEY ([ID])
)
