CREATE PROCEDURE [dbo].[UpdatePessoa]
	@PessoaId int,
	@PessoaNome varchar(150),     
	@PessoaEmail varchar(300) ,
	@PessoaIdade tinyint,
	@PessoaProfissao  int,
	@PessoaStatus tinyint
AS
	Update Pessoas set  PessoaNome = @PessoaNome ,   PessoaEmail =  @PessoaEmail ,     PessoaIdade = @PessoaIdade ,     PessoaProfissao = @PessoaProfissao ,     PessoaStatus = @PessoaStatus
    WHERE  PessoaId =  @PessoaId

RETURN 0
