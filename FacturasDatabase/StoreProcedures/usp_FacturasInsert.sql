CREATE PROC [dbo].[usp_FacturasInsert] 
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
	
	INSERT INTO [dbo].[Facturas] ([Codigo], [Descripcion], [Total], [Subtotal], [Vendedor], [MetodoPago], [Pagado])
	SELECT @Codigo, @Descripcion, @Total, @Subtotal, @Vendedor, @MetodoPago, @Pagado
	
	-- Begin Return Select <- do not remove
	SELECT [Id], [Codigo], [Descripcion], [Total], [Subtotal], [Vendedor], [MetodoPago], [Pagado]
	FROM   [dbo].[Facturas]
	WHERE  [Id] = SCOPE_IDENTITY()
	-- End Return Select <- do not remove
               
	COMMIT
GO