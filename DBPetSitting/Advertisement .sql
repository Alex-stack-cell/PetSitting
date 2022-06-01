CREATE TABLE [dbo].[Advertissement]
(
	[Id] INT IDENTITY NOT NULL,
	[Title] NVARCHAR (60) NOT NULL,
	[Description] NVARCHAR (60) NOT NULL,
	CreatedAt DATETIME2 DEFAULT GETDATE(), 
	[Region] NVARCHAR(60) NOT NULL,
	[City] NVARCHAR(60),
	[DateStart] DATETIME2 NOT NULL,
	[DateEnd] DATETIME2 NOT NULL,
	CHECK (DAY([DateStart])+2>DAY([DateEnd])),
	CONSTRAINT [PK_Advertissement] PRIMARY KEY([ID]),
)
