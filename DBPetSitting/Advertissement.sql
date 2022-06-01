CREATE TABLE [dbo].[Advertisement]
(
	[ID] INT IDENTITY NOT NULL,
	[ID_Owner] INT NOT NULL,
	[ID_Prestation] INT NOT NULL,
	[Title] NVARCHAR (60) NOT NULL,
	[Description] NVARCHAR (60) NOT NULL,
	[CreatedAt] DATETIME2 DEFAULT GETDATE(), 
	[Region] NVARCHAR(60) NOT NULL,
	[City] NVARCHAR(60),
	[DateStart] DATETIME2 NOT NULL,
	[DateEnd] DATETIME2 NOT NULL,
	CHECK (DAY([DateStart])+2>DAY([DateEnd])),
	CHECK (DAY([DateStart])>=Day([CreatedAt])),
	CONSTRAINT [PK_Advertissement] PRIMARY KEY([ID]),
	CONSTRAINT [FK_ID_OwnerAdvertissement] FOREIGN KEY ([ID_Owner]) REFERENCES Owner([ID]),
	CONSTRAINT [FK_ID_PrestationAdvertissement] FOREIGN KEY ([ID_Prestation]) REFERENCES Prestation([ID]),
)
