CREATE PROCEDURE [dbo].[sp_GetPessoa]
	@PessoaId int = 0
AS
	SELECT PessoaId ,     PessoaNome ,     PessoaEmail ,     PessoaIdade ,     PessoaProfissao ,     PessoaStatus  
	FROM Pessoas
	WHERE PessoaId=@PessoaId
RETURN 0
