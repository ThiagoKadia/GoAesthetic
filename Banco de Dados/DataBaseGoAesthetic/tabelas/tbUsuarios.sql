CREATE TABLE [dbo].[tbUsuarios]
(
	[USR_Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [AUT_Id] INT NOT NULL,
    [USR_Nome] VARCHAR (200) NULL,
    [USR_Email] VARCHAR(100) NULL, 
    [USR_Senha] VARCHAR(MAX) NULL, 
    [USR_DataNascimento] DATETIME NULL, 
    [USR_Sexo] INT NULL 
)
