CREATE PROC [dbo].[usp_FacturasUpdate] 
    @Id int,
    @Codigo varchar(MAX),
    @Descripcion varchar(MAX),
    @Total numeric(18, 2),
    @Subtotal numeric(18, 2),
    @Vendedor varchar(MAX),
    @MetodoPago varchar(MAX),
    @Pagado bit
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [dbo].[Facturas]
	SET    [Codigo] = @Codigo, [Descripcion] = @Descripcion, [Total] = @Total, [Subtotal] = @Subtotal, [Vendedor] = @Vendedor, [MetodoPago] = @MetodoPago, [Pagado] = @Pagado
	WHERE  [Id] = @Id
	
	-- Begin Return Select <- do not remove
	SELECT [Id], [Codigo], [Descripcion], [Total], [Subtotal], [Vendedor], [MetodoPago], [Pagado]
	FROM   [dbo].[Facturas]
	WHERE  [Id] = @Id	
	-- End Return Select <- do not remove

	COMMIT
GO