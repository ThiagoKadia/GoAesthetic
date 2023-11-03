CREATE TABLE [dbo].[tbAutorizacao]
(
	[AUT_Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[AUT_Usuario] varchar(50) NOT NULL,
	[AUT_Senha] varchar(MAX) NOT NULL,
	[AUT_Role] varchar(50) NOT NULL
)