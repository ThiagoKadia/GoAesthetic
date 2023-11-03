CREATE TABLE [dbo].[tbDicionario]
(
	[DIC_Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[DIC_Chave] varchar(50) NOT NULL,
	[DIC_Valor] varchar(50) NOT NULL
)