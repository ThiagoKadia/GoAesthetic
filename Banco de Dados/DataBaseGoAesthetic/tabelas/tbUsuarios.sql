CREATE TABLE [dbo].[tbUsuarios]
(
	[USR_Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [USR_Email] VARCHAR(100) NULL, 
    [USR_Senha] VARCHAR(100) NULL, 
    [USR_Idade] INT NULL, 
    [USR_Sexo] INT NULL, 
    [USR_Altura] DECIMAL(8, 3) NULL, 
    [USR_Peso] DECIMAL(8, 3) NULL 
)
