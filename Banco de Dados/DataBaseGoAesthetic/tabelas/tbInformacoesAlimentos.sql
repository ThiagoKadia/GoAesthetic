CREATE TABLE [dbo].[tbInformacoesAlimentos]
(
	[IFA_Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [GAL_Id] INT NOT NULL,
	[IFA_Nome] [varchar](max) NULL,
	[IFA_Energia] FLOAT NULL,
	[IFA_Proteina] FLOAT NULL,
	[IFA_Lipideos] FLOAT NULL,
	[IFA_Colasterol] FLOAT NULL,
	[IFA_Carboidrato] FLOAT NULL,
	[IFA_FibraAlimentar] FLOAT NULL,
	[IFA_Ferro] FLOAT NULL,
	[IFA_Sodio] FLOAT NULL,
	[IFA_VitaminaC] FLOAT NULL,
	CONSTRAINT [FK_tbInformacoesAlimentos_tbGrupoAlimentos] FOREIGN KEY ([GAL_Id]) REFERENCES [tbGrupoAlimentos]([GAL_Id])
)
