CREATE PROCEDURE [dbo].[sp_GetLista]
AS
	SELECT PessoaId ,     PessoaNome ,     PessoaEmail ,     PessoaIdade ,     PessoaProfissao ,     PessoaStatus  
	FROM Pessoas
RETURN 0
