CREATE PROCEDURE [dbo].[sp_AddPessoa]
	@PessoaNome varchar(150),     
	@PessoaEmail varchar(300) ,
	@PessoaIdade tinyint,
	@PessoaProfissao  int,
	@PessoaStatus tinyint,
	@PessoaId int OUTPUT
AS
	Insert into Pessoas(     PessoaNome ,     PessoaEmail ,     PessoaIdade ,     PessoaProfissao ,     PessoaStatus)
                VALUES(     @PessoaNome ,     @PessoaEmail ,     @PessoaIdade ,     @PessoaProfissao ,     @PessoaStatus)	          

	Set @PessoaId = @@IDENTITY
	RETURN 0

