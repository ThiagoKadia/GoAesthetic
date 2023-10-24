CREATE TABLE [dbo].[tbMarcosEvolucao]
(
	[MEV_Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [USR_Id] INT NOT NULL, 
    [MEV_Altura] FLOAT NULL, 
    [MEV_Peso] FLOAT NULL, 
    [MEV_CaminhoFoto] VARCHAR(MAX) NULL, 
    [MEV_Data] DATETIME NULL, 
    CONSTRAINT [FK_tbMarcosEvolucao_tbUsuarios] FOREIGN KEY ([USR_Id]) REFERENCES [tbUsuarios]([USR_Id])
)
