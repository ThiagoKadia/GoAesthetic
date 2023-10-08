CREATE TABLE [dbo].[tbInformacoesAlimentos]
(
	[IFA_Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [GAL_Id] INT NOT NULL,
	[IFA_Nome] [varchar](max) NULL,
	[IFA_Energia] [decimal](18, 5) NULL,
	[IFA_Proteina] [decimal](18, 5) NULL,
	[IFA_Lipideos] [decimal](18, 5) NULL,
	[IFA_Colasterol] [decimal](18, 5) NULL,
	[IFA_Carboidrato] [decimal](18, 5) NULL,
	[IFA_FibraAlimentar] [decimal](18, 5) NULL,
	[IFA_Ferro] [decimal](18, 5) NULL,
	[IFA_Sodio] [decimal](18, 5) NULL,
	[IFA_VitaminaC] [decimal](18, 5) NULL,
	CONSTRAINT [FK_tbInformacoesAlimentos_tbGrupoAlimentos] FOREIGN KEY ([GAL_Id]) REFERENCES [tbGrupoAlimentos]([GAL_Id])
)
