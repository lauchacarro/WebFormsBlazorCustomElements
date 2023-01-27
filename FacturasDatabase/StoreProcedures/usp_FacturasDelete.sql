CREATE PROC [dbo].[usp_FacturasDelete] 
    @Id int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	DELETE
	FROM   [dbo].[Facturas]
	WHERE  [Id] = @Id

	COMMIT
GO