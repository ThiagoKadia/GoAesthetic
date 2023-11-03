CREATE TABLE [dbo].[tbMarcosEvolucao]
(
	[MEV_Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [USR_Id] INT NOT NULL, 
    [MEV_Altura] FLOAT NOT NULL, 
    [MEV_Peso] FLOAT NOT NULL, 
    [MEV_NomeArquivoFoto] VARCHAR(50) NULL, 
    [MEV_Data] DATETIME NOT NULL, 
    CONSTRAINT [FK_tbMarcosEvolucao_tbUsuarios] FOREIGN KEY ([USR_Id]) REFERENCES [tbUsuarios]([USR_Id])
)
