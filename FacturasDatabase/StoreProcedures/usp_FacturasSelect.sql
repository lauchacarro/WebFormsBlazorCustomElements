CREATE PROC [dbo].[usp_FacturasSelect] 
    @Id int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT [Id], [Codigo], [Descripcion], [Total], [Subtotal], [Vendedor], [MetodoPago], [Pagado] 
	FROM   [dbo].[Facturas] 
	WHERE  ([Id] = @Id OR @Id IS NULL) 

	COMMIT
GO