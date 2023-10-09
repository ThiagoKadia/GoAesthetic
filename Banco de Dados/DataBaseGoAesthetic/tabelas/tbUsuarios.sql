CREATE TABLE [dbo].[tbUsuarios]
(
	[USR_Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [USR_Nome] VARCHAR (200) NULL,
    [USR_Email] VARCHAR(100) NULL, 
    [USR_Senha] VARCHAR(100) NULL, 
    [USR_Idade] INT NULL, 
    [USR_Sexo] INT NULL, 
    [USR_Altura] FLOAT NULL, 
    [USR_Peso] FLOAT NULL 
)
