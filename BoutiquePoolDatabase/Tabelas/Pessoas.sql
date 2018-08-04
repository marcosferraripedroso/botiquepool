CREATE TABLE [dbo].[Pessoas]
(
	[PessoaId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [PessoaNome] VARCHAR(150) NOT NULL, 
    [PessoaEmail] VARCHAR(300) NULL, 
    [PessoaIdade] TINYINT NULL, 
    [PessoaProfissao] INT NULL, 
    [PessoaStatus] TINYINT NOT NULL DEFAULT 1
)
