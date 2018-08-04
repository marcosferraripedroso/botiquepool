CREATE PROCEDURE [dbo].[sp_CountPessoa]
	
AS
	SELECT count(*) from Pessoas
RETURN 0
