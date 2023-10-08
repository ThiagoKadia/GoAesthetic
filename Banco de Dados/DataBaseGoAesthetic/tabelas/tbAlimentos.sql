CREATE TABLE [dbo].[tbAlimentos]
(
	[ALM_Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [IFA_Id] INT NOT NULL, 
    [ALM_Quantidade] DECIMAL(5, 2) NULL,
    CONSTRAINT [FK_tbAlimentos_tbInformacoesAlimentos] FOREIGN KEY ([IFA_Id]) REFERENCES [tbInformacoesAlimentos]([IFA_Id])
)
