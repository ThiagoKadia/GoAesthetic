CREATE TABLE [dbo].[tbRegistroRefeicoes]
(
	[RRF_Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [USR_Id] INT NOT NULL, 
    [RRF_Nome] VARCHAR(200) NOT NULL, 
    [RRF_Data] DATETIME NOT NULL,
    CONSTRAINT [FK_tbRegistroRefeicoes_tbUsuarios] FOREIGN KEY ([USR_Id]) REFERENCES [tbUsuarios]([USR_Id])
)
