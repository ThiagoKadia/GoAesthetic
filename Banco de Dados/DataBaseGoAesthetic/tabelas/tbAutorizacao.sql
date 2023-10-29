CREATE TABLE [dbo].[tbAutorizacao]
(
	[AUT_Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[AUT_Usuario] varchar(50),
	[AUT_Senha] varchar(50),
	[AUT_Role] varchar(50)
)