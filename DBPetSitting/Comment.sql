CREATE TABLE [dbo].[Comment]
(
	[ID] INT IDENTITY NOT NULL,
	[ID_Prestation] INT NOT NULL,
	[ID_Owner] INT NOT NULL,
	[ID_PetSitter] INT NOT NULL,
	[Title] NVARCHAR(60) NOT NULL,
	[Description] NVARCHAR(2000) NOT NULL,
	[CreatedAt] DATETIME2 DEFAULT GETDATE(),
	[Score] INT NOT NULL,
	[IsOwner] BIT NULL, 
    CHECK ([Score] BETWEEN 0 AND 5),
	CHECK(LEN([Title])>=3),
	CHECK(LEN([Description])>100),
	CONSTRAINT [PF_Comment] PRIMARY KEY ([ID]),
	CONSTRAINT [FK_ID_PrestationComment] FOREIGN KEY ([ID_Prestation]) REFERENCES Prestation([ID]),
	CONSTRAINT [FK_ID_OwnerComment] FOREIGN KEY ([ID_Owner]) REFERENCES Owner([ID]),
	CONSTRAINT [FK_ID_PetSitterComment] FOREIGN KEY ([ID_PetSitter]) REFERENCES PetSitter([ID]),
)
