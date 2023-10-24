CREATE TABLE [dbo].[tbRegistroRefeicoes]
(
	[RRF_Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [USR_Id] INT NOT NULL, 
    [RRF_Nome] VARCHAR(200) NULL, 
    [RRF_Data] DATETIME NULL,
    CONSTRAINT [FK_tbRegistroRefeicoes_tbUsuarios] FOREIGN KEY ([USR_Id]) REFERENCES [tbUsuarios]([USR_Id])
)
