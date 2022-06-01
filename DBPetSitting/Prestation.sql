CREATE TABLE [dbo].[Prestation]
(
	[ID] INT IDENTITY NOT NULL,
	[ID_PetSitter] INT NOT NULL,
	[DateStart] DATETIME2 NOT NULL,
	[DateEnd] DATETIME2 NOT NULL
	CHECK(DAY([DateEnd])+2>DAY([DateStart])),
	CONSTRAINT [PK_Prestation] PRIMARY KEY ([ID]),
	CONSTRAINT [FK_ID_PetSitterPrestation] FOREIGN KEY ([ID_PetSitter]) REFERENCES PetSitter([ID]) 
)
